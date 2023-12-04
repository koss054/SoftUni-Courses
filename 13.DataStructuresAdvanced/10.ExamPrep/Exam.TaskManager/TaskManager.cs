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

            var task = _allTasks[taskId];
            _allTasks.Remove(taskId);

            if (_executedTasks.Contains(task))
            {
                _executedTasks.Remove(task);
            }
            else
            {
                _taskQueue.Remove(task);
            }
        }

        public Task ExecuteTask()
        {
            if (_taskQueue.Count == 0)
            {
                throw new ArgumentException();
            }

            var task = _taskQueue.First.Value;
            _taskQueue.RemoveFirst();

            _executedTasks.Add(task);

            return task;
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            return _allTasks
                .Values
                .OrderByDescending(x => x.EstimatedExecutionTime)
                .ThenBy(x => x.Name);

        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var tasks = _taskQueue.Where(x => x.Domain == domain).ToList();

            if (tasks.Count == 0)
            {
                throw new ArgumentException();
            }

            return tasks;
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
            return _taskQueue
                .Where(x => x.EstimatedExecutionTime >= lowerBound
                         && x.EstimatedExecutionTime <= upperBound);
        }

        public void RescheduleTask(string taskId)
        {
            if (!_allTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var task = _allTasks[taskId];
            _executedTasks.Remove(task);
            _taskQueue.AddLast(task);
        }

        public int Size()
        {
            return _allTasks.Count;
        }
    }
}
