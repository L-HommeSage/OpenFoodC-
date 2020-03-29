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
    /// Logique d'interaction pour VehiclePage.xaml
    /// </summary>
    public partial class VehiclePage : Page
    {
        Vehicle vehicle;
        String backUrl;
        public VehiclePage(String url,String backUrl)
        {
            InitializeComponent();
            vehicle = VehicleViewModel.GetVehicle(url);
            this.backUrl = backUrl;
            if (this.backUrl == "")
            {
                backButton.Visibility = Visibility.Hidden;
            }
            else
            {
                backButton.Visibility = Visibility.Visible;
            }
            name.Content += ' ' + vehicle.name;
            model.Content += ' ' + vehicle.model;
            manufacturer.Content += ' ' + vehicle.manufacturer;
            credits.Content += ' ' + vehicle.cost_in_credits;
            lenght.Content += ' ' + vehicle.length;
            capacity.Content += ' ' + vehicle.cargo_capacity;
            Sclass.Content += ' ' + vehicle.vehicle_class;
            speed.Content += ' ' + vehicle.max_atmosphering_speed;
            consumables.Content += ' ' + vehicle.consumables;
            crew.Content += ' ' + vehicle.crew;
            passengers.Content += ' ' + vehicle.passengers;
            created.Content += ' ' + ConvertToDateTime(vehicle.created);
            edited.Content += ' ' + ConvertToDateTime(vehicle.edited);
            listFilms.MouseDoubleClick += callFilm;
            listCharacters.MouseDoubleClick += callPeople;
            listFilms.Items.Clear();
            listCharacters.Items.Clear();
            backButton.Click += GoBack;
            foreach (String f in vehicle.films)
            {
                listFilms.Items.Add(FilmViewModel.GetFilm(f));
            }
            foreach (String p in vehicle.pilots)
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
            this.Content = FilmViewModel.CallFilm(sender, e, listFilms,vehicle.url);

        }
        private void callPeople(object sender, MouseEventArgs e)
        {
            this.Content = PeopleViewModel.CallPeople(sender, e, listCharacters,vehicle.url);
        }
        private void GoBack(object sender, EventArgs e)
        {
            this.Content = Helpers.Helper.GoBack(backUrl);

        }
    }
}
