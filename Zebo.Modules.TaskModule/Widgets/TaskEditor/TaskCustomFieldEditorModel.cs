using Zebo.Domain.Models.Tasks;
using Zebo.Presentation.Common;

namespace Zebo.Modules.TaskModule.Widgets.TaskEditor
{
    public class TaskCustomFieldEditorModel : ObservableObject
    {
        private string _value;

        public TaskCustomFieldEditorModel(TaskCustomField taskCustomField)
        {
            Model = taskCustomField;
        }

        protected TaskCustomField Model { get; set; }
        public string Name { get { return Model.Name; } }
        public string Value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChanged(() => Value); }
        }
    }
}