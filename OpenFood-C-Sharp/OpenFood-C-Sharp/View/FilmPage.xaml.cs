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
    /// Logique d'interaction pour FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        private const string V = "....";
        String filmUrl;
        List<String> backUrl;
        Film film;
        public FilmPage(String url, List<String> backUrl)
        {
            InitializeComponent();
            filmUrl = url;
            this.backUrl = backUrl;
            backButton.Click += GoBack;
            if(this.backUrl.Last() ==""){
                backButton.Visibility = Visibility.Hidden;
            }
            else
            {
                backButton.Visibility = Visibility.Visible;
            }
            film = FilmViewModel.GetFilm(url);
            title.Content += film.title;
            open.Content += film.opening_crawl + V;
            director.Content += ' ' + film.director;
            producer.Content += ' ' + film.producer;
            release.Content += ' ' + ConvertToDateTime(film.release_date);
            created.Content += ' ' + ConvertToDateTime(film.created);
            edited.Content += ' ' + ConvertToDateTime(film.edited);
            ListCharacters.MouseDoubleClick += CallPeople;
            ListSpaceShip.MouseDoubleClick += callStarship;
            ListVehicles.MouseDoubleClick += CallVehicule;
            ListSpecies.MouseDoubleClick += CallSpecies;
            ListCharacters.Items.Clear();
            ListSpaceShip.Items.Clear();
            ListSpecies.Items.Clear();
            ListVehicles.Items.Clear();
            foreach (String charac in film.characters)
            {
                ListCharacters.Items.Add(PeopleViewModel.GetPeople(charac));
                
            }
            foreach (String v in film.vehicles)
            {
                ListVehicles.Items.Add(VehicleViewModel.GetVehicle(v));

            }
            foreach (String s in film.starships)
            {
                ListSpaceShip.Items.Add(StarshipViewModel.GetStarship(s));

            }
            foreach (String spe in film.species)
            {
                ListSpecies.Items.Add(SpeciesViewModel.GetSpecies(spe));

            }
        }
        private void CallPeople(object sender, MouseEventArgs e)
        {
            backUrl.Add(film.url);
           this.Content = PeopleViewModel.CallPeople(sender, e, ListCharacters,backUrl);
        }
        private void GoBack(object sender, EventArgs e)
        {
            this.Content = Helpers.Helper.GoBack(backUrl);

        }
        private void callStarship(object sender, MouseEventArgs e)
        {
            this.Content = StarshipViewModel.CallStarship(sender, e, ListSpaceShip);
        }
        private void CallVehicule(object sender, MouseEventArgs e)
        {
            this.Content = VehicleViewModel.CallVehicule(sender, e, ListVehicles);
        }
        private void CallSpecies(object sender, MouseEventArgs e)
        {
            this.Content = SpeciesViewModel.CallSpecies(sender, e, ListSpecies);
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

    }
}
