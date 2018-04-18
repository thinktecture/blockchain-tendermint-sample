using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NumberTransfer.Transactions;

namespace DebugRequestCreator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var command = configuration.GetValue<string>("command");
            var copyToClipboard = configuration.GetValue<bool>("ctc");
            var party = configuration.GetValue<string>("party");

            if (string.IsNullOrWhiteSpace(party) && command != "bs2s")
            {
                throw new Exception("Party is not set");
            }

            if (command == "create-number")
            {
                var owner = configuration.GetValue<string>("owner");
                var phoneNumber = configuration.GetValue<string>("phone");
                await Output(CreateNumberRequest(owner, phoneNumber), copyToClipboard, party);

                return;
            }

            if (command == "request-transfer")
            {
                var phoneNumber = configuration.GetValue<string>("phone");
                var currentOwner = configuration.GetValue<string>("owner");
                var newOwner = configuration.GetValue<string>("new-owner");
                await Output(RequestTransferRequest(phoneNumber, currentOwner, newOwner), copyToClipboard, party);

                return;
            }

            if (command == "deny-transfer")
            {
                var phoneNumber = configuration.GetValue<string>("phone");
                var newOwner = configuration.GetValue<string>("new-owner");
                await Output(DenyTransferRequest(phoneNumber, newOwner), copyToClipboard, party);

                return;
            }

            if (command == "confirm-transfer")
            {
                var phoneNumber = configuration.GetValue<string>("phone");
                var newOwner = configuration.GetValue<string>("new-owner");
                await Output(ConfirmTransferRequest(phoneNumber, newOwner), copyToClipboard, party);

                return;
            }

            if (command == "bs2s")
            {
                var byteString = configuration.GetValue<string>("bs");
                var byteArray = HexStringToByteArray(byteString);
                var utf8String = Encoding.UTF8.GetString(byteArray);
                Console.WriteLine(utf8String);
                return;
            }

            Console.WriteLine("No command given.");
        }

        private static async Task Output(BaseTransaction tx, bool copyToClipboard, string party)
        {
            tx.TransactionTime = DateTime.Now;
            var jsonString = JsonConvert.SerializeObject(tx, new TransactionSerializerSettings());
            var byteArray = Encoding.UTF8.GetBytes(jsonString);
            var transactionToken = new TransactionToken(byteArray);

            var currentDirectory = Directory.GetCurrentDirectory();
            if (!currentDirectory.Contains("netcoreapp"))
            {
                throw new Exception("Please execute the request creator within netcoreapp2.0 folder.");
            }

            var basePath = Path.Combine(currentDirectory, "..", "..", "..", "..", "..", "certificates");
            var certificate = new X509Certificate2(Path.Combine(basePath, $"{party}.p12"), "thinktecture");

            transactionToken.Sign(certificate);

            var tokenString = transactionToken.ToTokenString();
            Console.WriteLine("Sending the following tokenstring...");
            Console.WriteLine(tokenString);

            if (copyToClipboard)
            {
                CopyToClipboard(tokenString);
            }

            Console.WriteLine(await MakeRequest(tokenString));
        }

        private static Task<string> MakeRequest(string tokenString)
        {
            const string baseUrl = "http://localhost:46657/broadcast_tx_commit?tx=";
            var url = $"{baseUrl}\"{tokenString}\"";

            var httpClient = new HttpClient();
            return httpClient.GetStringAsync(url);
        }

        private static byte[] HexStringToByteArray(string input)
        {
            var res = new byte[input.Length / 2];

            for (var i = 0; i < input.Length / 2; i++)
            {
                var h = input.Substring(i * 2, 2);
                res[i] = Convert.ToByte(h, 16);
            }

            return res;
        }

        #region Shell stuff

        private static string Run(string filename, string arguments)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }

        private static string Bash(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");
            string result = Run("/bin/bash", $"-c \"{escapedArgs}\"");
            return result;
        }

        // https://stackoverflow.com/questions/44205260/net-core-copy-to-clipboard
        private static void CopyToClipboard(string content)
        {
            Bash($"echo \"{content}\" | pbcopy");
        }

        #endregion

        #region payload creation

        private static BaseTransaction DenyTransferRequest(string phoneNumber, string newOwner) => new DenyTransferRequest()
        {
            NewOwner = newOwner,
            PhoneNumber = phoneNumber
        };

        private static BaseTransaction ConfirmTransferRequest(string phoneNumber, string newOwner) => new ConfirmTransferRequest()
        {
            NewOwner = newOwner,
            PhoneNumber = phoneNumber
        };

        private static BaseTransaction RequestTransferRequest(string phoneNumber, string currentOwner, string newOwner) => new RequestTransfer()
        {
            CurrentOwner = currentOwner,
            NewOwner = newOwner,
            PhoneNumber = phoneNumber,
            TransferStarted = DateTime.Now
        };

        private static BaseTransaction CreateNumberRequest(string owner, string phoneNumber) => new CreateNumber()
        {
            Owner = owner,
            PhoneNumber = phoneNumber
        };

        #endregion
    }
}
