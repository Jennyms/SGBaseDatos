using SDBaseDatosBOL;
using SDBaseDatosENL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            else if (item.Name == "querItemDBs" || item.Name == "eliminarItemDBs" || item.Name == "refrescarItemDBs")
            {
                OpcionesDB(item.Text);
            }

            else if (item.Name == "agregarSchemas" || item.Name == "eliminarSchemas" || item.Name == "refrescarSchemas")
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
        }

        public void OpcionesSchemasDB(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "CREATE SCHEMA ingreseElNombre";
                    break;
                case "Elimminar":
                    txtQuery.Text = "DROP SCHEMA " + nombreSchemas;
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


        public void OpcionDB(string item)
        {
            switch (item)
            {
                case "Agregar":
                    gbQuery.Visible = true;
                    txtQuery.Text = "CREATE DATABASE ingreseElNombre";
                    break;
                case "Refrescar":
                    gbQuery.Visible = true;
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

        public void OpcionesDB(string item)
        {
            switch (item)
            {
                case "Query":
                    gbQuery.Visible = true;
                    break;
                case "Elimminar":
                    txtQuery.Text = "DROP DATABASE " + nombre;
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
        public void OpcionesRoles(string item)
        {
            switch (item)
            {
                case "Elimminar":
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
                        if(listaBD[i].ToString() != "postgres")
                        {
                            nombre = listaBD[i].ToString();
                            CrearOpcion("querItemDBs", "Query");
                            CrearOpcion("eliminarItemDBs", "Elimminar");
                            CrearOpcion("refrescarItemDBs", "Refrescar");
                        }
                    }
                }
            }
            if (e.Node.Text == "Schemas")
            {
                nombreSchemas = e.Node.Text;
                CrearOpcion("agregarSchemas", "Agregar");
                CrearOpcion("eliminarSchemas", "Elimminar");
                CrearOpcion("refrescarSchemas", "Refrescar");
            }
            if (e.Node.Text == "Login/Group Roles")
            {
                nombreRol = e.Node.Text;
                CrearOpcion("agregarRoles", "Agregar");
            }
            if(listaUsersBD != null)
            {
                for (int i = 0; i < listaUsersBD.Count; i++)
                {
                    if(e.Node.Text == listaUsersBD[i].ToString())
                    {
                        nombreRol = listaUsersBD[i].ToString();
                        CrearOpcion("modificarRol", "Modificar");
                        CrearOpcion("eliminarRol", "Elimminar");
                    }
                    
                }
            }
            
        }

        private void Click_BtnPlay(object sender, EventArgs e)
        {
            MessageBox.Show(txtQuery.SelectedText);
        }
    }
}
