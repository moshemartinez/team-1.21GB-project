let mediaRecorder;
let chunks = [];
let mediaStream;


console.log('Hello from whisper.js');

// * turns on microphone and starts recording
// * pushes data to chunks array
const startRecording = async () => {
    navigator.mediaDevices.getUserMedia({ audio: true })
        .then(stream => {
            mediaStream = stream;
            mediaRecorder = new MediaRecorder(stream);
            mediaRecorder.start();
            console.log(mediaRecorder.state);
            mediaRecorder.ondataavailable = e => {
                chunks.push(e.data);
            };
        });
};

// * waits for all data to be pushed to chunks array
// * and then stops recording
// * creates blob from chunks array
// * creates file from blob
// * creates formData object
// * appends file to formData object
// * sends formData object to server
const stopRecording = async () => {
    try {
        await new Promise(resolve => {
            mediaRecorder.onstop = resolve;
            mediaRecorder.stop();
        });
        console.log(mediaRecorder.state);
        const blob =  new Blob(chunks, { type: 'audio/mp3' });
        const file = new File([blob], 'recording.mp3', { type: 'audio/mp3' });
        chunks = [];
        const formData = new FormData();
        formData.append('file', file);
        console.log('formData', formData);
        console.log('formData.get(file);', formData.get('file'));
        console.log('Calling ajax');
        await $.ajax({
            url: '/api/Whisper/PostTextFromSpeech',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: successOnAjax,
            error: errorOnAjax
        });
    }
    catch (e) {
        console.log(e);
        await mediaStream.getTracks().forEach(track => track.stop());

    }
};
const successOnAjax = async (response) => {
    await mediaStream.getTracks().forEach(track => track.stop());
    console.log('success:', response);
    // alert(response);
    //$('#chat').val($('#chat').val() + response);
    $('#prompt').val(response);
}

const errorOnAjax = async (xhr, status, error) => {
    await mediaStream.getTracks().forEach(track => track.stop());
    console.log(xhr.responseText);
    console.log(status);
    console.log(error);
}

$().ready(() => {
    const recordBtn = $('#recordBtn');
    const stopBtn = $('#stopBtn');
    const sendBtn = $('#send');

    recordBtn.on('click', async () => {
        sendBtn.attr('disabled', 'true');
        recordBtn.attr('disabled', 'true');
        await startRecording();

    });
    stopBtn.on('click', async () => {
        console.log('Stop button clicked');
        await stopRecording();
        console.log('Stop should be done');
        sendBtn.removeAttr('disabled');
        recordBtn.removeAttr('disabled');
    });

    // $('#recordBtn').on('click', async () => {
    //     await startRecording();
    // });

    // $('#stopBtn').on('click', async () => {
    //     console.log('Stop button clicked');
    //     await stopRecording();
    //     console.log('Stop should be done');
    // });
});
