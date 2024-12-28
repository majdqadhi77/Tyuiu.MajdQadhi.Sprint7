using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

using Tyuiu.MajdQadhi.Sprint7.Project.V12.Lib;

namespace Tyuiu.MajdQadhi.Sprint7.Project.V12.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetData()
        {
            DataService ds = new DataService();

            string path = @"C:\Users\KILIAN\source\repos\Tyuiu.MajdQadhi.Sprint7\Tyuiu.MajdQadhi.Sprint7.Project.V12\bin\Back-end\personal_computer.csv";
            string[,] res = ds.GetData(path);

            string[,] wait = {
                { "MSI", "AMD Ryzen 5 3600", "8", "3,5", "16", "1000", "01.01.2020", "40000" },
                { "ASUS", "AMD Ryzen 7 1600", "6", "3,7", "16", "1000", "09.10.2015", "35000" }
            };

            CollectionAssert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ValidAverageValue()
        {
            DataService ds = new DataService();

            double[] arrayNums = { 1, 2, 3 };

            double res = ds.AverageValue(arrayNums);

            double wait = 2;

            Assert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ValidMinValue()
        {
            DataService ds = new DataService();

            double[] arrayNums = { 1, 2, 3 };

            double res = ds.MinValue(arrayNums);

            double wait = 1;

            Assert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ValidMaxValue()
        {
            DataService ds = new DataService();

            double[] arrayNums = { 1, 2, 3 };

            double res = ds.MaxValue(arrayNums);

            double wait = 3;

            Assert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ValidAddNewData()
        {
            DataService ds = new DataService();

            string path = @"C:\Users\KILIAN\Desktop\Копии экселей\test.csv";
            string[] arrayNums = { "Test", "Test", "Test" };

            bool res = ds.AddNewData(path, arrayNums);

            bool wait = true;

            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidUpdateData()
        {
            DataService ds = new DataService();

            string path = @"C:\Users\KILIAN\Desktop\Копии экселей\test.csv";

            string[,] data = {
                { "AKA", "AKA", "AKA" },
                { "AKA", "AKA", "AKA" },
                { "AKA", "AKA", "AKA" },
                { "AKA", "AKA", "AKA" },
                { "AKA", "AKA", "AKA" }
            };

            bool res = ds.UpdateData(path, data);

            bool wait = true;

            Assert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ValidGetPrice()
        {
            DataService ds = new DataService();

            string[,] matrix = {
                { "123456", "123456", "123456", "123456", "123456", "123456", "123456", "123456" },
                { "123456", "123456", "123456", "123456", "123456", "123456", "123456", "123456" },
                { "123456", "123456", "123456", "123456", "123456", "123456", "123456", "123456" }
            };
            double[] res = ds.GetPrice(matrix);

            double[] wait = { 123456, 123456, 123456 };

            CollectionAssert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ValidGetName()
        {
            DataService ds = new DataService();

            string[,] matrix = {
                { "MSI", "123456", "123456", "123456", "123456", "123456", "123456", "123456" },
                { "ASUS", "123456", "123456", "123456", "123456", "123456", "123456", "123456" },
                { "Gigabyte", "123456", "123456", "123456", "123456", "123456", "123456", "123456" }
            };
            string[] res = ds.GetNameManufacturer(matrix);

            string[] wait = { "MSI", "ASUS", "Gigabyte" };

            CollectionAssert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidGetCountRows()
        {
            DataService ds = new DataService();

            string[,] matrix = {
                { "MSI", "123456", "123456", "123456", "123456", "123456", "123456", "123456" },
                { "ASUS", "123456", "123456", "123456", "123456", "123456", "123456", "123456" },
                { "Gigabyte", "123456", "123456", "123456", "123456", "123456", "123456", "123456" }
            };
            int res = ds.GetCountRows(matrix);

            int wait = 3;

            Assert.AreEqual(wait, res);
        }
    }
}
