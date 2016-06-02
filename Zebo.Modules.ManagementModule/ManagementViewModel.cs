using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Zebo.Presentation.Common.Commands;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Common.Services;

namespace Zebo.Modules.ManagementModule
{
    [Export]
    public class ManagementViewModel : ModelListViewModelBase
    {
        public ObservableCollection<DashboardCommandCategory> CategoryView
        {
            get
            {
                var result = new ObservableCollection<DashboardCommandCategory>(
                     PresentationServices.DashboardCommandCategories.OrderBy(x => x.Order));
                return result;
            }
        }

        protected override string GetHeaderInfo()
        {
            return "Dashboard";
        }

        public void Refresh()
        {
            RaisePropertyChanged(() => CategoryView);
        }
    }
}
