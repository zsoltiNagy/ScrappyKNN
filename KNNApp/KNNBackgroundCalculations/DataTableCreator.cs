using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    
    public class DataTableCreator
    {
        public DataTable MyDataTable { get; private set; }

        public DataTableCreator(string filePath)//string[] lines)
        {
            // Get the file's text.
            string rawData = File.ReadAllText(filePath);
            rawData = rawData.Replace('\n', '\r');
            rawData = rawData.Replace('\t', ',');
            string[] lines = rawData.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);
            MyDataTable = Create(lines);
        }

        private Type[] GetDataTypes(string row)
        {
            string[] line = row.Split(',');
            Type[] types = new Type[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                if (Double.TryParse(line[i], out double number))
                {
                    types[i] = typeof(Double);
                } else
                {
                    types[i] = typeof(String);
                }

            }
            return types;
        }

        private DataTable Create(string[] lines)
        {
            DataTable table = new DataTable();
            Type[] types = GetDataTypes(lines[0]);

            int x = lines[0].Split(',').Length;

            for (int i = 0; i<x; i++)
            {
                table.Columns.Add(i.ToString(), types[i]);
            }

            Console.WriteLine(table.Columns.Count);

            foreach (var line in lines)
            {
                string[] row = line.Split(',');
                object[] cells = new object[row.Length];
                for ( int i = 0; i<row.Length; i++)
                {
                    if (Double.TryParse(row[i], out double number))
                    {
                        cells[i] = number;
                    } else
                    {
                        cells[i] = row[i];
                    }
                }
                Console.WriteLine(cells.Length);
                table.Rows.Add(cells);

            }
            return table;
        }
    }

}
