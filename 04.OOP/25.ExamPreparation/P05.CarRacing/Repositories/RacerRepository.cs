using System;

using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System.Collections.Generic;
using CarRacing.Utilities.Messages;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(
                    ExceptionMessages.InvalidAddRacerRepository);
            }

            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer searchedRacer = this.models
                .FirstOrDefault(x => x.Username == property);

            return searchedRacer;
        }

        public bool Remove(IRacer model)
            => this.models.Remove(model);
    }
}
