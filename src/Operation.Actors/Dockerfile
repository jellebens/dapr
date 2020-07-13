#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 3000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Operation.Actors/Operation.Actors.csproj", "Operation.Actors/"]
RUN dotnet restore "Operation.Actors/Operation.Actors.csproj"
COPY . .
WORKDIR "/src/Operation.Actors"
RUN dotnet build "Operation.Actors.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Operation.Actors.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Operation.Actors.dll"]