# Pokemon Shakespearean API
This is an API created in C# ASP.NET CORE Web Application

GitHub Location - [PokemonAPI](https://github.com/evteevee/Programs/tree/master/PokemonAPI)

-----------
### _Software Requirements:_
please ensure these are installed in your system.
* Microsoft .NET Core SDK 3.1.302 - download from [.NET Microsoft 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
* Microsoft .NET Core SDK 3.1.410 - download from [.NET Microsoft 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
* Microsoft .NET Core SDK 5.0.301 - download from [.NET Microsoft 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* Docker Desktop - download from [Docker.com](https://www.docker.com/products/docker-desktop)
* WSL2 Linux kernel update package for x64 machines - download from [docs.Microsoft.com](https://docs.microsoft.com/en-us/windows/wsl/install-win10)
_`(it is in Step 4 on the page)`_
* GitHub Desktop - for the codes solution package folder - download from [desktop.Github.com](https://desktop.github.com/)

-----------
### _Packages Used:_
* Microsoft.AspNet.WebApi.Core
* Microsoft.AspNet.WebApi.Cors
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.OpenApi
* Swashbuckle.AspNetCore _`(used during dev testing, not really needed)`_

-----------
-----------
## Steps for Running the API:
1. Install all software requirements above by navigating to the links (mostly download and install)
2. Sign up to Docker.com if you do not have an account and login.
3. Ensure Docker Desktop is running without issues
4. Open Windows Powershell and type the below command (enter to execute command)
```
docker pull emmfranklin21/pokemonapi
```
5. Confirm that pull is complete by checking your Docker Desktop Images section
6. Open Windows Powershell and type the below command (enter to execute command)
```
docker run -p 8080:80 emmfranklin21/pokemonapi
```
7. check if API is running by opening an Internet Browser (IE, Chrome) and navigating to [http://localhost:8080/pokemon](http://localhost:8080/pokemon).
If the response is as shown below, then the API is running correctly
```
{"id":0,"name":"Error: Name is blank!","description":"Error: Name is blank!"}
```

-----------
-----------
## Opening the Landing Page index.html:
this is the main User Interface
1. Download the GitHub files from GitHub Location - [PokemonAPI](https://github.com/evteevee/Programs/tree/master/PokemonAPI)
2. Open PokemonAPI/PokemonAPI_LandingPage folder
3. Open index.html on any Internet Browser (IE, Chrome)
4. You can type a Pokemon Name on the text box and click Go.
_(`Charizard` or `Bulbasaur` for this project)_
5. If the Pokemon does not exist, you can click the Create Button and try to search again
6. Reset button clears the response and textbox
7. Clicking on `Automated Testing Page` button will redirect you to the Automated Testing page. There you can use the buttons to test GET and POST requests.

-----------
-----------
## ENJOY =)
## by `Emmanuel Franklin`
## _emmfranklin21@gmail.com_