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
    /// Logique d'interaction pour SpeciesPage.xaml
    /// </summary>
    public partial class SpeciesPage : Page
    {
        public SpeciesPage(String url)
        {
            InitializeComponent();
            Species species = SpeciesViewModel.GetSpecies(url);
            height.Content += ' ' + species.average_height;
            lifespan.Content += ' ' + species.average_lifespan;
            classification.Content += ' ' + species.classification;
            designation.Content += ' ' + species.designation;
            eye.Content += ' ' + species.eye_colors;
            hair.Content += ' ' + species.hair_colors;
            homeworld.Content += ' '+ GetHomeWorld(species.homeworld);
            language.Content += ' ' + species.language;
            skin.Content += ' ' + species.skin_colors;
            created.Content += ' ' + ConvertToDateTime(species.created);
            edited.Content += ' ' + ConvertToDateTime(species.edited);

            listPeople.Items.Clear();
            listFilms.Items.Clear();
            foreach (String charac in species.people)
            {
                listPeople.Items.Add(PeopleViewModel.GetPeople(charac));
            }
            foreach (String f in species.films)
            {
                listFilms.Items.Add(FilmViewModel.GetFilm(f));
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

        private static string GetHomeWorld(string value)
        {
            Planet planet = PlanetViewModel.GetPlanet(value);
            return planet.name;
        }
    }
}
