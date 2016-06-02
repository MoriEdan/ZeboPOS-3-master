using System.Windows.Input;

namespace Zebo.Presentation.Common
{
    public interface ICaptionCommand : ICommand
    {
        string Caption { get; set; }
    }
}
