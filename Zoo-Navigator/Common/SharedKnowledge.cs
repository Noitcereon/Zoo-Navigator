using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zoo_Navigator.Annotations;
using Zoo_Navigator.Models;

namespace Zoo_Navigator.Common
{
    class SharedKnowledge : INotifyPropertyChanged
    {
        private Animal _selectedAnimal;
        private static SharedKnowledge _instance = new SharedKnowledge();

        private SharedKnowledge()
        {
            Animal a = new Animal(200, "kat", "", Enum.AreaCategory.Børnezoo);
            a.AnimalFacts.Add("Svend");
            a.AnimalFacts.Add("fact 1");
            a.AnimalFacts.Add("Hello bob");
            a.AddAnimalFact("hello johan");
            _selectedAnimal = a;
        }

        public static SharedKnowledge Instance
        {
            get { return _instance; }
        }
        public Animal SelectedAnimal
        {
            get { return _selectedAnimal; }
            set
            {
                if (Equals(value, _selectedAnimal)) return;
                _selectedAnimal = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
