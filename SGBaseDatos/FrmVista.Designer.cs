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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PostgresSQL 10");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Servers", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvSGBD = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gbQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvSGBD
            // 
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
            this.tvSGBD.DoubleClick += new System.EventHandler(this.tvServers_DoubleClick);
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(627, 165);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.richTextBox1);
            this.gbQuery.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuery.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbQuery.Location = new System.Drawing.Point(270, 12);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(639, 199);
            this.gbQuery.TabIndex = 3;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Table";
            // 
            // FrmVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 497);
            this.Controls.Add(this.gbQuery);
            this.Controls.Add(this.groupBox1);
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
    }
}

