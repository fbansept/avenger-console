using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvengersConsole.controller;
using MySql.Data.MySqlClient;

namespace AvengersConsole
{
    class Application
    {
        private MySqlConnection connection;
        private string connectionString = "SERVER=127.0.0.1; PORT=3306; DATABASE=avengers; UID=root; PASSWORD=root";

        private DaoUtilisateur _daoUtilisateur;
        private ControllerUtilisateur _controllerUtilisateur;
        private ControllerMenu _controllerMenu;

        static void Main(string[] args)
        {
            new Application();
        }

        public Application()
        {
            InitialisationConnexionBdd();
            InitialisationDao();
            InitialisationController();

            _controllerUtilisateur.AffichagePageLogin();
        }

        void InitialisationConnexionBdd()
        {
            this.connection = new MySqlConnection(connectionString);
        }

        void InitialisationDao()
        {
            this._daoUtilisateur = new DaoUtilisateur(this.connection);
        }

        void InitialisationController()
        {
            _controllerMenu = new ControllerMenu(_daoUtilisateur);
            _controllerUtilisateur = new ControllerUtilisateur(_daoUtilisateur, _controllerMenu);
            this.connection = new MySqlConnection(connectionString);
        }

        
    }
}
