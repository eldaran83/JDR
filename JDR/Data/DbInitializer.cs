using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VousEtesLeHeros.Models.BO.Equipements;

namespace JDR.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            //look for any Personne ( base is created)
            if (context.Personnes.Any())
            {
                return; //Db has bben seeded
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            //on s'occupe des categories avant des entités
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Categorie equipement
            var categorieEquipements = new CategorieEquipement[]
            {
                new CategorieEquipement{CategorieEquipementID=1, TitreCategorie="Meubles"},
                new CategorieEquipement{CategorieEquipementID=2,TitreCategorie="Armes"},
                new CategorieEquipement{CategorieEquipementID=3,TitreCategorie="Armures"},
                new CategorieEquipement{CategorieEquipementID=4,TitreCategorie="Déplacements"},
            };
            foreach (CategorieEquipement categorie in categorieEquipements)
            {
                context.CategorieEquipements.Add(categorie);
            }
            context.SaveChanges();

            var categoriePersonnes = new CategoriePersonne[]
            {
                new CategoriePersonne{CategoriePersonneId=1,Titre="PNJ"},
                new CategoriePersonne{CategoriePersonneId=2,Titre="Montres"},
                new CategoriePersonne{CategoriePersonneId=3,Titre="Joueur"}
            };
            foreach (CategoriePersonne categorie in categoriePersonnes)
            {
                context.CategoriePersonnes.Add(categorie);
            }
            context.SaveChanges();
        }
    }
 }
