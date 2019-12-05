using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum = Zoo_Navigator.Common.Enum;

namespace Zoo_Navigator.Models
{
    public class Tiger : Animal
    {

        public Tiger(int animalId, string imagePath)
        :base(animalId ,species:"Tiger", imagePath, Enum.AreaCategory.Asien)
        {
        }
    }
}
