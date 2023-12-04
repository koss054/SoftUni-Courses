using System;
using System.Collections.Generic;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        public void AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Task task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteTask()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            throw new NotImplementedException();
        }

        public Task GetTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            throw new NotImplementedException();
        }

        public void RescheduleTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
