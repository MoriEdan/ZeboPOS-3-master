using System.Windows;
using System.Windows.Controls;
using Zebo.Domain.Models.Entities;
using Zebo.Presentation.Services;

namespace Zebo.Presentation.Common.Widgets
{
    public interface IWidgetCreator
    {
        string GetCreatorName();
        string GetCreatorDescription();
        FrameworkElement CreateWidgetControl(IDiagram widget, ContextMenu contextMenu);
        Widget CreateNewWidget();
        IDiagram CreateWidgetViewModel(Widget widget, IApplicationState applicationState);
    }
}