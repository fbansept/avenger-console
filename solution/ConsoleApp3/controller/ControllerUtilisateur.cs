using AvengersConsole.model;
using AvengersConsole.vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersConsole.controller
{
    class ControllerUtilisateur
    {
        private DaoUtilisateur _utilisateurDao;
        private ControllerMenu _controllerMenu;
        private VueLogin vueLogin; 

        public Utilisateur utilisateurConnecte = null;

        public ControllerUtilisateur(DaoUtilisateur utilisateurDao, ControllerMenu controllerMenu)
        {
            vueLogin = new VueLogin(this);
            _utilisateurDao = utilisateurDao;
            _controllerMenu = controllerMenu;
        }

        //Affichage de la page de login
        public void AffichagePageLogin()
        {
            vueLogin.AffichageAccueil();
        }

        //On recherche dans la base de donnée si l'email et le mot de passe existe
        //Si oui utilisateurConnecte recoit les information de l'utilisateur
        public void Login(string email, string motDePasse)
        {
            if(_utilisateurDao.GetUtilisateurAvecEmailEtMotDePasse(email, motDePasse, out utilisateurConnecte))
            {
                vueLogin.AffichageConnexionReussi(utilisateurConnecte);
                _controllerMenu.InitialisationMenu();
                _controllerMenu.AffichagPageMenu();
            }
            else
            {
                vueLogin.AffichageConnexionRefuser();
                AffichagePageLogin();
            }
        }
    }
}
