using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_Navigator.Common;

namespace Zoo_Navigator.Models
{
    public class Animal
    {

        private readonly int _animalId;
        private string _species;
        private List<string> _animalFacts;
        private string _imagePath;
        private Common.Enum.AreaCategory _category;

        public Animal(int animalId, string species, string imagePath, Common.Enum.AreaCategory category)
        {
            _animalId = animalId;
            _species = species;
            _imagePath = imagePath;
            _category = category;
            _animalFacts = new List<string>();
        }

        public List<string> AnimalFacts
        {
            get { return _animalFacts; }
        }

        public int AnimalId
        {
            get => _animalId;
        }

        public string Species
        {
            get => _species;
            set => _species = value;
        }

        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }

        public Common.Enum.AreaCategory Category
        {
            get => _category;
            set => _category = value;
        }

        public void AddAnimalFact(string animalFact)
        {
            AnimalFacts.Add(animalFact);
        }
    }
}
