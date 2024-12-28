using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyuiu.MajdQadhi.Sprint7.Project.V12.Lib
{
    public class DataService
    {
        public string[,] GetData(string path)
        {
            string fileData = File.ReadAllText(path, Encoding.GetEncoding(1251));
            fileData = fileData.Replace('\n', '\r');
            string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int rows = lines.Length;
            int columns = lines[0].Split(';').Length;

            string[,] arrayValues = new string[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < columns; c++)
                {
                    arrayValues[r, c] = line_r[c];
                }
            }
            return arrayValues;
        }
        public double AverageValue(double[] arrayNumber)
        {
            double avg = arrayNumber.Average();
            return avg;
        }
        public double MinValue(double[] arrayNumber)
        {
            double min = arrayNumber.Min();
            return min;
        }
        public double MaxValue(double[] arrayNumber)
        {
            double max = arrayNumber.Max();
            return max;
        }

        public bool AddNewData(string path, string[] line)
        {
            bool completed = false;

            string str = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (i != line.Length - 1)
                {
                    str = str + line[i] + ";";
                }
                else
                {
                    str = str + line[i];
                }
            }
            File.AppendAllText(path, str + Environment.NewLine, Encoding.GetEncoding(1251));
            completed = true;
            return completed;
        }

        public bool UpdateData(string path, string[,] data)
        {
            bool completed = false;

            File.WriteAllText(path, string.Empty);

            string str = "";

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (j != data.GetLength(1) - 1)
                    {
                        str = str + data[i, j] + ";";
                    }
                    else
                    {
                        str = str + data[i, j];
                    }
                }

                if (i != data.GetLength(0) - 1)
                {
                    File.AppendAllText(path, str + Environment.NewLine, Encoding.GetEncoding(1251));
                }
                else
                {
                    File.AppendAllText(path, str + Environment.NewLine, Encoding.GetEncoding(1251));
                }

                str = "";
            }

            completed = true;
            return completed;
        }

        public double[] GetPrice(string[,] matrix)
        {
            double[] priceArray = new double[matrix.GetLength(0)];

            for (int i = 0; i < priceArray.Length; i++)
            {
                priceArray[i] = Convert.ToDouble(matrix[i, 7]);
            }

            return priceArray;
        }

        public string[] GetNameManufacturer(string[,] matrix)
        {
            string[] nameArray = new string[matrix.GetLength(0)];

            for (int i = 0; i < nameArray.Length; i++)
            {
                nameArray[i] = matrix[i, 0];
            }

            return nameArray;
        }

        public int GetCountRows(string[,] matrix)
        {
            int countRows = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                countRows += 1;
            }

            return countRows;
        }
    }
}
