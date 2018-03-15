using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VousEtesLeHeros.Models.BO.Histoires
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }

        //nav
        //un message doit appartenir à une aventure
        public Aventure Aventure { get; set; }
    }
}
