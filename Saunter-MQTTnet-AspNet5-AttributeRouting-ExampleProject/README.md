# Saunter MQTTnet AspNet5 AttributeRouting ExampleProject

<p align="left">
    <a href="https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/releases">
        <img src="https://img.shields.io/github/downloads/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/total?label=Total%20Downloads&logo=github" alt="Total Releases Downloaded from GitHub">
    </a> <a href="https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/releases/latest">
        <img src="https://img.shields.io/github/v/release/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject?include_prereleases&label=Latest%20Release&logo=github" alt="Latest Official Release on GitHub">
    </a> <a href="https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/blob/main/LICENSE">
        <img src="https://img.shields.io/github/license/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject" alt="MIT License">
    </a> <a href="https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject#saunter-mqttnet-aspnet5-attributerouting-exampleproject">
        <img src="https://img.shields.io/badge/Docs-Example_Project-blue?logo=libreoffice&logoColor=white" alt="The current place where you can find all Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject Documentation!">
    </a><a href="https://www.iconomi.com/register?ref=zQQPK">
        <img src="https://img.shields.io/badge/Join-ICONOMI-blue?logo=bitcoin&logoColor=white" alt="ICONOMI - The world’s largest crypto strategy provider">
    </a> <a href="https://www.buymeacoffee.com/Rikj000">
        <img src="https://img.shields.io/badge/-Buy%20me%20a%20Coffee!-FFDD00?logo=buy-me-a-coffee&logoColor=black" alt="Buy me a Coffee as a way to sponsor this project!">
    </a>
</p>

An example project that implements following packages in a ASP.NET 5 MQTT Broker/Server:

## Current Implemented Package Status:
- [**MQTTnet**](https://github.com/chkr1011/MQTTnet) - `v3.0.16` - Working
- [**MQTTnet - AspNetCore - AttributeRouting**](https://github.com/Atlas-LiftTech/MQTTnet.AspNetCore.AttributeRouting) - `v3.0.16` *(Forked, see [NuGet](https://www.nuget.org/packages/MQTTnet.AspNetCore.AttributeRouting.Forked/))* - Working
- [**Saunter**](https://github.com/tehmantra/saunter) - `v0.4.0` - Working *(Newer versions will break documentation generation)*

## Some Notes:
- Tested with [**MQTTnet.App**](https://github.com/chkr1011/MQTTnet.App) as the client, configured as following:
  - Transport protocol: `WebSocket`
  - TLS version: `no TLS`
  - Host: `localhost:5000/mqtt`
  - Port: `5000`
- A [**CatchAllController**](https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/blob/main/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/Controllers/Mqtt/CatchAllController.cs) has been implemented, this will log all MQTT related messages going in/out of the MQTTnet Broker/Server
- A (MQTT) [**ExampleController**](https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/blob/main/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/Controllers/Mqtt/ExampleController.cs) has been implemented with following **Publish Topics**:
  - `ExampleController/publish/<PostalCode>/temperature`
    - PostalCode: `90210`
    - Payload: `int`
  - `ExampleController/publish/test`
    - Payload: `byte`
- The [**MqttService**](https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/blob/main/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/Services/MqttService.cs) has been implemented with following **Subscribe Topic**:
  - `MqttService/subscribe/kiss`
    - It will send a Payload every `KissIntervalSeconds` *(Configurable in `appsettings.json`)* for as long as there are clients connected.
    - Payload: `$"MQTTnet hosted on {frameworkName} is still running at {DateTime.Now}!"`
  - Here you can also configure various MQTT Broker related settings / handlers
- [**Startup**](https://github.com/Rikj000/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/blob/main/Saunter-MQTTnet-AspNet5-AttributeRouting-ExampleProject/Startup.cs) is where most of the other Package configuration happens
