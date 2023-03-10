console.log("Hello from reCAPTCHAV3.js");

$(function () {
    grecaptcha.ready(function () {
        grecaptcha.execute('6LcR_-YkAAAAAIR4vU4A-D3bq9NjQvyv129J7Azj', { action: 'submit' }).then(function (token) {
            // Add your logic to submit to your backend server here.
            console.log(token);
            $("#dalleRecaptcha").val(token);
        });
    });
});

$('form').on('submit', function (e) {
    if (grecaptcha.getResponse() == "") {
        e.preventDefault();
        alert("Please complete the CAPTCHA before submitting the form.");
    }
    else {
        console.log("reCAPTCHA passed on client side.");
    }
});

$(function () {
    grecaptcha.ready(function () {
        grecaptcha.execute('6LcR_-YkAAAAAIR4vU4A-D3bq9NjQvyv129J7Azj', { action: 'submit' }).then(function (token) {
            // Add your logic to submit to your backend server here.
            console.log(token);
            $("#recaptcha").val(token);
        });
    });
});