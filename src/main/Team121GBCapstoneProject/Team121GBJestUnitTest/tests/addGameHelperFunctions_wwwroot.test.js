//import { GameDto } from "../../Team121GBCapstoneProject/wwwroot/js/GameDtoClass";
//import { GameDto } from "../../Team121GBCapstoneProject/wwwroot/js/GameDtoClass";
//import { getGameInfoFromPage } from "../../Team121GBCapstoneProject/wwwroot/js/addGame";
import { setUpURL } from "../../Team121GBCapstoneProject/wwwroot/js/addGameHelperFunctions"
import { validateUserLists } from "../../Team121GBCapstoneProject/wwwroot/js/validation.js"

describe("Test Methods for adding game helper functions", () => {
    test("setUpUrl Success", () => {
        console.log("setUpUrl success");
        const origin = "https://Home";
        const url = `${origin}/api/Game/addGame`;
        const urlFrom_setUpURL = setUpURL(origin);
        expect(urlFrom_setUpURL).toEqual(url);
    });
    test("setUpUrl failure null origin", () => {
        console.log("setUpUrl failure null origin");
        const origin = null;
        const urlFrom_setUpURL = setUpURL(origin);
        expect(urlFrom_setUpURL).toBe(false);
    });
    test("setUpUrl failure undefined origin", () => {
        console.log("setUpUrl failure undefined origin");
        const origin = undefined;
        const urlFrom_setUpURL = setUpURL(origin);
        expect(urlFrom_setUpURL).toBe(false);
    });
    test("setUpUrl failure empty origin", () => {
        console.log("setUpUrl failure empty origin");
        const origin = "";
        const urlFrom_setUpURL = setUpURL(origin);
        expect(urlFrom_setUpURL).toBe(false);
    });
    
});