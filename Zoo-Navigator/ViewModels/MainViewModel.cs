using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private RelayCommand _backCommand;
        private List<Category> _categories;
        private readonly SharedKnowledge _shared;
        private RCO _nextCommand;

        public MainViewModel()
        {
            Animal tiger = new Tiger(1, "undefined");
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
            _categories = new List<Category>();

            Category asien = new Category(Enum.AreaCategory.Asien, "Asien");
            Category norden = new Category(Enum.AreaCategory.Norden, "Norden");
            Category savannen = new Category(Enum.AreaCategory.Savannen, "Savannen");
            Category boerneZoo = new Category(Enum.AreaCategory.Børnezoo, "BørneZoo");
            Category verdensPladsen = new Category(Enum.AreaCategory.Verdenspladsen, "Verdenspladsen");

            _categories.Add(asien);
            _categories.Add(norden);
            _categories.Add(savannen);
            _categories.Add(boerneZoo);
            _categories.Add(verdensPladsen);

            _popCommand = new RelayCommand(Tænd);
            _backCommand = new RelayCommand(GoBack);
            _nextCommand = new RCO(Next);
            _isMenuOpen = false;
            _shared = SharedKnowledge.Instance;
        }
        #region Methods
        private void Tænd()
        {
            IsMenuOpen = true;
        }

        private void Next(object obj)
        {
            _shared.SelectedAnimal = (Animal) obj;

            Frame f = (Frame) Window.Current.Content;
            f.Navigate(typeof(AnimalPage));
        }

        private void GoBack()
        {
            Frame f = (Frame) Window.Current.Content;
            if (f.CanGoBack) { f.GoBack();}
        }
        #endregion

        #region Properties
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

        public RelayCommand BackCommand
        {
            get { return _backCommand; }
        }

        public RCO NextCommand
        {
            get { return _nextCommand; }
        }

        public List<Category> Categories
        {
            get { return _categories; }
        }

        public Dictionary<int, Animal> Animals
        {
            get { return _animals; }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
