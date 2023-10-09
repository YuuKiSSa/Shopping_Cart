window.onload = function () {
    let form = document.getElementById("loginForm");

    form.addEventListener("submit", function (event) {
        event.preventDefault();
        submit();
    })
}

function submit() {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Home/Validate");
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");
    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE) {
            if (this.status != 200) {
                return;
            }
            let response = JSON.parse(this.responseText);

            if (response.message == false) {
                let message = document.getElementById("message");
                message.innerHTML = "Wrong ID or Passage! Please try again!";
                password.value = "";
            }
            else {
                window.location.href = "/Home/Privacy?UserId=" + userId;
            }
            
        }
    }

    let userId = document.getElementById("UserId");
    let password = document.getElementById("Password");

    let data = { "UserId": userId.value, "Password": password.value };

    let json = JSON.stringify(data);

    xhr.send(json);

}