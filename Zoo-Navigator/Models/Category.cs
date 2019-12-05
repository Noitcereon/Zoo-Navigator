using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Navigator.Models
{
    public class Category
    {
        private Common.Enum _areaCategory;

        public Category(Common.Enum areaCategory)
        {
            _areaCategory = areaCategory;
        }
    }
}
