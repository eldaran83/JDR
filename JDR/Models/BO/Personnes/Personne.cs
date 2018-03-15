using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VousEtesLeHeros.Models.BO.Personnes
{
    public class Personne
    {
        public int PersonneID { get; set; }

        public string Nom { get; set; }

        public int Intelligence { get; set; }
        [Display(Name ="Dextérité")]
        public int Dexterite { get; set; }
        public int Force { get; set; }
        public int Vie { get; set; }

        [Display(Name = "Expérience")]
        public int Experience { get; set; }
        public int Niveau { get; set; }

        //FK
        public int CategoriePersonneID { get; set; }
        //nav 
        //une personne doit avoir une catégoriepersonne
        public CategoriePersonne CategoriePersonne { get; set; }
    }
}
