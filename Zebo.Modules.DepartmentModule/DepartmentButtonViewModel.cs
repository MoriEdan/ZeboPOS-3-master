﻿using Zebo.Presentation.Common;
using Zebo.Presentation.Common.Commands;
using Zebo.Presentation.Services;

namespace Zebo.Modules.DepartmentModule
{
    public class DepartmentButtonViewModel : ObservableObject
    {
        private readonly IApplicationState _applicationState;
        private readonly DepartmentSelectorViewModel _parentViewModel;

        public DepartmentButtonViewModel(DepartmentSelectorViewModel parentViewModel,
            IApplicationState applicationState)
        {
            _parentViewModel = parentViewModel;
            _applicationState = applicationState;
            DepartmentSelectionCommand = new CaptionCommand<string>("Select", OnSelectDepartment);
        }

        private void OnSelectDepartment(string obj)
        {
            _parentViewModel.UpdateSelectedDepartment(DepartmentId);
        }

        public ICaptionCommand DepartmentSelectionCommand { get; set; }

        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string ButtonColor { get { return _applicationState.CurrentDepartment != null && _applicationState.CurrentDepartment.Id == DepartmentId ? "Gray" : "Gainsboro"; } }

        public void Refresh()
        {
            RaisePropertyChanged(() => ButtonColor);
        }
    }
}
