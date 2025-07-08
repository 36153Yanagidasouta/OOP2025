namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btokclick = new Button();
            label1 = new Label();
            lbVersion = new Label();
            SuspendLayout();
            // 
            // btokclick
            // 
            btokclick.FlatStyle = FlatStyle.Popup;
            btokclick.Location = new Point(223, 185);
            btokclick.Name = "btokclick";
            btokclick.Size = new Size(87, 62);
            btokclick.TabIndex = 0;
            btokclick.Text = "OK";
            btokclick.UseVisualStyleBackColor = true;
            btokclick.Click += btokclick_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("メイリオ", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(59, 24);
            label1.Name = "label1";
            label1.Size = new Size(240, 28);
            label1.TabIndex = 1;
            label1.Text = "カーレポート管理システム";
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbVersion.Location = new Point(59, 94);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(89, 30);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Ver.0.0.1";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 259);
            Controls.Add(lbVersion);
            Controls.Add(label1);
            Controls.Add(btokclick);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btokclick;
        private Label label1;
        private Label lbVersion;
    }
}