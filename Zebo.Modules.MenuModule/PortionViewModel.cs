using Zebo.Domain.Models.Menus;
using Zebo.Presentation.Common;

namespace Zebo.Modules.MenuModule
{
    public class PortionViewModel : ObservableObject
    {
        public PortionViewModel(MenuItemPortion model)
        {
            Model = model;
        }

        public string Name { get { return Model.Name; } set { Model.Name = value; } }
        public decimal Price { get { return Model.Price; } set { Model.Price= value; } }
        public int Multiplier { get { return Model.Multiplier; } set { Model.Multiplier = value; } }
        public MenuItemPortion Model { get; private set; }
    }
}
