FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ef-7-IMaterializationInterceptor.csproj", "./"]
RUN dotnet restore "Ef-7-IMaterializationInterceptor.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Ef-7-IMaterializationInterceptor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ef-7-IMaterializationInterceptor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ef-7-IMaterializationInterceptor.dll"]
