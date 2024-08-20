# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY GameStore/*.csproj ./GameStore/
COPY GameStoreTest/*.csproj ./GameStoreTest/
RUN dotnet nuget locals all --clear
RUN dotnet restore --ignore-failed-sources


COPY GameStore/. ./GameStore/
COPY GameStoreTest/. ./GameStoreTest/
WORKDIR /source/GameStore
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "GameStore.dll"]