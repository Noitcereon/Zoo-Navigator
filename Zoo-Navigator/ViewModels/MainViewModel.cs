using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zoo_Navigator.Annotations;
using Zoo_Navigator.Models;
using Enum = Zoo_Navigator.Common.Enum;

namespace Zoo_Navigator.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private bool _isMenuOpen = true;
        private Dictionary<int, Animal> _animals;

        public MainViewModel()
        {
            Animal tiger = new Tiger("undefined");
            tiger.AddAnimalFact("fact 1");
            tiger.AddAnimalFact("fact 2");
            tiger.AddAnimalFact("fact 3");
            tiger.AddAnimalFact("fact 4");
            tiger.AddAnimalFact("fact 5");
            tiger.AddAnimalFact("fact 6");
            tiger.AddAnimalFact("fact 7");
            tiger.AddAnimalFact("fact 8");
            tiger.AddAnimalFact("fact 9");
            tiger.AddAnimalFact("fact 10");

            Animal redPanda = new RedPanda("undefined");
            redPanda.AddAnimalFact("red panda fact 1");
            redPanda.AddAnimalFact("red panda fact 2");
            redPanda.AddAnimalFact("red panda fact 3");
            redPanda.AddAnimalFact("red panda fact 4");
            redPanda.AddAnimalFact("red panda fact 5");
            redPanda.AddAnimalFact("red panda fact 6");

            _animals = new Dictionary<int, Animal>();

            _animals.Add(redPanda.AnimalId, redPanda);
            _animals.Add(tiger.AnimalId, tiger);
        }

        public bool IsMenuOpen
        {
            get => _isMenuOpen;
            set => _isMenuOpen = value;
        }

        public Dictionary<int, Animal> Animals
        {
            get { return _animals; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
