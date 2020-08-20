using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBConsoleApp.Domain
{
    public class Movie
    {
        public string Name { get; set; }
        public DateTime YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<Person> Actor { get; set; }
        public List<Person> Producer { get; set; }

    }
}
