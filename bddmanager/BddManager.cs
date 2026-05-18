using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//importer MySQL dans BddManager//
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// Classe singleton permettant la connexion à la base MySQL
    public class BddManager

    {
        ///constructeur
        private static BddManager instance = null;
        private readonly MySqlConnection connection;
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }
        /// Retourne l'unique instance de BddManager.
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }
        /// Exécute une requête INSERT, UPDATE ou DELETE
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
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader.GetName(i)); reader.GetValue(i);
                    }
                    rows.add(row);
                }
                return Row;
            }
        }
    }
}

