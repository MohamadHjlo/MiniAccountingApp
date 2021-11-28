namespace AccountingApp
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPaassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pcWelcom = new System.Windows.Forms.PictureBox();
            this.pcPass = new System.Windows.Forms.PictureBox();
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator2 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcWelcom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPass)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtPaassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("B Homa", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(372, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ورود به برنامه";
            // 
            // txtPaassword
            // 
            this.txtPaassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.txtPaassword.Location = new System.Drawing.Point(14, 85);
            this.txtPaassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPaassword.Name = "txtPaassword";
            this.txtPaassword.PasswordChar = '*';
            this.txtPaassword.Size = new System.Drawing.Size(268, 29);
            this.txtPaassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Homa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(290, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "کلمه عبور :";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(14, 30);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(268, 29);
            this.txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Homa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(286, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربری  :";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.HotPink;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("B Kamran", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogin.Location = new System.Drawing.Point(278, 161);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 33);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "ورود به برنامه";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            this.btnLogin.MouseLeave += new System.EventHandler(this.BtnLogin_MouseLeave);
            this.btnLogin.MouseHover += new System.EventHandler(this.BtnLogin_MouseHover);
            // 
            // pcWelcom
            // 
            this.pcWelcom.BackColor = System.Drawing.Color.Transparent;
            this.pcWelcom.Image = ((System.Drawing.Image)(resources.GetObject("pcWelcom.Image")));
            this.pcWelcom.Location = new System.Drawing.Point(12, 148);
            this.pcWelcom.Name = "pcWelcom";
            this.pcWelcom.Size = new System.Drawing.Size(269, 45);
            this.pcWelcom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcWelcom.TabIndex = 2;
            this.pcWelcom.TabStop = false;
            // 
            // pcPass
            // 
            this.pcPass.BackColor = System.Drawing.Color.Transparent;
            this.pcPass.Image = ((System.Drawing.Image)(resources.GetObject("pcPass.Image")));
            this.pcPass.Location = new System.Drawing.Point(110, 151);
            this.pcPass.Name = "pcPass";
            this.pcPass.Size = new System.Drawing.Size(118, 54);
            this.pcPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcPass.TabIndex = 3;
            this.pcPass.TabStop = false;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtUsername;
            this.requiredFieldValidator1.ErrorMessage = "نام کاربری را وارد کنید";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator2.ControlToValidate = this.txtPaassword;
            this.requiredFieldValidator2.ErrorMessage = "کلمه عبور را وارد کنید";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(254)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(395, 206);
            this.Controls.Add(this.pcPass);
            this.Controls.Add(this.pcWelcom);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("B Nasim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ورود به برنامه";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcWelcom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPaassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator2;
        private System.Windows.Forms.PictureBox pcWelcom;
        private System.Windows.Forms.PictureBox pcPass;
    }
}