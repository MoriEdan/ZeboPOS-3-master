using System.ComponentModel.Composition;
using System.Windows.Controls;
using Zebo.Presentation.Common;

namespace Zebo.Modules.ModifierModule
{
    /// <summary>
    /// Interaction logic for SelectedOrdersView.xaml
    /// </summary>
    /// 
    [Export]
    public partial class AutomationCommandValueSelectorView : UserControl
    {
        [ImportingConstructor]
        public AutomationCommandValueSelectorView(AutomationCommandValueSelectorViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
