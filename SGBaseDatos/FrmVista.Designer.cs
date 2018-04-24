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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVista));
            this.tvSGBD = new System.Windows.Forms.TreeView();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.dgvSelect = new System.Windows.Forms.DataGridView();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.cmsOpciones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect)).BeginInit();
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvSGBD
            // 
            this.tvSGBD.ContextMenuStrip = this.cmsOpciones;
            this.tvSGBD.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSGBD.Location = new System.Drawing.Point(0, 28);
            this.tvSGBD.Name = "tvSGBD";
            treeNode1.Name = "NodoNomServer";
            treeNode1.Text = "PostgresSQL 10";
            treeNode2.Name = "NodoServer";
            treeNode2.Text = "Servers";
            this.tvSGBD.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvSGBD.Size = new System.Drawing.Size(256, 456);
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
            this.cmsOpciones.Size = new System.Drawing.Size(87, 26);
            // 
            // xdToolStripMenuItem
            // 
            this.xdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dxxToolStripMenuItem});
            this.xdToolStripMenuItem.Name = "xdToolStripMenuItem";
            this.xdToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.xdToolStripMenuItem.Text = "xd";
            // 
            // dxxToolStripMenuItem
            // 
            this.dxxToolStripMenuItem.Name = "dxxToolStripMenuItem";
            this.dxxToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.dxxToolStripMenuItem.Text = "dxx";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvSGBD);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 484);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browser";
            // 
            // txtQuery
            // 
            this.txtQuery.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.Location = new System.Drawing.Point(6, 28);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(627, 165);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.Text = "";
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.dgvSelect);
            this.gbQuery.Controls.Add(this.txtQuery);
            this.gbQuery.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuery.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbQuery.Location = new System.Drawing.Point(270, 50);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(639, 446);
            this.gbQuery.TabIndex = 3;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Table";
            // 
            // dgvSelect
            // 
            this.dgvSelect.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelect.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelect.Location = new System.Drawing.Point(7, 200);
            this.dgvSelect.Name = "dgvSelect";
            this.dgvSelect.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelect.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSelect.Size = new System.Drawing.Size(626, 235);
            this.dgvSelect.TabIndex = 3;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(16, 2);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(56, 35);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.Click_BtnPlay);
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.Controls.Add(this.btnPlay);
            this.pnlOpciones.Location = new System.Drawing.Point(270, 10);
            this.pnlOpciones.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(639, 37);
            this.pnlOpciones.TabIndex = 5;
            // 
            // FrmVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 497);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.gbQuery);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmVista";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVista_FormClosing);
            this.Load += new System.EventHandler(this.FrmVista_Load);
            this.cmsOpciones.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvSelect;
    }
}

