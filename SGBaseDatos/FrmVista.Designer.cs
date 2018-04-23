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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVista));
            this.tvSGBD = new System.Windows.Forms.TreeView();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.cmsOpciones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbQuery.SuspendLayout();
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvSGBD
            // 
            this.tvSGBD.ContextMenuStrip = this.cmsOpciones;
            this.tvSGBD.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSGBD.Location = new System.Drawing.Point(0, 34);
            this.tvSGBD.Margin = new System.Windows.Forms.Padding(4);
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
            // cmsOpciones
            // 
            this.cmsOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xdToolStripMenuItem});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(95, 28);
            // 
            // xdToolStripMenuItem
            // 
            this.xdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dxxToolStripMenuItem});
            this.xdToolStripMenuItem.Name = "xdToolStripMenuItem";
            this.xdToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.xdToolStripMenuItem.Text = "xd";
            // 
            // dxxToolStripMenuItem
            // 
            this.dxxToolStripMenuItem.Name = "dxxToolStripMenuItem";
            this.dxxToolStripMenuItem.Size = new System.Drawing.Size(107, 26);
            this.dxxToolStripMenuItem.Text = "dxx";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvSGBD);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(351, 596);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browser";
            // 
            // txtQuery
            // 
            this.txtQuery.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.Location = new System.Drawing.Point(8, 34);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(835, 202);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.Text = "";
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.txtQuery);
            this.gbQuery.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuery.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbQuery.Location = new System.Drawing.Point(360, 61);
            this.gbQuery.Margin = new System.Windows.Forms.Padding(4);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Padding = new System.Windows.Forms.Padding(4);
            this.gbQuery.Size = new System.Drawing.Size(852, 245);
            this.gbQuery.TabIndex = 3;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Table";
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(22, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 43);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.Click_BtnPlay);
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.Controls.Add(this.btnPlay);
            this.pnlOpciones.Location = new System.Drawing.Point(360, 12);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(852, 46);
            this.pnlOpciones.TabIndex = 5;
            // 
            // FrmVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 612);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.gbQuery);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVista";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVista_FormClosing);
            this.Load += new System.EventHandler(this.FrmVista_Load);
            this.cmsOpciones.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbQuery.ResumeLayout(false);
            this.pnlOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvSGBD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem xdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dxxToolStripMenuItem;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel pnlOpciones;
    }
}

