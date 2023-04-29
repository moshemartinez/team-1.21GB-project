
$(document).ready(function () {
    $('#send').on('click', function () {
        // let prompt = $('#prompt').val();
        // sendMessage(prompt);
        sendMessage($('#prompt').val());
    });
    // $('#prompt').on('keydown', function(event) {
    //     if (event.keyCode === 13) { // 13 is the code for the Enter key
    //         event.preventDefault(); // prevent the default behavior of the enter key
    //         // $('#send').click(); // trigger the click event on the #send button
    //         sendMessage($('#prompt').val());
    //     }
    // });
});

function sendMessage(prompt) {
    $.ajax({
        url: '/api/ChatGpt/GetChatResponse',
        method: 'GET',
        data: {
            prompt: prompt
        },
        success: sendMessageSuccess,
        error: sendMessageError
    });
}

function sendMessageSuccess(data) {
    console.log(data);
    document.getElementById("responses").innerHTML += "<p>" + data + "</p>";
}

function sendMessageError(data) {
    console.log(data);
    // document.createElement("div");
    document.getElementById("responses").innerHTML += "<p>" + data + "</p>";
}