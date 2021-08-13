
namespace SmartReader
{
    partial class UserProfile
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.button2Cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCurrState = new System.Windows.Forms.Button();
            this.buttonDeleteProf = new System.Windows.Forms.Button();
            this.buttonUpdateState = new System.Windows.Forms.Button();
            this.buttonViewState = new System.Windows.Forms.Button();
            this.guna2ToggleSwitchOptions = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.labelOptions = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelFontStyle = new System.Windows.Forms.Label();
            this.labelvoiceType = new System.Windows.Forms.Label();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.labelfontColor = new System.Windows.Forms.Label();
            this.labelfont = new System.Windows.Forms.Label();
            this.labelMode = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 103);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 66);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome to profile";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(894, 109);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 16;
            this.buttonBack.Text = "BACK";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // button2Cancel
            // 
            this.button2Cancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2Cancel.Location = new System.Drawing.Point(869, 502);
            this.button2Cancel.Name = "button2Cancel";
            this.button2Cancel.Size = new System.Drawing.Size(100, 32);
            this.button2Cancel.TabIndex = 17;
            this.button2Cancel.Text = "Cancel";
            this.button2Cancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.buttonCurrState);
            this.panel2.Controls.Add(this.buttonDeleteProf);
            this.panel2.Controls.Add(this.buttonUpdateState);
            this.panel2.Controls.Add(this.buttonViewState);
            this.panel2.Location = new System.Drawing.Point(-2, 196);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 338);
            this.panel2.TabIndex = 18;
            // 
            // buttonCurrState
            // 
            this.buttonCurrState.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCurrState.Location = new System.Drawing.Point(34, 104);
            this.buttonCurrState.Name = "buttonCurrState";
            this.buttonCurrState.Size = new System.Drawing.Size(120, 62);
            this.buttonCurrState.TabIndex = 21;
            this.buttonCurrState.Text = "View Current State";
            this.buttonCurrState.UseVisualStyleBackColor = true;
            this.buttonCurrState.Click += new System.EventHandler(this.buttonCurrState_Click);
            // 
            // buttonDeleteProf
            // 
            this.buttonDeleteProf.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonDeleteProf.Location = new System.Drawing.Point(34, 268);
            this.buttonDeleteProf.Name = "buttonDeleteProf";
            this.buttonDeleteProf.Size = new System.Drawing.Size(120, 54);
            this.buttonDeleteProf.TabIndex = 20;
            this.buttonDeleteProf.Text = "Delete Profile";
            this.buttonDeleteProf.UseVisualStyleBackColor = true;
            this.buttonDeleteProf.Click += new System.EventHandler(this.buttonDeleteProf_Click);
            // 
            // buttonUpdateState
            // 
            this.buttonUpdateState.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonUpdateState.Location = new System.Drawing.Point(34, 182);
            this.buttonUpdateState.Name = "buttonUpdateState";
            this.buttonUpdateState.Size = new System.Drawing.Size(120, 71);
            this.buttonUpdateState.TabIndex = 19;
            this.buttonUpdateState.Text = "Update As Current State";
            this.buttonUpdateState.UseVisualStyleBackColor = true;
            this.buttonUpdateState.Click += new System.EventHandler(this.buttonUpdateState_Click);
            // 
            // buttonViewState
            // 
            this.buttonViewState.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonViewState.Location = new System.Drawing.Point(34, 24);
            this.buttonViewState.Name = "buttonViewState";
            this.buttonViewState.Size = new System.Drawing.Size(120, 62);
            this.buttonViewState.TabIndex = 18;
            this.buttonViewState.Text = "View Saved State";
            this.buttonViewState.UseVisualStyleBackColor = true;
            this.buttonViewState.Click += new System.EventHandler(this.buttonViewState_Click);
            // 
            // guna2ToggleSwitchOptions
            // 
            this.guna2ToggleSwitchOptions.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ToggleSwitchOptions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ToggleSwitchOptions.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitchOptions.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitchOptions.CheckedState.Parent = this.guna2ToggleSwitchOptions;
            this.guna2ToggleSwitchOptions.Location = new System.Drawing.Point(12, 108);
            this.guna2ToggleSwitchOptions.Name = "guna2ToggleSwitchOptions";
            this.guna2ToggleSwitchOptions.ShadowDecoration.Parent = this.guna2ToggleSwitchOptions;
            this.guna2ToggleSwitchOptions.Size = new System.Drawing.Size(50, 24);
            this.guna2ToggleSwitchOptions.TabIndex = 19;
            this.guna2ToggleSwitchOptions.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitchOptions.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitchOptions.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitchOptions.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitchOptions.UncheckedState.Parent = this.guna2ToggleSwitchOptions;
            this.guna2ToggleSwitchOptions.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitchOptions_CheckedChanged);
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptions.Location = new System.Drawing.Point(68, 108);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(149, 27);
            this.labelOptions.TabIndex = 20;
            this.labelOptions.Text = "View Options";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelFontStyle);
            this.panel3.Controls.Add(this.labelvoiceType);
            this.panel3.Controls.Add(this.labelFontSize);
            this.panel3.Controls.Add(this.labelfontColor);
            this.panel3.Controls.Add(this.labelfont);
            this.panel3.Controls.Add(this.labelMode);
            this.panel3.Location = new System.Drawing.Point(223, 203);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(623, 331);
            this.panel3.TabIndex = 21;
            this.panel3.Visible = false;
            // 
            // labelFontStyle
            // 
            this.labelFontStyle.AutoSize = true;
            this.labelFontStyle.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFontStyle.Location = new System.Drawing.Point(21, 288);
            this.labelFontStyle.Name = "labelFontStyle";
            this.labelFontStyle.Size = new System.Drawing.Size(115, 27);
            this.labelFontStyle.TabIndex = 26;
            this.labelFontStyle.Text = "Font Style";
            // 
            // labelvoiceType
            // 
            this.labelvoiceType.AutoSize = true;
            this.labelvoiceType.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelvoiceType.Location = new System.Drawing.Point(19, 84);
            this.labelvoiceType.Name = "labelvoiceType";
            this.labelvoiceType.Size = new System.Drawing.Size(125, 27);
            this.labelvoiceType.TabIndex = 25;
            this.labelvoiceType.Text = "Voice Type";
            // 
            // labelFontSize
            // 
            this.labelFontSize.AutoSize = true;
            this.labelFontSize.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFontSize.Location = new System.Drawing.Point(21, 240);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(107, 27);
            this.labelFontSize.TabIndex = 24;
            this.labelFontSize.Text = "Font Size";
            // 
            // labelfontColor
            // 
            this.labelfontColor.AutoSize = true;
            this.labelfontColor.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfontColor.Location = new System.Drawing.Point(21, 185);
            this.labelfontColor.Name = "labelfontColor";
            this.labelfontColor.Size = new System.Drawing.Size(123, 27);
            this.labelfontColor.TabIndex = 23;
            this.labelfontColor.Text = "Font Color";
            // 
            // labelfont
            // 
            this.labelfont.AutoSize = true;
            this.labelfont.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfont.Location = new System.Drawing.Point(21, 132);
            this.labelfont.Name = "labelfont";
            this.labelfont.Size = new System.Drawing.Size(58, 27);
            this.labelfont.TabIndex = 22;
            this.labelfont.Text = "Font";
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMode.Location = new System.Drawing.Point(21, 34);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(71, 27);
            this.labelMode.TabIndex = 21;
            this.labelMode.Text = "Mode";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Kristen ITC", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(384, 140);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(209, 47);
            this.labelUser.TabIndex = 22;
            this.labelUser.Text = "UserName";
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 546);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelOptions);
            this.Controls.Add(this.guna2ToggleSwitchOptions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2Cancel);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.panel1);
            this.Name = "UserProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserProfile";
            this.Load += new System.EventHandler(this.UserProfile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button button2Cancel;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitchOptions;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelvoiceType;
        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.Label labelfontColor;
        private System.Windows.Forms.Label labelfont;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelFontStyle;
        private System.Windows.Forms.Button buttonDeleteProf;
        private System.Windows.Forms.Button buttonUpdateState;
        private System.Windows.Forms.Button buttonViewState;
        private System.Windows.Forms.Button buttonCurrState;
    }
}