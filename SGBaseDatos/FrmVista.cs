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
                CargarTodo();
            }
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
                ArrayList listaBD = bol.CargarBD();
                ArrayList listaUsersBD = bol.CargarUserBD();
                ArrayList listaTableSpaceBD = bol.CargarTableSpaceBD();
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
            return item;
        }
        private void Click_NodoEscogido(object sender, TreeNodeMouseClickEventArgs e)
        {
            cmsOpciones.Items.Clear();
            if (e.Node.Text == "DataBases")
            {
                CrearOpcion("agregarMenuItem", "Agregar");
                CrearOpcion("eliminarMenuItem", "Eliminar");
                CrearOpcion("modificarMenuItem", "modificar");
            }
        }
    }
}
