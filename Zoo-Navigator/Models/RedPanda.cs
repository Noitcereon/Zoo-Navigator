using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum = Zoo_Navigator.Common.Enum;

namespace Zoo_Navigator.Models
{
    public class RedPanda : Animal
    {
        public RedPanda(int animalId, string imagePath)
            : base(animalId, species: "Red Panda", imagePath, Enum.AreaCategory.Asien)
        {

        }
    }
}
