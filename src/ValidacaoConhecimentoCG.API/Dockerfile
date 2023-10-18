FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5050
ENV ASPNETCORE_URLS=http://+:5050

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ValidacaoConhecimentoCG.API/ValidacaoConhecimentoCG.API.csproj", "ValidacaoConhecimentoCG.API/"]
RUN dotnet restore "ValidacaoConhecimentoCG.API/ValidacaoConhecimentoCG.API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "ValidacaoConhecimentoCG.API/ValidacaoConhecimentoCG.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ValidacaoConhecimentoCG.API/ValidacaoConhecimentoCG.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ValidacaoConhecimentoCG.API.dll"]