
using System.Data.SqlClient;
namespace CRUDCORE.Datos
{
    public class Conexion
    {
        private string CadenaMysql = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            CadenaMysql = builder.GetSection("ConnectionStrings:Conexion").Value;

        }
        public string getCadenaSql()
        {
            return CadenaMysql;
        }

    }
}
