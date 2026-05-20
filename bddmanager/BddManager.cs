using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// Classe singleton permettant la connexion à la base MySQL
    /// et l'exécution des requêtes SQL.
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de la classe.
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Connexion à la base de données.
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Constructeur privé permettant d'ouvrir la connexion.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion à la base MySQL.</param>
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// <summary>
        /// Retourne l'unique instance de BddManager.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion à la base MySQL.</param>
        /// <returns>Instance unique de BddManager.</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }

            return instance;
        }

        /// <summary>
        /// Exécute une requête INSERT, UPDATE ou DELETE.
        /// </summary>
        /// <param name="stringQuery">Requête SQL à exécuter.</param>
        /// <param name="parameters">Paramètres de la requête.</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);

            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }

            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécute une requête SELECT et retourne les lignes obtenues.
        /// </summary>
        /// <param name="stringQuery">Requête SELECT à exécuter.</param>
        /// <param name="parameters">Paramètres de la requête.</param>
        /// <returns>Liste des lignes retournées par la requête.</returns>
        public List<Dictionary<string, object>> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);

            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }

            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader.GetValue(i));
                }

                rows.Add(row);
            }

            reader.Close();

            return rows;
        }
    }
}