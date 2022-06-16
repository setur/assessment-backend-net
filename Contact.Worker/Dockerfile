#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Contact.Worker/Contact.Worker.csproj", "Contact.Worker/"]
RUN dotnet restore "Contact.Worker/Contact.Worker.csproj"
COPY . .
WORKDIR "/src/Contact.Worker"
RUN dotnet build "Contact.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contact.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.Worker.dll"]
