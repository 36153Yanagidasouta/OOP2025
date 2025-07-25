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
            cbUrl = new ComboBox();
            btRssGet = new Button();
            listboxTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btGoBack = new Button();
            btGoForward = new Button();
            btfavorite = new Button();
            textboxUrl = new TextBox();
            delbt = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // cbUrl
            // 
            cbUrl.BackColor = SystemColors.GradientInactiveCaption;
            cbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.ForeColor = Color.Black;
            cbUrl.Location = new Point(262, 24);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(396, 33);
            cbUrl.TabIndex = 0;
            cbUrl.SelectedIndexChanged += textboxUrl_SelectedIndexChanged;
            // 
            // btRssGet
            // 
            btRssGet.BackColor = SystemColors.GradientInactiveCaption;
            btRssGet.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btRssGet.ForeColor = Color.Black;
            btRssGet.Location = new Point(662, 12);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(97, 59);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = false;
            btRssGet.Click += btRssGet_Click;
            // 
            // listboxTitles
            // 
            listboxTitles.AllowDrop = true;
            listboxTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listboxTitles.BackColor = Color.Silver;
            listboxTitles.DrawMode = DrawMode.OwnerDrawFixed;
            listboxTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            listboxTitles.ForeColor = Color.Black;
            listboxTitles.FormattingEnabled = true;
            listboxTitles.ItemHeight = 21;
            listboxTitles.Location = new Point(37, 166);
            listboxTitles.Name = "listboxTitles";
            listboxTitles.Size = new Size(919, 256);
            listboxTitles.TabIndex = 2;
            listboxTitles.Click += listboxTitles_Click;
            listboxTitles.DrawItem += listboxTitles_DrawItem;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.BackColor = Color.AliceBlue;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.ForeColor = SystemColors.ActiveCaptionText;
            wvRssLink.Location = new Point(37, 444);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(919, 401);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // btGoBack
            // 
            btGoBack.BackColor = SystemColors.GradientInactiveCaption;
            btGoBack.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btGoBack.Location = new Point(12, 14);
            btGoBack.Name = "btGoBack";
            btGoBack.Size = new Size(64, 55);
            btGoBack.TabIndex = 4;
            btGoBack.Text = "戻る";
            btGoBack.UseVisualStyleBackColor = false;
            btGoBack.Click += btBack_Click;
            // 
            // btGoForward
            // 
            btGoForward.BackColor = SystemColors.GradientInactiveCaption;
            btGoForward.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btGoForward.Location = new Point(82, 12);
            btGoForward.Name = "btGoForward";
            btGoForward.Size = new Size(68, 57);
            btGoForward.TabIndex = 5;
            btGoForward.Text = "進む";
            btGoForward.UseVisualStyleBackColor = false;
            btGoForward.Click += btGo_Click;
            // 
            // btfavorite
            // 
            btfavorite.BackColor = SystemColors.GradientInactiveCaption;
            btfavorite.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btfavorite.Location = new Point(662, 83);
            btfavorite.Name = "btfavorite";
            btfavorite.Size = new Size(97, 34);
            btfavorite.TabIndex = 7;
            btfavorite.Text = "おきに入り登録";
            btfavorite.UseVisualStyleBackColor = false;
            btfavorite.Click += btfavorite_Click;
            // 
            // textboxUrl
            // 
            textboxUrl.BackColor = SystemColors.GradientInactiveCaption;
            textboxUrl.Location = new Point(286, 101);
            textboxUrl.Name = "textboxUrl";
            textboxUrl.Size = new Size(353, 23);
            textboxUrl.TabIndex = 8;
            textboxUrl.TextChanged += textboxUrl_SelectedIndexChanged;
            // 
            // delbt
            // 
            delbt.BackColor = SystemColors.GradientInactiveCaption;
            delbt.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            delbt.Location = new Point(662, 123);
            delbt.Name = "delbt";
            delbt.Size = new Size(97, 29);
            delbt.TabIndex = 9;
            delbt.Text = "削除";
            delbt.UseVisualStyleBackColor = false;
            delbt.Click += delbt_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlDark;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            textBox1.Location = new Point(180, 101);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 20);
            textBox1.TabIndex = 10;
            textBox1.Text = "タイトル記入";
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlDark;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            textBox2.Location = new Point(156, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 20);
            textBox2.TabIndex = 10;
            textBox2.Text = "URL記入";
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1046, 840);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(delbt);
            Controls.Add(textboxUrl);
            Controls.Add(btfavorite);
            Controls.Add(btGoForward);
            Controls.Add(btGoBack);
            Controls.Add(wvRssLink);
            Controls.Add(listboxTitles);
            Controls.Add(btRssGet);
            Controls.Add(cbUrl);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "RSSリーダー";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbUrl;
        private Button btRssGet;
        private ListBox listboxTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btGoBack;
        private Button btGoForward;
        private Button btfavorite;
        private TextBox textboxUrl;
        private Button delbt;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
