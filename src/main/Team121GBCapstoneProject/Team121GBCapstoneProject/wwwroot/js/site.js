// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Search feature
$(document).ready(function () {
    $("#searchButton").click(function (event) {
        event.preventDefault(); // prevent the default form submission behavior
        var query = $("#searchInput").val(); // get the value from the search input field

        $.ajax({
            type: "GET",
            url: "/api/Game",
            data: { query: query }, // pass the search query as a parameter to the API Controller
            dataType: "json",
            success: function (data) {
                $("#gameTableBody").empty(); // clear the table body before populating with new data
                $.each(data, function (i, game) {
                    // resize cover image
                    var resizedCoverArt = game.gameCoverArt.replace("thumb", "logo_med");

                    var row = "<tr><td><img src=\"" + resizedCoverArt + "\"></td><td>" + game.gameTitle + "</td><td><a href=\"" + game.gameWebsite +  "\">" + game.gameWebsite + "</a></td></tr>";
                    $("#gameTableBody").append(row);
                });

                // redirect to the search results page after the ajax call is successful
                //window.location.href = "/Search/Results";
            }
        });
    });
});


// Attempt 2
//$(document).ready(function () {
//    $("#searchForm").submit(function (event) {
//        event.preventDefault(); // prevent the default form submission behavior
//        var query = $("#searchInput").val(); // get the value from the search input field

//        // make AJAX call to API Controller
//        $.ajax({
//            type: "GET",
//            url: "/api/Game",
//            data: { query: query }, // pass the search query as a parameter to the API Controller
//            dataType: "json",
//            success: function (data) {
//                $("#gameTableBody").empty(); // clear the table body before populating with new data
//                $.each(data, function (i, game) {
//                    // resize cover image
//                    var resizedCoverArt = game.gameCoverArt.replace("thumb", "logo_med");

//                    var row = "<tr><td><img src=\"" + resizedCoverArt + "\"></td><td>" + game.gameTitle + "</td><td><a href=\"" + game.gameWebsite + "\">" + game.gameWebsite + "</a></td></tr>";
//                    $("#gameTableBody").append(row);
//                });
//            }
//        });

//        // navigate to search results page
//        window.location.href = "/Search/Results/";
//    });
//});
