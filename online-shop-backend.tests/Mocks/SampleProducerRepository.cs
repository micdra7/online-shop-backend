using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleProducerRepository : IProducerRepository
    {
        private ICollection<Producer> Producers { get; set; }

        public SampleProducerRepository()
        {
            this.Producers = new List<Producer>
            {
                new Producer
                {
                    ID = 1,
                    Name = "Producer1",
                    Details = new List<ProducerDetail>
                    {
                        new ProducerDetail
                        {
                            ID = 1,
                            ProducerID = 1,
                            Address1 = "QWERTY",
                            Address2 = "ASDF",
                            City = "ZXCV",
                            Country = "JKL",
                            Email = "QWERTY@email.com",
                            PhoneNumber = "1234567890"
                        }
                    }
                },
                new Producer
                {
                    ID = 2,
                    Name = "Producer2",
                    Details = new List<ProducerDetail>
                    {
                        new ProducerDetail
                        {
                            ID = 2,
                            ProducerID = 2,
                            Address1 = "UIOP",
                            Address2 = "BNM",
                            City = "TYU",
                            Country = "ZXCBNM",
                            Email = "ASDFG@email.com",
                            PhoneNumber = "0987654321"
                        }
                    }
                }
            };
        }
        
        public void AddProducer(Producer producer)
        {
            Producers.Add(producer);
        }

        public void RemoveProducer(Producer producer)
        {
            Producers.Remove(producer);
        }

        public void UpdateProducer(Producer producer)
        {
            Producers.Remove(Producers.First(p => p.ID == producer.ID));
            Producers.Add(producer);
        }

        public Producer GetProducer(int id)
        {
            return Producers.First(p => p.ID == id);
        }

        public ICollection<Producer> GetAllProducers()
        {
            return Producers;
        }

        public ICollection<ProducerDetail> GetDetailsForProducer(int id)
        {
            return Producers.First(p => p.ID == id)?.Details;
        }
    }
}