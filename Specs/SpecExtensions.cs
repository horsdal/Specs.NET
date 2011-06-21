using System;

namespace Specs
{
    public static class SpecExtensions
    {
        public static void should(this string unitUnderTest, Action executableSpecification)
        {
            Console.WriteLine(unitUnderTest + " should");
            executableSpecification();
        }

        public static string asIn(this string readableSpecification, Action executableSpecification)
        {
            Console.WriteLine(@"	" + readableSpecification);
            return RunExecutableSpecification(readableSpecification, executableSpecification);
        }

        public static string andIn(this string readableSpecification, Action executableSpecification)
        {
            return RunExecutableSpecification(readableSpecification, executableSpecification);
        }

        private static string RunExecutableSpecification(string readableSpecification, Action executableSpecification)
        {
            executableSpecification();
            return readableSpecification;
        }
    }
}
