namespace PharmaSign
{
    partial class UC2CONF
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC2CONF));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ValeurIPBDD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ValeurIPRPI = new System.Windows.Forms.TextBox();
            this.ModifierValeurIpRPI = new System.Windows.Forms.Button();
            this.ModifierValeurIpBDD = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configuration des serveurs";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(306, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(17, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(271, 113);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serveur base de données";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Serveur passerelle (raspberry PI)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Adresse IP :";
            // 
            // ValeurIPBDD
            // 
            this.ValeurIPBDD.Location = new System.Drawing.Point(104, 193);
            this.ValeurIPBDD.Name = "ValeurIPBDD";
            this.ValeurIPBDD.Size = new System.Drawing.Size(122, 20);
            this.ValeurIPBDD.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(319, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Adresse IP :";
            // 
            // ValeurIPRPI
            // 
            this.ValeurIPRPI.Location = new System.Drawing.Point(392, 193);
            this.ValeurIPRPI.Name = "ValeurIPRPI";
            this.ValeurIPRPI.Size = new System.Drawing.Size(122, 20);
            this.ValeurIPRPI.TabIndex = 5;
            // 
            // ModifierValeurIpRPI
            // 
            this.ModifierValeurIpRPI.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.ModifierValeurIpRPI.Location = new System.Drawing.Point(516, 192);
            this.ModifierValeurIpRPI.Name = "ModifierValeurIpRPI";
            this.ModifierValeurIpRPI.Size = new System.Drawing.Size(60, 21);
            this.ModifierValeurIpRPI.TabIndex = 6;
            this.ModifierValeurIpRPI.Text = "Modifier";
            this.ModifierValeurIpRPI.UseVisualStyleBackColor = true;
            this.ModifierValeurIpRPI.Click += new System.EventHandler(this.ModifierValeurIpRPI_Click);
            // 
            // ModifierValeurIpBDD
            // 
            this.ModifierValeurIpBDD.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.ModifierValeurIpBDD.Location = new System.Drawing.Point(228, 192);
            this.ModifierValeurIpBDD.Name = "ModifierValeurIpBDD";
            this.ModifierValeurIpBDD.Size = new System.Drawing.Size(60, 21);
            this.ModifierValeurIpBDD.TabIndex = 6;
            this.ModifierValeurIpBDD.Text = "Modifier";
            this.ModifierValeurIpBDD.UseVisualStyleBackColor = true;
            this.ModifierValeurIpBDD.Click += new System.EventHandler(this.ModifierValeurIpBDD_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(31, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Répertoire de configuration des fichiers";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.button3.Location = new System.Drawing.Point(498, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 21);
            this.button3.TabIndex = 6;
            this.button3.Text = "Parcourir ...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(28, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "C:\\Program Files (x86)\\Interface\\PharmaSign\\";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(292, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Note : Chemin du répertoire d\'installation par défaut.";
            // 
            // UC2CONF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ModifierValeurIpBDD);
            this.Controls.Add(this.ModifierValeurIpRPI);
            this.Controls.Add(this.ValeurIPRPI);
            this.Controls.Add(this.ValeurIPBDD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "UC2CONF";
            this.Size = new System.Drawing.Size(594, 332);
            this.Load += new System.EventHandler(this.UC2CONF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ValeurIPBDD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ValeurIPRPI;
        private System.Windows.Forms.Button ModifierValeurIpRPI;
        private System.Windows.Forms.Button ModifierValeurIpBDD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
