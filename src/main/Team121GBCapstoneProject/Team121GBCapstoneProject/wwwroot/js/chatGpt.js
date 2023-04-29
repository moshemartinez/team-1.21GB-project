
$(document).ready(function () {
    $('#send').on('click', function () {
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
    console.log(data);
    $('#responses').append('<div class="card text-white bg-primary" style="max-width: 30rem; min-width: 15rem"></div>');
    typeLetter(data);
    $('#responses').append('<br/>');
}

function sendMessageError(data) {
    console.log(data);
    $('#responses').append('<div class="card text-white bg-danger" style="max-width: 15rem;"></div>');
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
    $('#responses').append(`<div class="card" style="background-image: linear-gradient(white, white); max-width: 30rem; min-width: 15rem;">${query}</div>`);
    $('#responses').append('<br/>');
}


// // function formatDiv($responses) {
// //     $responses.css('width', 'auto');
// //     // const contentWidth = data.length * 10;
// //     // return contentWidth;
// // }
// function formatDiv($responses, data) {
//     // create a temporary hidden element to measure dimensions
//     const $temp = $('<span>').css({
//       position: 'absolute',
//       visibility: 'hidden',
//       whiteSpace: 'nowrap'
//     }).text(data);
    
//     // append the temporary element to the DOM
//     $('body').append($temp);
    
//     // measure the dimensions of the temporary element
//     const width = $temp.width();
//     const height = $temp.height();
    
//     // remove the temporary element
//     $temp.remove();
    
//     // set the dimensions of the div
//     $responses.css({
//       width: width + 'px',
//       height: height + 'px'
//     });
//     return $responses;
//   }