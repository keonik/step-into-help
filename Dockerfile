# Build Vite Client App
FROM cgr.dev/chainguard/node:latest AS node-build
WORKDIR /app
USER node
COPY --chown=node:nonroot ./client ./client

WORKDIR /app/client

RUN npm install
RUN npm run build

# Build .NET API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ["StepIntoHelp.csproj", "./"]
COPY --chown=nonroot:nonroot . /source
RUN dotnet restore "StepIntoHelp.csproj"
COPY . .
RUN dotnet build "StepIntoHelp.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "StepIntoHelp.csproj" --use-current-runtime --self-contained false -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=node-build /app/client/dist /app/wwwroot
ENTRYPOINT ["dotnet", "StepIntoHelp.dll"]
