FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore

COPY . .
# COPY ./Data ./Data
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "CarterApp.dll"]
CMD ["--urls", "http://+:80"]
