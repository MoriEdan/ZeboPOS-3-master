using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Zebo.Domain.Models.Users;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.ModelBase;

namespace Zebo.Modules.UserModule
{
    [ModuleExport(typeof(UserModule))]
    public class UserModule : ModuleBase
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public UserModule(IRegionManager regionManager)
        {
            AddDashboardCommand<EntityCollectionViewModelBase<UserRoleViewModel, UserRole>>(Resources.UserRoleList, Resources.Users, 50);
            AddDashboardCommand<EntityCollectionViewModelBase<UserViewModel, User>>(Resources.UserList, Resources.Users);
            _regionManager = regionManager;
        }

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.RightUserRegion, typeof(LoggedInUserView));
        }
    }
}
