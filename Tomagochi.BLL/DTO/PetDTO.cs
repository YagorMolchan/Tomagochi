using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tomagochi.BLL.DTO
{
    public class PetDTO
    {
        [Display(Name="Name")]
        [Required(ErrorMessage = "The name of the pet must be inputted!")]
        public string Name { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }

        [Display(Name = "Eyes")]
        public string Eye { get; set; }

        [Display(Name = "Mouth")]
        public string Mouth { get; set; }

        [Display(Name = "Nose")]
        public string Nose { get; set; }

        public List<string> Bodies { get; set; }

        public List<string> Eyes { get; set; }

        public List<string> Mouths { get; set; }
            
        public List<string> Noses { get; set; }

        public PetDTO()
        {
            Bodies = new List<string>
            {
                "/img/bodies/body11.png",
                "/img/bodies/body2.png",
                "/img/bodies/body3.png",
                "/img/bodies/body4.png",
                "/img/bodies/body5.png"
            };

            Eyes = new List<string>
            {
                "/img/eyes/eyes1.png",
                "/img/eyes/eyes2.png",
                "/img/eyes/eyes3.png",
                "/img/eyes/eyes4.png",
                "/img/eyes/eyes5.png",
                "/img/eyes/eyes6.png"
            };

            Mouths = new List<string>
            {
                "/img/mouths/mouth1.png",
                "/img/mouths/mouth2.png",
                "/img/mouths/mouth3.png",
                "/img/mouths/mouth4.png",
                "/img/mouths/mouth5.png"
            };

            Noses = new List<string>
            {
                "/img/noses/nose1.png",
                "/img/noses/nose2.png",
                "/img/noses/nose3.png",
                "/img/noses/nose4.png",
                "/img/noses/nose5.png",
                "/img/noses/nose6.png"
            };

        }
    }
}
