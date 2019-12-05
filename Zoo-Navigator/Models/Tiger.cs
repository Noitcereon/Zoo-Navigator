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
        private string _imagePath;

        public Tiger(string imagePath)
        :base(species:"Tiger", imagePath, Enum.AreaCategory.Asien)
        {
            _imagePath = imagePath;
        }
    }
}
