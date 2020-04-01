using AvengersConsole.controller;
using AvengersConsole.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersConsole.vue
{
    class VueLogin
    {
        private readonly ControllerUtilisateur _controllerUtilisateur;

        public VueLogin(ControllerUtilisateur controllerUtilisateur)
        {
            _controllerUtilisateur = controllerUtilisateur;
        }

        public void AffichageAccueil()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" 8888b. 888  888.d88b. 88888b.  .d88b.  .d88b. 888d888.d8888b");
            Console.WriteLine("    \"88b888  888d8P  Y8b888 \"88bd88P\"88bd8P  Y8b888P\"  88K");
            Console.WriteLine(".d888888Y88  88P88888888888  888888  88888888888888    \"Y8888b. ");
            Console.WriteLine("888  888 Y8bd8P Y8b.    888  888Y88b 888Y8b.    888         X88");
            Console.WriteLine("\"Y888888  Y88P   \"Y8888 888  888 \"Y88888 \"Y8888 888     88888P' ");
            Console.WriteLine("                                     888");
            Console.WriteLine("                                Y8b d88P");
            Console.WriteLine("                                 \"Y88P\"");
            Console.ResetColor();

            Console.WriteLine("Entrez votre email");
            string email = Console.ReadLine();

            Console.WriteLine("Entrez votre mot de passe");
            string motDePasse = Console.ReadLine();

            _controllerUtilisateur.Login(email, motDePasse);
        }

        public void AffichageConnexionReussi(Utilisateur utilisateur)
        {
            Console.Clear();
            Console.WriteLine("Bienvenue " + utilisateur.Prenom + " " + utilisateur.Nom);
            Console.WriteLine();
        }

        public void AffichageConnexionRefuser()
        {
            Console.WriteLine("Mauvais identifiant....");
        }
    }
}
