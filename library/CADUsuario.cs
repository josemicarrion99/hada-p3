using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;

namespace library
{
    public class CADUsuario
    {
        private String constring;

        public CADUsuario()
        {
            //Recuperamos la cadena de conexion del archivo de configuracion
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createUsuario(ENUsuario en)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);//creamos la conexion
                con.Open();//abrimos la conexion

                string consulta = "Insert INTO [dbo].[Usuarios] (nombre,nif,edad) VALUES ('" + en.nombreUsuario + "','" + en.nifUsuario + "', '" + en.edadUsuario + "')";

                SqlCommand com = new SqlCommand(consulta, con);
                com.ExecuteNonQuery();
                con.Close();
                return true;

            }catch(SqlException ex) {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }

        }
        public bool readUsuario(ENUsuario en)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);//creamos la conexion
                con.Open();//abrimos la conexion

                string consulta = "Select * FROM [dbo].[Usuarios] WHERE nif = '" + en.nifUsuario + "' ";

                SqlCommand com = new SqlCommand(consulta, con);
                SqlDataReader reading = com.ExecuteReader();
                reading.Read();

                bool encontrado = true;
                if(reading["nif"].ToString() == en.nifUsuario)
                {
                    en.nombreUsuario = reading["nombre"].ToString();
                    en.nifUsuario = reading["nif"].ToString();
                    en.edadUsuario = int.Parse(reading["edad"].ToString());
                }
                else
                {
                    encontrado = false;
                }

                reading.Close();
                con.Close();

                return encontrado;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }

        }

        public bool readFirstUsuario(ENUsuario en)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);//creamos la conexion
                con.Open();//abrimos la conexion

                string consulta = "Select * FROM [dbo].[Usuarios]";

                SqlCommand com = new SqlCommand(consulta, con);
                SqlDataReader reading = com.ExecuteReader();
                reading.Read();


                en.nombreUsuario = reading["nombre"].ToString();
                en.nifUsuario = reading["nif"].ToString();
                en.edadUsuario = int.Parse(reading["edad"].ToString());
                

                reading.Close();
                con.Close();

                return true; ;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }

        }
        public bool readNextUsuario(ENUsuario en)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);//creamos la conexion
                con.Open();//abrimos la conexion

                string consulta = "Select * FROM [dbo].[Usuarios]";

                SqlCommand com = new SqlCommand(consulta, con);
                SqlDataReader reading = com.ExecuteReader();

                bool found = false;
                while (reading.Read())
                {
                    if (found)
                    {
                        en.nombreUsuario = reading["nombre"].ToString();
                        en.nifUsuario = reading["nif"].ToString();
                        en.edadUsuario = int.Parse(reading["edad"].ToString());
                        break;
                    }
                    else if (en.nifUsuario.ToString() == reading["nif"].ToString())
                    {
                        found = true;
                    }
                }


                reading.Close();
                con.Close();

                return true; 
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }
        public bool readPrevUsuario(ENUsuario en)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(constring);//creamos la conexion
                con.Open();//abrimos la conexion

                string consulta = "Select * FROM [dbo].[Usuarios]";

                SqlCommand com = new SqlCommand(consulta, con);
                SqlDataReader reading = com.ExecuteReader();
                reading.Read();
                ENUsuario auxEn = new ENUsuario();
                auxEn.nombreUsuario = reading["nombre"].ToString();
                auxEn.nifUsuario = reading["nif"].ToString();
                auxEn.edadUsuario = int.Parse(reading["edad"].ToString());

                bool found = false;
                while(reading.Read() && !found)
                {
                    if(reading["nif"].ToString() == en.nifUsuario)
                    {
                        found = true;
                        break;
                    }
                    auxEn.nombreUsuario = reading["nombre"].ToString();
                    auxEn.nifUsuario = reading["nif"].ToString();
                    auxEn.edadUsuario = int.Parse(reading["edad"].ToString());
                }


                en.nombreUsuario = auxEn.nombreUsuario;
                en.nifUsuario = auxEn.nifUsuario;
                en.edadUsuario = auxEn.edadUsuario;

                reading.Close();
                con.Close();

                return true; 
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
            
        }
        public bool updateUsuario(ENUsuario en)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);//creamos la conexion
                con.Open();//abrimos la conexion

                string consulta = "UPDATE [dbo].[Usuarios] SET nombre= '" + en.nombreUsuario + "' ,edad=" + en.edadUsuario + "WHERE nif = '" + en.nifUsuario + "'";

                SqlCommand com = new SqlCommand(consulta, con);
                com.ExecuteNonQuery();

                con.Close();

                return true; 
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }

        }
        public bool deleteUsuario(ENUsuario en)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);//creamos la conexion
                con.Open();//abrimos la conexion

                string consulta = "DELETE FROM [dbo].[Usuarios] WHERE nif = '" + en.nifUsuario + "'";

                SqlCommand com = new SqlCommand(consulta, con);

                com.ExecuteNonQuery();
                con.Close();

                return true; 
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                return false;
            }

        }

    }
}
