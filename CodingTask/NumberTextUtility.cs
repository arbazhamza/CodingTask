namespace CodingTask        //service to increase the reusability of the code
{
    public class NumberTextUtility
    {
        public static string GetTextForNumber(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "Eurofins";
            else if (number % 3 == 0)
                return "Three";
            else if (number % 5 == 0)
                return "Five";
            else
                return number.ToString();
        }
    }
}
