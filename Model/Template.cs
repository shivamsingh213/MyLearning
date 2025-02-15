using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDocument.Model
{
    public class Template
    {
        public List<Configuration> Configurations { get; set; }

    }
    public class Configuration
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}";
        }

    }
}



