using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        void AddProducer(Producer producer);
        void RemoveProducer(Producer producer);
        void UpdateProducer(Producer producer);
        Producer GetProducer(int id);
        ICollection<Producer> GetAllProducers();
        ICollection<ProducerDetail> GetDetailsForProducer(int id);
    }
}