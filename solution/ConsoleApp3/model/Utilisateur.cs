using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersConsole.model
{
    class Utilisateur
    {
        private string _id;
        private string _nom;
        private string _prenom;
        private string _email;

        public Utilisateur(string id, string nom, string prenom, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }

        public string Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
