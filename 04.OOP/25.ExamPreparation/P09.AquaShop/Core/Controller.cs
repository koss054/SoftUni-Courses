using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return String.Format(
                OutputMessages.SuccessfullyAdded,
                aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return String.Format(
                OutputMessages.SuccessfullyAdded,
                decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fishToAdd;
            IAquarium aquariumToAddTo = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                fishToAdd = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fishToAdd = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidFishType);
            }

            if (fishType == "FreshwaterFish" && aquariumToAddTo.GetType().Name == "FreshwaterAquarium" ||
                fishType == "SaltwaterFish" && aquariumToAddTo.GetType().Name == "SaltwaterAquarium")
            {
                aquariumToAddTo.AddFish(fishToAdd);

                return String.Format(
                    OutputMessages.EntityAddedToAquarium,
                    fishType, aquariumName);
            }
            else
            {
                return String.Format(
                    OutputMessages.UnsuitableWater);
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquariumToCalculatePrice = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal totalPrice = aquariumToCalculatePrice.Fish.Sum(x => x.Price) +
                aquariumToCalculatePrice.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {totalPrice:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquariumToFeed = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquariumToFeed.Feed();

            return String.Format(
                OutputMessages.FishFed,
                aquariumToFeed.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decorationToInsert = this.decorations.FindByType(decorationType);
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (decorationToInsert == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentDecoration,
                    decorationType));
            }

            aquarium.AddDecoration(decorationToInsert);
            this.decorations.Remove(decorationToInsert);

            return String.Format(
                OutputMessages.EntityAddedToAquarium,
                decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
