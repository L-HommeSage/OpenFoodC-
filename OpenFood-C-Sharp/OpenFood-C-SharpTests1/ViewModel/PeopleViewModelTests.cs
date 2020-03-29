using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenFood_C_Sharp.ViewModel;
using OpenFood_C_Sharp.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFood_C_Sharp.ViewModel.Tests
{
    [TestClass()]
    public class PeopleViewModelTests
    {
        [TestMethod()]
        public void GetPeopleTest()
        {
            People people = PeopleViewModel.GetPeople("https://swapi.co/api/people/1/");
            string a = "Luke Skywalker";
            Assert.AreEqual(a,people.name);
        }
    }
}