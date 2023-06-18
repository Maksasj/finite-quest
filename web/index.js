const form = document.getElementById('registrationForm');
const infoDiv = document.getElementById('registrationFormInfo');
const realmTable = document.getElementById('realmTable');

form.addEventListener('submit', async function(event) {
    event.preventDefault();

    const registrationFormUsername = document.getElementById('registrationFormUsername');
    const registrationFormPassword = document.getElementById('registrationFormPassword');

    const body = {
        username: registrationFormUsername.value,
        password: registrationFormPassword.value,
    };

    $.ajax({
        type:"POST",
        url: 'https://grumpy-shrimp-29.telebit.io/authorization/register',
        dataType: "text",
        data: body,
        success: function (response) {
            infoDiv.style.color = "green"; 
            infoDiv.innerHTML = response;
        },
        error: function (error) {
            infoDiv.style.color = "red"; 
            infoDiv.innerHTML = error.responseText;
        }
    });
});

async function tableUpdate() {
    let realmStatus = {};
    let realmData = {};

    await $.getJSON('https://maksasj.github.io/finite-quest/status.json', function(data) {
        realmData = data;
    });

    var promises = [];

    for(const realm of realmData.realms) {
        var request = $.ajax({ 
            type: "GET",   
            url: realm.main_endpoint + "status"
        })
        .done(function (data, textStatus, jqXHR) {
            realmStatus[realm.main_endpoint] = {
                status: 'online',
                population: realm.usersOnline + '/' + realm.population,
            };
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            realmStatus[realm.main_endpoint] = {
                status: 'offline',
                population: '-1/-1',
            };
        });

        promises.push(request);
    };

    $.when.apply($, promises).always(function(){
        const childElements = realmTable.querySelectorAll('.realmTableRow');
    
        childElements.forEach((childElement) => {
            childElement.remove();
        });
        realmData.realms.forEach(realm => {
            const newRow = document.createElement("tr");
            newRow.classList.add('realmTableRow');
        
            const realmLabel = document.createElement('td');
            realmLabel.textContent = realm.realm_name;
        
            const endpointLabel = document.createElement('td');
            endpointLabel.textContent = realm.main_endpoint;
        
            const statusLabel = document.createElement('td');
            statusLabel.textContent = realmStatus[realm.main_endpoint].status;
        
            const populationLabel = document.createElement('td');
            populationLabel.textContent = realmStatus[realm.main_endpoint].population;
        
            newRow.appendChild(realmLabel);
            newRow.appendChild(endpointLabel);
            newRow.appendChild(statusLabel);
            newRow.appendChild(populationLabel);
            
            realmTable.appendChild(newRow);
        });
        
        setTimeout(tableUpdate, 1000);
    })
}

tableUpdate();