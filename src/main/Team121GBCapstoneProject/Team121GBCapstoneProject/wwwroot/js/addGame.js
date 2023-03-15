console.log("Hello from addGame.js");

$(document).ready(function () {
    $("table").on("click", "button", function () {
        const $row = $(this).closest("tr");
        // * retrieve info from from tag
        const $name = $row.find("b");

        console.log(`$row:${$row}`);
        console.log(`$name:${$name.text()}`);

        $.ajax({
            type: "GET",
            url: "/api/Game/getUserLists",
            dataType: "json",
            success: getUserListsSuccess,
            error: getUserListsFailure
        });

    });

    $("#formSubmit").on("click", function () {
        const $listName = $("#listName option:selected").text();
        const $tds = $("tr").find("td");
        const $imageSrc = $($tds[0]).find("img").attr("src");
        const $gameTitle = $($tds[1]).text();

        let gameDto = new GameDto($listName, $gameTitle, $imageSrc);
        const poo = JSON.stringify(gameDto);
        console.log(poo);
        const origin = $(location).attr("origin");
        $.ajax({
            type: "POST",
            dataType: "json",
            url: `${origin}/api/Game/addGame`,
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify(gameDto),
            success: afterAddGame,
            error: errorAddingGameToList
        });
    });
});

class GameDto {
    constructor(listKind, gameTitle, imageSrc) {
        this.listKind = listKind;
        this.gameTitle = gameTitle;
        this.imageSrc = imageSrc;
    }
}

function afterAddGame(data) {
    const notification = $(`<div>
                            <h1>Success!</h1>
                          </div>`);
    $("#topOfPageHeader").after(notification);
}

function errorAddingGameToList(data) {
    const notification = $(`<div>
                            <h1>Something went wrong. Please try again.</h1>
                          </div>`);
    $("#topOfPageHeader").after(notification);
}
// ! Modifying the DOM
function getUserListsSuccess(data) {

    console.log("Getting user lists succeeded");
    let listNameFormId = $("#listName").attr("id");
    $("#listName").empty();
    for (let i = 0; i < data.length; ++i) {
        console.log(data[i]);
        let selectOption = `<option value="${data[i].listKind}">${data[i].listKind}</option>`;
        $("#listName").append(selectOption);
    }
}

function getUserListsFailure(data) {
    console.log("You don't have any lists to add a game to!");
}