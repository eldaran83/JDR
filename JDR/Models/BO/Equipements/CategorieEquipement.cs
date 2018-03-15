using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VousEtesLeHeros.Models.BO.Equipements
{
    public class CategorieEquipement
    {
        public int CategorieEquipementID { get; set; }

        [Display(Name ="Catégorie")]
        public string TitreCategorie { get; set; }

        //nav
        //CategorieEquipement peut concerner plusieurs equipement
        public ICollection<Equipement> Equipements { get; set; }
    }
}
