namespace Opiskelijat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            comboBoxRyhma = new ComboBox();
            textBoxEtunimi = new TextBox();
            Etunimi = new Label();
            Sukunimi = new Label();
            textBoxSukunimi = new TextBox();
            buttonlisaa = new Button();
            buttonPoista = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(369, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(419, 309);
            dataGridView1.TabIndex = 0;
            // 
            // comboBoxRyhma
            // 
            comboBoxRyhma.FormattingEnabled = true;
            comboBoxRyhma.Location = new Point(106, 184);
            comboBoxRyhma.Name = "comboBoxRyhma";
            comboBoxRyhma.Size = new Size(182, 33);
            comboBoxRyhma.TabIndex = 1;
            // 
            // textBoxEtunimi
            // 
            textBoxEtunimi.Location = new Point(125, 53);
            textBoxEtunimi.Name = "textBoxEtunimi";
            textBoxEtunimi.Size = new Size(150, 31);
            textBoxEtunimi.TabIndex = 2;
            // 
            // Etunimi
            // 
            Etunimi.AutoSize = true;
            Etunimi.Location = new Point(28, 56);
            Etunimi.Name = "Etunimi";
            Etunimi.Size = new Size(71, 25);
            Etunimi.TabIndex = 3;
            Etunimi.Text = "Etunimi";
            // 
            // Sukunimi
            // 
            Sukunimi.AutoSize = true;
            Sukunimi.Location = new Point(28, 114);
            Sukunimi.Name = "Sukunimi";
            Sukunimi.Size = new Size(85, 25);
            Sukunimi.TabIndex = 4;
            Sukunimi.Text = "Sukunimi";
            // 
            // textBoxSukunimi
            // 
            textBoxSukunimi.Location = new Point(125, 111);
            textBoxSukunimi.Name = "textBoxSukunimi";
            textBoxSukunimi.Size = new Size(150, 31);
            textBoxSukunimi.TabIndex = 5;
            // 
            // buttonlisaa
            // 
            buttonlisaa.Location = new Point(12, 247);
            buttonlisaa.Name = "buttonlisaa";
            buttonlisaa.Size = new Size(112, 34);
            buttonlisaa.TabIndex = 6;
            buttonlisaa.Text = "Lisää";
            buttonlisaa.UseVisualStyleBackColor = true;
            // 
            // buttonPoista
            // 
            buttonPoista.Location = new Point(163, 247);
            buttonPoista.Name = "buttonPoista";
            buttonPoista.Size = new Size(112, 34);
            buttonPoista.TabIndex = 7;
            buttonPoista.Text = "Poista";
            buttonPoista.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 184);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 8;
            label1.Text = "Ryhmä";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(buttonPoista);
            Controls.Add(buttonlisaa);
            Controls.Add(textBoxSukunimi);
            Controls.Add(Sukunimi);
            Controls.Add(Etunimi);
            Controls.Add(textBoxEtunimi);
            Controls.Add(comboBoxRyhma);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBoxRyhma;
        private TextBox textBoxEtunimi;
        private Label Etunimi;
        private Label Sukunimi;
        private TextBox textBoxSukunimi;
        private Button buttonlisaa;
        private Button buttonPoista;
        private Label label1;
    }
}