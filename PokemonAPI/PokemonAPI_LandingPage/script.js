
var data;
var baseURL = "http://localhost:8080/pokemon";
let checkCharizard;
let pokemonName;

//call HttpGET from API to retrieve Pokemon description using Pokemon Name as key
function getPokemon() {
    pokemonName = document.getElementById('pokemonName').value
    console.log(pokemonName)

    if(pokemonName === "")
    {
        document.getElementById("description").innerHTML = "Error: Search box cannot be blank.";
    }
    else
    {
        fetch(baseURL + "/" + pokemonName)
        .then(res => res.json())
        .then(data => {
        console.log(data)
        //Now you get the js variable inside your form element
        document.getElementById("description").innerHTML = data.description;
        })
        .catch(error => {
            if (typeof error.json === "function") {
                error.json().then(jsonError => {
                    console.log("Json error from API");
                    console.log(jsonError);
                }).catch(genericError => {
                    console.log("Generic error from API");
                    console.log(error.statusText);
                });
            } else {
                console.log("Fetch error");
                console.log(error);
                document.getElementById("description").innerHTML = "Error: Pokemon " + pokemonName + " does not exist in the system.";
            }
        });
    }
 
}

//clear the form/page
function resetSearch() {
    document.getElementById("description").innerHTML = null;
    document.getElementById("pokemonName").value = null;
}

//create charizard if it does not exist using HttpPOST in API
function createCharizard() {
    console.log("check if Charizard exists")

    fetch(baseURL)
    .then(res => res.json())
    .then(data => {
        console.log(data)
        if(data[0] != null)
        {
           console.log("Charizard already exists")
           document.getElementById("description").innerHTML = "Charizard already exists!";
        }
        else
        { 
            console.log("Charizard does not exists")
            console.log("create Charizard")
            var xhttp = new XMLHttpRequest();
            var jsonCreateCharizard = '{"id":0, "name":"Charizard","description":"Charizard flies \'round the sky in search of powerful opponents. \'t breathes fire of such most wondrous heat yond \'t melts aught. However, \'t nev\'r turns its fiery breath on any opponent weaker than itself."}';

            xhttp.onreadystatechange = function() {
            if (xhttp.readyState == 4) {
                //document.getElementById("mainDisplay").innerHTML =xhttp.responseText;
            }
            };
      
            xhttp.open("POST", baseURL,true);
            xhttp.setRequestHeader("Content-type", "application/json");
            xhttp.setRequestHeader("X-Atlassian-Token", "nocheck");
            xhttp.send(jsonCreateCharizard);
            document.getElementById("description").innerHTML = "Charizard have been added to the system.";
        }
    })

}

//create Bulbasaur if it does not exist using HttpPOST in API
function createBulbasaur() {
    console.log("check if Bulbasaur exists")

    fetch(baseURL)
    .then(res => res.json())
    .then(data => {
        console.log(data)
        if(data[1] != null)
        {
           console.log("Bulbasaur already exists")
           document.getElementById("description").innerHTML = "Bulbasaur already exists!";
        }
        else
        { 
            console.log("Bulbasaur does not exists")
            console.log("create Bulbasaur")
            var xhttp = new XMLHttpRequest();
            var jsonCreateBulbasaur = '{"id":0,"name":"Bulbasaur","description":"Bulbasaur art bawbling, squat amphibian and planteth pokémon yond moveth on all four forks, and has\'t lighteth blue-green bodies with dark\'r blue-green spots. The bulb on its backeth blossoms into a quite quaint floweth\'r"}';

            xhttp.onreadystatechange = function() {
            if (xhttp.readyState == 4) {
                //document.getElementById("mainDisplay").innerHTML =xhttp.responseText;
            }
            };
      
            xhttp.open("POST", baseURL,true);
            xhttp.setRequestHeader("Content-type", "application/json");
            xhttp.setRequestHeader("X-Atlassian-Token", "nocheck");
            xhttp.send(jsonCreateBulbasaur);
            document.getElementById("description").innerHTML = "Bulbasaur have been added to the system.";
        }
    })

}


