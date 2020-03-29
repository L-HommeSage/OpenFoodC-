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
        Window1 window1 = new Window1();
        String filmUrl;
        String backUrl;
        Film film;
        public FilmPage(String url, String backUrl)
        {
            InitializeComponent();
            filmUrl = url;
            this.backUrl = backUrl;
            backButton.Click += GoBack;
            if(this.backUrl ==""){
                backButton.Visibility = Visibility.Hidden;
            }
            else
            {
                backButton.Visibility = Visibility.Visible;
            }
            film = FilmViewModel.GetFilm(url);
            title.Content += film.title;
            ListCharacters.MouseDoubleClick += CallPeople;
            ListCharacters.Items.Clear();
            foreach (String charac in film.characters)
            {
                ListCharacters.Items.Add(PeopleViewModel.GetPeople(charac));
                
            }
        }
        private void CallPeople(object sender, MouseEventArgs e)
        {
           this.Content = PeopleViewModel.CallPeople(sender, e, ListCharacters,film.url);
        }
        private void GoBack(object sender, EventArgs e)
        {
            this.Content = Helpers.Helper.GoBack(backUrl);

        }
    }
}
