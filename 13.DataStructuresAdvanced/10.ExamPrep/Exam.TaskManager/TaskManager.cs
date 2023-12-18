using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        private LinkedList<Task> _taskQueue = new LinkedList<Task>();
        private HashSet<Task> _executedTasks = new HashSet<Task>();
        private Dictionary<string, Task> _allTasks = new Dictionary<string, Task>();

        public void AddTask(Task task)
        {
            _taskQueue.AddLast(task);
            _allTasks.Add(task.Id, task);
        }

        public bool Contains(Task task)
        {
            return _allTasks.ContainsKey(task.Id);
        }

        public void DeleteTask(string taskId)
        {
            if (!_allTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var taskToRemove = _allTasks[taskId];
            if (_executedTasks.Contains(taskToRemove))
            {
                _executedTasks.Remove(taskToRemove);
            }
            else
            {
                _taskQueue.Remove(taskToRemove);
            }
            _allTasks.Remove(taskId);
        }

        public Task ExecuteTask()
        {
            if (_taskQueue.Count == 0)
            {
                throw new ArgumentException();
            }

            var taskToExecute = _taskQueue.First();
            _taskQueue.RemoveFirst();
            _executedTasks.Add(taskToExecute);

            return taskToExecute;
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            var tasksToReturn = _allTasks.Values
                .OrderByDescending(x => x.EstimatedExecutionTime)
                .ThenBy(x => x.Name.Length)
                .ToList();

            return tasksToReturn;
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var tasksToReturn = _taskQueue.Where(x => x.Domain == domain).ToList();
            return tasksToReturn.Count > 0 ? tasksToReturn : throw new ArgumentException();
        }

        public Task GetTask(string taskId)
        {
            if (!_allTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return _allTasks[taskId];
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            var tasksToReturn = _taskQueue
                .Where(x => x.EstimatedExecutionTime >= lowerBound
                         && x.EstimatedExecutionTime <= upperBound)
                .ToList();

            return tasksToReturn;
        }

        public void RescheduleTask(string taskId)
        {
            if (!_allTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var taskToReschedule = _executedTasks.First(x => x.Id == taskId);
            _taskQueue.AddLast(taskToReschedule);
            _executedTasks.Remove(taskToReschedule);
        }

        public int Size()
        {
            return _taskQueue.Count;
        }
    }
}
