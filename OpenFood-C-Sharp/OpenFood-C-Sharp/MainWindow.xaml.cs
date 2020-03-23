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

namespace OpenFood_C_Sharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TabItem tabItem = new TabItem();
        List<string> listcollection = new List<string>();
        string category = "";
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
            search.TextChanged += textBox_TextChanged;

            listcollection.Clear();
            foreach(string str in ListElements.Items)
            {
                listcollection.Add(str);
            }


        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(search.Text);
            List<People> resultSearch = Request.MakeSearch(category, search.Text);
            ListElements.Items.Clear();
            foreach (People element in resultSearch)
            {
                ListElements.Items.Add(element);

            }
        }
        private void CallPage(object sender, MouseEventArgs e)
        {
            
            switch (ListElements.SelectedItem.GetType().ToString())
            {
                case "OpenFood_C_Sharp.Modele.People":
                    People p = (People)ListElements.SelectedItem;
                    PeoplePage peoplePage = new PeoplePage(p.url,"");
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
                case "OpenFood_C_Sharp.Modele.Starship":
                    Starship star = (Starship)ListElements.SelectedItem;
                    StarshipPage starshipPage = new StarshipPage(star.url);
                    Frame starsShipFrame = new Frame();
                    starsShipFrame.Content = starshipPage;
                    tabItem = new TabItem();
                    tabItem.Header = star.ToString();
                    tabItem.Content = starsShipFrame;
                    mainTab.Items.Add(tabItem);
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Vehicule":
                    Vehicle v = (Vehicle)ListElements.SelectedItem;
                    VehiclePage vehiclePage = new VehiclePage(v.url);
                    Frame vehiculeFrame = new Frame();
                    vehiculeFrame.Content = vehiclePage;
                    tabItem = new TabItem();
                    tabItem.Header = v.ToString();
                    tabItem.Content = vehiculeFrame;
                    mainTab.Items.Add(tabItem);
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Species":
                    Species s = (Species)ListElements.SelectedItem;
                    SpeciesPage speciesPage = new SpeciesPage(s.url);
                    Frame speciesFrame = new Frame();
                    speciesFrame.Content = speciesPage;
                    tabItem = new TabItem();
                    tabItem.Header = s.ToString();
                    tabItem.Content = speciesFrame;
                    mainTab.Items.Add(tabItem);
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Planet":
                    Planet pla = (Planet)ListElements.SelectedItem;
                    PlanetPage planetPage = new PlanetPage(pla.url);
                    Frame planetFrame = new Frame();
                    planetFrame.Content = planetFrame;
                    tabItem = new TabItem();
                    tabItem.Header = pla.ToString();
                    tabItem.Content = planetFrame;
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
            category = "people";
        }
        private void GetFilm_Click(object sender, EventArgs e)
        {
            List<Film> films = FilmViewModel.GetAllFilm();
            ListElements.Items.Clear();
            foreach (Film film in films)
            {
                ListElements.Items.Add(film);
            }
            category = "films";

        }
        private void GetSpecies_Click(object sender, EventArgs e)
        {
            List<Species> species = SpeciesViewModel.GetAllSpecies();
            ListElements.Items.Clear();
            foreach (Species spe in species)
            {
                ListElements.Items.Add(spe);
            }
            category = "species";

        }

        private void GetStarships_Click(object sender, EventArgs e)
        {
            List<Starship> starship = StarshipViewModel.GetAllStarships();
            ListElements.Items.Clear();
            foreach (Starship sta in starship)
            {
                ListElements.Items.Add(sta);
            }
            category = "starships";

        }

        private void GetVehicles_Click(object sender, EventArgs e)
        {
            List<Vehicle> vehicles = VehicleViewModel.GetAllVehicles();
            ListElements.Items.Clear();
            foreach (Vehicle ve in vehicles)
            {
                ListElements.Items.Add(ve);
            }
            category = "vehicles";
        }

        private void GetPlanets_Click(object sender, EventArgs e)
        {
            List<Planet> planets = PlanetViewModel.GetAllPlanets();
            ListElements.Items.Clear();
            foreach (Planet pla in planets)
            {
                ListElements.Items.Add(pla);
            }
            category = "planets";

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
