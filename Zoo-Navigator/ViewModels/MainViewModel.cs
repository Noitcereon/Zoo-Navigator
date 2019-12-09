using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Zoo_Navigator.Annotations;
using Zoo_Navigator.Common;
using Zoo_Navigator.Models;
using Zoo_Navigator.Views;
using Enum = Zoo_Navigator.Common.Enum;

namespace Zoo_Navigator.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private bool _isMenuOpen = true;
        private Dictionary<int, Animal> _animals;
        private RelayCommand _popCommand;
        private readonly SharedKnowledge _shared;

        public MainViewModel()
        {
            Animal tiger = new Tiger(1,"undefined");
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

            Animal redPanda = new RedPanda(2, "undefined");
            redPanda.AddAnimalFact("red panda fact 1");
            redPanda.AddAnimalFact("red panda fact 2");
            redPanda.AddAnimalFact("red panda fact 3");
            redPanda.AddAnimalFact("red panda fact 4");
            redPanda.AddAnimalFact("red panda fact 5");
            redPanda.AddAnimalFact("red panda fact 6");

            _animals = new Dictionary<int, Animal>();

            _animals.Add(redPanda.AnimalId, redPanda);
            _animals.Add(tiger.AnimalId, tiger);
            /*
            _animals.Add(tiger.AnimalId+3, tiger);
            _animals.Add(redPanda.AnimalId+4, redPanda);
            _animals.Add(redPanda.AnimalId+5, redPanda);
            _animals.Add(tiger.AnimalId+8, tiger);

    */
            _popCommand = new RelayCommand(Tænd);
            _isMenuOpen = false;
            _shared = SharedKnowledge.Instance;
        }

        private void Tænd()
        {
            IsMenuOpen = true;
           
        }

        public bool IsMenuOpen
        {
            get => _isMenuOpen;
            set { _isMenuOpen = value; OnPropertyChanged(); }
        }

        public SharedKnowledge Instance
        {
            get { return _shared; }
        }

        public RelayCommand PopCommand
        {
            get { return _popCommand; }
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
