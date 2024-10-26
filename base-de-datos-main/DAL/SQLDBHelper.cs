using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SQLDBHelper
    {
        public readonly string connectionString = "Data Source=DESKTOP-70H9HGV;Initial Catalog=youtubeapi;Integrated Security=True";

        public void GuardarBusqueda(string informacion) // Cambia el parámetro a 'informacion'
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Busquedas (Informacion) VALUES (@informacion)"; // Cambia 'Query' a 'Informacion'
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@informacion", SqlDbType.NVarChar).Value = informacion; // Cambia 'query' a 'informacion'
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
