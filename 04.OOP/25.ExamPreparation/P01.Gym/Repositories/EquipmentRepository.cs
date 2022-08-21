using System.Linq;
using System.Collections.Generic;
using Gym.Models.Equipment;
using Gym.Repositories.Contracts;
using Gym.Models.Equipment.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models
        { get { return this.models.AsReadOnly(); } }

        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public IEquipment FindByType(string type)
            => this.models.FirstOrDefault(e => e.GetType().Name == type);

        public bool Remove(IEquipment model)
            => this.models.Remove(model);
    }
}
