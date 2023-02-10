using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team121GBCapstoneProject;

namespace Team121GBNUnitTests;

public class AccountRegistrationCAPTCHATests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void reCAPTCHAisPassed()
    {
        //setup
        var reCAPTCHAvalue = false;

        //arrange

        //assert
        Assert.That(reCAPTCHAvalue, Is.EqualTo(true));
    }
    [Test]
    public void reCAPTCHAisNOTPassed()
    {
        //setup
        var reCAPTCHAvalue = false;

        //arrange
        reCAPTCHAvalue = true; //temporary
        //assert
        Assert.That(reCAPTCHAvalue, Is.EqualTo(false));
    }
}
