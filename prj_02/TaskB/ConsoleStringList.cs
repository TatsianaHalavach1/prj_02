using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskB
{
    class ConsoleStringList
    {

        List<int> IntLines;//list of ints
        List<double> DoubleLines;//list of doubles
        List<string> NotNumberLines;//list of not-numbers

        //Singleton realization
        private static ConsoleStringList instance;
        private ConsoleStringList()
        {
            IntLines = new List<int>();
            DoubleLines = new List<double>();
            NotNumberLines = new List<string>();
        }
        public static ConsoleStringList GetInstance()
        {
            if (instance == null)
            {
                instance = new ConsoleStringList();
            }
            return instance;
        }

        //add and filter: int, double, notNumber
        public void addStringToList(string currentLine)
        {
            if (int.TryParse(currentLine, out int ivalue))
            {
                IntLines.Add(ivalue);
            }
            else if (double.TryParse(currentLine, out double dvalue))
            {
                DoubleLines.Add(dvalue);
            }
            else
            {
                NotNumberLines.Add(currentLine);
            }
        }
        public int GetIntAmount()
        {
            return IntLines.Count;
        }
        public int GetDoubleAmount()
        {
            return DoubleLines.Count;
        }

        public string ShowAllIntWithAverage()
        {
            StringBuilder resultOfMethod = new StringBuilder("Int numbers with average value:\n");//Result string
            double average = 0;
            foreach (int ivalue in IntLines)
            {
                average += ivalue;
                resultOfMethod.AppendLine(ivalue.ToString().PadLeft(50));
            }
            average /= GetIntAmount();
            resultOfMethod.AppendLine(string.Format($"Avg: {average}").PadLeft(50));
            return resultOfMethod.ToString();
        }
        public string ShowAllDoubleWithAverage()
        {
            StringBuilder resultOfMethod = new StringBuilder("Double numbers with average value:\n");//Result string
            double average = 0;
            foreach (double dvalue in DoubleLines)
            {
                average += dvalue;
                resultOfMethod.AppendLine(string.Format("{0:0.##}", dvalue).PadLeft(50));
            }
            average /= GetDoubleAmount();
            resultOfMethod.AppendLine(string.Format($"Avg: {average}").PadLeft(50));
            return resultOfMethod.ToString();
        }

        public string ShowAllNotNumbers()
        {
            var varNotNumber = NotNumberLines.OrderBy(nN => nN.Length).ThenBy(nN => nN);
            List<string> NotNumbersSorted = varNotNumber.ToList<string>();
            string resultOfMethod = string.Join("\n", NotNumbersSorted);
            return string.Format($"Sorted list of not-numbers:\n{resultOfMethod}");
        }

        public string showAll()
        {
            return ShowAllIntWithAverage() + ShowAllDoubleWithAverage() + ShowAllNotNumbers();
        }
    }
}
