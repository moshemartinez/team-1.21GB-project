// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Search feature
$(document).ready(function () {
    $("#searchButton").click(function (event) {

        event.preventDefault(); // prevent the default form submission behavior
        var query = $("#searchInput").val(); // get the value from the search input field

        // navigate to query url
        var location = "/Search/Results/?query=" + encodeURIComponent(query);
        window.location.href = location;
    });
});

$(document).ready(function () {
    if (window.location.href.includes("/Search/Results/")) {

        var urlParams = new URLSearchParams(window.location.search);
        var query = urlParams.get('query');

        console.log("Search: ", query);

        if (query != null) {
            displaySearchResults(query);
        } else {
            console.log("No search query provided");
        }
    }
});

// DALLE
function dalleModalOpen() {
    $('#DalleModal').modal('show');
}
function dalleModalClose() {
    $('#DalleModal').modal('hide');
}
