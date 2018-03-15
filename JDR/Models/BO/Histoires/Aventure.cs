using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VousEtesLeHeros.Models.BO.Equipements;
using VousEtesLeHeros.Models.BO.Personnes;

namespace VousEtesLeHeros.Models.BO.Histoires
{
    public class Aventure
    {
        public int AventureID { get; set; }
        public string Titre { get; set; }

        public DateTime DateDebut { get; set; }
        //nav
        //1 aventure peut concerner plusieurs equipement
        public ICollection<Equipement> Equipements { get; set; }
        //1 aventure peut concerner plusieurs personnages
        public ICollection<Personne> Personnes { get; set; }
        //1 aventure peut concerner plusieurs equipement
        public ICollection<Message> Messages { get; set; }
        //1 aventure peut concerner plusieurs equipement
        //1 aventure peut concerner plusieurs equipement
    }
}
