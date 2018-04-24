using Npgsql;
using SDBaseDatosDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDBaseDatosBOL
{
    public class ConexionBOL
    {
        private ConexionDAL dal;

        public ConexionBOL()
        {
            dal = new ConexionDAL();
        }
        public string Query(string bd, string query)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(query))
            {
                throw new Exception("Query requerido.");
            }
            return dal.EjecutarQuery(bd, query);
        }

        public ArrayList CargarBD()
        {
            return dal.CargarBD();
        }

        public ArrayList CargarUserBD()
        {
            return dal.CargarUserBD();
        }

        public ArrayList CargarTableSpaceBD()
        {
            return dal.CargarTableSpaceBD();
        }

        public ArrayList CargarSchemasBD(string bd)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida");
            }
            return dal.CargarSchemasBD(bd);
        }

        public ArrayList CargarTablesBD(string bd, string schema)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(schema))
            {
                throw new Exception("Esquema requerido.");
            }
            return dal.CargarTablesBD(bd, schema);
        }

        public ArrayList CargarTriggersBD(string bd, string schema)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(schema))
            {
                throw new Exception("Esquema requerido.");
            }
            return dal.CargarTriggersBD(bd, schema);
        }

        public ArrayList CargarFuntionsBD(string bd, string schema)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(schema))
            {
                throw new Exception("Esquema requerido.");
            }
            return dal.CargarFuntionsBD(bd, schema);
        }

        public ArrayList CargarSequencesBD(string bd, string schema)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(schema))
            {
                throw new Exception("Esquema requerido.");
            }
            return dal.CargarSequencesBD(bd, schema);
        }

        public ArrayList CargarViewsBD(string bd, string schema)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(schema))
            {
                throw new Exception("Esquema requerido.");
            }
            return dal.CargarViewsBD(bd, schema);
        }

        public ArrayList CargarColumnsBD(string bd, string schema, string table)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(schema))
            {
                throw new Exception("Esquema requerido.");
            }
            if (String.IsNullOrEmpty(table))
            {
                throw new Exception("Tabla requerida.");
            }
            return dal.CargarColumnsBD(bd, schema, table);
        }

        public ArrayList CargarIndexBD(string bd, string schema, string table)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(schema))
            {
                throw new Exception("Esquema requerido.");
            }
            if (String.IsNullOrEmpty(table))
            {
                throw new Exception("Tabla requerida.");
            }
            return dal.CargarIndexBD(bd, schema, table);
        }

        public bool Conectar(string user, string pass)
        {
            if (String.IsNullOrEmpty(user))
            {
                throw new Exception("User requerido.");
            }
            if (String.IsNullOrEmpty(pass))
            {
                throw new Exception("Password requerida.");
            }
            return dal.ConexionBD();
        }

        public NpgsqlDataAdapter SelectQuery(string bd, string query)
        {
            if (String.IsNullOrEmpty(bd))
            {
                throw new Exception("Base de Datos requerida.");
            }
            if (String.IsNullOrEmpty(query))
            {
                throw new Exception("Query requerido.");
            }
            return dal.SelectQuery(bd, query);
        }
    }
}
