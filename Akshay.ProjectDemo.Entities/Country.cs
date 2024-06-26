﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshay.ProjectDemo.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default Country";

        //Country have multipe states
        public ICollection<State> states { get; set; } = new HashSet<State>();
    }
}
