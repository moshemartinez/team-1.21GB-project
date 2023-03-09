console.log("Hello from reCAPTCHAV3.js");

//function onSubmit(token) {
//    $('#submitPromptButton').click();
//}
$(function () {
    grecaptcha.ready(function () {
        grecaptcha.execute('6LcR_-YkAAAAAIR4vU4A-D3bq9NjQvyv129J7Azj', { action: 'submit' }).then(function (token) {
            // Add your logic to submit to your backend server here.
            console.log(token);
            $("#dalleRecaptcha").val(token);
        });
    });
});



//$(function () {
//    $(document).ready(function () {
//        function onClick(e) {
//            e.preventDefault();
//            grecaptcha.ready(function () {
//                grecaptcha.execute('6LcR_-YkAAAAAIR4vU4A-D3bq9NjQvyv129J7Azj', { action: 'submit' }).then(function (token) {
//                    // Add your logic to submit to your backend server here.
//                    $.ajax({
//                        method: "GET",
//                        url: "api/GetImages",
//                        dataType: "json",
//                        success: successReCAPTCHAV3,
//                        error: /*failureReCAPTCHAV3*/
//                    });
//                });
//            });
//        }
//    });
//});
//function successReCAPTCHAV3() {
//    console.log("success on client side reCAPTCHV3.js");
//}

//function failureReCAPTCHAV3() {
//    alert("FAILURE!");
//}
