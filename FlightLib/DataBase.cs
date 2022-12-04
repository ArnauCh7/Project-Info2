using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;




namespace FlightLib
{
    public class DataBase
    {
        
        private SQLiteConnection cnx;//Conexion SQL a la base de datos

        /// <summary>
        /// Busca y abre la base de datos
        /// </summary>
        public void Open()
        {
            string dataSource = "Data Source = usuarios.db";
            cnx = new SQLiteConnection(dataSource);
            cnx.Open();
        }

        /// <summary>
        /// Cierra la base de datos
        /// </summary>
        public void Close()
        {
            cnx.Close();
        }


        
        /// <summary>
        /// Obtiene la contraseña del usuario introducido
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GetPassword(string user)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT password FROM users WHERE username='" + user + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            string password = dt.Rows[0][0].ToString();
            return password;

        }
        /// <summary>
        /// Busca si el usuario introducido esta en la base de datos
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool FindUser(string user)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT username FROM users WHERE username='" + user + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Añade un usuario a la base de datos
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool AddUser(string username, string password, string email)
        {
            string sql = "INSERT INTO users VALUES ('" + username + "', '" + password + "', '"+email+"', 0)";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int affected = command.ExecuteNonQuery();
            if (affected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// actualiza los puntos obtenidos por la simulacion
        /// </summary>
        /// <param name="user"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool UpdateScore(string user, int score)
        {
            string sql = "UPDATE users SET score = score + " + score + " WHERE username = '" + user + "';";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int affected = command.ExecuteNonQuery();
            if(affected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable Ranking100()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT username, score FROM users ORDER BY score DESC LIMIT 10;";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }

        public int GetScore(string user)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT score FROM users WHERE username='" + user + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            string text = dt.Rows[0][0].ToString();
            int score = Convert.ToInt32(text);
            return score;
        }
        /// <summary>
        /// Obtiene el email del usuario introducido
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetEmail(string username)
        {

            DataTable dt = new DataTable();
            string sql = "SELECT email FROM users WHERE username='" + username + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            string email = dt.Rows[0][0].ToString();
            return email;

        }
        public bool FindCompany(string name)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT name FROM Flight_Companies WHERE Name='" + name + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para añadir una compañia a la base de datos
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="pic"></param>
        /// <returns></returns>
        public bool AddCompany(string Name, int telephone, string email, byte[] pic)
        {
            string sql = "INSERT INTO Flight_Companies VALUES ('" + Name + "', " + telephone + ", '" + email + "', (@0));";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            SQLiteParameter param = new SQLiteParameter("@0", DbType.Binary);
            param.Value = pic;
            command.Parameters.Add(param);
            int affected = command.ExecuteNonQuery();
            if (affected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// metodo para obtener una tabla con los datos de la compañia ordenados por 0: name, 1: tel, 2:email, foto mejor usar LoadImage
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public DataTable GetCompany(string Name)
        {
            if (FindCompany(Name))
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM Flight_Companies WHERE Name='" + Name + "'";
                SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
                adp.Fill(dt);
                return dt;
            }
            else
                return null;
        }

        /// <summary>
        /// Metodo para borrar una compañia de la tabla
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteCompany(string name)
        {
            string sql = "DELETE FROM Flight_Companies WHERE Name = '" + name + "';";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int affected = command.ExecuteNonQuery();
            if (affected == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metodo para obtener una imagen en formato byte[] se ha de convertir
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public byte[] LoadImage(string Name)
        {
            
            string sql = "SELECT Photo FROM Flight_Companies WHERE Name = '" + Name + "';";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            try
            {
                IDataReader rdr = command.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        byte[] a = (System.Byte[])rdr[0];
                        return a;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;

        }
        /// <summary>
        /// Obtiene una datatable de todas las compañias
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCompanies()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Flight_Companies";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;

        }
        /// <summary>
        /// Obtiene una lista con todos los nombres de las compañias
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllCompanyNames()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Name FROM Flight_Companies";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            List<string> listanombres = new List<string>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                string nombre = dt.Rows[i][0].ToString();
                listanombres.Add(nombre);

            }
            return listanombres;
        }

        /// <summary>
        /// Añade un tipo de avion a la base de datos
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="passengers"></param>
        /// <param name="pic"></param>
        /// <returns></returns>
        public bool AddAircraftType(string Name, int passengers, byte[] pic)
        {
            string sql = "INSERT INTO aviones VALUES ('" + Name + "', " + passengers + ", (@0));";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            SQLiteParameter param = new SQLiteParameter("@0", DbType.Binary);
            param.Value = pic;
            command.Parameters.Add(param);
            int affected = command.ExecuteNonQuery();
            if (affected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAircraftType(string name)
        {
            string sql = "DELETE FROM aviones WHERE name = '" + name + "';";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int affected = command.ExecuteNonQuery();
            if (affected == 1)
                return true;
            else
                return false;
        }

        public bool FindAircraftType(string name)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT name FROM aviones WHERE name='" + name + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Carga la imagen del avion en una cadena de bytes
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public byte[] LoadImageFromAircrafts(string Name)
        {

            string sql = "SELECT picture FROM aviones WHERE name = '" + Name + "';";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            try
            {
                IDataReader rdr = command.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        byte[] a = (System.Byte[])rdr[0];
                        return a;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;

        }

        /// <summary>
        /// Obtiene una datatable de todos los tipos de avion
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public DataTable GetACType(string Name)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM aviones WHERE name='" + Name + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Obtiene una lista con todos los nombres de los tipos de avion
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllAircraftTypes()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT name FROM aviones";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            List<string> listanombres = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string nombre = dt.Rows[i][0].ToString();
                listanombres.Add(nombre);

            }
            return listanombres;
        }

    }
}