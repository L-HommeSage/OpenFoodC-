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
        Button b = new Button();
        StackPanel stack = new StackPanel();
        Label l = new Label();
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
            List<String> backUrl = new List<String>();
            backUrl.Add("");
            switch (ListElements.SelectedItem.GetType().ToString())
            {
                case "OpenFood_C_Sharp.Modele.People":
                    b = new Button();
                    b.Content = " X ";
                    People p = (People)ListElements.SelectedItem;
                    PeoplePage peoplePage = new PeoplePage(p.url,backUrl);
                    Frame peoplePageFrame = new Frame();
                    peoplePageFrame.Content = peoplePage;
                    tabItem = new TabItem();
                    stack = new StackPanel();
                    l = new Label();
                    l.Content = p.ToString();
                    stack.Children.Add(l);
                    stack.Children.Add(b);
                    stack.Orientation = Orientation.Horizontal;
                    tabItem.Header = stack;
                    tabItem.Content = peoplePageFrame;
                    mainTab.Items.Add(tabItem);
                    b.Click += removePanel;
                    b.Tag = tabItem;
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Film":
                    b = new Button();
                    b.Content = " X ";
                    Film f = (Film)ListElements.SelectedItem;
                    FilmPage filmPage = new FilmPage(f.url,backUrl);
                    Frame filmPageFrame = new Frame();
                    filmPageFrame.Content = filmPage;
                    tabItem = new TabItem();
                    stack = new StackPanel();
                    l = new Label();
                    l.Content = f.ToString();
                    stack.Children.Add(l);
                    stack.Children.Add(b);
                    stack.Orientation = Orientation.Horizontal;
                    tabItem.Header = stack;
                    tabItem.Content = filmPageFrame;
                    mainTab.Items.Add(tabItem);
                    b.Tag = tabItem;
                    b.Click += removePanel;
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Starship":
                    b = new Button();
                    b.Content = " X ";
                    Starship star = (Starship)ListElements.SelectedItem;
                    StarshipPage starshipPage = new StarshipPage(star.url,backUrl);
                    Frame starsShipFrame = new Frame();
                    starsShipFrame.Content = starshipPage;
                    tabItem = new TabItem();
                    stack = new StackPanel();
                    
                    l = new Label();
                    l.Content = star.ToString();
                    stack.Children.Add(l);
                    stack.Children.Add(b);
                    stack.Orientation = Orientation.Horizontal;
                    tabItem.Header = stack;
                    tabItem.Content = starsShipFrame;
                    mainTab.Items.Add(tabItem);
                    b.Tag = tabItem;
                    b.Click += removePanel;
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Vehicle":
                    b = new Button();
                    b.Content = " X ";
                    Vehicle v = (Vehicle)ListElements.SelectedItem;
                    VehiclePage vehiclePage = new VehiclePage(v.url,backUrl);
                    Frame vehiculeFrame = new Frame();
                    vehiculeFrame.Content = vehiclePage;
                    tabItem = new TabItem(); 
                    stack = new StackPanel();                   
                    l = new Label();
                    l.Content = v.ToString();
                    stack.Children.Add(l);
                    stack.Children.Add(b);
                    stack.Orientation = Orientation.Horizontal;
                    tabItem.Header = stack;
                    tabItem.Content = vehiculeFrame;
                    mainTab.Items.Add(tabItem);
                    b.Tag = tabItem;
                    b.Click += removePanel;
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Species":
                    b = new Button();
                    b.Content = " X ";
                    Species s = (Species)ListElements.SelectedItem;
                    SpeciesPage speciesPage = new SpeciesPage(s.url,backUrl);
                    Frame speciesFrame = new Frame();
                    speciesFrame.Content = speciesPage;
                    tabItem = new TabItem();
                    stack = new StackPanel();                   
                    l = new Label();
                    l.Content = s.ToString();
                    stack.Children.Add(l);
                    stack.Children.Add(b);
                    stack.Orientation = Orientation.Horizontal;
                    tabItem.Header = stack;
                    tabItem.Content = speciesFrame;
                    mainTab.Items.Add(tabItem);
                    b.Tag = tabItem;
                    b.Click += removePanel;
                    mainTab.SelectedItem = tabItem;
                    mainTab.Visibility = Visibility.Visible;
                    break;
                case "OpenFood_C_Sharp.Modele.Planet":
                    b = new Button();
                    b.Content = " X ";
                    Planet pla = (Planet)ListElements.SelectedItem;
                    PlanetPage planetPage = new PlanetPage(pla.url,backUrl);
                    Frame planetFrame = new Frame();
                    planetFrame.Content = planetPage;
                    tabItem = new TabItem();
                    stack = new StackPanel();
                    l = new Label();
                    l.Content = pla.ToString();
                    stack.Children.Add(l);
                    stack.Children.Add(b);
                    stack.Orientation = Orientation.Horizontal;
                    tabItem.Header = stack;
                    tabItem.Content = planetFrame;
                    mainTab.Items.Add(tabItem);
                    b.Click += removePanel;
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
        private void removePanel(object sender, EventArgs e)
        {
            
            Console.WriteLine(((Button)sender).Tag);
            mainTab.Items.Remove(((Button)sender).Tag);
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
