using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomagochi.DAL.Entities
{
    public class Pet
    {
        public int Id { get; set; }        
        
        public string Name { get; set; }

        public string BodyPath { get; set; }

        public string EyesPath { get; set; }

        public string MouthPath { get; set; }

        public string NosePath { get; set; }
    }
}
