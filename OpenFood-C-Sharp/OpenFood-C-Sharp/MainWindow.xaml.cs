using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using OpenFood_C_Sharp.Modele;
using OpenFood_C_Sharp.Helpers;
using OpenFood_C_Sharp.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace OpenFood_C_Sharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            

            InitializeComponent();
            peopleButton.Click += GetPeople_Click;
            filmsButton.Click += GetFilm_Click;
            ListElements.MouseDoubleClick += CallPage;

        }
        private void CallPage(object sender, MouseEventArgs e)
        {
            switch (ListElements.SelectedItem.GetType().ToString()) 
            {
                case "OpenFood_C_Sharp.Modele.People":
                 People p = (People)ListElements.SelectedItem;
                   
                    break;
                case "OpenFood_C_Sharp.Modele.Film":
                   Film f = (Film)ListElements.SelectedItem;
                    break;


            }

          

           

          

        }
        private void GetPeople_Click(object sender, EventArgs e)
        {
            List<People> peoples = PeopleViewModel.GetAllPeople();
            ListElements.Items.Clear();
            foreach(People people in peoples)
            {
                ListElements.Items.Add(people);

            }

        }
        private void GetFilm_Click(object sender, EventArgs e)
        {
            List<Film> films = FilmViewModel.GetAllFilm();
            foreach (Film film in films)
            {
                ListElements.Items.Add(film);
            }

        }

        public void getPeopleExemple()
        {

           /// ObservableCollection<People> A = PeopleViewModel.GetListOfPeople();


            People people = PeopleViewModel.GetPeople("https://swapi.co/api/people/1");
            Console.WriteLine(people.name);
           foreach (string i in people.films)
            {
               Film f =  FilmViewModel.GetFilm(i);
              Console.WriteLine(  f.title ) ; 
            }
        }
    }
}
