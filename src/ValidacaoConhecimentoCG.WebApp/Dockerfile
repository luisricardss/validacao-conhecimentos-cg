FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ValidacaoConhecimentoCG.WebApp/ValidacaoConhecimentoCG.WebApp.csproj", "ValidacaoConhecimentoCG.WebApp/"]
RUN dotnet restore "ValidacaoConhecimentoCG.WebApp/ValidacaoConhecimentoCG.WebApp.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "ValidacaoConhecimentoCG.WebApp/ValidacaoConhecimentoCG.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ValidacaoConhecimentoCG.WebApp/ValidacaoConhecimentoCG.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ValidacaoConhecimentoCG.WebApp.dll"]