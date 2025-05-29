using System.Text;

namespace TechTask_ATM
{
    internal class Program
    {
        private const int MAXAMOUNT100 = 100;

        static void Main(string[] args)
        {
            int amount = 30000;

            System.Console.WriteLine("The possible payouts for the amount are: \n");
            System.Console.WriteLine(CalcPayout(amount));
        }

        public static string CalcPayout(int amount)
        {
            int units100 = amount / 100;

            if (units100 > MAXAMOUNT100)
            {
                return "The amount exceeds the maximum available";
            }

            StringBuilder result = new StringBuilder();

            //This is very inefficient with large amounts, but it should be fine for 'reasonable' amounts
            for (int counter100 = 0; counter100 <= units100; counter100++)
            {
                int remaining = amount - counter100 * 100;

                int units50 = remaining / 50;
                int total50 = units50 * 50;

                for (int counter50 = 0; counter50 <= units50; counter50++)
                {
                    int remaining2 = remaining - counter50 * 50;
                    result.Append(formatResult(counter100, counter50, remaining2 / 10));
                }
            }

            return result.ToString();
        }

        private static string formatResult(int quant100, int quant50, int quant10)
        {
            StringBuilder result = new StringBuilder();

            if (quant100 == 0 && quant50 == 0 && quant10 == 0)
            {
                return "There's no available cartridge for that amount";
            }   

            if (quant100 > 0)
            {
                result.Append(quant100 + " x 100 EUR");
            }

            if (quant50 > 0)
            {
                if (result.Length > 0)
                {
                    result.Append(" + ");
                }

                result.Append(quant50 + " x 50 EUR");
            }

            if (quant10 > 0)
            {
                if (result.Length > 0)
                {
                    result.Append(" + ");
                }
                result.Append(quant10 + " x 10 EUR");
            }

            result.Append("\n");

            return result.ToString();
        }
    }
}
