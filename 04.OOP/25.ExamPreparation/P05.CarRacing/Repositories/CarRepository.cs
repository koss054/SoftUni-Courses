using System;
using System.Linq;

using System.Collections.Generic;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(
                    ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            ICar searchedCar = this.models
                .FirstOrDefault(x => x.VIN == property);

            return searchedCar;
        }

        public bool Remove(ICar model)
            => this.models.Remove(model);

    }
}
