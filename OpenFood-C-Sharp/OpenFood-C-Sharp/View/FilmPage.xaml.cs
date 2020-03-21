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
        public FilmPage(String url)
        {
            InitializeComponent();
            PeopleTab.Visibility = Visibility.Hidden;
            Film film = FilmViewModel.GetFilm(url);
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
            People p = (People)ListCharacters.SelectedItem;
            PeoplePage peoplePage = new PeoplePage(p.url);
            TabItem tabItem = new TabItem();
            Frame tabFrame = new Frame();
            tabFrame.Content = peoplePage;

            tabItem.Header = p.ToString();

            tabItem.Content = tabFrame;
            PeopleTab.Items.Add(tabItem);
            PeopleTab.SelectedItem = tabItem;
            PeopleTab.Visibility = Visibility.Visible;
        }
    }
}
