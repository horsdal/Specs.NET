using NUnit.Framework;

namespace Specs.Test
{
    [TestFixture]
    public class LeapYearTest
    {
        [Test]
        public void LeapYearSpec()
        {
            "A leap year".should(() =>
            {
                "be any year divisible by 400".asIn(() =>
                {
                    Assert.That(LeapYearChecker.IsLeapYear(0), Is.True);
                    Assert.That(LeapYearChecker.IsLeapYear(400), Is.True);
                    Assert.That(LeapYearChecker.IsLeapYear(800), Is.True);
                })
                .andIn(() =>
                {
                    Assert.That(LeapYearChecker.IsLeapYear(-400), Is.False);
                });
                
                "but not other years divisible by 100".asIn(() =>
                {
                    Assert.That(LeapYearChecker.IsLeapYear(100), Is.False);
                    Assert.That(LeapYearChecker.IsLeapYear(100), Is.False);
                    Assert.That(LeapYearChecker.IsLeapYear(200), Is.False);
                    Assert.That(LeapYearChecker.IsLeapYear(1000), Is.False);
                });
                
                "and all other years divisible by 4".asIn(() =>
                {
                    for (int i = 0; i < 100; i += 4)
                    {
                        Assert.That(LeapYearChecker.IsLeapYear(i), Is.True);
                    }
                })
                .andIn(() =>
                {
                    for (int i = 1600; i < 1700; i += 4)
                    {
                        Assert.That(LeapYearChecker.IsLeapYear(i), Is.True);
                    }
                })
                .andIn(() =>
                {
                    for (int i = 1601; i < 1700; i += 4)
                    {
                        Assert.That(LeapYearChecker.IsLeapYear(i), Is.False);
                    }
                });
            });
        }
    }


    public static class LeapYearChecker
    {
        public static bool IsLeapYear(int year)
        {
            return year >= 0 &&
                (year % 400 == 0 ||
                (year % 4 == 0 && year % 100 != 0));
        }
    }
}
