using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DAOUsers
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAOUsers()
        {
            this.con.ConnectionString = @"Data Source=DESKTOP-26CCQIV; Initial Catalog=usuarios; Integrated Security=true";
        }

        public List<Usuarios> getTabla()
        {
            List<Usuarios> data = new List<Usuarios>();
            cmd.Connection = this.con;
            cmd.CommandText = "select * from usuarios";
            cmd.Connection.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                data.Add(new Usuarios(int.Parse(lector[0].ToString()),
                                      lector[1].ToString(),
                                      lector[2].ToString(),
                                      lector[3].ToString()));
            }
            cmd.Connection.Close();
            lector.Close();
            return data;
        }

        public bool insertar(Usuarios u)
        {
            string sql = "insert into usuarios values(" + u.userid + ",'" + u.username + "','" + u.pass + "','" + u.nivel + "')";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool editar(int id, String username, String password, int nivel)
        {
            string sql = "update usuarios set username = '"+username+"', pass= '"+password+"', nivel="+nivel+" where userid = "+id+";";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool eliminar(int id)
        {
            string sql = "delete from usuarios where userid = "+id+";";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}