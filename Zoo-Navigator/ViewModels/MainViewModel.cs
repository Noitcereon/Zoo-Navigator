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
        private bool _isMenuOpen;
        private Dictionary<int, Animal> _animals;
        private RelayCommand _popCommand;
        private RelayCommand _backCommand;
        private List<Category> _categories;
        private readonly SharedKnowledge _shared;
        private RCO _nextCommand;
        private RelayCommand _navToTigerCommand;
        private RelayCommand _navToRedPandaCommand;
        private RelayCommand _navToCategoryCommand;

        public MainViewModel()
        {
            #region Animals
            Animal tiger = new Tiger(1, "../Assets/tiger-image.jpg");
            tiger.AddAnimalFact("Tigere er nemme at genkende med deres mørke striber og rød/orange pels.");
            tiger.AddAnimalFact("Modsat andre kattedyr, er tigere gode til at svømme og kan lide vand.");
            tiger.AddAnimalFact("Cubs are born blind and only open their eyes 1-2 weeks after birth.");
            tiger.AddAnimalFact("Voksne tigere lever som regel alene.");
            tiger.AddAnimalFact("The Bengal tiger is the most common tiger.");
            tiger.AddAnimalFact("Tigers are the largest cat species in the world reaching up to 3.3 meters in length and weighing up to 670 pounds!");
            tiger.AddAnimalFact("Tigere lever mellem 20-26 år i naturen");

            Animal redPanda = new RedPanda(2, "../Assets/rød-panda01.png");
            redPanda.AddAnimalFact("Røde pandaer er en truet dyreart. De har 2 uddøde relativer.");
            redPanda.AddAnimalFact("De er vegetariske karnivorer");
            redPanda.AddAnimalFact("En huskat er nogenlunde på samme størrelse som en rød panda, men røde pandaers hale kan blive helt op til omkring 46 cm.");
            redPanda.AddAnimalFact("En rød panda bruger dens hale til både balance og til at holde varmen.");
            redPanda.AddAnimalFact("De er mestre i at stikke af og har op til flere gange stukket af fra zoologiske haver.");
            redPanda.AddAnimalFact("Browseren Firefox er navngivet efter den røde panda, som også til tider bliver kaldt Firefox.");
            redPanda.AddAnimalFact("Røde pandaer har en 'falsk tommelfinger', som de bruger til at klatre og spise bambus.");

            _animals = new Dictionary<int, Animal>();
            _animals.Add(tiger.AnimalId, tiger);
            _animals.Add(redPanda.AnimalId, redPanda);

            _animals.Add(tiger.AnimalId + 3, tiger);
            _animals.Add(redPanda.AnimalId + 4, redPanda);
            _animals.Add(redPanda.AnimalId + 5, redPanda);
            _animals.Add(tiger.AnimalId + 8, tiger);

            // Til MainPage.xml
            Tiger = tiger;
            RedPanda = redPanda;

            #endregion

            #region Categories
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
            #endregion

            _popCommand = new RelayCommand(Tænd);
            _backCommand = new RelayCommand(GoBack);
            _nextCommand = new RCO(Next);
            _navToCategoryCommand = new RelayCommand(GoToCategory);
            _navToTigerCommand = new RelayCommand(NavToTiger);
            _navToRedPandaCommand = new RelayCommand(NavToRedPanda);

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
            var animalPair = (KeyValuePair<int, Animal>)obj;
            _shared.SelectedAnimal = animalPair.Value;

            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(AnimalPage));
        }
        private void NavToTiger()
        {
            _shared.SelectedAnimal = Tiger;

            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(AnimalPage));
        }
        private void NavToRedPanda()
        {
            _shared.SelectedAnimal = RedPanda;

            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(AnimalPage));
        }
        
        private void GoToCategory()
        {
            Frame f = (Frame)Window.Current.Content;
            f.Navigate(typeof(Categories));
        }

        private void GoBack()
        {
            Frame f = (Frame)Window.Current.Content;
            if (f.CanGoBack) { f.GoBack(); }
        }
        #endregion

        #region Properties
        public Animal Tiger { get; }
        public Animal RedPanda { get; }

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

        public RelayCommand NavToCategoryCommand
        {
            get => _navToCategoryCommand;
        }

        public RelayCommand BackCommand
        {
            get { return _backCommand; }
        }

        public RCO NextCommand
        {
            get { return _nextCommand; }
        }

        public RelayCommand NavToTigerCommand
        {
            get { return _navToTigerCommand; }
        }

        public RelayCommand NavToRedPandaCommand
        {
            get { return _navToRedPandaCommand; }
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
