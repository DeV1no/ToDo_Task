#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ToDo_Task/ToDo_Task.csproj", "ToDo_Task/"]
COPY ["ToDo_Task_DataAccess/ToDo_Task_DataAccess.csproj", "ToDo_Task_DataAccess/"]
COPY ["ToDo_Task_Repository/ToDo_Task_Repository.csproj", "ToDo_Task_Repository/"]
COPY ["ToDo_Task_Service/ToDo_Task_Service.csproj", "ToDo_Task_Service/"]
RUN dotnet restore "ToDo_Task/ToDo_Task.csproj"
COPY . .
WORKDIR "/src/ToDo_Task"
RUN dotnet build "ToDo_Task.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo_Task.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo_Task.dll"]