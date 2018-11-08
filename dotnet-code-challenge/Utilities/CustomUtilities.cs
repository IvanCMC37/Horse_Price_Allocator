

namespace dotnet_code_challenge.Utilities
{
    public static class CustomUtilities
    {
        //function for checking if user input is within range
        public static bool IsWithinRange(this int value, int min, int max) => value >= min && value <= max;

    }
}
