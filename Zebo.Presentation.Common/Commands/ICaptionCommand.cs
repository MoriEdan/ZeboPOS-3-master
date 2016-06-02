using System.Windows.Input;

namespace Zebo.Presentation.Common.Commands
{
    public interface ICaptionCommand : ICommand
    {
        string Caption { get; set; }
    }
}
