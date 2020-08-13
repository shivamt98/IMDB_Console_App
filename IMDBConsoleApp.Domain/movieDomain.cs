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
    }
    public class Actors
    {
        public List<string> Name { get; set; }
        public DateTime DOB { get; set; }
    }
    public class Producer
    {
        public string producer { get; set; }
        public DateTime DOB { get; set; }
    }
}
