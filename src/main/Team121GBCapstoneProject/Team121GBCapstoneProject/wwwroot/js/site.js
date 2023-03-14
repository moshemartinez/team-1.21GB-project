// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Search Feature
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



// when the dark mode toggle button is clicked
$('#dark-mode-toggle').click(function () {
    //// toggle the dark mode
    //$('body').toggleClass('dark-mode');

    //// save the user's preference
    //if ($('body').hasClass('dark-mode')) {
    //    localStorage.setItem('dark-mode-enabled', 'true');
    //} else {
    //    localStorage.setItem('dark-mode-enabled', 'false');
    //}

    darkmode.toggle();
    console.log("dark mode activated: ", darkmode.isActivated()); // should return true
});

// Darkmode.js
// See https://darkmodejs.learn.uno/
var options = {
    bottom: '64px', // default: '32px'
    right: 'unset', // default: '32px'
    left: '32px', // default: 'unset'
    time: '0.3s', // default: '0.3s'
    mixColor: '#fff', // default: '#fff'
    backgroundColor: '#fff',  // default: '#fff'
    buttonColorDark: '#100f2c',  // default: '#100f2c'
    buttonColorLight: '#fff', // default: '#fff'
    saveInCookies: true, // default: true,
    label: '🌓', // default: ''
    autoMatchOsTheme: true // default: true
}

var darkmode = new Darkmode(options);

