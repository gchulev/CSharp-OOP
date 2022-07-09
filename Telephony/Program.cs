using System;

namespace Telephony
{
    public class Program
    {
        static void Main()
        {


            string[] firstLineInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondLineInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            //Calling Numbers
            foreach (string number in firstLineInput)
            {
                if (!ValidateNumber(number))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    Console.WriteLine(smartPhone.CallNumber(number));
                }
                else if (number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.CallNumber(number));
                }
            }

            //Browsing URL's
            foreach (string url in secondLineInput)
            {
                if (!ValidateURL(url))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(smartPhone.BrowseURL(url));
                }
            }

            bool ValidateNumber(string num)
            {
                foreach (char symbol in num)
                {
                    if (!char.IsDigit(symbol))
                    {
                        return false;
                    }
                }
                return true;
            }

            bool ValidateURL(string url)
            {
                foreach (char symbol in url)
                {
                    if (char.IsDigit(symbol))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
