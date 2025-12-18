# 40069

First, read the [Renovate minimal reproduction instructions](https://github.com/renovatebot/renovate/blob/main/docs/development/minimal-reproductions.md).

Then replace the current `h1` with the Renovate Issue/Discussion number.

## Current behavior

The nuget manager can extract package directives from single file dotnet scripts. Cakebuild however extends the functionality to be able to install dotnet tools. The mechanism to install in single file C# build files is to use dedicated methods. Package references in those methods are not yet handled by renovate.

## Expected behavior
Given the cake build file uses the `InstallTool` or `InstallTools` methods, the package names versions in there are updated,
while other strings are left unchanged.

`#:package` and `#:sdk` directives are not relevant because they are handled by another manager (nuget), because it's not specific to cake build files.

```csharp
#:sdk Cake.Sdk

InstallTool("dotnet:https://api.nuget.org/v3/index.json?package=GitVersion.Tool&version=6.5.0");

// Install multiple tools at once
InstallTools(
    "dotnet:https://api.nuget.org/v3/index.json?package=dotnet-trace=9.0.621003",
    "dotnet:?package=Octopus.DotNet.Cli&version=9.1.6"
);

var installTool = "dotnet:https://api.nuget.org/v3/index.json?package=dotnet-dump&version=9.0.621003";
```

result:
```csharp
#:sdk Cake.Sdk

InstallTool("dotnet:https://api.nuget.org/v3/index.json?package=GitVersion.Tool&version=6.5.1");

// Install multiple tools at once
InstallTools(
    "dotnet:https://api.nuget.org/v3/index.json?package=dotnet-trace=9.0.652701",
    "dotnet:?package=Octopus.DotNet.Cli&version=9.1.7"
);

var installTool = "dotnet:https://api.nuget.org/v3/index.json?package=dotnet-dump&version=9.0.621003";
```


## Link to the Renovate issue or Discussion

https://github.com/renovatebot/renovate/discussions/40069
