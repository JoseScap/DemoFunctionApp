using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;

namespace DemoFunctionApp.Functions
{
    public static class HelloWorldDurableFunctions
    {
        [Function(nameof(HelloWorldDurableFunctions))]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            ILogger logger = context.CreateReplaySafeLogger(nameof(HelloWorldDurableFunctions));
            logger.LogInformation("Saying hello.");
            var outputs = new List<string>
            {
                // Replace name and input with values relevant for your Durable Functions Activity
                await context.CallActivityAsync<string>(nameof(SayHelloActivity), "Argentina"),
                await context.CallActivityAsync<string>(nameof(SayHelloActivity), "Peru"),
                await context.CallActivityAsync<string>(nameof(SayHelloActivity), "Mexico")
            };

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [Function(nameof(SayHelloActivity))]
        public static string SayHelloActivity([ActivityTrigger] string name, FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger("SayHello");

            // Generar un tiempo de espera aleatorio entre 15 y 45 segundos
            Random random = new Random();
            int delay = random.Next(5000, 10000);
            logger.LogInformation("Saying hello to {name} in {delay}.", name, delay);

            // Hacer que el hilo duerma durante el tiempo generado
            Thread.Sleep(delay);

            logger.LogInformation("Saying hello to {name}.", name);
            return $"Hello {name}!";
        }

        [Function($"{nameof(HelloWorldDurableFunctions)}_Start")]
        public static async Task<HttpResponseData> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            [DurableClient(TaskHub = "DurableFunctionsHub")] DurableTaskClient client,
            FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger($"{nameof(HelloWorldDurableFunctions)}_Start");

            // Function input comes from the request content.
            string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
                nameof(HelloWorldDurableFunctions));

            logger.LogInformation("Started orchestration with ID = '{instanceId}'.", instanceId);

            // Returns an HTTP 202 response with an instance management payload.
            // See https://learn.microsoft.com/azure/azure-functions/durable/durable-functions-http-api#start-orchestration
            return await client.CreateCheckStatusResponseAsync(req, instanceId);
        }
    }
}
