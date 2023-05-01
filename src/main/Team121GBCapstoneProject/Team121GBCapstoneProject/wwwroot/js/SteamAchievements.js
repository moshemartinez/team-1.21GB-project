function steamModalOpen(gameId) {
    const steamId = BigInt(document.getElementById("steamId").value);

    $.ajax({
        method: "GET",
        url: `/api/Steam/GetSteamAchievements?userID=${steamId}&gameID=${gameId}`,
        dataType: "json",					// data type expected in response
        success: displaySteam,
        error: errorOnAjax
    });

    $('#SteamModal').modal('show');
}
function steamModalClose() {
    $('#SteamModal').modal('hide');
}

function displaySteam(data) {
    console.log(data);
}

function errorOnAjax(data) {
    console.log("Error in AJAX call " + data);
}