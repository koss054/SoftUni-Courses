using System;
using System.Collections.Generic;
using System.Linq;

namespace Kubernetes
{
    public class Controller : IController
    {
        private Dictionary<string, Pod> _pods = new Dictionary<string, Pod>();

        public bool Contains(string podId)
        {
            return _pods.Values.Any(x => x.Id == podId);
        }

        public void Deploy(Pod pod)
        {
            _pods.Add(pod.Id, pod);
        }

        public Pod GetPod(string podId)
        {
            if (!_pods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            return _pods[podId];
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            return _pods.Values
                .Where(x => x.Port >= lowerBound
                         && x.Port <= upperBound);
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
            return _pods.Values
                .Where(x => x.Namespace == @namespace);
        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            return _pods.Values
                .OrderByDescending(x => x.Port)
                .ThenBy(x => x.ServiceName);
        }

        public int Size()
        {
            return _pods.Count;
        }

        public void Uninstall(string podId)
        {
            if (!_pods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            _pods.Remove(podId);
        }

        public void Upgrade(Pod pod)
        {
            if (!_pods.ContainsKey(pod.Id))
            {
                _pods.Add(pod.Id, pod);
            }
            else
            {
                _pods[pod.Id] = pod;
            }
        }
    }
}