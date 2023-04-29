
$(document).ready(function () {
    $('#send').on('click', function () {
        $('#loadingChatGif').removeAttr("hidden"); 
        let $prompt = $('#prompt').val();
        $prompt.trim();
        if ($prompt === "" || $prompt === null || $prompt === undefined) {
            sendMessageError("Please enter a prompt.");
            return;
        }
        $('#prompt').val('');
        addUserQueryToDOM($prompt);
        sendMessage($prompt);
    });
    $("#prompt").keypress(function(event) {
        if (event.keyCode === 13) {
            $('#loadingChatGif').removeAttr("hidden"); 
            let $prompt = $('#prompt').val();
            $prompt.trim();
            if ($prompt === "" || $prompt === null || $prompt === undefined) {
                sendMessageError("Please enter a prompt.");
                return;
            }
            $('#prompt').val('');
            addUserQueryToDOM($prompt);
            sendMessage($prompt);
        }
      });
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
    $('#loadingChatGif').attr('hidden', 'true'); 
    console.log(data);
    $('#responses').append('<div class="card text-white bg-primary" style="max-width: 30rem; min-width: 15rem; justify-content: center;"></div>');
    typeLetter(data);
    $('#responses').append('<br/>');
}

function sendMessageError(data) {
    $('#loadingChatGif').attr("hidden", "true"); 
    console.log(data);
    $('#responses').append('<div class="card text-white bg-danger" style="max-width: 15rem;  justify-content: center; align-items: center;"></div>');
    typeLetter(data);
    $('#responses').append('<br/>');
}

function typeLetter(data) {
    const text = data.split(' ');
    let $responses = $('#responses').children().last();
    $responses.css('color', 'white');
    // * typing animation
    $.each(text, function (i, letter) {
        setTimeout(function () {
            $responses.append(letter + ' ');
        }, 100 * i);
    });
}

function addUserQueryToDOM(query) {
    $('#responses').append(`<div class="card" style="background-image: linear-gradient(white, white); max-width: 30rem; min-width: 15rem;  justify-content: center; align-items: center;">${query}</div>`);
    $('#responses').append('<br/>');
}