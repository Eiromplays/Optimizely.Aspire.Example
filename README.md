# Optimizely.Aspire.Example

This repository demonstrates how to set up and run an Optimizely CMS application using .NET Aspire for cloud-native development.

## Overview

This project showcases a modern approach to Optimizely CMS development using .NET Aspire, which provides a set of libraries and tools for building cloud-native applications with distributed architecture patterns.

The solution consists of several projects:
- `Optimizely.Aspire.Example.AppHost` - The Aspire application host that orchestrates the services
- `Optimizely.Aspire.Example.ServiceDefaults` - Common service configuration defaults
- `Optimizely.CMS` - The Optimizely CMS application

## Prerequisites

- .NET 9.0 SDK or later
- Docker Desktop (for running SQL Server and other dependencies)
- Rider 2024 or Visual Studio 2022 or later (recommended) or VS Code

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Set the `Optimizely.Aspire.Example.AppHost` project as the startup project
4. Press Shift + F10 in Rider or F5 in Visual Studio to run the application (this will depend on your IDE and keybindings)

The Aspire dashboard will open automatically, showing all the services and their health status.

## Features

- **Optimizely CMS Integration**: Demonstrates how to set up Optimizely CMS with .NET Aspire
- **Service Discovery**: Automatic service discovery and configuration
- **Distributed Tracing**: Built-in observability with OpenTelemetry
- **Containerization**: Docker support for local development
- **Health Checks**: Integrated health monitoring for all services

## Project Structure

- The `AppHost` project defines the application components and their relationships
- The `ServiceDefaults` project provides common configuration for all services
- The `CMS` project contains the Optimizely CMS implementation

## Configuration

The application is configured using standard .NET configuration patterns, with additional Aspire-specific configuration in the `AppHost` project.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
This is primarily just to showcase Aspire with Optimizely, so it will probably not change much.

## License

This project is licensed under the terms specified in the repository.
