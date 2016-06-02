using System;
using System.Collections.Generic;
using Zebo.Domain.Models.Tasks;

namespace Zebo.Persistance
{
    public interface ITaskDao
    {
        void SaveTask(Task task);
        IEnumerable<Task> GetTasks(int taskTypeId, DateTime endDate);
    }
}
