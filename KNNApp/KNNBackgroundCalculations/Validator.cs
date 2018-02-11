using System;
using System.IO;

namespace KNNBackgroundCalculations
{
    public class CsvValidator
    {
        public Boolean Result { get; private set; }
        public CsvValidator(string filePath)
        {
            string fileType = filePath.Substring(filePath.Length - 4, 4);
            if (!fileType.Equals(".csv"))
            {
                Result = false;
            }
            else
            {
                // Get the file's text.
                string rawData = File.ReadAllText(filePath);
                rawData = rawData.Replace('\n', '\r');
                rawData = rawData.Replace('\t', ',');
                string[] lines = rawData.Split(new char[] { '\r' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (CheckRowLength(lines) && CheckTypeConsistency(lines))
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
        }

        /// <summary>
        /// Checks if every line in lines has the same type in every column.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Boolean</returns>
        private Boolean CheckTypeConsistency(string[] lines)
        {
            var baseLine = lines[0].Split(',');
            int benchmark = baseLine.Length;
            Type[] types = new Type[benchmark];
            double number;
            for (int i = 0; i < benchmark; i++)
            {
                if (Double.TryParse(baseLine[i], out number))
                {
                    types[i] = number.GetType();
                }
                else
                {
                    types[i] = baseLine[i].GetType();
                }
            }

            foreach (var line in lines)
            {
                var currentLine = line.Split(',');
                for (int i = 0; i < benchmark; i++)
                {
                    if (Double.TryParse(currentLine[i], out number))
                    {
                        if (!number.GetType().Equals(types[i]))
                        {
                            return false;
                        }
                    }
                    else if (!currentLine[i].GetType().Equals(types[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if the rows in the csv are equal.
        /// </summary>
        /// <param name="lines"> A string array containing every line of the csv as a string.</param>
        /// <returns> A boolean, corresponding to the methods function. </returns>
        private Boolean CheckRowLength(string[] lines)
        {
            int benchmark = lines[0].Split(',').Length;
            foreach (var line in lines)
            {
                if (line.Split(',').Length != benchmark)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
