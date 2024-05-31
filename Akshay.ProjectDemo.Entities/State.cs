using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshay.ProjectDemo.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default State";

        public int CountryId { get; set; } //Foreignkey
        
        // Reference or navigation property
        public Country country { get; set; }

        public ICollection<City> cities { get; set; } = new HashSet<City>();
    }
}
