
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
        // addUserQueryToDOM($prompt);
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
            // addUserQueryToDOM($prompt);
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
        // /error: console.log("erro//)
    });
}
         
function sendMessageSuccess(data) {
    $('#loadingChatGif').attr('hidden', 'true');
    console.log(data);
    let $responses = $('#responses');
    let msg = $('<div>').html(data)
                        .addClass('card text-white bg-primary');
    typeLetter(data);
    $responses.append(msg);
}
// function sendMessageSuccess(data) {
//     $('#loadingChatGif').attr('hidden', 'true'); 
//     console.log(data);
//     let $responses = $('#responses');
//     $responses.append('<div class="row"></div>');
//     let msg = $('<div>').html(data)
//                         .addClass('card text-white bg-primary')
//                         .css('max-width', '30rem')
//                         .css('min-width', '15rem')
//                         .css('justify-content', 'center')
//                         .css('align-items', 'center');
//     $('#responses').children()
//                    .last()
//                    .append(msg);
//     typeLetter(data);
//     // $('#responses').append('<br/>');
// }
// function sendMessageSuccess(data) {
//     document.querySelector('#loadingChatGif').setAttribute('hidden', 'true');
//     console.log(data);
//     let responses = document.querySelector('#responses');
//     let newRow = document.createElement('div');
//     newRow.classList.add('row');
//     responses.appendChild(newRow);
//     let newMsg = document.createElement('div');
//     newMsg.innerHTML = data;
//     newMsg.classList.add('card', 'text-white', 'bg-primary');
//     newMsg.style.maxWidth = '30rem';
//     newMsg.style.minWidth = '15rem';
//     newMsg.style.justifyContent = 'center';
//     newMsg.style.alignItems = 'center';
//     // let lastChild = responses.lastElementChild;
//     newRow.appendChild(newMsg);
//     typeLetter(data);
// }

// function sendMessageSuccess(data) {
//     $('#loadingChatGif').attr('hidden', 'true');
//     console.log(data);
//     let $responses = $('#responses');
//     $responses.append(`<div class="row">
//     <div class="col-sm-6">
//       <div class="card">
//         <div class="card-body">
//           <h5 class="card-title">Special title treatment</h5>
//           <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
//           <a href="#" class="btn btn-primary">Go somewhere</a>
//         </div>
//       </div>
//     </div>`);
// }

// function sendMessageError(data) {
//     $('#loadingChatGif').attr("hidden", "true"); 
//     console.log(data);
//     let $responses = $('#responses');
//     $responses.append('<div class="row"></div>');
    
//     $('#responses').append('<div class="card text-white bg-danger" style="max-width: 15rem;  justify-content: center; align-items: center;"></div>');
//     typeLetter(data);
//     $('#responses').append('<br/>');
// }

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

// function addUserQueryToDOM(query) {
//                                         $('#responses').append('<div class="card text-white bg-primary" style="max-width: 30rem; min-width: 15rem; justify-content: center;"></div>');

//     $('#responses').append(`<div class="card" style="background-image: linear-gradient(white, white); max-width: 30rem; min-width: 15rem;  justify-content: center; align-items: center;">${query}</div>`);
//     $('#responses').append('<br/>');
// }
