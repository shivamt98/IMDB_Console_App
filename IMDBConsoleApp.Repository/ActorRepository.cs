using IMDBConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBConsoleApp.Repository
{
    public class ActorRepository
    {
        private IList<Person> _actors;

        public ActorRepository()
        {
            _actors = new List<Person>();
        }

        public void AddActor(Person actor)
        {
            _actors.Add(actor);
        }

        public List<Person> GetActor(List<string> name)
        {
            List<Person> _actorList = new List<Person>();
            foreach(var actorName in name)
            {
                var actor = _actors.FirstOrDefault(a => a.Name == actorName);                
                _actorList.Add(actor);
            }           
            return _actorList;                      
        }

        public IList<Person> GetAllActors()
        {
            return _actors.ToList();
        }
    }
}