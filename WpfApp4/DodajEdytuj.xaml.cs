// DodajEdytuj.xaml.cs
using System.Windows;

namespace WpfApp4
{
    public partial class DodajEdytuj : Window
    {
        public bool IsOkPressed { get; set; }
        public Person AddedPerson { get; private set; }

        public DodajEdytuj()
        {
            InitializeComponent();
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            string imie = textBoxImie.Text;
            string nazwisko = textBoxNazwisko.Text;
            string pesel = textBoxPesel.Text;

            // Sprawdzanie, czy wprowadzone dane są poprawne (dla uproszczenia)

            AddedPerson = new Person(imie, nazwisko, pesel);
            IsOkPressed = true;
            this.Close();
        }
    }
}
