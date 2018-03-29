using SDBaseDatosBOL;
using SDBaseDatosENL;
using System;
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
    public partial class FrmLogin : Form
    {
        private ConexionBOL bol;

        public FrmLogin()
        {
            InitializeComponent();
            CenterToScreen();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario.User = txtUser.Text.Trim();
                Usuario.Pass = txtPass.Text.Trim();
                if (bol.Conectar(Usuario.User, Usuario.Pass))
                {
                    if(Owner != null)
                    {
                        Owner.Hide();
                    }
                    FrmVista frm = new FrmVista();
                    frm.Show(this);
                    this.Hide();
                }
                else
                {
                    txtUser.Text = "";
                    txtPass.Text = "";
                    Usuario.User = txtUser.Text.Trim();
                    Usuario.Pass = txtPass.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            bol = new ConexionBOL();
        }
    }
}
