using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.Commands;
using Zebo.Presentation.Common.Services;

namespace Zebo.Modules.NavigationModule
{
    [Export]
    public class NavigationViewModel : ObservableObject
    {
        public ObservableCollection<ICategoryCommand> CategoryView
        {
            get
            {
                return new ObservableCollection<ICategoryCommand>(
                    PresentationServices.NavigationCommandCategories.OrderBy(x => x.Order));
            }
        }

        public void Refresh()
        {
            RaisePropertyChanged(() => CategoryView);
        }
    }
}
