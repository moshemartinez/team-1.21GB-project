console.log("Hello from addGame.js");

$(document).ready( function () {
    $("table").on("click", "button", function () {
        let id = $(this).attr("id");
        let tableDataId = $(`#td${id}`).attr("id");
        const title = $(`#${tableDataId}`).text();
    
        console.log(id);
        console.log(tableDataId);
        console.log(title);
        //
        $.ajax({
            type: "GET",
            url: "/api/Game/getUserLists",
            dataType: "json",
            success: function (data) {
                console.log("Getting user lists succeeded");
                let listNameFormId = $("#listName").attr("id");
                $("#listName").empty();
                for (let i = 0; i < data.length; ++i) {
                    console.log(data[i]);
                    let selectOption = `<option value="${data[i].listName}">${data[i].listName}</option>`;
                    $("#listName").append(selectOption);
                }
    
                $("#formSubmit").on("click", function () {
                    const list = $("#listName").text();
                    console.log("listName = " + list);
                    let origin = $(location).attr("origin");
                    console.log(title);
                    const dataToSend = { listName: list, gameTitle: title };
                    console.log(dataToSend);
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        url: `${origin}/api/Game/addGame`,
                        contentType: "application/json; charset=UTF-8",
                        data: JSON.stringify(dataToSend),
                        success: afterAddGame,
                        error: errorAlert
                    });
                });
            },
            error: getUserListsFailure
        });
    
    });
});

function addGame() {

}

function getUserListsSuccess(data) {

    console.log("Getting user lists succeeded");
    let listNameFormId = $("#listName").attr("id");
    $("#listName").empty();
    for (let i = 0; i < data.length; ++i) {
        console.log(data[i]);
        let selectOption = `<option value="${data[i].listName}">${data[i].listName}</option>`;
        $("#listName").append(selectOption);
    }

    $("#formSubmit").on("click", function () {
        const list = $("#listName").text();
        console.log("listName = " + list);
        //let id = $(this).attr("id");
        //let tableDataId = $(`#td${id}`).attr("id");
        //const title = $(`#${tableDataId}`).text();
        ////const title = $("#").text();

        console.log(this.title);
        const dataToSend = { listName: list, gameTitle: this.title };
        console.log(dataToSend);
        $.ajax({
            type: "POST",
            dataType: "json",
            url: `api/Game/addGame`,
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify(dataToSend),
            success: afterAddGame,
            error: errorAlert
        });
    });
}

function getUserListsFailure(data) {
    console.log("You don't have any lists to add a game to!");
}