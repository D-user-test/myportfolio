// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    const alertDiv = document.getElementById("pageAlert");
    if (alertDiv) {
        alertDiv.classList.add("d-none");
    }
   

    var scrollSpy = new bootstrap.ScrollSpy(document.body, {
        target: '#navbarScrollspy',
        offset: 100
    });


        document.addEventListener('click', function (event) {
            const navbar = document.querySelector('.navbar-collapse');
                const toggle = document.querySelector('.navbar-toggler');

                // If navbar is open and click is outside toggle or navbar
                if (navbar.classList.contains('show') &&
                !navbar.contains(event.target) &&
                !toggle.contains(event.target)) {
                    toggle.click(); // Programmatically close the navbar
            }
          });


});


function sendDataToContact() {
    let form = document.getElementById("contactForm");
    var name= document.getElementById('name').value;
    var msg= document.getElementById("msg").value;
    var sub= document.getElementById("sub").value;
    var email = document.getElementById("email").value;
    let btn = document.getElementById("sendBtn");

    const alertDiv = document.getElementById("pageAlert");

    if (name == '' || msg == '' || sub == '' || email == '') {

        alert("please fill all input fields");
        return false;
    }
    function isValidEmail(email) {
        // Basic email pattern
        var pattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return pattern.test(email);
    }

    if (!isValidEmail(email)) {
        alert("Invalid email");
        return false;
    } else {
        console.log("valid email");
    }

    btn.disabled = true;
    btn.innerHTML = `
            <span class="spinner-border spinner-border-sm" aria-hidden="true"></span>
            <span role="status"> Sending...</span>
          `;

    $.ajax({
        url: '../Profile/Contact',
        type: 'POST',
        data: { name: name, msg: msg, sub: sub, email: email },
        success: function (response) {
            console.log("fromProcess", response.fromProcess)
            console.log("fromUser", response.fromUser)
            console.log("fromMachine", response.fromMachine)
            console.log("servemail", response.servemail)
            if (response == true) {
                setTimeout(() => {
                    // After success, reset button
                    btn.disabled = false;
                    btn.innerHTML = "Send";
                    document.getElementById("modalMessage").innerText ="Thank you for contacting us..";
                    alertDiv.classList.remove("d-none");
                    form.reset();
                }, 2000);
            } else {
                setTimeout(() => {
                    // After success, reset button
                    btn.disabled = false;
                    btn.innerHTML = "Send";
                    document.getElementById("modalMessage").innerText =  "Failed to send Email..";
                    alertDiv.classList.remove("d-none");
                form.reset();
                }, 2000);
            }
        },
        error: function () {
            alert("Error while sending mail.");
            reject(false);
        }
    });
}

