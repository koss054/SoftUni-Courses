using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class Manager : IManager
    {
        private Dictionary<string, Task> _tasks = new Dictionary<string, Task>();

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!_tasks.ContainsKey(taskId) || !_tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            var task = _tasks[taskId];
            IndirectDependency(taskId, dependentTaskId);
            task.DependentTasks.Add(dependentTaskId, "");
        }

        private void IndirectDependency(string taskId, string dependentTaskId)
        {
            var relatedTasks = _tasks.Values
                .Where(x => x.DependentTasks.ContainsKey(taskId));

            foreach (var relatedTask in relatedTasks)
            {
                relatedTask.DependentTasks.Add(dependentTaskId, taskId);
            }
        }

        public void AddTask(Task task)
        {
            if (_tasks.ContainsKey(task.Id))
            {
                throw new ArgumentException();
            }

            _tasks.Add(task.Id, task);
        }

        public bool Contains(string taskId)
        {
            return _tasks.ContainsKey(taskId);
        }

        public Task Get(string taskId)
        {
            if (!_tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return _tasks[taskId];
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            if (!_tasks.ContainsKey(taskId))
            {
                return Enumerable.Empty<Task>();
            }

            var keys = _tasks.Values
                .FirstOrDefault(x => x.Id == taskId)
                .DependentTasks
                .Keys;

            var dependenciesToReturn = new HashSet<Task>();
            foreach (var key in keys)
            {
                dependenciesToReturn.Add(_tasks[key]);
            }

            return dependenciesToReturn;
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            if (!_tasks.ContainsKey(taskId))
            {
                return Enumerable.Empty<Task>();
            }

            return _tasks.Values
                .Where(x => x.DependentTasks.ContainsKey(taskId));
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!_tasks.ContainsKey(taskId) || !_tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            var task = _tasks[taskId];
            if (!task.DependentTasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            task.DependentTasks.Remove(dependentTaskId);
        }

        public void RemoveTask(string taskId)
        {
            if (!_tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var relatedTasks = _tasks.Values
                .Where(x => x.DependentTasks.ContainsKey(taskId));

            foreach(var relatedTask in relatedTasks)
            {
                relatedTask.DependentTasks.Remove(taskId);
            }

            _tasks.Remove(taskId);
        }

        public int Size()
        {
            return _tasks.Count;
        }
    }
}