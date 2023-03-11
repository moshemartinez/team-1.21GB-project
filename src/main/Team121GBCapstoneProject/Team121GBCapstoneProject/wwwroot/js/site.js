// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Search feature
//$(document).ready(function () {
//    $("#searchButton").click(function (event) {

//        event.preventDefault(); // prevent the default form submission behavior
//        var query = $("#searchInput").val(); // get the value from the search input field

//        $.ajax({
//            type: "GET",
//            url: "/api/Game",
//            data: { query: query }, // pass the search query as a parameter to the API Controller
//            dataType: "json",
//            success: function (data) {
//                if (data.length === 0) {
//                    // Display "No results found" message
//                    $("#gameTableBody").html("<tr> <td colspan=\"4\" style=\"text-align: center; color: gray;\">No results found</td></tr>");
//                } else {

//                    $("#gameTableBody").empty(); // clear the table body before populating with new data
//                    $.each(data,
//                        function(i, game) {
//                            // resize cover image
//                            var resizedCoverArt = game.gameCoverArt.replace("thumb", "logo_med");

//                            var row = `<tr>
//                                    <td><img src="${resizedCoverArt}"></td>
//                                    <td>${game.gameTitle}</td>
//                                    <td><a href="${game.gameWebsite}">${game.gameWebsite}"</a></td>
//                                    <td><button class="btn btn-primary">Add Game</button></td>
//                               </tr>`;
//                            $("#gameTableBody").append(row);
//                        });

//                    // redirect to the search results page after the ajax call is successful
//                    //window.location.href = "/Search/Results";
//                }
//            }
//        });
//    });
//});

$(document).ready(function () {
    $("#searchButton").click(function (event) {

        event.preventDefault(); // prevent the default form submission behavior
        var query = $("#searchInput").val(); // get the value from the search input field

        // modify the form action URL to include the query parameter
        var location = "/Search/Results/?query=" + encodeURIComponent(query);
        window.location.href = location;

    });
});

$(document).ready(function () {
    if (window.location.href.includes("/Search/Results/")) {

        // Test
        $("#gameTableBody").html("<tr> <td colspan=\"4\" style=\"text-align: center; color: gray;\">No results found</td></tr>");
    }
});


function dalleModalOpen() {
    $('#DalleModal').modal('show');
}
function dalleModalClose() {
    $('#DalleModal').modal('hide');
}
