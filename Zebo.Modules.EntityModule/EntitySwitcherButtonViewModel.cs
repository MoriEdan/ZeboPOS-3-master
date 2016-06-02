﻿using Zebo.Domain.Models.Entities;
using Zebo.Presentation.Common;
using Zebo.Presentation.Services;

namespace Zebo.Modules.EntityModule
{
    public class EntitySwitcherButtonViewModel : ObservableObject
    {
        public EntityScreen Model { get; set; }
        private readonly IApplicationState _applicationState;
        private readonly bool _displayActiveScreen;

        public EntitySwitcherButtonViewModel(EntityScreen model, IApplicationState applicationState, bool displayActiveScreen)
        {
            Model = model;
            _applicationState = applicationState;
            _displayActiveScreen = displayActiveScreen;
        }

        public string Caption { get { return _applicationState.IsLandscape ? Model.Name : Model.Name.Replace(" ", "\r"); } }
        public string ButtonColor { get { return Model != _applicationState.SelectedEntityScreen || !_displayActiveScreen ? "Gainsboro" : "Gray"; } }
        public void Refresh() { RaisePropertyChanged(() => ButtonColor); }
    }
}
