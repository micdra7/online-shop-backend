using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IProducerDetailRepository
    {
        void AddProducerDetail(ProducerDetail producerDetail);
        void RemoveProducerDetail(ProducerDetail producerDetail);
        void UpdateProducerDetail(ProducerDetail producerDetail);
        ProducerDetail GetProducerDetail(long id);
        ICollection<ProducerDetail> GetAllProducerDetails();
        Producer GetProducerForProducerDetail(long id);
    }
}