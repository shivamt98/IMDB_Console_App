using IMDBConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBConsoleApp.Repository
{
    public class ActorRepository
    {
        private IList<Person> _actor;

        public ActorRepository()
        {
            _actor = new List<Person>();
        }

        public void AddActor(Person actor)
        {
            _actor.Add(actor);
        }

        public Person GetActor()
        {
            var actors = _actor;
            return (Person)actors;            
        }

        public IList<Person> GetAllActors()
        {
            return _actor.ToList();
        }
    }
}
