class GameDto {
    constructor(listKind, gameTitle, imageSrc) {
        this.listKind = listKind;
        this.gameTitle = gameTitle;
        this.imageSrc = imageSrc;
    }
}
console.log("Calling Constructor for GameDto inside GameDtoClass");
export { GameDto }