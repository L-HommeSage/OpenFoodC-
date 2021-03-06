﻿using System;
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
using OpenFood_C_Sharp.View;

namespace OpenFood_C_Sharp
{
    /// <summary>
    /// Logique d'interaction pour PeoplePage.xaml
    /// </summary>
    public partial class PeoplePage : Page
    {
        People people;
        List<String> backUrl;
        public PeoplePage(String url,List<String> backUrl)
        {
            InitializeComponent();
            people = PeopleViewModel.GetPeople(url);
            name.Content += people.name;
            this.backUrl = backUrl;
            if (this.backUrl.Last() == "")
            {
                backButton.Visibility = Visibility.Hidden;
            }
            else
            {
                backButton.Visibility = Visibility.Visible;
            }
            mass.Content += ' '+people.mass;
            height.Content += ' ' + people.height;
            birth.Content += ' ' + people.birth_year;
            eye.Content += ' ' + people.eye_color;
            gender.Content += ' ' + people.gender;
            hair.Content += ' ' + people.hair_color;
            homeworld.Content += ' ' + GetHomeWorld(people.homeworld);
            skin.Content += ' ' + people.skin_color;
            created.Content += ' ' + ConvertToDateTime(people.created);
            edited.Content += ' ' + ConvertToDateTime(people.edited);
            backButton.Click += GoBack;

            listFilms.MouseDoubleClick += callFilm;
            listStarships.MouseDoubleClick += callStarship;
            listVehicles.MouseDoubleClick += CallVehicule;

            listFilms.Items.Clear();
            listStarships.Items.Clear();
            listVehicles.Items.Clear();
            foreach (String f in people.films)
            {
                listFilms.Items.Add(FilmViewModel.GetFilm(f));
            }
            foreach (String s in people.starships)
            {
                listStarships.Items.Add(StarshipViewModel.GetStarship(s));
            }
            foreach (String v in people.vehicles)
            {
                listVehicles.Items.Add(VehicleViewModel.GetVehicle(v));
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
                return(value);
            }
        }

        private static string GetHomeWorld(string value)
        {
            Planet planet = PlanetViewModel.GetPlanet(value);
            return planet.name;
        }
        private void GoBack(object sender, EventArgs e)
        {
            this.Content = Helpers.Helper.GoBack(backUrl);

        }
        private void callFilm(object sender, MouseEventArgs e)
        {
            backUrl.Add(people.url);
            this.Content = FilmViewModel.CallFilm(sender, e, listFilms,backUrl);
            
        }
        private void callStarship(object sender, MouseEventArgs e)
        {
            backUrl.Add(people.url);
            this.Content = StarshipViewModel.CallStarship(sender, e, listStarships,backUrl) ;
        }
        private void CallVehicule(object sender, MouseEventArgs e)
        {
            backUrl.Add(people.url);
            this.Content = VehicleViewModel.CallVehicule(sender, e, listVehicles,backUrl);
        }
        
    }
}
