using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersConsole.model
{
    class Organisation : Utilisateur
    {
        private string _designation;
        private Civil _directeur;

        public Organisation(string id, string nom, string prenom, string email, string designation, Civil directeur) : base(id, nom, prenom, email)
        {
            Designation = designation;
            Directeur = directeur;
        }
        
        public string Designation { get => _designation; set => _designation = value; }
        internal Civil Directeur { get => _directeur; set => _directeur = value; }
    }
}
