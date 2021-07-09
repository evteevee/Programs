#Dockerfile which will run through Docker Engine which creates a Docker Image of the App
#Get base SDK 3.1 Image from microsoft and create working directory
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#Copy the CSPROJ file from PC into working container and restore any dependencies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

# Copy the project files into the container and build our release
COPY . ./
RUN dotnet publish -c Release -o out

#Generate runtime image by only using dotnet core runtime inside container
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

#expose port 80
EXPOSE 80

#run the app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PokemonAPI.dll"]