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
            #region Animal initilization
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

            Animal leopard = new Animal(3, "Leopard", "../Assets/leopard.jpg", Enum.AreaCategory.Asien);
            leopard.AddAnimalFact("Leopard fact 1");
            leopard.AddAnimalFact("Leopard fact 2");
            leopard.AddAnimalFact("Leopard fact 3");
            leopard.AddAnimalFact("Leopard fact 4");
            leopard.AddAnimalFact("Leopard fact 5");
            leopard.AddAnimalFact("Leopard fact 6");

            Animal tucan = new Animal(4, "Tucan", "../Assets/Tucan.jpg", Enum.AreaCategory.Asien);
            tucan.AddAnimalFact("Tucanens næb er stort, men skrøbeligt.");
            tucan.AddAnimalFact("Tucan fact 2");
            tucan.AddAnimalFact("Tucan fact 3");
            tucan.AddAnimalFact("Tucan fact 4");
            tucan.AddAnimalFact("Tucan fact 5");
            tucan.AddAnimalFact("Tucan fact 6");

            Animal sloth = new Animal(5, "Dovendyr", "../Assets/sloth.jpg", Enum.AreaCategory.Asien);
            sloth.AddAnimalFact("Alger gror på dovendyr, hvilket fungerer som camouflage.");
            sloth.AddAnimalFact("Dovendyr defækerer og urinerer en gang om ugen.");
            sloth.AddAnimalFact("Et dovendyr bruger ca. 90% af tiden på at hænge oppefra og ned fra grene.");
            sloth.AddAnimalFact("Dovendyr kan dreje deres hoved på en 270 graders akse.");
            sloth.AddAnimalFact("Dovendyr kan holde vejret i ca. 40 min og svømmer 3 gange hurtigere end det bevæger sig på land.");
            sloth.AddAnimalFact("Dovendyr bevæger sig generelt ikke længere end 38 meter om dagen og bevæger sig kun 30 cm i minuttet når det befinder sig på jorden");

            Animal ape = new Animal(6, "Abe", "../Assets/monkey-selfie - Copy.jpg", Enum.AreaCategory.Asien);
            ape.AddAnimalFact("Monkey see, monkey do.");
            ape.AddAnimalFact("Abe fact 2");
            ape.AddAnimalFact("Abe fact 3");
            ape.AddAnimalFact("Abe fact 4");
            ape.AddAnimalFact("Abe fact 5");

            #endregion

            _animals = new Dictionary<int, Animal>();
            _animals.Add(tiger.AnimalId, tiger);
            _animals.Add(redPanda.AnimalId, redPanda);
            _animals.Add(leopard.AnimalId, leopard);
            _animals.Add(tucan.AnimalId, tucan);
            _animals.Add(sloth.AnimalId, sloth);
            _animals.Add(ape.AnimalId, ape);


            // Til MainPage.xml
            Tiger = tiger;
            RedPanda = redPanda;

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
