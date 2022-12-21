namespace Practice
{
    partial class Authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.lbl_recode = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_accept = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.recode = new System.Windows.Forms.Button();
            this.code = new System.Windows.Forms.TextBox();
            this.pass = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.TextBox();
            this.lblcode = new System.Windows.Forms.Label();
            this.lblpass = new System.Windows.Forms.Label();
            this.lblmail = new System.Windows.Forms.Label();
            this.lblinfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_recode
            // 
            this.lbl_recode.AutoSize = true;
            this.lbl_recode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_recode.Location = new System.Drawing.Point(166, 225);
            this.lbl_recode.Name = "lbl_recode";
            this.lbl_recode.Size = new System.Drawing.Size(123, 16);
            this.lbl_recode.TabIndex = 25;
            this.lbl_recode.Text = "Код доступа: 0000";
            this.lbl_recode.Visible = false;
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_timer.Location = new System.Drawing.Point(26, 329);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(38, 15);
            this.lbl_timer.TabIndex = 24;
            this.lbl_timer.Text = "00:00";
            this.lbl_timer.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_cancel.Location = new System.Drawing.Point(204, 256);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(85, 31);
            this.btn_cancel.TabIndex = 23;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_accept
            // 
            this.btn_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_accept.Enabled = false;
            this.btn_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_accept.Location = new System.Drawing.Point(307, 256);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(85, 31);
            this.btn_accept.TabIndex = 22;
            this.btn_accept.Text = "Вход";
            this.btn_accept.UseVisualStyleBackColor = true;
            this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(419, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(135, 110);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 21;
            this.logo.TabStop = false;
            // 
            // recode
            // 
            this.recode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("recode.BackgroundImage")));
            this.recode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recode.Enabled = false;
            this.recode.FlatAppearance.BorderSize = 0;
            this.recode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recode.Location = new System.Drawing.Point(376, 194);
            this.recode.Name = "recode";
            this.recode.Size = new System.Drawing.Size(32, 28);
            this.recode.TabIndex = 20;
            this.recode.UseVisualStyleBackColor = true;
            this.recode.Click += new System.EventHandler(this.recode_Click);
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.code.Location = new System.Drawing.Point(238, 196);
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Size = new System.Drawing.Size(132, 26);
            this.code.TabIndex = 19;
            this.code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.code_KeyDown);
            // 
            // pass
            // 
            this.pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass.Location = new System.Drawing.Point(238, 162);
            this.pass.Name = "pass";
            this.pass.ReadOnly = true;
            this.pass.Size = new System.Drawing.Size(170, 26);
            this.pass.TabIndex = 18;
            this.pass.Text = "qwerty";
            this.pass.TextChanged += new System.EventHandler(this.pass_TextChanged);
            this.pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pass_KeyDown);
            // 
            // mail
            // 
            this.mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mail.Location = new System.Drawing.Point(238, 127);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(170, 26);
            this.mail.TabIndex = 17;
            this.mail.Text = "Yrmen46@yandex.ru";
            this.mail.TextChanged += new System.EventHandler(this.mail_TextChanged);
            this.mail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mail_KeyDown);
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblcode.Location = new System.Drawing.Point(165, 196);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(39, 20);
            this.lblcode.TabIndex = 16;
            this.lblcode.Text = "Код";
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblpass.Location = new System.Drawing.Point(165, 162);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(67, 20);
            this.lblpass.TabIndex = 15;
            this.lblpass.Text = "Пароль";
            // 
            // lblmail
            // 
            this.lblmail.AutoSize = true;
            this.lblmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblmail.Location = new System.Drawing.Point(165, 130);
            this.lblmail.Name = "lblmail";
            this.lblmail.Size = new System.Drawing.Size(57, 20);
            this.lblmail.TabIndex = 14;
            this.lblmail.Text = "Почта";
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblinfo.Location = new System.Drawing.Point(45, 59);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(220, 25);
            this.lblinfo.TabIndex = 13;
            this.lblinfo.Text = "Телеком Нева Связь";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(573, 365);
            this.Controls.Add(this.lbl_recode);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_accept);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.recode);
            this.Controls.Add(this.code);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.lblcode);
            this.Controls.Add(this.lblpass);
            this.Controls.Add(this.lblmail);
            this.Controls.Add(this.lblinfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Activated += new System.EventHandler(this.Authorization_Activated);
            this.Load += new System.EventHandler(this.Authorization_Load);
            this.Shown += new System.EventHandler(this.Authorization_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_recode;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_accept;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button recode;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lblmail;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.Timer timer1;
    }
}

