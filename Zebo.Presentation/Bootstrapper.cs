﻿using System;
using System.ComponentModel.Composition.Hosting;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Zebo.Infrastructure.Settings;
using Zebo.Localization.Engine;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Common.Services;
using Zebo.Presentation.Properties;
using Zebo.Presentation.Services;
using Zebo.Presentation.Services.Common;
using Zebo.Presentation.Services.Common.DataGeneration;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Presentation
{
    public class Bootstrapper : MefBootstrapper
    {
        static readonly Mutex Mutex = new Mutex(true, "{aa77c8c4-b8c1-4e61-908f-48c6fb65227d}");

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            var path = System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location);
            if (path != null)
            {
                AggregateCatalog.Catalogs.Add(new DirectoryCatalog(path, "Zebo.Persistance.dll"));
                AggregateCatalog.Catalogs.Add(new DirectoryCatalog(path, "Zebo.Modules*"));
                AggregateCatalog.Catalogs.Add(new DirectoryCatalog(path, "Zebo.Presentation*"));
                AggregateCatalog.Catalogs.Add(new DirectoryCatalog(path, "Zebo.Services*"));

            }
            LocalSettings.AppPath = path;
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            var moduleInitializationService = ServiceLocator.Current.GetInstance<IModuleInitializationService>();
            moduleInitializationService.Initialize();
        }

        protected override void InitializeShell()
        {
#if DEBUG
            // Bypass Singleton check
#else
            if (!Mutex.WaitOne(TimeSpan.Zero, true) && !LocalSettings.AllowMultipleClients)
            {
                NativeWin32.PostMessage((IntPtr)NativeWin32.HWND_BROADCAST, NativeWin32.WM_SHOWZEBOPOS, IntPtr.Zero, IntPtr.Zero);
                Environment.Exit(1);
            }
#endif
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            System.Net.ServicePointManager.Expect100Continue = false;

            LocalizeDictionary.ChangeLanguage(LocalSettings.CurrentLanguage);

            InteractionService.UserIntraction = ServiceLocator.Current.GetInstance<IUserInteraction>();
            InteractionService.UserIntraction.ToggleSplashScreen();

            ServiceLocator.Current.GetInstance<IApplicationState>().MainDispatcher = Application.Current.Dispatcher;
            var logger = ServiceLocator.Current.GetInstance<ILogService>();

            var messagingService = ServiceLocator.Current.GetInstance<IMessagingService>();
            messagingService.RegisterMessageListener(new MessageListener());

            if (LocalSettings.StartMessagingClient)
                messagingService.StartMessagingClient();

            PresentationServices.Initialize();

            base.InitializeShell();

            try
            {
                var creationService = new DataCreationService();
                creationService.CreateData();
            }
            catch (Exception e)
            {
                if (!string.IsNullOrEmpty(LocalSettings.ConnectionString))
                {
                    var connectionString =
                        InteractionService.UserIntraction.GetStringFromUser(
                        "Connection String",
                        string.Format(Resources.ConnectionStringError, e.Message),
                        LocalSettings.ConnectionString);

                    var cs = String.Join(" ", connectionString);

                    if (!string.IsNullOrEmpty(cs))
                        LocalSettings.ConnectionString = cs.Trim();

                    logger.LogError(e, Resources.RestartAppError);
                }
                else
                {
                    logger.LogError(e);
                    LocalSettings.ConnectionString = "";
                }
                LocalSettings.SaveSettings();
                Environment.Exit(1);
            }

            var rm = Container.GetExportedValue<IRegionManager>();
            rm.RegisterViewWithRegion("MessageRegion", typeof(WorkPeriodStatusView));
            rm.RegisterViewWithRegion("MessageRegion", typeof(MessageClientStatusView));

            Application.Current.MainWindow = (Shell)Shell;

            if (LocalizeDictionary.Instance.Culture.TextInfo.IsRightToLeft)
            {
                Application.Current.MainWindow.FlowDirection = FlowDirection.RightToLeft;
            }

            ServiceLocator.Current.GetInstance<ITriggerService>().UpdateCronObjects();

            InteractionService.UserIntraction.ToggleSplashScreen();
            EntityCollectionSortManager.Load(LocalSettings.DocumentPath + "\\CollectionSort.txt");
            
            if (!string.IsNullOrEmpty(LocalSettings.CallerIdDeviceName))
            {
                ServiceLocator.Current.GetInstance<IDeviceService>().InitializeDevice(LocalSettings.CallerIdDeviceName);                
            }

            Application.Current.MainWindow.Show();
            EventServiceFactory.EventService.PublishEvent(EventTopicNames.ShellInitialized);
            Mouse.UpdateCursor();
        }
    }
}
