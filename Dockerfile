FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StepIntoHelp.csproj", "./"]
RUN dotnet restore "StepIntoHelp.csproj"
COPY . .
RUN dotnet build "StepIntoHelp.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "StepIntoHelp.csproj" -c Release -o /app/publish
RUN dotnet dev-certs https
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StepIntoHelp.dll"]