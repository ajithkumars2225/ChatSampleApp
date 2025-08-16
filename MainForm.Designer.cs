namespace ChatClient
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Your ID";
            this.txtUsername.Size = new System.Drawing.Size(150, 23);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(168, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 15;
            this.lstMessages.Location = new System.Drawing.Point(12, 50);
            this.lstMessages.Size = new System.Drawing.Size(400, 200);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(12, 270);
            this.txtTo.PlaceholderText = "To User";
            this.txtTo.Size = new System.Drawing.Size(100, 23);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(120, 270);
            this.txtMessage.PlaceholderText = "Message";
            this.txtMessage.Size = new System.Drawing.Size(210, 23);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(340, 270);
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(430, 320);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Text = "Chat Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
