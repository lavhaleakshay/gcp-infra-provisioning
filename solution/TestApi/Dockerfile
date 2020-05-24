FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
WORKDIR /src
COPY ["TestApi.csproj", ""]
RUN dotnet restore "TestApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "TestApi.csproj" -c Release -o /app
RUN dotnet publish "TestApi.csproj" -c Release -o /app
WORKDIR /app
RUN mkdir /app/weather
COPY *.json /app/weather/
ENTRYPOINT ["dotnet", "TestApi.dll"]
EXPOSE 5001
