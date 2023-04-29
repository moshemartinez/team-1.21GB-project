
$(document).ready(function () {
    $('#send').on('click', function () {
        addUserQueryToDOM($('#prompt').val());
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
    if (prompt === "" || prompt === null || prompt === undefined) {
        sendMessageError("Please enter a prompt.");
        return;
    }
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
    // $('#responses').append('<div class="card" style="background-image: linear-gradient(#1099ff, blue);"></div>');
    $('#responses').append('<div class="card text-white bg-primary"></div>');

    typeLetter(data);
    $('#responses').append('<br/>');
}

function sendMessageError(data) {
    console.log(data);
    $('#responses').append('<div class="card text-white bg-danger"></div>');
    typeLetter(data);
    $('#responses').append('<br/>');
}
function typeLetter(data) {
    const text = data.split(' ');
    const $responses = $('#responses').children().last();
    $responses.css('color', 'white');

    // * format the chat to the size of the response
    const contentWidth = formatDiv(data, $responses);
    $responses.css('width', contentWidth);

    $.each(text, function (i, letter) {
        setTimeout(function () {
            $responses.append(letter + ' ');
        }, 100 * i);
    });
}

function formatDiv(data, $responses) {
    const contentWidth = data.length * 10;
    return contentWidth;
}

function addUserQueryToDOM(query) {
    $('#responses').append(`<div class="card" style="background-image: linear-gradient(white, white);">${query}</div>`);
    $('#responses').append('<br/>');
}