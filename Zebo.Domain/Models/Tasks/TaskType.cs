using System.Collections.Generic;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Tasks
{
    public class TaskType : EntityClass
    {
        public TaskType()
        {
            _taskCustomFields = new List<TaskCustomField>();
        }

        private IList<TaskCustomField> _taskCustomFields;
        public virtual IList<TaskCustomField> TaskCustomFields
        {
            get { return _taskCustomFields; }
            set { _taskCustomFields = value; }
        }
    }
}