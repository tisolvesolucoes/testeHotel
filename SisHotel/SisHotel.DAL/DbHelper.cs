using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace SisHotel.DAL
{
    public static class DbHelper
    {

        private static string conexao
        {
            get
            {
                return @"Data Source=DESKTOP-QSCL495;
                    Initial Catalog=SisHotelDb;
                    Integrated Security=true";
            }
        }

        public static IDataReader ExecuteReader(string storeProcedure, params object[] parametros)
        {
            var cn = new SqlConnection(conexao);
            var cmd = new SqlCommand(storeProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            PreencherParametros(parametros, cmd);
            cn.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }

        public static int ExecuteNonQuery(string storeProcedure, params object[] parametros)
        {

            int retorno = 0;
            using (var cn = new SqlConnection(conexao))
            {

                using (var cmd = new SqlCommand(storeProcedure, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    PreencherParametros(parametros, cmd);
                    cn.Open();
                    retorno = cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
            return retorno;
        }


        private static void PreencherParametros(object[] parametros, SqlCommand cmd)
        {
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }
        }

    }
}
