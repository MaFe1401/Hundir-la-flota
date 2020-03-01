namespace WindowsFormsApplication1
{
    partial class Partida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridJugador = new System.Windows.Forms.DataGridView();
            this.dataGridRival = new System.Windows.Forms.DataGridView();
            this.Jugadorlbl = new System.Windows.Forms.Label();
            this.Rivallbl = new System.Windows.Forms.Label();
            this.enviar = new System.Windows.Forms.Button();
            this.Estadolbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Moneda = new System.Windows.Forms.Button();
            this.clock_time = new System.Windows.Forms.Timer(this.components);
            this.mindec = new System.Windows.Forms.Label();
            this.minunit = new System.Windows.Forms.Label();
            this.labelcolon = new System.Windows.Forms.Label();
            this.segdec = new System.Windows.Forms.Label();
            this.segunits = new System.Windows.Forms.Label();
            this.rendirseBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRival)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridJugador
            // 
            this.dataGridJugador.AllowDrop = true;
            this.dataGridJugador.AllowUserToAddRows = false;
            this.dataGridJugador.AllowUserToDeleteRows = false;
            this.dataGridJugador.AllowUserToResizeColumns = false;
            this.dataGridJugador.AllowUserToResizeRows = false;
            this.dataGridJugador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridJugador.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridJugador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridJugador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridJugador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridJugador.ColumnHeadersVisible = false;
            this.dataGridJugador.Location = new System.Drawing.Point(21, 131);
            this.dataGridJugador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridJugador.Name = "dataGridJugador";
            this.dataGridJugador.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridJugador.RowHeadersVisible = false;
            this.dataGridJugador.RowHeadersWidth = 51;
            this.dataGridJugador.RowTemplate.Height = 24;
            this.dataGridJugador.Size = new System.Drawing.Size(600, 600);
            this.dataGridJugador.TabIndex = 0;
            this.dataGridJugador.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridJugador_MouseUp);
            // 
            // dataGridRival
            // 
            this.dataGridRival.AllowUserToAddRows = false;
            this.dataGridRival.AllowUserToDeleteRows = false;
            this.dataGridRival.AllowUserToResizeColumns = false;
            this.dataGridRival.AllowUserToResizeRows = false;
            this.dataGridRival.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridRival.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridRival.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridRival.ColumnHeadersHeight = 29;
            this.dataGridRival.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridRival.ColumnHeadersVisible = false;
            this.dataGridRival.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridRival.Location = new System.Drawing.Point(869, 131);
            this.dataGridRival.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridRival.Name = "dataGridRival";
            this.dataGridRival.RowHeadersVisible = false;
            this.dataGridRival.RowHeadersWidth = 51;
            this.dataGridRival.RowTemplate.Height = 24;
            this.dataGridRival.Size = new System.Drawing.Size(600, 600);
            this.dataGridRival.TabIndex = 1;
            // 
            // Jugadorlbl
            // 
            this.Jugadorlbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Jugadorlbl.AutoSize = true;
            this.Jugadorlbl.Location = new System.Drawing.Point(276, 92);
            this.Jugadorlbl.Name = "Jugadorlbl";
            this.Jugadorlbl.Size = new System.Drawing.Size(60, 17);
            this.Jugadorlbl.TabIndex = 2;
            this.Jugadorlbl.Text = "Jugador";
            // 
            // Rivallbl
            // 
            this.Rivallbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Rivallbl.AutoSize = true;
            this.Rivallbl.Location = new System.Drawing.Point(1153, 92);
            this.Rivallbl.Name = "Rivallbl";
            this.Rivallbl.Size = new System.Drawing.Size(39, 17);
            this.Rivallbl.TabIndex = 3;
            this.Rivallbl.Text = "Rival";
            // 
            // enviar
            // 
            this.enviar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.enviar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.enviar.Location = new System.Drawing.Point(925, 758);
            this.enviar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(75, 23);
            this.enviar.TabIndex = 4;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // Estadolbl
            // 
            this.Estadolbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Estadolbl.AutoSize = true;
            this.Estadolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estadolbl.Location = new System.Drawing.Point(538, 48);
            this.Estadolbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Estadolbl.Name = "Estadolbl";
            this.Estadolbl.Size = new System.Drawing.Size(122, 31);
            this.Estadolbl.TabIndex = 5;
            this.Estadolbl.Text = "Estado: ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(678, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Location = new System.Drawing.Point(785, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // Moneda
            // 
            this.Moneda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Moneda.Location = new System.Drawing.Point(516, 758);
            this.Moneda.Name = "Moneda";
            this.Moneda.Size = new System.Drawing.Size(75, 23);
            this.Moneda.TabIndex = 11;
            this.Moneda.Text = "Moneda";
            this.Moneda.UseVisualStyleBackColor = true;
            this.Moneda.Click += new System.EventHandler(this.Moneda_Click);
            // 
            // clock_time
            // 
            this.clock_time.Enabled = true;
            this.clock_time.Interval = 1000;
            this.clock_time.Tick += new System.EventHandler(this.clock_time_Tick);
            // 
            // mindec
            // 
            this.mindec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mindec.Location = new System.Drawing.Point(399, 64);
            this.mindec.Name = "mindec";
            this.mindec.Size = new System.Drawing.Size(26, 23);
            this.mindec.TabIndex = 12;
            this.mindec.Text = "0";
            // 
            // minunit
            // 
            this.minunit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.minunit.Location = new System.Drawing.Point(411, 64);
            this.minunit.Name = "minunit";
            this.minunit.Size = new System.Drawing.Size(69, 23);
            this.minunit.TabIndex = 13;
            this.minunit.Text = "0";
            // 
            // labelcolon
            // 
            this.labelcolon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelcolon.AutoSize = true;
            this.labelcolon.Location = new System.Drawing.Point(431, 64);
            this.labelcolon.Name = "labelcolon";
            this.labelcolon.Size = new System.Drawing.Size(12, 17);
            this.labelcolon.TabIndex = 14;
            this.labelcolon.Text = ":";
            // 
            // segdec
            // 
            this.segdec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.segdec.Location = new System.Drawing.Point(447, 64);
            this.segdec.Name = "segdec";
            this.segdec.Size = new System.Drawing.Size(33, 20);
            this.segdec.TabIndex = 15;
            this.segdec.Text = "0";
            // 
            // segunits
            // 
            this.segunits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.segunits.AutoSize = true;
            this.segunits.Location = new System.Drawing.Point(464, 64);
            this.segunits.Name = "segunits";
            this.segunits.Size = new System.Drawing.Size(16, 17);
            this.segunits.TabIndex = 16;
            this.segunits.Text = "0";
            // 
            // rendirseBtn
            // 
            this.rendirseBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rendirseBtn.Location = new System.Drawing.Point(38, 758);
            this.rendirseBtn.Name = "rendirseBtn";
            this.rendirseBtn.Size = new System.Drawing.Size(79, 23);
            this.rendirseBtn.TabIndex = 17;
            this.rendirseBtn.Text = "Rendirse";
            this.rendirseBtn.UseVisualStyleBackColor = true;
            this.rendirseBtn.Click += new System.EventHandler(this.rendirseBtn_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1006, 758);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cuando te hayas decidido, clica el botón enviar.";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 758);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Las casillas azules marcan el área de dominio de los barcos";
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.mar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1491, 803);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rendirseBtn);
            this.Controls.Add(this.segunits);
            this.Controls.Add(this.segdec);
            this.Controls.Add(this.labelcolon);
            this.Controls.Add(this.minunit);
            this.Controls.Add(this.mindec);
            this.Controls.Add(this.Moneda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Estadolbl);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.Rivallbl);
            this.Controls.Add(this.Jugadorlbl);
            this.Controls.Add(this.dataGridRival);
            this.Controls.Add(this.dataGridJugador);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Partida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partida";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Partida_FormClosing);
            this.Load += new System.EventHandler(this.Partida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRival)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridJugador;
        private System.Windows.Forms.DataGridView dataGridRival;
        private System.Windows.Forms.Label Jugadorlbl;
        private System.Windows.Forms.Label Rivallbl;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Label Estadolbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Moneda;
        private System.Windows.Forms.Timer clock_time;
        private System.Windows.Forms.Label mindec;
        private System.Windows.Forms.Label minunit;
        private System.Windows.Forms.Label labelcolon;
        private System.Windows.Forms.Label segdec;
        private System.Windows.Forms.Label segunits;
        private System.Windows.Forms.Button rendirseBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}