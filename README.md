# Cardalog in Blazor

Cardalog is starting life as a basic web app for curating CCG collections.

## Development

Cardalog is being developed with the following tools:

1. Blazor
2. .NET Core 3.1
3. PowerShell
4. Visual Studio Code

### Bootstrapping

You'll need the latest [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) then get the Blazor WASM template with the following command.

```ps
dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.1.0-preview3.19555.2
```

Scaffold the app with:

```ps
dotnet new blazorwasm -o Cardalog
```

And run it with:

```ps
dotnet run
```

Visit `http://localhost:5000` or `https://localhost:5001` to see the app.
