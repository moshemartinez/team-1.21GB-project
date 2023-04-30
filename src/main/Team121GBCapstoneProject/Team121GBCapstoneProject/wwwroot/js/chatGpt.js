
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

//q: will this make the javascript wait till the ajax call returns?
//a: no, it will not
//q: why not?
//a: because the ajax call is async
//q: how can I make it wait for the ajax call to finsh?
//a: use async: false in the ajax call

async function sendMessage(prompt) {
    await $.ajax({
        url: '/api/ChatGpt/GetChatResponse',
        method: 'GET',
        data: {
            prompt: prompt
        },
        success: sendMessageSuccess,
        error: sendMessageError
    });
}

async function sendMessageSuccess(data) {
    $('#loadingChatGif').attr('hidden', 'true');
    console.log(data);
    let $responses = $('#responses');
    let $row = $('<div></div>').addClass('card text-white bg-primary');
    await $responses.append($row);
    typeLetter(data);
}

async function sendMessageError(data) {
    $('#loadingChatGif').attr('hidden', 'true');
    console.log(data);
    let $responses = $('#responses');
    let $row = $('<div></div>').addClass('card text-white bg-danger');
    await $responses.append($row);
    typeLetter(data);
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

function addUserQueryToDOM(prompt) {
    let $responses = $('#responses');
    let msg = $('<div>').html(prompt)
                        .addClass('card text-white bg-secondary');
    $responses.append(msg);
}
