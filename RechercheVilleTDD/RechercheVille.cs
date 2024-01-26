using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheVilleTDD
{
    public class RechercheVille
    {
        private List<String> _villes;



        public RechercheVille(List<string> villes)
        {
            _villes = villes;
        }

        public List<String> Rechercher(String mot)
        {
            if (mot == "*")
                return _villes;
            if (mot.Length < 2)
            {
                throw new NotFoundException("Error");
            }
            return _villes.Where(ville => ville.ToLower().Contains(mot.ToLower())).ToList();
        }
    }
}