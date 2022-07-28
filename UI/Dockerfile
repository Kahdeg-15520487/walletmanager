FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UI/UI.csproj", "UI/"]
RUN dotnet restore "UI/UI.csproj"
COPY . .
WORKDIR "/src/UI"
RUN dotnet build "UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UI.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
EXPOSE 80
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY "UI/nginx.conf" /etc/nginx/nginx.conf