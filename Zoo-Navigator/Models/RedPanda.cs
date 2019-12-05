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
        private string _imagePath;

        public RedPanda(string imagePath)
            : base("Red Panda", imagePath, Enum.AreaCategory.Asien)
        {
            _imagePath = imagePath;
        }
    }
}
