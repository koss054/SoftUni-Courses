using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
            => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations
            => this.decorations;

        public ICollection<IFish> Fish
            => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.Append("Fish: ");

            if (this.fish.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                sb.AppendLine(string.Join(", ", this.fish.Select(x => x.Name).ToArray()));
            }

            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
            => this.fish.Remove(fish);
    }
}
