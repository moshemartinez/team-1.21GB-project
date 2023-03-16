console.log("Hello from addGame.js");
class GameDto {
    constructor(listKind, gameTitle, imageSrc) {
        this.listKind = listKind;
        this.gameTitle = gameTitle;
        this.imageSrc = imageSrc;
    }
}
// function afterAddGame() {
//     $.ajax({
//         method: "GET",
//         url: "/api/Game/getUserLists",
//         dataType: "json",
//         success: getUserListsSuccess,
//         error: getUserListsFailure
//     });
// }
function addGame(gameDto, url) {
    return $.ajax({
        method: "POST",
        url: url,
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(gameDto),
        success: afterAddGame1,
        error: errorAddingGameToList
    });
}

function afterAddGame1(data) {
    console.log(data);
    console.log('afterAddGame hit');
    const notification = $(`<div>
                            <h1>Success!</h1>
                          </div>`);
    $("#statusMessage").append($(notification));
    //$("#topOfPageHeader").after(notification);
}

function errorAddingGameToList(data) {
    console.log("errorAddingGameToList hit");
    const notification = $(`<div>
                            <h1>Something went wrong. Please try again.</h1>
                          </div>`);
    $("#statusMessage").append($(notification));
    $("#statusMessage").show();

    /*  $("#topOfPageHeader").after(notification);*/
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

    $("#formSubmit").on("click", async function (event) {
        event.preventDefault(); // prevent the default form submission behavior
        
        console.log("#formSubmit Clicked");
        const $listName = $("#listName option:selected").text();
        const $tds = $("tr").find("td");
        const $imageSrc = $($tds[0]).find("img").attr("src");
        const $gameTitle = $($tds[1]).text();

        let gameDto = new GameDto($listName, $gameTitle, $imageSrc);
        const origin = $(location).attr("origin");
        const url = `${origin}/api/Game/addGame`;
        
        try {
            let response = await addGame(gameDto, url);
            let data = response;
            console.log(data);
            console.log("We made it");
        } catch (error) {
            console.log(error);
        }
    });
});