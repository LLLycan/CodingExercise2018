using DataHelper;
using MarkdownLog;
using SportsCategory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise2018
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string filePath = "../../../football.dat";

                // Give file path, initialize generic type constructor, processing data and sorted data list
                List<Soccer> sortedList = DataHandler.GetSortedDataList(filePath, (name, scoresF, scoresA) => new Soccer(name, scoresF, scoresA));

                // Print out sorted list
                Console.WriteLine("Team information (Name, For, Against, Difference) from .DAT file are:" + "\n");

                CreateTableView(sortedList);

                // Print out Smallest Scores Difference list
                var resultList = DataHandler.GetSmallestScoresDifference(sortedList);

                Console.WriteLine("Team with the smallest difference in ‘for’ and ‘against’ goals are:" + "\n");

                CreateTableView(resultList);
            }
            catch (FileNotFoundException)
            {
                // Show instruction of File not exist
                Console.WriteLine("File not exists! Please provide a valid file path.");
            }
            catch (TimeoutException)
            {
                // Show instruction of handle data time out
                Console.WriteLine("Timeout! Please try again.");
            }
            catch (InvalidDataException)
            {
                // Show instruction of dataset format invalid
                Console.WriteLine("DataSet Invalid! Please make sure your data format is correct.");
            }
            catch (Exception)
            {
                // Show instruction of unknow error
                Console.WriteLine("Unknown error! Please try later.");
            }
            Console.ReadKey();
        }

        public static void CreateTableView(List<Soccer> dataList)
        {
            // Print result as table view on Console
            Console.WriteLine(dataList.Select(d => new
            {
                Name = d.SportName,
                For = d.SoccerScoresA,
                Against = d.SoccerScoresF,
                Difference = d.ScoresDifference,
            }).ToMarkdownTable());
        }
    }
}
