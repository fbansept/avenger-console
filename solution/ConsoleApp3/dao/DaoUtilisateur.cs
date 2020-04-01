using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvengersConsole.model;
using MySql.Data.MySqlClient;

namespace AvengersConsole
{
    class DaoUtilisateur
    {
        private MySqlConnection connection;
        private string connectionString = "SERVER=127.0.0.1; PORT=3306; DATABASE=avengers; UID=root; PASSWORD=root";


        // Constructeur
        public DaoUtilisateur(MySqlConnection connection)
        {
            this.connection = connection;
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            this.connection = new MySqlConnection(connectionString);
        }

        // Méthode pour ajouter un contact
        public bool GetUtilisateurAvecEmailEtMotDePasse(string email, string motDePasse, out Utilisateur utilisateurConnecte)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "Select id, nom , prenom FROM utilisateur WHERE email = '" + email + "' and mot_de_passe = '" + motDePasse + "'";

                // utilisation de l'objet contact passé en paramètre
                //cmd.Parameters.AddWithValue("@email", email);
                // cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                // Exécution de la commande SQL
                MySqlDataReader reponse = cmd.ExecuteReader();

                // Fermeture de la connexion

                if (reponse.HasRows)
                {
                    reponse.Read();
                    utilisateurConnecte = new Utilisateur(reponse.GetString(0), reponse.GetString(1), reponse.GetString(2), email);
                    return true;
                }
                else
                {
                    utilisateurConnecte = null;
                    return false;
                }
            }
            finally
            {
                this.connection.Close();
            }

        }
    }
}
