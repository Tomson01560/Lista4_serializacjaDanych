// Person.cs
using System.ComponentModel;

namespace WpfApp4
{
    public class Person : INotifyPropertyChanged
    {
        private string imie;
        public string Imie
        {
            get { return imie; }
            set
            {
                if (imie != value)
                {
                    imie = value;
                    OnPropertyChanged(nameof(Imie));
                }
            }
        }

        private string nazwisko;
        public string Nazwisko
        {
            get { return nazwisko; }
            set
            {
                if (nazwisko != value)
                {
                    nazwisko = value;
                    OnPropertyChanged(nameof(Nazwisko));
                }
            }
        }

        private string pesel;
        public string Pesel
        {
            get { return pesel; }
            set
            {
                if (pesel != value)
                {
                    pesel = value;
                    OnPropertyChanged(nameof(Pesel));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Person() { }

        public Person(string imie, string nazwisko, string pesel)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
        }

        public Person(Person other)
        {
            Imie = other.Imie;
            Nazwisko = other.Nazwisko;
            Pesel = other.Pesel;
        }
    }
}
