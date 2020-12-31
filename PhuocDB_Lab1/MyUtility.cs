using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhuocDB_Lab1
{
    class MyUtility
    {
        public static void GetString(out string result, string msg, string alert1, string alert2, string pattern)
        {
            while (true)
            {
                try
                {
                    Console.Write(msg);
                    result = Console.ReadLine();
                    if (result.Trim() == string.Empty)
                    {
                        Console.WriteLine(alert1);
                    }
                    else if(!Regex.IsMatch(result, pattern))
                    {
                        Console.WriteLine(alert2);
                    }
                    else
                    {
                        break;
                    }
                }
                catch(Exception e)
                {
                }
            }
        }
        public static void GetFloat(out float result, string msg, string alert, string errorParsing)
        {
            while (true)
            {
                try
                {
                    Console.Write(msg);
                    result = (float)Convert.ToDouble(Console.ReadLine());
                    if(result <= 0)
                    {
                        Console.WriteLine(alert);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(errorParsing);
                }
            }
        }
    }
}
