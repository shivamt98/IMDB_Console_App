using IMDBConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBConsoleApp.Repository
{
    public class ProducerRepository
    {
        private IList<Person> _producers;
        public ProducerRepository()
        {
            _producers = new List<Person>();
        }

        public void AddProducer(Person producer)
        {
            _producers.Add(producer);
        }

        public Person GetProducer(string name)
        {
            var producer = _producers.FirstOrDefault(p => p.Name == name);
            return producer;
        }
        
        public IList<Person> GetAllProducers()
        {
            return _producers.ToList();
        }
    }
}
