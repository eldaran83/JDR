using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VousEtesLeHeros.Models.BO.Equipements
{
    public class Equipement
    {
        public int EquipementID { get; set; }

        public string Nom { get; set; }
        public int Prix { get; set; }

        [Display(Name ="Dureté")]
        public int Durete { get; set; }
        public int? Dommage { get; set; }

         //nav
        //equipement doit concerner 1 Categorie Equipement
        public CategorieEquipement CategorieEquipement { get; set; }
    }
}
