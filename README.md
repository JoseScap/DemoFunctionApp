# DemoFunctionApp

## Overview

DemoFunctionApp is a demonstration of how to use Azure Functions App with .NET 8. This project includes simple Azure Functions and Durable Azure Functions to showcase various capabilities.

## Features

The example code is located in the `Functions` directory, which contains three files:

1. **HelloWorld.cs**: This file contains simple functions triggered via HTTP and timer triggers. The outputs include HTTP responses and writing to Azure Storage Blob containers.

2. **DurableHelloWorld.cs**: This file contains a Durable Function that sequentially triggers three activity functions.

3. **FoFiHelloWorld.cs**: Similar to the previous Durable Function, this one also triggers three activities but runs them concurrently to save time.

## Configuration

To configure the application, you need to set the values in `local.settings.json`:

- `AzureWebJobsStorage`: This is the storage account where our code is hosted.
- `AZUREBLOBSTORAGE_CONFIG`: This is a storage account where all blobs output by our functions will be sent.

## Getting Started

1. Clone the repository.
2. Navigate to the project directory.
3. Open the `local.settings.json` file and set the values for `AzureWebJobsStorage` and `AZUREBLOBSTORAGE_CONFIG`.
4. Build and run the project.

## Dependencies

- .NET 8
- Azure Functions SDK

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgements

This project uses the [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/) platform.
