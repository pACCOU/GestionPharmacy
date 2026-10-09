using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestionPharmacy
{
    /// <summary>
    /// Accès unique à la base de données.
    /// - La chaîne de connexion est lue dans App.config (clé "MaPharmacie"),
    ///   plus aucun chemin C:\Users\... codé en dur dans les formulaires.
    /// - Toutes les requêtes sont paramétrées : plus d'injection SQL, et les
    ///   dates / nombres sont transmis avec leur vrai type.
    /// </summary>
    internal static class Db
    {
        private static string ConnectionString
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["MaPharmacie"];
                if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                    throw new InvalidOperationException(
                        "Chaîne de connexion 'MaPharmacie' absente de App.config.");
                return cs.ConnectionString;
            }
        }

        public static SqlConnection Open()
        {
            var con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }

        private static SqlCommand Build(SqlConnection con, string sql, params SqlParameter[] p)
        {
            var cmd = new SqlCommand(sql, con);
            if (p != null) cmd.Parameters.AddRange(p);
            return cmd;
        }

        /// <summary>Exécute INSERT / UPDATE / DELETE, renvoie le nombre de lignes touchées.</summary>
        public static int Execute(string sql, params SqlParameter[] p)
        {
            using (var con = Open())
            using (var cmd = Build(con, sql, p))
                return cmd.ExecuteNonQuery();
        }

        /// <summary>Renvoie la première colonne de la première ligne (COUNT, MAX…).</summary>
        public static object Scalar(string sql, params SqlParameter[] p)
        {
            using (var con = Open())
            using (var cmd = Build(con, sql, p))
                return cmd.ExecuteScalar();
        }

        /// <summary>Renvoie un DataTable prêt pour un DataGridView ou un ComboBox.</summary>
        public static DataTable Table(string sql, params SqlParameter[] p)
        {
            using (var con = Open())
            using (var cmd = Build(con, sql, p))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Raccourci pour créer un paramètre ; DBNull si la valeur est null.</summary>
        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }
    }
}
