namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.jugador1 = new System.Windows.Forms.Label();
            this.QueryButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.texto = new System.Windows.Forms.TextBox();
            this.Invitar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Conectados = new System.Windows.Forms.DataGridView();
            this.usuarioVeces = new System.Windows.Forms.TextBox();
            this.usuarioTiempo = new System.Windows.Forms.TextBox();
            this.usuarioPuntos = new System.Windows.Forms.TextBox();
            this.Jugar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.jugador2 = new System.Windows.Forms.Label();
            this.veces = new System.Windows.Forms.RadioButton();
            this.tiempo = new System.Windows.Forms.RadioButton();
            this.puntotal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteAccount = new System.Windows.Forms.Button();
            this.Chat = new System.Windows.Forms.Label();
            this.SignUP = new System.Windows.Forms.Button();
            this.LogIN = new System.Windows.Forms.Button();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resultado = new System.Windows.Forms.Label();
            this.Disconnect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // jugador1
            // 
            this.jugador1.AutoSize = true;
            this.jugador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugador1.Location = new System.Drawing.Point(17, 59);
            this.jugador1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.jugador1.Name = "jugador1";
            this.jugador1.Size = new System.Drawing.Size(0, 32);
            this.jugador1.TabIndex = 1;
            // 
            // QueryButton
            // 
            this.QueryButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QueryButton.Location = new System.Drawing.Point(347, 105);
            this.QueryButton.Margin = new System.Windows.Forms.Padding(4);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(100, 28);
            this.QueryButton.TabIndex = 5;
            this.QueryButton.Text = "Enviar";
            this.QueryButton.UseVisualStyleBackColor = true;
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Send);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.texto);
            this.groupBox1.Controls.Add(this.Invitar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Conectados);
            this.groupBox1.Controls.Add(this.usuarioVeces);
            this.groupBox1.Controls.Add(this.usuarioTiempo);
            this.groupBox1.Controls.Add(this.usuarioPuntos);
            this.groupBox1.Controls.Add(this.Jugar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.jugador2);
            this.groupBox1.Controls.Add(this.veces);
            this.groupBox1.Controls.Add(this.tiempo);
            this.groupBox1.Controls.Add(this.puntotal);
            this.groupBox1.Controls.Add(this.jugador1);
            this.groupBox1.Controls.Add(this.QueryButton);
            this.groupBox1.Location = new System.Drawing.Point(16, 240);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(932, 263);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(23, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "partida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Send
            // 
            this.Send.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Send.Location = new System.Drawing.Point(379, 229);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 21;
            this.Send.Text = "Enviar";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Enviar Mensaje al jugador seleccionado:";
            // 
            // texto
            // 
            this.texto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.texto.Location = new System.Drawing.Point(272, 229);
            this.texto.Name = "texto";
            this.texto.Size = new System.Drawing.Size(100, 22);
            this.texto.TabIndex = 19;
            // 
            // Invitar
            // 
            this.Invitar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Invitar.Location = new System.Drawing.Point(499, 229);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(75, 23);
            this.Invitar.TabIndex = 18;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 34);
            this.label5.TabIndex = 17;
            this.label5.Text = "Selecciona 1 jugador para enviarle una invitación \r\no un mensaje:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(746, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 17;
            // 
            // Conectados
            // 
            this.Conectados.AllowUserToAddRows = false;
            this.Conectados.AllowUserToDeleteRows = false;
            this.Conectados.AllowUserToResizeColumns = false;
            this.Conectados.AllowUserToResizeRows = false;
            this.Conectados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Conectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Conectados.Location = new System.Drawing.Point(580, 60);
            this.Conectados.Name = "Conectados";
            this.Conectados.ReadOnly = true;
            this.Conectados.RowHeadersWidth = 51;
            this.Conectados.RowTemplate.Height = 24;
            this.Conectados.Size = new System.Drawing.Size(345, 196);
            this.Conectados.TabIndex = 16;
            // 
            // usuarioVeces
            // 
            this.usuarioVeces.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usuarioVeces.Location = new System.Drawing.Point(272, 75);
            this.usuarioVeces.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioVeces.Name = "usuarioVeces";
            this.usuarioVeces.Size = new System.Drawing.Size(175, 22);
            this.usuarioVeces.TabIndex = 16;
            // 
            // usuarioTiempo
            // 
            this.usuarioTiempo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usuarioTiempo.Location = new System.Drawing.Point(272, 48);
            this.usuarioTiempo.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioTiempo.Name = "usuarioTiempo";
            this.usuarioTiempo.Size = new System.Drawing.Size(175, 22);
            this.usuarioTiempo.TabIndex = 15;
            // 
            // usuarioPuntos
            // 
            this.usuarioPuntos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usuarioPuntos.Location = new System.Drawing.Point(272, 22);
            this.usuarioPuntos.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioPuntos.Name = "usuarioPuntos";
            this.usuarioPuntos.Size = new System.Drawing.Size(175, 22);
            this.usuarioPuntos.TabIndex = 14;
            // 
            // Jugar
            // 
            this.Jugar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Jugar.Location = new System.Drawing.Point(0, 0);
            this.Jugar.Name = "Jugar";
            this.Jugar.Size = new System.Drawing.Size(75, 23);
            this.Jugar.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 12;
            // 
            // jugador2
            // 
            this.jugador2.AutoSize = true;
            this.jugador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugador2.Location = new System.Drawing.Point(17, 91);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(0, 32);
            this.jugador2.TabIndex = 11;
            // 
            // veces
            // 
            this.veces.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.veces.AutoSize = true;
            this.veces.Location = new System.Drawing.Point(35, 79);
            this.veces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.veces.Name = "veces";
            this.veces.Size = new System.Drawing.Size(236, 21);
            this.veces.TabIndex = 9;
            this.veces.TabStop = true;
            this.veces.Text = "Dime cuantas veces ha ganado: ";
            this.veces.UseVisualStyleBackColor = true;
            // 
            // tiempo
            // 
            this.tiempo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tiempo.AutoSize = true;
            this.tiempo.Location = new System.Drawing.Point(35, 52);
            this.tiempo.Margin = new System.Windows.Forms.Padding(4);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(228, 21);
            this.tiempo.TabIndex = 7;
            this.tiempo.TabStop = true;
            this.tiempo.Text = "Dime el tiempo total jugado de: ";
            this.tiempo.UseVisualStyleBackColor = true;
            // 
            // puntotal
            // 
            this.puntotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.puntotal.AutoSize = true;
            this.puntotal.Location = new System.Drawing.Point(35, 23);
            this.puntotal.Margin = new System.Windows.Forms.Padding(4);
            this.puntotal.Name = "puntotal";
            this.puntotal.Size = new System.Drawing.Size(239, 21);
            this.puntotal.TabIndex = 8;
            this.puntotal.TabStop = true;
            this.puntotal.Text = "Dime los barcos derribados por : ";
            this.puntotal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.DeleteAccount);
            this.groupBox2.Controls.Add(this.Chat);
            this.groupBox2.Controls.Add(this.SignUP);
            this.groupBox2.Controls.Add(this.LogIN);
            this.groupBox2.Controls.Add(this.contraseña);
            this.groupBox2.Controls.Add(this.usuario);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.resultado);
            this.groupBox2.Location = new System.Drawing.Point(14, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(931, 218);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro";
            // 
            // DeleteAccount
            // 
            this.DeleteAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteAccount.Location = new System.Drawing.Point(805, 165);
            this.DeleteAccount.Name = "DeleteAccount";
            this.DeleteAccount.Size = new System.Drawing.Size(91, 46);
            this.DeleteAccount.TabIndex = 17;
            this.DeleteAccount.Text = "Borrar mi cuenta";
            this.DeleteAccount.UseVisualStyleBackColor = true;
            this.DeleteAccount.Click += new System.EventHandler(this.DeleteAccount_Click);
            // 
            // Chat
            // 
            this.Chat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Chat.AutoSize = true;
            this.Chat.Location = new System.Drawing.Point(744, 109);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(37, 17);
            this.Chat.TabIndex = 16;
            this.Chat.Text = "Chat";
            // 
            // SignUP
            // 
            this.SignUP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SignUP.Location = new System.Drawing.Point(403, 128);
            this.SignUP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SignUP.Name = "SignUP";
            this.SignUP.Size = new System.Drawing.Size(99, 43);
            this.SignUP.TabIndex = 15;
            this.SignUP.Text = "Sign UP";
            this.SignUP.UseVisualStyleBackColor = true;
            this.SignUP.Click += new System.EventHandler(this.SignUP_Click_1);
            // 
            // LogIN
            // 
            this.LogIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogIN.Location = new System.Drawing.Point(403, 66);
            this.LogIN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogIN.Name = "LogIN";
            this.LogIN.Size = new System.Drawing.Size(99, 43);
            this.LogIN.TabIndex = 14;
            this.LogIN.Text = "Log IN";
            this.LogIN.UseVisualStyleBackColor = true;
            this.LogIN.Click += new System.EventHandler(this.LogIN_Click);
            // 
            // contraseña
            // 
            this.contraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.contraseña.Location = new System.Drawing.Point(259, 128);
            this.contraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contraseña.Name = "contraseña";
            this.contraseña.PasswordChar = '·';
            this.contraseña.Size = new System.Drawing.Size(100, 22);
            this.contraseña.TabIndex = 14;
            // 
            // usuario
            // 
            this.usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usuario.Location = new System.Drawing.Point(259, 76);
            this.usuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(100, 22);
            this.usuario.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "CONTRASEÑA";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "USUARIO";
            // 
            // resultado
            // 
            this.resultado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resultado.AutoSize = true;
            this.resultado.Location = new System.Drawing.Point(28, 32);
            this.resultado.Name = "resultado";
            this.resultado.Size = new System.Drawing.Size(208, 17);
            this.resultado.TabIndex = 5;
            this.resultado.Text = "Escribe tu usuario y contraseña";
            // 
            // Disconnect
            // 
            this.Disconnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Disconnect.Location = new System.Drawing.Point(725, 618);
            this.Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(269, 62);
            this.Disconnect.TabIndex = 14;
            this.Disconnect.Text = "Desconectar";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 708);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label jugador1;
        private System.Windows.Forms.Button QueryButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton tiempo;
        private System.Windows.Forms.RadioButton puntotal;
        private System.Windows.Forms.RadioButton veces;
        private System.Windows.Forms.Label jugador2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label resultado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.Button SignUP;
        private System.Windows.Forms.Button LogIN;
        private System.Windows.Forms.Button Jugar;
        private System.Windows.Forms.TextBox usuarioVeces;
        private System.Windows.Forms.TextBox usuarioTiempo;
        private System.Windows.Forms.TextBox usuarioPuntos;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.DataGridView Conectados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox texto;
        private System.Windows.Forms.Label Chat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DeleteAccount;
        private System.Windows.Forms.Timer timer1;
    }
}

