using ChatApp.Grpc;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        private ChatService.ChatServiceClient? _client;
        private string _userId = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Enter your User ID first.");
                return;
            }

            _userId = txtUsername.Text.Trim();

            var channel = Grpc.Net.Client.GrpcChannel.ForAddress("http://localhost:5000");
            _client = new ChatService.ChatServiceClient(channel);

            var reg = await _client.RegisterAsync(new RegisterRequest { UserId = _userId });
            lstMessages.Items.Add(reg.Message);

            _ = Task.Run(async () =>
            {
                using var call = _client.ReceiveMessages(new ReceiveMessagesRequest { UserId = _userId });
                while (await call.ResponseStream.MoveNext())
                {
                    var msg = call.ResponseStream.Current;
                    AppendMessage($"{msg.FromUser} -> {msg.ToUser}: {msg.Message}");
                }
            });
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (_client == null)
            {
                MessageBox.Show("Connect first.");
                return;
            }

            var to = txtTo.Text.Trim();
            var message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(to) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Enter recipient and message.");
                return;
            }

            var reply = await _client.SendMessageAsync(new SendMessageRequest
            {
                FromUser = _userId,
                ToUser = to,
                Message = message
            });

            AppendMessage($"Me -> {to}: {message} ({reply.Status})");
            txtMessage.Clear();
        }

        private void AppendMessage(string text)
        {
            if (lstMessages.InvokeRequired)
                lstMessages.Invoke(new Action(() => lstMessages.Items.Add(text)));
            else
                lstMessages.Items.Add(text);
        }
    }
}
