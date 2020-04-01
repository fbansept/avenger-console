using AvengersConsole.model;
using AvengersConsole.vue;
using AvengersConsole.controller;
using System;
using System.Collections.Generic;

namespace AvengersConsole.controller
{
    class ControllerMenu
    {
        private DaoUtilisateur _utilisateurDao;
        private VueMenu vueMenu;

        public Utilisateur utilisateurConnecte = null;

        Dictionary<int, string> listeMenu = new Dictionary<int, string>();

        public ControllerMenu(DaoUtilisateur utilisateurDao)
        {
            vueMenu = new VueMenu(this);
            _utilisateurDao = utilisateurDao;
        }

        //Affichage de la page de login
        public void InitialisationMenu()
        {
            //TODO exo 1 : Voici tous les choix d'actions possibles. 
            //Cette liste doit correpondre aux droits de l'utilisateur connecté
            //Utilisé les droits de utilisateurConnecte

            listeMenu.Add(1, "Afficher les supers heros"); /*TODO : Une foix afficher,
                                                             un nouveau menu propose une action a effectuer 
                                                             sur un des supers heros via son id :
                                                                - Supprimer le super hero
                                                                - Ajouter une evaluation */

            listeMenu.Add(2, "Rechercher un super héro ou un civil");//TODO exo 3 Afficher tous les civils et les supers heros correpondant à la selection

            listeMenu.Add(3, "Ajouter un super hero"); //TODO exo 2-1: Pour ajouter un super héro, il faut lui donner l'id du civil
            listeMenu.Add(4, "Ajouter un civil"); //TODO exo 2-2

            listeMenu.Add(5, "Afficher le classement des supers heros"); //TODO exo 4
        }

        //Affichage de la page de login
        public void AffichagPageMenu()
        {
            vueMenu.AffichageMenu(listeMenu);
        }

        //Affichage de la page de login
        public void ChoixMenu(int selection)
        {
            if(listeMenu.TryGetValue(selection, out string nomMenu))
            {
                vueMenu.AffichageSelectionMenu(nomMenu);

                //TODO : selon la selection effectuée, appelez le controleur et la méthode adéquate.
            }
            else
            {
                vueMenu.AffichageMenuIncorrect();
            }
        }

        //Affichage d'une erreur de saisie, et affiche de nouveau le menu
        public void ChoixMenuIncorrect()
        {
            vueMenu.AffichageMenuIncorrect();
            AffichagPageMenu();
        }
    }
}
