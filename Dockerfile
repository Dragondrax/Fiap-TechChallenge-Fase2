FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar arquivos csproj e restaurar dependências
COPY ["src/WebApi/Fiap.TechChallenge.Fase1.WebAPI/Fiap.TechChallenge.Fase1.WebAPI.csproj", "src/WebApi/Fiap.TechChallenge.Fase1.WebAPI/"]
COPY ["src/Core/Fiap.TechChallenge.Fase1.SharedKernel/Fiap.TechChallenge.Fase1.SharedKernel.csproj", "Csrc/ore/Fiap.TechChallenge.Fase1.SharedKernel/"]
COPY ["src/Services/Fiap.TechChallenge.Fase1.Aplicacao/Fiap.TechChallenge.Fase1.Aplicacao.csproj", "src/Services/Fiap.TechChallenge.Fase1.Aplicacao/"]
COPY ["src/Services/Fiap.TechChallenge.Fase1.Data/Fiap.TechChallenge.Fase1.Data.csproj", "src/Services/Fiap.TechChallenge.Fase1.Data/"]
COPY ["src/Services/Fiap.TechChallenge.Fase1.Dominio/Fiap.TechChallenge.Fase1.Dominio.csproj", "src/Services/Fiap.TechChallenge.Fase1.Dominio/"]
COPY ["src/Services/Fiap.TechChallenge.Fase1.Infraestructure/Fiap.TechChallenge.Fase1.Infraestructure.csproj", "src/Services/Fiap.TechChallenge.Fase1.Infraestructure/"]
COPY ["src/Services/Fiap.TechChallenge.Fase1.IoC/Fiap.TechChallenge.Fase1.IoC.csproj", "src/Services/Fiap.TechChallenge.Fase1.IoC/"]
COPY ["src/Tests/Fiap.TechChallenge.Fase1.Tests/Fiap.TechChallenge.Fase1.Tests.csproj", "src/Tests/Fiap.TechChallenge.Fase1.Tests/"]

RUN dotnet restore "src/WebApi/Fiap.TechChallenge.Fase1.WebAPI/Fiap.TechChallenge.Fase1.WebAPI.csproj"

# Copiar o restante dos arquivos e construir o projeto
COPY . .
WORKDIR "/src/src/WebApi/Fiap.TechChallenge.Fase1.WebAPI"
RUN dotnet build "Fiap.TechChallenge.Fase1.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Fiap.TechChallenge.Fase1.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.TechChallenge.Fase1.WebAPI.dll"]
