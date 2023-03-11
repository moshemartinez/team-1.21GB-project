
// Use this function for updating the SearchResults page using Ajax

function displaySearchResults(query) {

    $.ajax({
        type: "GET",
        url: "/api/Game",
        data: { query: query }, // pass the search query as a parameter to the API Controller
        dataType: "json",
        success: function (data) {
            if (data.length === 0) {
                // Display "No results found" message
                $("#gameTableBody").html("<tr> <td colspan=\"4\" style=\"text-align: center; color: gray;\">No results found</td></tr>");
            } else {
                $("#gameTableBody").empty(); // clear the table body before populating with new data
                $.each(data,
                    function (i, game) {
                        // resize cover image
                        var resizedCoverArt = game.gameCoverArt.replace("thumb", "logo_med");

                        var row = `<tr>
                                    <td><img src="${resizedCoverArt}"></td>
                                    <td><b>${game.gameTitle}</b></td>
                                    <td><a href="${game.gameWebsite}">${game.gameWebsite}"</a></td>
                                    <td><button class="btn btn-primary">Add Game</button></td>
                               </tr>`;
                        $("#gameTableBody").append(row);
                    });
            }
        }
    });
}