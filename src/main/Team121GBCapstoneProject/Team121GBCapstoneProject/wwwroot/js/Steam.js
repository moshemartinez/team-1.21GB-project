function displaySteam(data) {
    console.log(data)
}

function errorOnAjax(data) {
    console.log("Error in AJAX call " + data.url);
}

function steamLoad(steamId) {
    $.ajax({
        method: "GET",
        url: `/api/Steam/GetSteamUser?id=${steamId}`,
        dataType: "json",					// data type expected in response
        success: displaySteam,
        error: errorOnAjax
    });
}
