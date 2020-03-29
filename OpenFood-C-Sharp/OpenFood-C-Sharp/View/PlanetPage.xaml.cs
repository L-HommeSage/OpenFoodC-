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
using OpenFood_C_Sharp.Modele;
using OpenFood_C_Sharp.ViewModel;

namespace OpenFood_C_Sharp.View
{
    /// <summary>
    /// Logique d'interaction pour PlanetPage.xaml
    /// </summary>
    public partial class PlanetPage : Page
    {
        Planet planet;
        String backUrl;
        public PlanetPage(String url, String backUrl)
        {
            InitializeComponent();
            this.backUrl = backUrl;
            if (this.backUrl == "")
            {
                backButton.Visibility = Visibility.Hidden;
            }
            else
            {
                backButton.Visibility = Visibility.Visible;
            }
            planet = PlanetViewModel.GetPlanet(url);
            name.Content += ' ' + planet.name;
            diameter.Content += ' ' + planet.diameter;
            orbital.Content += ' ' + planet.orbital_period;
            climate.Content += ' ' + planet.climate;
            gravity.Content += ' ' + planet.gravity;
            Water.Content += ' ' + planet.surface_water;
            terrain.Content += ' ' + planet.terrain;
            population.Content += ' ' + planet.population;
            created.Content += ' ' + ConvertToDateTime(planet.created);
            edited.Content += ' ' + ConvertToDateTime(planet.edited);
            backButton.Click += GoBack;
            listResidents.Items.Clear();
            listFilms.Items.Clear();
            foreach (String charac in planet.residents)
            {
                Console.WriteLine(charac);
                listResidents.Items.Add(PeopleViewModel.GetPeople(charac));
            }
            foreach (String f in planet.films)
            {
                listFilms.Items.Add(FilmViewModel.GetFilm(f));
            }
            listFilms.MouseDoubleClick += callFilm;
            listResidents.MouseDoubleClick += callPeople;
        }

        private static string ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);
                string input = value;
                string sub = input.Substring(0, 10);

                return (sub);
            }
            catch (FormatException)
            {
                return (value);
            }
        }
        private void callFilm(object sender, MouseEventArgs e)
        {
            this.Content = FilmViewModel.CallFilm(sender, e, listFilms,planet.url);

        }
        private void callPeople(object sender, MouseEventArgs e)
        {
           
            this.Content = PeopleViewModel.CallPeople(sender, e, listResidents, planet.url);
        }
        private void GoBack(object sender, EventArgs e)
        {
            this.Content = Helpers.Helper.GoBack(backUrl);

        }
    }
}
