using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NumberTransfer.Transactions;

namespace NumberTransferWebApi.Controllers
{
    public class QueryRequest
    {
        [JsonProperty("c")]
        public string Command { get; set; }

        [JsonProperty("d")]
        public string Data { get; set; }
    }

    public class QueryResponse
    {
        [JsonProperty("parsed")]
        public object Parsed { get; set; }

        [JsonProperty("original")]
        public object Original { get; set; }
    }

    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public CommandController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        private string GetParty() => Request.Headers.Single(header => header.Key == "X-Party").Value;

        [HttpPost("CreateNumber")]
        public async Task<IActionResult> CreateNumber([FromBody] CreateNumber payload) => Ok(await ExecuteTransaction(CreateSignedToken(payload).ToTokenString()));

        [HttpPost("RequestTransfer")]
        public async Task<IActionResult> RequestTransfer([FromBody] RequestTransfer payload) =>
            Ok(await ExecuteTransaction(CreateSignedToken(SetRequestTransferStartedTime(payload)).ToTokenString()));

        [HttpPost("ConfirmTransferRequest")]
        public async Task<IActionResult> ConfirmTransferRequest([FromBody] ConfirmTransferRequest payload) =>
            Ok(await ExecuteTransaction(CreateSignedToken(payload).ToTokenString()));

        [HttpPost("DenyTransferRequest")]
        public async Task<IActionResult> DenyTransferRequest([FromBody] DenyTransferRequest payload) => Ok(await ExecuteTransaction(CreateSignedToken(payload).ToTokenString()));

        [HttpPost("Query")]
        public async Task<IActionResult> Query([FromBody] QueryRequest payload) => Ok(await ExecuteQuery(payload.Command, payload.Data));

        private TransactionToken CreateSignedToken(BaseTransaction tx)
        {
            tx.TransactionTime = DateTime.Now;
            var jsonString = JsonConvert.SerializeObject(tx, new TransactionSerializerSettings());
            var byteArray = Encoding.UTF8.GetBytes(jsonString);
            var transactionToken = new TransactionToken(byteArray);

            var basePath = Path.Combine(_environment.WebRootPath);
            var certificate = new X509Certificate2(Path.Combine(basePath, $"{GetParty()}.p12"), "thinktecture");

            transactionToken.Sign(certificate);

            return transactionToken;
        }

        private RequestTransfer SetRequestTransferStartedTime(RequestTransfer payload)
        {
            payload.TransferStarted = DateTime.Now;
            return payload;
        }

        private Task<string> ExecuteTransaction(string tokenString)
        {
            var url = $"http://localhost:46657/broadcast_tx_commit?tx=\"{tokenString}\"";

            var httpClient = new HttpClient();
            return httpClient.GetStringAsync(url);
        }

        private async Task<QueryResponse> ExecuteQuery(string command, string data)
        {
            var url = $"http://localhost:46657/abci_query?path=\"{command}\"&data=\"{data}\"";

            var httpClient = new HttpClient();
            var resultString = await httpClient.GetStringAsync(url);
            var responseQuery = JObject.Parse(resultString);

            var byteArray = HexStringToByteArray(responseQuery.SelectToken("result.response.value").Value<string>());
            var utf8String = Encoding.UTF8.GetString(byteArray);

            return new QueryResponse()
            {
                Parsed = JsonConvert.DeserializeObject(utf8String),
                Original = responseQuery
            };
        }

        private byte[] HexStringToByteArray(string input)
        {
            var res = new byte[input.Length / 2];

            for (var i = 0; i < input.Length / 2; i++)
            {
                var h = input.Substring(i * 2, 2);
                res[i] = Convert.ToByte(h, 16);
            }

            return res;
        }
    }
}
