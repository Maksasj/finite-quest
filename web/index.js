const form = document.getElementById('registrationForm');
const infoDiv = document.getElementById('registrationFormInfo');

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