namespace SGBaseDatos
{
    partial class FrmVista
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PostgresSQL 10");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Servers", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvSGBD = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.gbQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvSGBD
            // 
            this.tvSGBD.ContextMenuStrip = this.cmsOpciones;
            this.tvSGBD.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSGBD.Location = new System.Drawing.Point(0, 34);
            this.tvSGBD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvSGBD.Name = "tvSGBD";
            treeNode1.Name = "NodoNomServer";
            treeNode1.Text = "PostgresSQL 10";
            treeNode2.Name = "NodoServer";
            treeNode2.Text = "Servers";
            this.tvSGBD.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvSGBD.Size = new System.Drawing.Size(340, 560);
            this.tvSGBD.TabIndex = 0;
            this.tvSGBD.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Click_NodoEscogido);
            this.tvSGBD.DoubleClick += new System.EventHandler(this.tvServers_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvSGBD);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(351, 596);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browser";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 34);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(835, 202);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.richTextBox1);
            this.gbQuery.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuery.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbQuery.Location = new System.Drawing.Point(360, 15);
            this.gbQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbQuery.Size = new System.Drawing.Size(852, 245);
            this.gbQuery.TabIndex = 3;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Table";
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 612);
            this.Controls.Add(this.gbQuery);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmVista";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVista_FormClosing);
            this.Load += new System.EventHandler(this.FrmVista_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbQuery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvSGBD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
    }
}

