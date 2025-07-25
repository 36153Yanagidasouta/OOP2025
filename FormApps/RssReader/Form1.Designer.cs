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
            textboxUrl = new ComboBox();
            btRssGet = new Button();
            listboxTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btGoBack = new Button();
            btGoForward = new Button();
            btokiniiri = new Button();
            cbUrl = new TextBox();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // textboxUrl
            // 
            textboxUrl.BackColor = SystemColors.ButtonHighlight;
            textboxUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textboxUrl.ForeColor = Color.Black;
            textboxUrl.Location = new Point(261, 12);
            textboxUrl.Name = "textboxUrl";
            textboxUrl.Size = new Size(354, 33);
            textboxUrl.TabIndex = 0;
            textboxUrl.SelectedIndexChanged += textboxUrl_SelectedIndexChanged;
            // 
            // btRssGet
            // 
            btRssGet.BackColor = Color.White;
            btRssGet.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btRssGet.ForeColor = Color.Black;
            btRssGet.Location = new Point(658, 12);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(86, 59);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = false;
            btRssGet.Click += btRssGet_Click;
            // 
            // listboxTitles
            // 
            listboxTitles.AllowDrop = true;
            listboxTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listboxTitles.BackColor = Color.White;
            listboxTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            listboxTitles.ForeColor = Color.Black;
            listboxTitles.FormattingEnabled = true;
            listboxTitles.ItemHeight = 21;
            listboxTitles.Location = new Point(37, 149);
            listboxTitles.Name = "listboxTitles";
            listboxTitles.Size = new Size(692, 235);
            listboxTitles.TabIndex = 2;
            listboxTitles.Click += listboxTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.BackColor = Color.AliceBlue;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.ForeColor = SystemColors.ActiveCaptionText;
            wvRssLink.Location = new Point(48, 418);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(681, 352);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // btGoBack
            // 
            btGoBack.Location = new Point(12, 16);
            btGoBack.Name = "btGoBack";
            btGoBack.Size = new Size(64, 55);
            btGoBack.TabIndex = 4;
            btGoBack.Text = "戻る";
            btGoBack.UseVisualStyleBackColor = true;
            btGoBack.Click += btBack_Click;
            // 
            // btGoForward
            // 
            btGoForward.Location = new Point(82, 14);
            btGoForward.Name = "btGoForward";
            btGoForward.Size = new Size(72, 57);
            btGoForward.TabIndex = 5;
            btGoForward.Text = "進む";
            btGoForward.UseVisualStyleBackColor = true;
            btGoForward.Click += btGo_Click;
            // 
            // btokiniiri
            // 
            btokiniiri.Location = new Point(662, 85);
            btokiniiri.Name = "btokiniiri";
            btokiniiri.Size = new Size(82, 34);
            btokiniiri.TabIndex = 7;
            btokiniiri.Text = "おきに";
            btokiniiri.UseVisualStyleBackColor = true;
            btokiniiri.Click += btokiniiri_Click;
            // 
            // cbUrl
            // 
            cbUrl.Location = new Point(262, 92);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(353, 23);
            cbUrl.TabIndex = 8;
            cbUrl.TextChanged += textboxUrl_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(819, 791);
            Controls.Add(cbUrl);
            Controls.Add(btokiniiri);
            Controls.Add(btGoForward);
            Controls.Add(btGoBack);
            Controls.Add(wvRssLink);
            Controls.Add(listboxTitles);
            Controls.Add(btRssGet);
            Controls.Add(textboxUrl);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "RSSリーダー";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox textboxUrl;
        private Button btRssGet;
        private ListBox listboxTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btGoBack;
        private Button btGoForward;
        private Button btokiniiri;
        private TextBox cbUrl;
    }
}
