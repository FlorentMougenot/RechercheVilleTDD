using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RechercheVilleTDD;

namespace RechercheVille.Tests
{
    public class RechercheVilleTest
    {
        private List<string> _villesTest;

        public RechercheVilleTest()
        {
            Setup();
        }

        private void Setup()
        {
            /*Liste des villes servant pour les tests*/
            _villesTest = new List<string>() { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Dubaï", "Rome", "Istanbul" };
        }

        [Fact]
        public void When_SearchTextLength_Less_Than_2_Then_Throw_NotFoundException()
        {
            var rechercheVille = new RechercheVilleTDD.RechercheVille(_villesTest);
            string searchText = "A";
            Assert.Throws<NotFoundException>(() => rechercheVille.Rechercher(searchText));
        }

        [Fact]
        public void When_SearchTextLength_Greater_Than_1_Then_Return_CitiesStartingWithSearchText()
        {
            var rechercheVille = new RechercheVilleTDD.RechercheVille(_villesTest);
            var result = rechercheVille.Rechercher("Sy");
            Assert.Contains("Sydney", result);
        }
        [Fact]
        public void ShouldBe_CaseInsensitive()
        {
            var rechercheVille = new RechercheVilleTDD.RechercheVille(_villesTest);
            var result = rechercheVille.Rechercher("va");
            Assert.Equal(new List<string>() { "Valence", "Vancouver" }, result);
        }
        [Fact]
        public void Partial_Search()
        {
            var rechercheVille = new RechercheVilleTDD.RechercheVille(_villesTest);
            var result = rechercheVille.Rechercher("ape");
            Assert.Contains("Budapest", result);
        }
        [Fact]
        public void TestRechercheAsterisque()
        {
            var rechercheVille = new RechercheVilleTDD.RechercheVille(_villesTest);
            var result = rechercheVille.Rechercher("*");
            Assert.Equal(_villesTest.Count, result.Count);
        }
    }
}
