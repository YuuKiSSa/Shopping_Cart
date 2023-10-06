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
            
            if (data.message == false) {
                let message = document.getElementById("message");
                message.innerHTML = "Wrong ID or Passage! Please tey again!";
            }
            else {
                window.location.href = "/Home/Privacy?UserId=" + userId;
            }
            
        }
    }

    let userId = document.getElementById("UserId").value;
    let password = document.getElementById("Password").value;

    let data = { "UserId": userId, "Password": password };

    let json = JSON.stringify(data);

    xhr.send(json);

}