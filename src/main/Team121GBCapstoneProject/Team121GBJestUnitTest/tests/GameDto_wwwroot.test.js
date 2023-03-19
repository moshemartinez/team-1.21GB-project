import { GameDto } from "../../Team121GBCapstoneProject/wwwroot/js/GameDtoClass";

test("creates a GameDto object with listKind = test, gameTitle = title, imageSrc = source", () => {
    const gameDto = new GameDto("test", "title", "source");
    expect(gameDto.listKind).toBe("test");
    expect(gameDto.gameTitle).toBe("title");
    expect(gameDto.imageSrc).toBe("source");
});