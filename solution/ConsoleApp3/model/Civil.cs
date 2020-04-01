using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersConsole.model
{
    class Civil : Utilisateur
    {
        List<Organisation> _listeOrganisation = new List<Organisation>();

        public Civil(string id, string nom, string prenom, string email) : base(id, nom, prenom, email)
        {
        }

        internal List<Organisation> ListeOrganisation { get => _listeOrganisation; set => _listeOrganisation = value; }
    }
}
