using IMDBConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBConsoleApp.Repository
{
    public class ProducerRepository
    {
        private IList<Person> _producer;
        public ProducerRepository()
        {
            _producer = new List<Person>();
        }

        public void AddProducer(Person producer)
        {
            _producer.Add(producer);
        }

        public Person GetProducer()
        {
            var producers = _producer;
            return (Person)producers;
        }
        
        public IList<Person> GetAllProducers()
        {
            return _producer.ToList();
        }
    }
}
