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

namespace OpenFood_C_Sharp
{
    /// <summary>
    /// Logique d'interaction pour PeoplePage.xaml
    /// </summary>
    public partial class PeoplePage : Page
    {
        public PeoplePage(String url,String backUrl)
        {
            InitializeComponent();
            People people = PeopleViewModel.GetPeople(url);
            name.Content += people.name;
            mass.Content += people.mass;
            height.Content += people.height;
            backButton.Click += GoBack;

        }
        private void GoBack(object sender, EventArgs e)
        {

        }
        }
}
