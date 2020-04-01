using AvengersConsole.controller;
using AvengersConsole.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersConsole.vue
{
    class VueMenu
    {
        private readonly ControllerMenu _controllerMenu;

        public VueMenu(ControllerMenu controllerMenu)
        {
            _controllerMenu = controllerMenu;
        }

        public void AffichageMenu(Dictionary<int,string> listeMenu)
        {
            Console.WriteLine("Saisissez le numéro de l'action à effectuer :");

            //pour chaque item de listeMenu on affiche le numero et le nom du menu
            foreach (KeyValuePair<int, string> menu in listeMenu)
            {
                Console.WriteLine(menu.Key + " : " + menu.Value);
            }

            int choix;
              
            //Si la saisie de l'utilisateur est un nombre et que ce nombre fait partie des chois possible
            if(int.TryParse(Console.ReadLine(), out choix) && listeMenu.ContainsKey(choix)) {
                _controllerMenu.ChoixMenu(choix);
            }
            else
            {
                _controllerMenu.ChoixMenuIncorrect();
            }
        }

        public void AffichageMenuIncorrect()
        {
            Console.WriteLine("La saisie du menu est incorrecte...");
        }

        internal void AffichageSelectionMenu(string nomMenu)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--------------- " + nomMenu.ToUpper() + "-------------------");
            Console.WriteLine();
        }
    }
}
