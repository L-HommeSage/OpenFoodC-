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
    /// Logique d'interaction pour StarshipPage.xaml
    /// </summary>
    public partial class StarshipPage : Page
    {
        public StarshipPage(String url)
        {
            InitializeComponent();
            Starship starship = StarshipViewModel.GetStarship(url);
            name.Content += ' ' + starship.name;
            model.Content += ' ' + starship.model;
            manufacturer.Content += ' ' + starship.manufacturer;
            credits.Content += ' ' + starship.cost_in_credits;
            lenght.Content += ' ' + starship.length;
            capacity.Content += ' ' + starship.cargo_capacity;
            Sclass.Content += ' ' + starship.starship_class;
            speed.Content += ' ' + starship.max_atmosphering_speed;
            hyperdrive.Content += ' ' + starship.hyperdrive_rating;
            consumables.Content += ' ' + starship.consumables;
            crew.Content += ' ' + starship.crew;
            passengers.Content += ' ' + starship.passengers;
            created.Content += ' ' + ConvertToDateTime(starship.created);
            edited.Content += ' ' + ConvertToDateTime(starship.edited);
            listFilms.MouseDoubleClick += callFilm;
            listCharacters.MouseDoubleClick += callPeople;
            listFilms.Items.Clear();
            listCharacters.Items.Clear();
            foreach (String f in starship.films)
            {
                listFilms.Items.Add(FilmViewModel.GetFilm(f));
            }
            foreach (String p in starship.pilots)
            {
                listCharacters.Items.Add(PeopleViewModel.GetPeople(p));
            }

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
            this.Content = FilmViewModel.CallFilm(sender, e, listFilms);

        }
        private void callPeople(object sender, MouseEventArgs e)
        {
            this.Content = PeopleViewModel.CallPeople(sender, e, listCharacters);
        }
    }
}
