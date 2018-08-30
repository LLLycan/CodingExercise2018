using SportsCategory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataHelper
{
    public class DataHandler
    {
        /// <summary>
        /// Read & Convert & Sort a .dat file of data to a generic BaseSports type list.
        /// </summary>
        /// <typeparam name="T">A type that inherits from generic BaseSports type</typeparam>
        /// <param name="path">.dat file Path</param>
        /// <param name="createSortedList">Func for generic type constructor expression</param>
        /// <returns>List of SortedDataList</returns>
        public static List<T> GetSortedDataList<T>(string path, Func<string, string, string, T> createSortedList) where T : BaseSportsCategory, new()
        {
            List<T> dataList = new List<T>();
            string[] rawText = null;
            string[] dataColoumns = null;

            //Initial processing time
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (true)
            {
                // Check if file exists
                if (!File.Exists(path + ""))
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    rawText = File.ReadAllLines(path);
                }

                foreach (var raw in rawText)
                {
                    // Get coloumns for each row, and remove empty or extra blank
                    dataColoumns = raw.Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries); // Get coloumns for each row, and remove empty or extra blank
                    
                    // Get index number of '-' for each row
                    int dashIndex = Array.FindIndex(dataColoumns, w => w.ToString() == "-");

                    // Get index number of 'For' for each row
                    int forIndex = dashIndex - 1;

                    // Get index number of 'Against' for each row
                    int againstIndex = dashIndex + 1;

                    //Skip header row
                    if (dataColoumns.Length == 10) 
                    {
                        // Check if 'For' & 'Against' column is digital
                        if (IsDigitalValue(dataColoumns[forIndex]) && IsDigitalValue(dataColoumns[againstIndex])) 
                        {
                            T data = createSortedList(dataColoumns[1], dataColoumns[forIndex], dataColoumns[againstIndex]);
                            dataList.Add(data);
                        }
                        else
                        {
                            throw new InvalidDataException();
                        }
                    }
                }

                // Check if time out when processing a big data file
                if (sw.ElapsedMilliseconds > 10000) 
                {
                    throw new TimeoutException();
                }

                // Sorted list by scores difference
                return dataList.OrderBy(x => x.ScoresDifference).ToList();
            }
        }

        /// <summary>
        /// Grab the top 1 record in the List
        /// </summary>
        /// <typeparam name="T">A type that inherits from generic BaseSports type</typeparam>
        /// <param name="dataList">.dat file Path</param>
        /// <returns>Top 1 record</returns>
        public static List<T> GetSmallestScoresDifference<T>(List<T> dataList) where T : BaseSportsCategory
        {
            List<T> resultDataList = new List<T>();

            int smallestDifference = dataList.First().ScoresDifference;

            // Grab the smallest record of score difference
            return dataList.FindAll(d => d.ScoresDifference == smallestDifference);
        }

        /// <summary>
        /// Check if value is digital number
        /// </summary>
        /// <param name="value">string value from data column</typeparam>
        /// <returns>True or False</returns>
        public static bool IsDigitalValue(string value)
        {
            if (Regex.IsMatch(value, @"\d"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
