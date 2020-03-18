using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_auteurs.BO;

namespace TP_auteurs
{
    class Program
    {

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        static void Main(string[] args)
        {
            InitialiserDatas();

            // Afficher la liste des prenoms des auteurs dont le nom commence par G
            Console.WriteLine("-- Liste des prénoms des auteurs dont le nom commence par G --");
            var prenomsG = ListeAuteurs.Where(p => p.Nom.StartsWith("G")).Select(p => p.Prenom);
            foreach (var prenom in prenomsG)
            {
                Console.WriteLine(prenom);
            }

            //Afficher l’auteur ayant écrit le plus de livres 
            Console.WriteLine();
            var moreLivre = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(l => l.Count()).First().Key;
            Console.WriteLine($" -- Auteur avec le plus de livres : {moreLivre.Nom} {moreLivre.Prenom}");

            //Afficher le nombre moyen de pages par livre par auteur
            Console.WriteLine();
            var livresByAuteur = ListeLivres.GroupBy(l => l.Auteur);
            Console.WriteLine(" -- Le nombre moyen de pages par livre/auteur --  ");
            foreach (var livre in livresByAuteur)
            {
                Auteur auteur = livre.Key;
                double nbPages = livre.Average(l => l.NbPages);
                Console.WriteLine($"{auteur.Nom} {auteur.Prenom} a écrit en moyenne {nbPages} pages");
            }

            //Afficher le titre du livre avec le plus de pages 
            Console.WriteLine();
            var livreMorePage = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine(" -- Le titre du livre avec le plus de pages --");
            Console.WriteLine(livreMorePage.Titre);

            //Afficher combien ont gagné les auteurs en moyenne(moyenne des factures) 
            Console.WriteLine();
            var moyenneFacture = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine("-- Ils ont gagnés en moyenne " + moyenneFacture + "euros");

            //Afficher les auteurs et la liste de leurs livres
            Console.WriteLine();
            Console.WriteLine("-- Les auteurs et la liste de leurs livres --  ");
            var auteurLivres = ListeLivres.GroupBy(l => l.Auteur);
            foreach (var livres in auteurLivres)
            {
                Auteur auteur = livres.Key;
                Console.WriteLine();
                Console.WriteLine($"{auteur.Nom} {auteur.Prenom} a écrit");
                foreach (var livre in livres)
                {
                    Console.WriteLine($"{livre.Titre}");
                }
            }

            //Afficher les titres de tous les livres triés par ordre alphabétique
            Console.WriteLine();
            Console.WriteLine("-- Titres des livres triés par ordre alphabétique --");
            var livresOrderByTitre = ListeLivres.OrderBy(l => l.Titre).Select(l => l.Titre);
            foreach (var titre in livresOrderByTitre)
            {
                Console.WriteLine(titre);
            }

            //Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne 
            Console.WriteLine();
            var moyenne = ListeLivres.Average(l => l.NbPages);
            Console.WriteLine($" -- Livres dont le nb de pages est sup à la moyenne : {moyenne}");
            var livresSupMoyenne = ListeLivres.Where(l => l.NbPages > moyenne);
            foreach (var livre in livresSupMoyenne)
            {
                Console.WriteLine($"Le livre {livre.Titre} avec {livre.NbPages} pages.");
            }

            //Afficher l'auteur ayant écrit le moins de livres 
            Console.WriteLine();
            Console.WriteLine(" -- L'auteur ayant écrit le moins de livres --");
            var auteurLessLivres = ListeLivres.GroupBy(l => l.Auteur).OrderBy(a => a.Count()).FirstOrDefault().Key;
            Console.WriteLine($"{auteurLessLivres.Nom} {auteurLessLivres.Prenom}");

            Console.ReadKey();
        }
    }
}
