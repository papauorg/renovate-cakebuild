#:sdk Cake.Sdk

InstallTool("dotnet:https://api.nuget.org/v3/index.json?package=GitVersion.Tool&version=6.5.0");

// Install multiple tools at once
InstallTools(
    "dotnet:https://api.nuget.org/v3/index.json?package=dotnet-trace&version=9.0.621003",
    "dotnet:?package=Octopus.DotNet.Cli&version=9.1.6"
);
