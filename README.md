# AOED-System
Doctor System | The Association of Occupational and Environmental Diseases of Thailand
Hosting on Microsoft Azure at https://aoed-system.azurewebsites.net

# 🖥 Stack 

Server: [Asp.Net Core 3.1 Preview](https://dotnet.microsoft.com/apps/aspnet) on [Azure app service](https://azure.microsoft.com/en-us/services/app-service/) running Linux image + Azure SQL Server

Client: [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)

# 🔐 Secrets 

`Connection String`, `JWT Secret`, `Inviation Key` are stored in Azure App Service environment variables.

# 🚀 Automatic compilation using Azure DevOps pipeline 
The `master` branch of this source code is directly connected to Azure DevOps pipeline
[![Build Status](https://dev.azure.com/tonnet-asia/AOED-System/_apis/build/status/Lukespacewalker.AOED?branchName=master)](https://dev.azure.com/tonnet-asia/AOED-System/_build/latest?definitionId=3&branchName=master)

By pushing to `master` branch, the website will be built and deployed automatically. 

## Manual compilation on your local computer
Now, It looks like you want to get your hand very dirty. 😋

## System Prerequisite
### Operation system
Windows , MacOS, Linux , or whatever OS that can install these softwares.
### Compilation software
[Microsoft Visual Studio 2019 16.4 Preview 4](https://visualstudio.microsoft.com/)

[.NET Core SDK 3.1 Preview2+](https://dotnet.microsoft.com/download/dotnet-core/3.1)
### Source distribution control software
 [Git](https://git-scm.com
) or Git GUI Software such as [Git-Kraken](https://www.gitkraken.com/) or [Fork](https://git-fork.com/)
