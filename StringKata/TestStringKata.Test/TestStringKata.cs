using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringKata;

namespace TestStringKata.Test
{
    [TestFixture]
    public class TestStringKata
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            string number="";
            int Expected = 0;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected,result);
        }

        private CalcKata CreateCalcKata()
        {
            return new CalcKata();
        }

        [Test]
        public void Add_GivenOne_ShouldReturn1()
        {
            //---------------Set up test pack-------------------
            string number = "1";
            int Expected = 1;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenTwoDigits_ShouldReturn3()
        {
            //---------------Set up test pack-------------------

            string number = "1,2";
            int Expected = 3;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenTwoDigits_ShouldReturn5()
        {
            //---------------Set up test pack-------------------
            string number = "3,2";
            int Expected = 5;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenTwoDigitsWithSpace_ShouldReturn15()
        {
            //---------------Set up test pack-------------------
            string number = "10\n2,3";
            int Expected = 15;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenDelimiter_ShouldReturn3()
        {
            //---------------Set up test pack-------------------
            string number = "//;\n1;2";
            int Expected = 3;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenDelimiter_ShouldReturn6()
        {
            //---------------Set up test pack-------------------
            string number = "//.\n1,2.3";
            int Expected = 6;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var number = "//.\n1,-10.3";
            var Expected = "Negative numbers not allowed -10";
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<Exception>(() => calcKata.Add(number));
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, exception.Message);
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldThrowExceptionContainingAllNegativeNumber()
        {
            //---------------Set up test pack-------------------
            var number = "//.\n1,-10,2.3.-50";
            var Expected = "Negative numbers not allowed -10-50";
            var calcKata = CreateCalcKata();

            //---------------Execute Test ----------------------
            var exception = Assert.Throws<Exception>(() => calcKata.Add(number));
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, exception.Message);
        }

        [Test]
        public void Add_GivenNumberGreaterThan10000_ShouldBeIgnored()
        {
            //---------------Set up test pack-------------------
            string number = "//.\n1,1000,2.3.1250";
            int Expected = 1006;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenAnyDelimiterLenght_ShouldReturn6()
        {
            //---------------Set up test pack-------------------
            string number = "//[***]\n1***2***3";
            int Expected = 6;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenMultipleDelimiters_ShouldReturn6()
        {
            //---------------Set up test pack-------------------
            string number = "//[*][%]\n1*2%3";
            int Expected = 6;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void Add_GivenMultipleDelimitersWithLenghtLongerThan1Char_ShouldReturn6()
        {
            //---------------Set up test pack-------------------
            string number = "//[****][%%%%][----]\n1****2%%%%3";
            int Expected = 6;
            var calcKata = CreateCalcKata();
            //---------------Execute Test ----------------------
            var result = calcKata.Add(number);
            //---------------Test Result -----------------------
            Assert.AreEqual(Expected, result);
        }
    }
}
