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
using OpenFood_C_Sharp.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace OpenFood_C_Sharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 Window = new Window1();
        TabItem tabItem = new TabItem();
        public MainWindow()
        {
            

            InitializeComponent();
            mainTab.Visibility = Visibility.Hidden;
            peopleButton.Click += GetPeople_Click;
            filmsButton.Click += GetFilm_Click;
            speciesButton.Click += GetSpecies_Click;
            starshipsButton.Click += GetStarships_Click;
            planetsButton.Click += GetPlanets_Click;
            vehiclesButton.Click += GetVehicles_Click;
            ListElements.MouseDoubleClick += CallPage;


        }
        private void CallPage(object sender, MouseEventArgs e)
        {
            /* switch (ListElements.SelectedItem.GetType().ToString()) 
             {
                 case "OpenFood_C_Sharp.Modele.People":
                  People p = (People)ListElements.SelectedItem;
                     PeoplePage peoplePage = new PeoplePage(p.url);
                     this.Content = peoplePage;
                     break;
                 case "OpenFood_C_Sharp.Modele.Film":
                    Film f = (Film)ListElements.SelectedItem;
                     break;


             }*/
            switch (ListElements.SelectedItem.GetType().ToString())
            {
                case "OpenFood_C_Sharp.Modele.People":
                    People p = (People)ListElements.SelectedItem;
                    PeoplePage peoplePage = new PeoplePage(p.url);
                    Frame peoplePageFrame = new Frame();
                    peoplePageFrame.Content = peoplePage;
                    tabItem = new TabItem();
                    tabItem.Header = p.ToString();
                    tabItem.Content = peoplePageFrame;
                    mainTab.Items.Add(tabItem);
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Film":
                    Film f = (Film)ListElements.SelectedItem;
                    FilmPage filmPage = new FilmPage(f.url);
                    Frame filmPageFrame = new Frame();
                    filmPageFrame.Content = filmPage;
                    tabItem = new TabItem();
                    tabItem.Header = f.ToString();
                    tabItem.Content = filmPageFrame;
                    mainTab.Items.Add(tabItem);
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
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
            ListElements.Items.Clear();
            foreach (Film film in films)
            {
                ListElements.Items.Add(film);
            }

        }
        private void GetSpecies_Click(object sender, EventArgs e)
        {
            List<Species> species = SpeciesViewModel.GetAllSpecies();
            ListElements.Items.Clear();
            foreach (Species spe in species)
            {
                ListElements.Items.Add(spe);
            }

        }

        private void GetStarships_Click(object sender, EventArgs e)
        {
            List<Starship> starship = StarshipViewModel.GetAllStarships();
            ListElements.Items.Clear();
            foreach (Starship sta in starship)
            {
                ListElements.Items.Add(sta);
            }

        }

        private void GetVehicles_Click(object sender, EventArgs e)
        {
            List<Vehicle> vehicles = VehicleViewModel.GetAllVehicles();
            ListElements.Items.Clear();
            foreach (Vehicle ve in vehicles)
            {
                ListElements.Items.Add(ve);
            }

        }

        private void GetPlanets_Click(object sender, EventArgs e)
        {
            List<Planet> planets = PlanetViewModel.GetAllPlanets();
            ListElements.Items.Clear();
            foreach (Planet pla in planets)
            {
                ListElements.Items.Add(pla);
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
