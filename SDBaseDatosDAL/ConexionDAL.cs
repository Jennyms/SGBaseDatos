using Npgsql;
using SDBaseDatosENL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDBaseDatosDAL
{
    public class ConexionDAL
    {

        public bool ConexionBD()
        {
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=postgres";
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                Usuario.Activo = true;
                return true;
            }
        }

        public string EjecutarSelectQuery(string bd, string query)
        {
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                try
                {
                    string sql = query;
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    return "Query successful";
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public string EjecutarQuery(string bd, string query)
        {
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                try
                {
                    string sql = query;
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    return "Query successful";
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public ArrayList CargarBD()
        {
            ArrayList listaBD = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=postgres";
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT datname FROM pg_database";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((reader.GetString(0).Equals("template0") == false) && (reader.GetString(0).Equals("template1") == false))
                    {
                        listaBD.Add(reader.GetString(0));
                    }
                }
                con.Close();
            }
            return listaBD;
        }

        public ArrayList CargarUserBD()
        {
            ArrayList listaUserBD = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=postgres";

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT rolname FROM pg_roles";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaUserBD.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaUserBD;
        }

        public ArrayList CargarTableSpaceBD()
        {
            ArrayList listaTableSpaceBD = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=postgres";

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT spcname FROM pg_tablespace";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaTableSpaceBD.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaTableSpaceBD;
        }

        public ArrayList CargarSchemasBD(string bd)
        {
            ArrayList listaSchemasBD = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT nspname FROM pg_catalog.pg_namespace WHERE nspname like 'pg_%' = false AND nspname != 'information_schema'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaSchemasBD.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaSchemasBD;
        }

        public NpgsqlDataAdapter SelectQuery(string bd, string query)
        {
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = query;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
                dataAdapter.SelectCommand = new NpgsqlCommand(sql, con);
                
                if(dataAdapter != null)
                {
                    return dataAdapter;
                }
                else
                {
                    return null;
                }
            }
        }

        public ArrayList CargarTablesBD(string bd, string schema)
        {
            ArrayList listaTablesBD = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT table_name FROM information_schema.tables WHERE table_schema = '" + schema + "' AND table_type='BASE TABLE'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaTablesBD.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaTablesBD;
        }

        public ArrayList CargarTriggersBD(string bd, string schema)
        {
            ArrayList listaTablesBD = new ArrayList();
            Configuracion.ConStr = "Server = 127.0.0.1; Port = 5432; User Id = " + Usuario.User + "; Password = " + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT trigger_name FROM information_schema.triggers WHERE trigger_schema = '" + schema + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaTablesBD.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaTablesBD;
        }

        public ArrayList CargarFuntionsBD(string bd, string schema)
        {
            ArrayList listaFuntions = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT proname FROM pg_catalog.pg_namespace n JOIN pg_catalog.pg_proc p ON pronamespace = n.oid WHERE nspname = '" + schema + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaFuntions.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaFuntions;
        }

        public ArrayList CargarSequencesBD(string bd, string schema)
        {
            ArrayList listaSequences = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT sequence_name FROM information_schema.sequences WHERE sequence_schema = '" + schema + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaSequences.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaSequences;
        }

        public ArrayList CargarViewsBD(string bd, string schema)
        {
            ArrayList listaViews = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT table_name FROM information_schema.views WHERE table_schema ='" + schema + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaViews.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaViews;
        }

        public ArrayList CargarColumnsBD(string bd, string schema, string table)
        {
            ArrayList listaColumns = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT column_name FROM information_schema.columns WHERE table_schema ='" + schema + "' AND table_name = '" + table + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaColumns.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaColumns;
        }

        public ArrayList CargarIndexBD(string bd, string schema, string table)
        {
            ArrayList listaIndex = new ArrayList();
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd;

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                string sql = "SELECT indexname FROM pg_indexes WHERE schemaname = '" + schema + "' AND tablename = '" + table + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaIndex.Add(reader.GetString(0));
                }
                con.Close();
            }
            return listaIndex;
        }
    }
}
