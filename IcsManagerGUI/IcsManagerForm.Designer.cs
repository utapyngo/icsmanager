namespace IcsManagerGUI
{
    partial class IcsManagerForm
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
            this.cbSharedConnection = new System.Windows.Forms.ComboBox();
            this.cbHomeConnection = new System.Windows.Forms.ComboBox();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStopSharing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSharedConnection
            // 
            this.cbSharedConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSharedConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSharedConnection.FormattingEnabled = true;
            this.cbSharedConnection.Location = new System.Drawing.Point(16, 33);
            this.cbSharedConnection.Name = "cbSharedConnection";
            this.cbSharedConnection.Size = new System.Drawing.Size(346, 24);
            this.cbSharedConnection.TabIndex = 0;
            // 
            // cbHomeConnection
            // 
            this.cbHomeConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHomeConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHomeConnection.FormattingEnabled = true;
            this.cbHomeConnection.Location = new System.Drawing.Point(16, 80);
            this.cbHomeConnection.Name = "cbHomeConnection";
            this.cbHomeConnection.Size = new System.Drawing.Size(346, 24);
            this.cbHomeConnection.TabIndex = 1;
            this.cbHomeConnection.SelectedIndexChanged += new System.EventHandler(this.cbHomeConnection_SelectedIndexChanged);
            // 
            // ButtonApply
            // 
            this.ButtonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonApply.Location = new System.Drawing.Point(202, 113);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 29);
            this.ButtonApply.TabIndex = 2;
            this.ButtonApply.Text = "Apply";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonClose.Location = new System.Drawing.Point(283, 113);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 29);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Shared connection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Home connection";
            // 
            // buttonStopSharing
            // 
            this.buttonStopSharing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStopSharing.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonStopSharing.Location = new System.Drawing.Point(16, 113);
            this.buttonStopSharing.Name = "buttonStopSharing";
            this.buttonStopSharing.Size = new System.Drawing.Size(111, 29);
            this.buttonStopSharing.TabIndex = 3;
            this.buttonStopSharing.Text = "Stop sharing";
            this.buttonStopSharing.UseVisualStyleBackColor = true;
            this.buttonStopSharing.Click += new System.EventHandler(this.buttonStopSharing_Click);
            // 
            // FormSharingManager
            // 
            this.AcceptButton = this.ButtonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonClose;
            this.ClientSize = new System.Drawing.Size(370, 154);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStopSharing);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonApply);
            this.Controls.Add(this.cbHomeConnection);
            this.Controls.Add(this.cbSharedConnection);
            this.Name = "FormSharingManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection Sharing Manager";
            this.Load += new System.EventHandler(this.FormSharingManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSharedConnection;
        private System.Windows.Forms.ComboBox cbHomeConnection;
        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStopSharing;
    }
}

