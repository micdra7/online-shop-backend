using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFProducerDetailRepository : IProducerDetailRepository
    {
        private ApplicationDbContext context;

        public EFProducerDetailRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddProducerDetail(ProducerDetail producerDetail)
        {
            context.ProducerDetails.Add(producerDetail);
            context.SaveChanges();
        }

        public void RemoveProducerDetail(ProducerDetail producerDetail)
        {
            context.ProducerDetails.Remove(producerDetail);
            context.SaveChanges();
        }

        public void UpdateProducerDetail(ProducerDetail producerDetail)
        {
            context.ProducerDetails.Update(producerDetail);
            context.SaveChanges();
        }

        public ProducerDetail GetProducerDetail(long id)
        {
            return context.ProducerDetails.Find(id);
        }

        public ICollection<ProducerDetail> GetAllProducerDetails()
        {
            return context.ProducerDetails.ToList();
        }

        public Producer GetProducerForProducerDetail(long id)
        {
            return context.ProducerDetails.Find(id)?.Producer;
        }
    }
}