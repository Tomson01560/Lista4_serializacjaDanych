// MainWindow.xaml.cs
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> listaOsob = new ObservableCollection<Person>();
        private string filePath = "test.xml";

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(filePath))
            {
                listaOsob = new ObservableCollection<Person>(Serializacja.DeserializeToObject<ObservableCollection<Person>>(filePath));
            }
            else
            {
                listaOsob.Add(new Person("Imie", "Nazwisko", "12345678901"));
                listaOsob.Add(new Person("Imie", "Nazwisko", "12345678901"));
                listaOsob.Add(new Person("Imie", "Nazwisko", "12345678901"));
                listaOsob.Add(new Person("Imie", "Nazwisko", "12345678901"));
            }

            dataGridPeople.ItemsSource = listaOsob;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializacja.SerializeToXml<ObservableCollection<Person>>(listaOsob, filePath);
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajEdytuj window = new DodajEdytuj();
            window.ShowDialog();

            if (window.IsOkPressed)
            {
                listaOsob.Add(window.AddedPerson);
            }
        }

        private void ButtonEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPeople.SelectedItem != null)
            {
                DodajEdytuj window = new DodajEdytuj();
                Person selectedPerson = (Person)dataGridPeople.SelectedItem;
                Person personCopy = new Person(selectedPerson);
                window.DataContext = personCopy;
                window.ShowDialog();

                if (window.IsOkPressed)
                {
                    int index = listaOsob.IndexOf(selectedPerson);
                    listaOsob[index] = personCopy;
                    dataGridPeople.Items.Refresh();
                }
            }
        }
    }
}
