using System.ComponentModel.Composition;
using Zebo.Domain.Models.Tickets;
using Zebo.Presentation.Common.ModelBase;

namespace Zebo.Modules.DepartmentModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class DepartmentListViewModel : EntityCollectionViewModelBase<DepartmentViewModel, Department>
    {

    }
}
