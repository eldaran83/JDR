using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VousEtesLeHeros.Models.BO.Personnes;

public class CategoriePersonne
    {
        public int CategoriePersonneId { get; set; }
        public string Titre { get; set; }

    //nav
    //une categoriepersonne peut concerner plusieur personnes
        public ICollection<Personne> Personnes { get; set; }

    }
