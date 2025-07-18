namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            textboxUrl = new TextBox();
            btRssGet = new Button();
            listboxTitles = new ListBox();
            SuspendLayout();
            // 
            // textboxUrl
            // 
            textboxUrl.Location = new Point(37, 12);
            textboxUrl.Multiline = true;
            textboxUrl.Name = "textboxUrl";
            textboxUrl.Size = new Size(611, 59);
            textboxUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(675, 12);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(86, 59);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // listboxTitles
            // 
            listboxTitles.AllowDrop = true;
            listboxTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listboxTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            listboxTitles.FormattingEnabled = true;
            listboxTitles.ItemHeight = 21;
            listboxTitles.Location = new Point(37, 90);
            listboxTitles.Name = "listboxTitles";
            listboxTitles.Size = new Size(724, 487);
            listboxTitles.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 621);
            Controls.Add(listboxTitles);
            Controls.Add(btRssGet);
            Controls.Add(textboxUrl);
            Name = "Form1";
            Text = "RSSリーダー";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textboxUrl;
        private Button btRssGet;
        private ListBox listboxTitles;
    }
}
