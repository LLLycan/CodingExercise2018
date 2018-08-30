using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsCategory;
using System.IO;
using System.Diagnostics;

namespace DataHelper.Tests
{
    [TestClass()]
    public class DataHandlerTests
    {
        /// <summary>
        /// Unit testing - show throw 'FileNotFoundException' when read invalid file path
        /// </summary>
        [TestMethod()]
        public void ShouldThrowFileNotFoundException()
        {
            //arrange
            string filePath = "../../../football_notExist.dat";
            string actualType = string.Empty;
            string expectedType = "FileNotFoundException";

            //act
            try
            {
                DataHandler.GetSortedDataList(filePath, (name, scoresF, scoresA) => new Soccer(name, scoresF, scoresA));
            }
            catch (Exception e)
            {
                actualType = e.GetType().Name;
            }
            // Assert
            Assert.AreEqual(expectedType, actualType);
        }


        /// <summary>
        /// Unit testing - show throw 'TimeoutException' when data processing timeout
        /// </summary>
        [TestMethod()]
        public void ShouldThrowTimeoutException()
        {
            //arrange
            string filePath = "../../../football.dat";
            string actualType = string.Empty;
            string expectedType = "TimeoutException";
            Stopwatch sw = new Stopwatch();

            //act
            try
            {
                sw.Start();

                DataHandler.GetSortedDataList(filePath, (name, scoresF, scoresA) => new Soccer(name, scoresF, scoresA));

                if (sw.ElapsedMilliseconds > 10000)
                {
                    throw new TimeoutException();
                }
            }
            catch (Exception e)
            {
                actualType = e.GetType().Name;
            }
            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        /// <summary>
        /// Unit testing - show throw 'InvalidDataException' when data file format invalid
        /// </summary>
        [TestMethod()]
        public void ShouldThrowInvalidDataException()
        {
            //arrange
            string filePath = "../../../football_InvalidData.dat";
            string actualType = string.Empty;
            string expectedType = "InvalidDataException";

            //act
            try
            {
                DataHandler.GetSortedDataList(filePath, (name, scoresF, scoresA) => new Soccer(name, scoresF, scoresA));
            }
            catch (Exception e)
            {
                actualType = e.GetType().Name;
            }
            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        /// <summary>
        /// Unit testing - Assert AreEqual is true when value is digital number
        /// </summary>
        [TestMethod()]
        public void DigitalValueInputWillPass()
        {
            //arrange
            bool expected = true;
            //act
            bool actual = DataHandler.IsDigitalValue("55");
            //assert
            Assert.AreEqual(expected, actual); 
        }

        /// <summary>
        /// Unit testing - Assert AreNotEqual is true when value is not a digital number
        /// </summary>
        [TestMethod()]
        public void NonDigitalValueInputWillPass() 
        {
            //arrange
            bool expected = true;
            //act
            bool actualString = DataHandler.IsDigitalValue("abc");
            bool actualChar = DataHandler.IsDigitalValue("@#");
            //assert
            Assert.AreNotEqual(expected, actualString);
            Assert.AreNotEqual(expected, actualChar);
        }
    }
}