# https://hub.docker.com/_/microsoft-dotnet-core
FROM mdsol/dotnet80-sdk AS build
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
RUN dotnet publish -c release -o /app --no-restore --ignore-failed-sources

# final stage/image
FROM mdsol/dotnet80-sdk
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "GameStore.dll"]