import { GameDto } from "./GameDtoClass.js";


function setUpURL() {
    const origin = $(location).attr("origin");
    const url = `${origin}/api/Game/addGame`;
    return url;
}

function getGameInfoFromPage($row) {
    const $listName = $("#listName option:selected").text();
    const $tds = $row.find("td");
    const $imageSrc = $($tds[0]).find("img").attr("src");
    const $gameTitle = $($tds[1]).text();
    let gameDto = new GameDto($listName, $gameTitle, $imageSrc);
    return gameDto;
}

function addGame(gameDto, url) {
    return $.ajax({
        method: "POST",
        url: url,
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(gameDto),
        success: afterAddGame,
        error: errorAddingGameToList
    });
}

function afterAddGame(data) {
    $("#statusMessage").empty();
    console.log(data);
    console.log('afterAddGame hit');
    const notification = `<div class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            <h1>${data}</h1>
                          </div>`;
    $("#statusMessage").append(notification);
    $("#statusMessage").show();
}

function errorAddingGameToList(data) {
    $("#statusMessage").empty();
    console.log(data.responseText);
    console.log(data.value);
    console.log(data);

    console.log("errorAddingGameToList hit");
    const notification = `<div class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            <h1>${data.responseText}</h1>
                          </div>`;
    $("#statusMessage").append(notification);
    $("#statusMessage").show();
}
// ! Modifying the DOM
function getUserLists() {
    return $.ajax({
        type: "GET",
        url: "/api/Game/getUserLists",
        dataType: "json",
        success: getUserListsSuccess,
        error: getUserListsFailure
    });
}
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

export { setUpURL, getGameInfoFromPage, addGame, afterAddGame, errorAddingGameToList, getUserLists, getUserListsSuccess, getUserListsFailure }