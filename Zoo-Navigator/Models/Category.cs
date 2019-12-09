using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum = Zoo_Navigator.Common.Enum;

namespace Zoo_Navigator.Models
{
    public class Category
    {
        private Common.Enum.AreaCategory _areaCategory;
        private string _areaCategoryString;

        public Category(Enum.AreaCategory areaCategory, string areaCategoryString)
        {
            _areaCategory = areaCategory;
            _areaCategoryString = areaCategoryString;
        }

        public string AreaCategoryString => _areaCategoryString;
    }
}