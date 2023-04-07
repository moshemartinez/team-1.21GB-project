/*
 * These tests were written by Nathaniel Kuga on 4/6/23
 * If you change or add tests, please note where you make changes
 * Or note which tests you wrote.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Models.DTO;
using Team121GBCapstoneProject.Services.Abstract;
using Team121GBCapstoneProject.Services.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Team121GBNUnitTest;

public class GameJsonDTOTests
{
    [TestCase(10223123, 1970)]// 10223123 == 1970
    [TestCase(1000000000, 2001)]// 10223123 == 2001
    [TestCase(1649266800, 2022)]// 1649266800 == 2022
    public void GameJsonDTO_ConvertFirstReleaseDate_FromUnixTimeStampToInteger(int unixTimeStamp, int expectedValue)
    {
        // Arrange  and Act
        int? yearPublished = GameJsonDTO.ConvertFirstReleaseDateFromUnixTimestampToYear(unixTimeStamp);
        //Assert
        Assert.That(yearPublished, Is.EqualTo(expectedValue));
        

    }
}