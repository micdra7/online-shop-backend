using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFProducerRepository : IProducerRepository
    {
        private ApplicationDbContext context;

        public EFProducerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddProducer(Producer producer)
        {
            context.Producers.Add(producer);
            context.SaveChanges();
        }

        public void RemoveProducer(Producer producer)
        {
            context.Producers.Remove(producer);
            context.SaveChanges();
        }

        public void UpdateProducer(Producer producer)
        {
            context.Producers.Update(producer);
            context.SaveChanges();
        }

        public Producer GetProducer(int id)
        {
            return context.Producers.Find(id);
        }

        public ICollection<Producer> GetAllProducers()
        {
            return context.Producers.ToList();
        }

        public ICollection<ProducerDetail> GetDetailsForProducer(int id)
        {
            return context.Producers.Find(id)?.Details;
        }
    }
}