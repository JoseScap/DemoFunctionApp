using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;

namespace DemoFunctionApp.Functions
{
    public static class FoFiDurableFunctions
    {
        // [Function(nameof(FoFiDurableFunctions))]
        // public static async Task<List<string>> RunOrchestrator(
        //     [OrchestrationTrigger] TaskOrchestrationContext context)
        // {
        //     ILogger logger = context.CreateReplaySafeLogger(nameof(FoFiDurableFunctions));
        //     logger.LogInformation("Saying hello.");
        //     var outputs = new List<string>();

        //     // Replace name and input with values relevant for your Durable Functions Activity
        //     var countryOneTask = context.CallActivityAsync<string>(nameof(FoFiSayHelloActivity), "España");
        //     var countryTwoTask = context.CallActivityAsync<string>(nameof(FoFiSayHelloActivity), "Italia");
        //     var countryThreeTask = context.CallActivityAsync<string>(nameof(FoFiSayHelloActivity), "Francia");

        //     // Esperar a que todas las tareas se completen
        //     var results = await Task.WhenAll(countryOneTask, countryTwoTask, countryThreeTask);

        //     // Agregar los resultados a la lista outputs
        //     outputs.AddRange(results);

        //     // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
        //     return outputs;
        // }

        // [Function(nameof(FoFiSayHelloActivity))]
        // public static string FoFiSayHelloActivity([ActivityTrigger] string name, FunctionContext executionContext)
        // {
        //     ILogger logger = executionContext.GetLogger("SayHello");

        //     // Generar un tiempo de espera aleatorio entre 15 y 45 segundos
        //     Random random = new Random();
        //     int delay = random.Next(30000, 45000);
        //     logger.LogInformation("Saying hello to {name} in {delay}.", name, delay);

        //     // Hacer que el hilo duerma durante el tiempo generado
        //     Thread.Sleep(delay);

        //     logger.LogInformation("Saying hello to {name}.", name);
        //     return $"Hello {name}!";
        // }

        // [Function($"{nameof(FoFiDurableFunctions)}_Start")]
        // public static async Task<HttpResponseData> FoFiHttpStart(
        //     [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        //     [DurableClient(TaskHub = "DurableFunctionsHub")] DurableTaskClient client,
        //     FunctionContext executionContext)
        // {
        //     ILogger logger = executionContext.GetLogger($"{nameof(FoFiDurableFunctions)}_Start");

        //     // Function input comes from the request content.
        //     string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
        //         nameof(FoFiDurableFunctions));

        //     logger.LogInformation("Started orchestration with ID = '{instanceId}'.", instanceId);

        //     // Returns an HTTP 202 response with an instance management payload.
        //     // See https://learn.microsoft.com/azure/azure-functions/durable/durable-functions-http-api#start-orchestration
        //     return await client.CreateCheckStatusResponseAsync(req, instanceId);
        // }
    }
}
