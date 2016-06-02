using System.Collections.Generic;
using Zebo.Domain.Models.Tasks;

namespace Zebo.Presentation.Services.Implementations.TaskModule
{
    class TaskCache
    {
        public IEnumerable<Task> Tasks { get; set; }
        public TaskCache()
        {
            Tasks = new List<Task>();
        }
    }
}