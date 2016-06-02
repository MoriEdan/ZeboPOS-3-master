using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using Zebo.Presentation.Common;

namespace Zebo.Modules.EntityModule
{
    /// <summary>
    /// Interaction logic for AccountEditorView.xaml
    /// </summary>
    
    [Export]
    public partial class EntityEditorView : UserControl
    {
        [ImportingConstructor]
        public EntityEditorView(EntityEditorViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
