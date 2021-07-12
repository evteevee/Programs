
var data;
var baseURL = "http://localhost:8080/pokemon";
let checkCharizard;
let pokemonName;

//call HttpGET from API to retrieve Pokemon description using Pokemon Name as key
function getPokemon() {
    pokemonName = document.getElementById('pokemonName').value
    console.log(pokemonName)

    fetch(baseURL + "/" + pokemonName)
    .then(res => res.json())
    .then(data => {
     console.log(data)
    //Now you get the js variable inside your form element
    document.getElementById("description").innerHTML = data.description;
    })
    .catch(error => {
            error.json().then(jsonError => {
                console.log("Json error from API");
                console.log(jsonError);
            }).catch(genericError => {
                console.log("Generic error from API");
                console.log(error.statusText);
            });
    });
}

//clear the form/page for index.html
function resetSearch() {
    document.getElementById("description").innerHTML = null;
    document.getElementById("pokemonName").value = null;
}

//create charizard if it does not exist using HttpPOST in API
function createCharizard() {
    var xhttp = new XMLHttpRequest();
    var jsonPost = '{"id":0, "name":"Charizard","description":"Charizard flies \'round the sky in search of powerful opponents. \'t breathes fire of such most wondrous heat yond \'t melts aught. However, \'t nev\'r turns its fiery breath on any opponent weaker than itself."}';
    //document.getElementById("httpRequest").innerHTML = jsonPost;

    xhttp.open("POST", baseURL,true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("X-Atlassian-Token", "nocheck");
    xhttp.send(jsonPost);
    

    xhttp.onreadystatechange = function() {
        if (xhttp.readyState == 4) {
            var data = JSON.parse(xhttp.responseText)
            console.log(data.name)
            document.getElementById("description").innerHTML = data.description;
        }
    };

}

//create Bulbasaur if it does not exist using HttpPOST in API
function createBulbasaur() {
    var xhttp = new XMLHttpRequest();
    var jsonPost = '{"id":0, "name":"Bulbasaur","description":"Bulbasaur art bawbling, squat amphibian and planteth pokémon yond moveth on all four forks, and has\'t lighteth blue-green bodies with dark\'r blue-green spots. The bulb on its backeth blossoms into a quite quaint floweth\'r"}';
    //document.getElementById("httpRequest").innerHTML = jsonPost;

    xhttp.open("POST", baseURL,true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("X-Atlassian-Token", "nocheck");
    xhttp.send(jsonPost);
    

    xhttp.onreadystatechange = function() {
        if (xhttp.readyState == 4) {
            var data = JSON.parse(xhttp.responseText)
            console.log(data.name)
            document.getElementById("description").innerHTML = data.description;
        }
    };

}


//Automated Testing

//clear the request/response
function resetReqRes() {
    document.getElementById("httpRequest").innerHTML = null;
    document.getElementById("httpResponse").innerHTML = null;
}

//test GET using Charizard as name
function testGetCharizard() {
    document.getElementById("httpRequest").innerHTML = "/Charizard";
    fetch(baseURL + "/Charizard")
    .then(res => res.text())
    .then(res => {
        console.log(res);
    document.getElementById("httpResponse").innerHTML = res;
    })
}

//test GET using spaces as name
function testGetSpaces() {
    document.getElementById("httpRequest").innerHTML = "/  ";
    fetch(baseURL + "/  ")
    .then(res => res.text())
    .then(res => {
        console.log(res);
    document.getElementById("httpResponse").innerHTML = res;
    })
}

//test GET using Bulbasaur as name
function testGetBulbasaur() {
    document.getElementById("httpRequest").innerHTML = "/Bulbasaur";
    fetch(baseURL + "/Bulbasaur")
    .then(res => res.text())
    .then(res => {
        console.log(res);
    document.getElementById("httpResponse").innerHTML = res;
    })
}

//test GET using integers as name
function testGetRandomInt() {
    document.getElementById("httpRequest").innerHTML = "/123456";
    fetch(baseURL + "/123456")
    .then(res => res.text())
    .then(res => {
        console.log(res);
    document.getElementById("httpResponse").innerHTML = res;
    })
}

//test GET using name that does not exist in db (null object)
function testGetNULLPokemon() {
    document.getElementById("httpRequest").innerHTML = "/abcde";
    fetch(baseURL + "/abcde")
    .then(res => res.text())
    .then(res => {
        console.log(res);
    document.getElementById("httpResponse").innerHTML = res;
    })
}

//test GET using name that includes string and integer together and does not exist in db (null object)
function testGetStringInt() {
    document.getElementById("httpRequest").innerHTML = "/123ABC";
    fetch(baseURL + "/123ABC")
    .then(res => res.text())
    .then(res => {
        console.log(res);
    document.getElementById("httpResponse").innerHTML = res;
    })
}

//test POST by sending json with correct Charizard values
function testPOSTCreateCharizard() {
    var xhttp = new XMLHttpRequest();
    var jsonPost = '{"id":0, "name":"Charizard","description":"Charizard flies \'round the sky in search of powerful opponents. \'t breathes fire of such most wondrous heat yond \'t melts aught. However, \'t nev\'r turns its fiery breath on any opponent weaker than itself."}';
    document.getElementById("httpRequest").innerHTML = jsonPost;

    xhttp.open("POST", baseURL,true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("X-Atlassian-Token", "nocheck");
    xhttp.send(jsonPost);

    xhttp.onreadystatechange = function() {
        if (xhttp.readyState == 4) {
            document.getElementById("httpResponse").innerHTML =xhttp.responseText;
        }
    };
}

//test POST by sending json with correct Bulbasaur values
function testPOSTCreateBulbasaur() {
    var xhttp = new XMLHttpRequest();
    var jsonPost = '{"id":0, "name":"Bulbasaur","description":"Bulbasaur art bawbling, squat amphibian and planteth pokémon yond moveth on all four forks, and has\'t lighteth blue-green bodies with dark\'r blue-green spots. The bulb on its backeth blossoms into a quite quaint floweth\'r"}';
    document.getElementById("httpRequest").innerHTML = jsonPost;

    xhttp.open("POST", baseURL,true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("X-Atlassian-Token", "nocheck");
    xhttp.send(jsonPost);

    xhttp.onreadystatechange = function() {
        if (xhttp.readyState == 4) {
            document.getElementById("httpResponse").innerHTML =xhttp.responseText;
        }
    };
}

//test POST by sending json with integers as name value
function testPOSTCreateNameInt() {
    var xhttp = new XMLHttpRequest();
    var jsonPost = '{"id":0, "name":"123456","description":"testing name with integers"}';
    document.getElementById("httpRequest").innerHTML = jsonPost;

    xhttp.open("POST", baseURL,true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("X-Atlassian-Token", "nocheck");
    xhttp.send(jsonPost);

    xhttp.onreadystatechange = function() {
        if (xhttp.readyState == 4) {
            document.getElementById("httpResponse").innerHTML =xhttp.responseText;
        }
    };
}
