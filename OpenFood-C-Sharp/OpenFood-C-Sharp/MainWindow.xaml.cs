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
using System.Collections.ObjectModel;

namespace OpenFood_C_Sharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            

            InitializeComponent();
            getPeopleExemple();

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
