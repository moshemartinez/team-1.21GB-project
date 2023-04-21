$(document).ready(function () {
    $("#games-submit").on("click", function () {
        const $query = document.getElementById("GameEntry").value;
        SpeedSearchSubmit($query);
    });
});

function SpeedSearchSubmit(query) {
    $.ajax({
        type: "POST",
        url: `/api/Game/SpeedSearch/?query=${query}`,
        datatype: "json",
        success: function () {
            alert("success");
        },
        error: function () {
            alert("error");
        }
    });
}

/*function SpeedSearchSubmit(query) {
    $.ajax({
        type: "POST",
        url: `/api/Game/SpeedSearch?query=${query}`,
        data: {
            query: query
        },
        datatype: "json",
        success: alert("success"),
        error: alert("error")
    });
}*/