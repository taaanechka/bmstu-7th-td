FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /app
# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy and publish app and libraries
COPY . .
RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "EmbedIOApp.dll"]
CMD ["http://+:80"]
