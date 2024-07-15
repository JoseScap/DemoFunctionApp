using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DemoFunctionApp.Functions
{
    public class HelloWorldFunctions(ILogger<HelloWorldFunctions> logger)
    {
        [Function("HttpHelloWorldHttp")]
        public IActionResult RunHttp([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            logger.LogInformation("HelloWorld function was triggered.");

            var nameQuery = req.Query["name"].ToString();
            var name = string.IsNullOrEmpty(nameQuery) ? "there" : nameQuery;
            var message = $"Hi {name}! Welcome to Azure Functions!";

            return new OkObjectResult(message);
        }

        [Function("HttpHelloWorldBlobStorage")]
        [BlobOutput("hello-world/message-from-{fileName}.txt", Connection = "AZUREBLOBSTORAGE_CONFIG")]
        public string RunStorage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            logger.LogInformation("HelloWorldStorage function was triggered.");

            var nameQuery = req.Query["name"].ToString();
            var name = string.IsNullOrEmpty(nameQuery) ? "there" : nameQuery;
            var message = $"Hi {name}! Welcome to Azure Functions!";

            return message;
        }

        /**
         * "* * * * *" -> "minutos horas dia_del_mes mes dia_de_la_semana"
         * "* * * * * *" -> "segundos minutos horas dia_del_mes mes dia_de_la_semana"
         **/
        [Function("TimerHelloWorldBlobStorage")]
        [BlobOutput("hello-world/timer.txt", Connection = "AZUREBLOBSTORAGE_CONFIG")]
        public string RunTimer([TimerTrigger("0 */1 * * *")] TimerInfo myTimer)
        {
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var outName = DateTime.Now.ToString("HH") + "-" + DateTime.Now.ToString("mm") + "-timer";
            var message = $"La hora es {outName}";

            return message;
        }
    }
}
