using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlShortener.Domain
{
    public static class IdEncoder
    {
        static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890".ToCharArray();

        static public string Encode(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0");
            }

            StringBuilder result = new StringBuilder();
            int workValue = id;
            while (workValue > 0)
            {
                int remainder = workValue % alphabet.Length;
                workValue = workValue / alphabet.Length;
                result.Append(alphabet[remainder]);
            }

            return result.ToString();
        }

        static public int Decode(string value)
        {
            long result = 0;
            foreach (var c in value.Reverse())
            {
                result = result * alphabet.Length;
                result += Array.IndexOf(alphabet, c);
            }
            return (int)result;
        }

    }
}
