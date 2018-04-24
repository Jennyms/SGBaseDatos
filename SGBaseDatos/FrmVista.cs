using SDBaseDatosBOL;
using SDBaseDatosENL;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace SGBaseDatos
{
    public partial class FrmVista : Form
    {
        private ConexionBOL bol;
        private ArrayList listaBD;
        private ArrayList listaUsersBD;
        private ArrayList listaTableSpaceBD;
        private string nombre;
        private string nombreSchemas;
        private string nombreRol;
        private DataSet ds;

        public FrmVista()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void FrmVista_Load(object sender, EventArgs e)
        {
            bol = new ConexionBOL();
            gbQuery.Visible = false;
            if (Usuario.Activo)
            {
                CargarListas();
                CargarTodo();
            }
        }

        public void CargarListas()
        {
            listaBD = bol.CargarBD();
            listaUsersBD = bol.CargarUserBD();
            listaTableSpaceBD = bol.CargarTableSpaceBD();
        }

        private void tvServers_DoubleClick(object sender, EventArgs e)
        {
            if (!Usuario.Activo)
            {
                if (tvSGBD.SelectedNode.Text.Equals("PostgresSQL 10"))
                {
                    FrmLogin frm = new FrmLogin();
                    frm.Show(this);
                }
            }
        }

        private void CargarTodo()
        {
            try
            {
                tvSGBD.Nodes[0].Nodes[0].Nodes.Add("DataBases");
                tvSGBD.Nodes[0].Nodes[0].Nodes.Add("Login/Group Roles");
                tvSGBD.Nodes[0].Nodes[0].Nodes.Add("Tablespace");
                CargarListas();
                //Base de Datos
                for (int i = 0; i < listaBD.Count; i++)
                {
                    tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes.Add(listaBD[i].ToString());
                }
                //Usuarios
                for (int i = 0; i < listaUsersBD.Count; i++)
                {
                    tvSGBD.Nodes[0].Nodes[0].Nodes[1].Nodes.Add(listaUsersBD[i].ToString());
                }
                //Table Space
                for (int i = 0; i < listaTableSpaceBD.Count; i++)
                {
                    tvSGBD.Nodes[0].Nodes[0].Nodes[2].Nodes.Add(listaTableSpaceBD[i].ToString());
                }
                //Squemas
                for (int i = 0; i < listaBD.Count; i++)
                {
                    tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes.Add("Schemas");
                    ArrayList listaSquemas = bol.CargarSchemasBD(listaBD[i].ToString());
                    for (int j = 0; j < listaSquemas.Count; j++)
                    {
                        tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes.Add(listaSquemas[j].ToString());
                        tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes.Add("Functions");
                        tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes.Add("Sequences");
                        tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes.Add("Tables");
                        tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes.Add("Triggers");
                        tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes.Add("Views");

                        //Funtions
                        ArrayList listaFuntions = bol.CargarFuntionsBD(listaBD[i].ToString(), listaSquemas[j].ToString());
                        for (int y = 0; y < listaFuntions.Count; y++)
                        {
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[0].Nodes.Add(listaFuntions[y].ToString());
                        }
                        //Sequences
                        ArrayList listaSequences = bol.CargarSequencesBD(listaBD[i].ToString(), listaSquemas[j].ToString());
                        for (int y = 0; y < listaSequences.Count; y++)
                        {
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[1].Nodes.Add(listaSequences[y].ToString());
                        }
                        //Tables
                        ArrayList listaTables = bol.CargarTablesBD(listaBD[i].ToString(), listaSquemas[j].ToString());
                        for (int y = 0; y < listaTables.Count; y++)
                        {
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[2].Nodes.Add(listaTables[y].ToString());
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[2].Nodes[y].Nodes.Add("Columns");
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[2].Nodes[y].Nodes.Add("Indexes");
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[2].Nodes[y].Nodes.Add("Constraints");
                            //Columns
                            ArrayList listaColumns = bol.CargarColumnsBD(listaBD[i].ToString(), listaSquemas[j].ToString(), listaTables[y].ToString());
                            for (int x = 0; x < listaColumns.Count; x++)
                            {
                                tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[2].Nodes[y].Nodes[0].Nodes.Add(listaColumns[x].ToString());
                            }
                            //Index
                            ArrayList listaIndex = bol.CargarIndexBD(listaBD[i].ToString(), listaSquemas[j].ToString(), listaTables[y].ToString());
                            for (int x = 0; x < listaIndex.Count; x++)
                            {
                                tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[2].Nodes[y].Nodes[1].Nodes.Add(listaIndex[x].ToString());
                            }
                            //Constraints
                            ArrayList listaConstraints = bol.CargarConstraintsBD(listaBD[i].ToString(), listaTables[y].ToString());
                            for (int z = 0; z < listaIndex.Count; z++)
                            {
                                tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[2].Nodes[y].Nodes[2].Nodes.Add(listaIndex[z].ToString());
                            }

                        }
                        //Triggers
                        ArrayList listaTriggers = bol.CargarTriggersBD(listaBD[i].ToString(), listaSquemas[j].ToString());
                        for (int y = 0; y < listaTriggers.Count; y++)
                        {
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[3].Nodes.Add(listaTriggers[y].ToString());
                        }
                        //Views
                        ArrayList listaViews = bol.CargarViewsBD(listaBD[i].ToString(), listaSquemas[j].ToString());
                        for (int y = 0; y < listaViews.Count; y++)
                        {
                            tvSGBD.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes[4].Nodes.Add(listaViews[y].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Método para crear los items del menú cuando se le da click derecho
        /// </summary>
        /// <param name="nomVariable">string con el nombre de la variable que se le quiere dar al item</param>
        /// <param name="nombre">string con el nombre que se le va a dar a la opción</param>
        /// <returns>ToolStripMenuItem con el item que se creo y se le agregara al contextMenuStrip</returns>
        public ToolStripMenuItem CrearOpcion(string nomVariable, string nombre)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            cmsOpciones.Items.AddRange(new ToolStripItem[] {
                item});
            item.Name = nomVariable;
            item.Size = new Size(138, 24);
            item.Text = nombre;
            item.Click += new System.EventHandler(MouseClickItem);
            return item;
        }

        private void MouseClickItem(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Name == "agregarItemDB" || item.Name == "refrescarItemDB")
            {
                OpcionDB(item.Text);
            }

            else if (item.Name == "queryItemDBs" || item.Name == "eliminarItemDBs" || item.Name == "refrescarItemDBs" || item.Name == "modificarItemDBs")
            {
                OpcionesDB(item.Text);
            }

            else if (item.Name == "agregarSchemas" || item.Name == "eliminarSchemas" || item.Name == "refrescarSchemas" || item.Name == "modificarSchemas")
            {
                OpcionesSchemasDB(item.Text);
            }

            else if (item.Name == "agregarRoles")
            {
                OpcionesRol(item.Text);
            }

            else if (item.Name == "modificarRol" || item.Name == "eliminarRol")
            {
                OpcionesRoles(item.Text);
            }

            else if (item.Name == "agregarFun" || item.Name == "modificarFun" || item.Name == "eliminarFun")
            {
                OpcionesFunciones(item.Text);
            }
            else if (item.Name == "agregarSeq" || item.Name == "modificarSeq" || item.Name == "eliminarSeq")
            {
                OpcionesSequences(item.Text);
            }
            else if (item.Name == "agregarTabla" || item.Name == "modificarTabla" || item.Name == "eliminarTabla")
            {
                OpcionesTabla(item.Text);
            }
            else if (item.Name == "agregarTri" || item.Name == "modificarTri" || item.Name == "eliminarTri")
            {
                OpcionesTriggers(item.Text);
            }
            else if (item.Name == "agregarViews" || item.Name == "modificarViews" || item.Name == "eliminarViews")
            {
                OpcionesViews(item.Text);
            }
            else if (item.Name == "agregarIndex" || item.Name == "modificarIndex" || item.Name == "eliminarIndex")
            {
                OpcionesIndex(item.Text);
            }
            else if (item.Name == "agregarColumns" || item.Name == "modificarColumns" || item.Name == "eliminarColumns")
            {
                OpcionesColumn(item.Text);
            }
            else if (item.Name == "agregarConstraints" || item.Name == "modificarConstraints" || item.Name == "eliminarConstraints")
            {
                OpcionesConstraints(item.Text);
            }
        }

        //LISTO
        public void OpcionesConstraints(string item)
        {
            gbQuery.Visible = true;
            switch (item)
            {

                case "Agregar":
                    txtQuery.Text = "CREATE CONSTRAINTS nomEsquema";
                    break;
                case "Eliminar":
                    txtQuery.Text = "DROP CONSTRAINTS nomEsquema";
                    break;
                case "Modificar":
                    txtQuery.Text = "ALTER CONSTRAINTS nomEsquema RENAME TO nuevoNombre";
                    break;
                case "Refrescar":
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    CargarTodo();
                    break;
                default:
                    break;
            }
        }

        //LISTO
        public void OpcionesSchemasDB(string item)
        {
            gbQuery.Visible = true;
            switch (item)
            {

                case "Agregar":
                    txtQuery.Text = "CREATE SCHEMA nomEsquema";
                    break;
                case "Eliminar":
                    txtQuery.Text = "DROP SCHEMA nomEsquema";
                    break;
                case "Modificar":
                    txtQuery.Text = "ALTER SCHEMA nomEsquema RENAME TO nuevoNombre";
                    break;
                case "Refrescar":
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    CargarTodo();
                    break;
                default:
                    break;
            }
        }

        //LISTO
        public void OpcionDB(string item)
        {
            gbQuery.Visible = true;
            switch (item)
            {

                case "Agregar":
                    txtQuery.Text = "CREATE DATABASE nomDB";
                    break;
                case "Refrescar":
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    gbQuery.Visible = false;
                    CargarTodo();
                    break;
                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesDB(string item)
        {
            switch (item)
            {
                case "Query":
                    gbQuery.Visible = true;
                    break;
                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP DATABASE " + nombre;
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER DATABASE " + nombre + " RENAME TO nuevoNombre";
                    break;
                case "Refrescar":
                    gbQuery.Visible = true;
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    tvSGBD.Nodes[0].Nodes[0].Nodes.RemoveAt(0);
                    CargarTodo();
                    break;
                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesRol(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "CREATE ROLE rolName  WITH SUPERUSER" + Environment.NewLine;
                    txtQuery.Text += "CREATE USER userName WITH PASSWORD ' '";
                    break;
                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesRoles(string item)
        {
            switch (item)
            {
                case "Elimminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP USER " + nombreRol + Environment.NewLine;
                    txtQuery.Text += "DROP ROLE " + nombreRol;
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER ROLE " + nombreRol + " WITH LOGIN" + Environment.NewLine;
                    txtQuery.Text += "ALTER USER " + nombreRol + " WITH PASSWORD ' '";
                    break;
                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesFunciones(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = @"CREATE FUNCTION sumar(integer,integer) RETURNS integer AS $func$ BEGIN
RETURN $1 +$2; 
END $func$ LANGUAGE plpgsql";
                    break;
                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP FUNCTION nameFunction";
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER FUNCTION nomFuncion RENAME TO nuevoNombre";
                    break;
                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesSequences(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "CREATE SEQUENCE nomSecuencia START 101";
                    break;
                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP SEQUENCE nomSecuencia";
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER SEQUENCE nomSecuencia RESTART WITH 105";
                    break;
                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesTabla(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = @"CREATE TABLE nomTable (
)";
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "UPDATE nomTable SET ";
                    break;

                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP TABLE nomTable";
                    break;

                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesTriggers(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = @"CREATE TRIGGER nomTrigger
AFTER INSERT OR UPDATE OR DELETE
ON nomTabla
FOR EACH ROW 
EXECUTE PROCEDURE nomProcedure;";
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER TRIGGER nomTrigger ON nomTable RENAME TO nuev";
                    break;

                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP TRIGGER name ON nomTable";
                    break;

                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesViews(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "CREATE VIEW nomView AS SELECT nomColumnas FROM nomTabla";
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER VIEW nombreOld RENAME TO nombreNew";
                    break;

                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP VIEW nomView";
                    break;

                default:
                    break;
            }
        }
        //LISTO
        public void OpcionesIndex(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = @"CREATE INDEX nomIndex
    ON nomTabla(columnaDeTabla ASC NULLS LAST)";
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER INDEX nombreIndex RENAME TO nuevoNom";
                    break;
                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "DROP INDEX nomIndex ON nomTabla";
                    break;
                default:
                    break;
            }
        }

        //LISTO
        public void OpcionesColumn(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER TABLE nomTabla ADD nomColumn text";
                    break;
                case "Modificar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER TABLE nomTabla ALTER COLUMN nomColumn TYPE varchar(20)";
                    break;
                case "Eliminar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "ALTER TABLE nomTabla DROP COLUMN nomColumn";
                    break;
                default:
                    break;
            }
        }

        private void Click_NodoEscogido(object sender, TreeNodeMouseClickEventArgs e)
        {
            cmsOpciones.Items.Clear();
            Console.WriteLine(e.Node.Name);

            if (e.Node.Text == "DataBases")
            {
                CrearOpcion("agregarItemDB", "Agregar");
                CrearOpcion("refrescarItemDB", "Refrescar");
            }
            if (listaBD != null)
            {
                for (int i = 0; i < listaBD.Count; i++)
                {
                    if (e.Node.Text == listaBD[i].ToString())
                    {
                        if (listaBD[i].ToString() != "postgres")
                        {
                            nombre = listaBD[i].ToString();
                            CrearOpcion("queryItemDBs", "Query");
                            CrearOpcion("eliminarItemDBs", "Eliminar");
                            CrearOpcion("modificarItemDBs", "Modificar");
                            CrearOpcion("refrescarItemDBs", "Refrescar");
                        }
                    }
                }
            }
            if (e.Node.Text == "Schemas")
            {
                nombreSchemas = e.Node.Text;
                CrearOpcion("agregarSchemas", "Agregar");
                CrearOpcion("eliminarSchemas", "Eliminar");
                CrearOpcion("modificarSchemas", "Modificar");
                CrearOpcion("refrescarSchemas", "Refrescar");
            }
            if (e.Node.Text == "Login/Group Roles")
            {
                nombreRol = e.Node.Text;
                CrearOpcion("agregarRoles", "Agregar");
            }
            if (listaUsersBD != null)
            {
                for (int i = 0; i < listaUsersBD.Count; i++)
                {
                    if (e.Node.Text == listaUsersBD[i].ToString())
                    {
                        nombreRol = listaUsersBD[i].ToString();
                        CrearOpcion("modificarRol", "Modificar");
                        CrearOpcion("eliminarRol", "Eliminar");
                    }

                }
            }
            if (e.Node.Text == "Functions")
            {
                CrearOpcion("agregarFun", "Agregar");
                CrearOpcion("modificarFun", "Modificar");
                CrearOpcion("eliminarFun", "Eliminar");

            }
            if (e.Node.Text == "Sequences")
            {
                CrearOpcion("agregarSeq", "Agregar");
                CrearOpcion("modificarSeq", "Modificar");
                CrearOpcion("eliminarSeq", "Eliminar");

            }
            if (e.Node.Text == "Tables")
            {
                CrearOpcion("agregarTabla", "Agregar");
                CrearOpcion("modificarTabla", "Modificar");
                CrearOpcion("eliminarTabla", "Eliminar");
            }
            if (e.Node.Text == "Triggers")
            {
                CrearOpcion("agregarTri", "Agregar");
                CrearOpcion("modificarTri", "Modificar");
                CrearOpcion("eliminarTri", "Eliminar");
            }
            if (e.Node.Text == "Views")
            {
                CrearOpcion("agregarViews", "Agregar");
                CrearOpcion("modificarViews", "Modificar");
                CrearOpcion("eliminarViews", "Eliminar");
            }
            if (e.Node.Text == "Indexes")
            {
                CrearOpcion("agregarIndex", "Agregar");
                CrearOpcion("modificarIndex", "Modificar");
                CrearOpcion("eliminarIndex", "Eliminar");
            }
            if (e.Node.Text == "Columns")
            {
                CrearOpcion("agregarColumns", "Agregar");
                CrearOpcion("modificarColumns", "Modificar");
                CrearOpcion("eliminarColumns", "Eliminar");
            }
            if (e.Node.Text == "Constraints")
            {
                CrearOpcion("agregarConstraints", "Agregar");
                CrearOpcion("modificarConstraints", "Modificar");
                CrearOpcion("eliminarConstraints", "Eliminar");
            }
        }

        private void Click_BtnPlay(object sender, EventArgs e)
        {
            try
            {
                if (dgvSelect.DataSource != null)
                {
                    DataTable dt = (DataTable)dgvSelect.DataSource;
                    dt.Clear();
                    dgvSelect.Columns.Clear();
                }
                Char[] selectChar;
                string query = txtQuery.Text.Trim();
                selectChar = query.ToCharArray();
                string s = selectChar[0].ToString() + selectChar[1].ToString() + selectChar[2].ToString() + selectChar[3].ToString() + selectChar[4].ToString() + selectChar[5].ToString();
                if (s.ToLower().Equals("select"))
                {
                    CargarTablaDB();
                }
                else
                {
                    MessageBox.Show(bol.Query(nombre, txtQuery.SelectedText));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargarTablaDB()
        {
            SelectQuery(nombre, txtQuery.SelectedText);
        }

        private void SelectQuery(string bd, string query)
        {
            Configuracion.ConStr = "Server=127.0.0.1;Port=5432;User Id=" + Usuario.User + ";Password=" + Usuario.Pass + ";Database=" + bd + ";Pooling=false";

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.ConStr))
            {
                con.Open();
                NpgsqlDataAdapter dataAdapter;
                dataAdapter = new NpgsqlDataAdapter(query, con);
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dgvSelect.DataSource = table;
            }
        }
    }
}
