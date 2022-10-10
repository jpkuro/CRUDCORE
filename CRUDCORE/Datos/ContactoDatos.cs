using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new MySqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("LISTARPRODUCTO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            idContacto = Convert.ToInt32(dr["idContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono  = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),

                        });
                    }
                }
            }
            return oLista;
        }
        public ContactoModel obtener(int idContacto)
        {
            var ocontacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new MySqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("BUSCARPRO", conexion);
                cmd.Parameters.AddWithValue("prod", idContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ocontacto.idContacto = Convert.ToInt32(dr["idContacto"]);
                        ocontacto.Nombre = dr["Nombre"].ToString();
                        ocontacto.Telefono = dr["Telefono"].ToString();
                        ocontacto.Correo = dr["Correo"].ToString();

                    }
                }
            }
            return ocontacto;
        }
        public bool Guardar(ContactoModel ocontacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new MySqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERTARPROD", conexion);
                    cmd.Parameters.AddWithValue("Nomb", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telef", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Corre", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (MySqlException e)
            {
                string error = e.Message;
                respuesta= false;
            }
            return respuesta;
        }
        public bool Editar(ContactoModel ocontacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new MySqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("MODIFICARPROD", conexion);
                    cmd.Parameters.AddWithValue("prod", ocontacto.idContacto);
                    cmd.Parameters.AddWithValue("Nomb", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telef", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Corre", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (MySqlException ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool Eliminar(int idcontacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new MySqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("ELIMINARPROD", conexion);
                    cmd.Parameters.AddWithValue("prod", idcontacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (MySqlException ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}
