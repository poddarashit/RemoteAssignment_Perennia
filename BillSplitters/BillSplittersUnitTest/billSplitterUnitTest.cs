using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillSplitters;
using System.Collections.Generic;
using System;
using System.Collections;


namespace BillSplittersUnitTest
{
    [TestClass]
    public class billSplitterUnitTest
    {
        [TestMethod]
        public void billSplitTripExpenseMethod()
        {
            List<double> bill = new List<double>();
            bill.Add(3);
            bill.Add(2);
            bill.Add(30.00);
            bill.Add(12.00);
            bill.Add(4);
            bill.Add(15.00);
            bill.Add(15.01);
            bill.Add(9.00);
            bill.Add(3.01);
            bill.Add(3);
            bill.Add(5);
            bill.Add(74);
            bill.Add(4);
            bill.Add(2);
            bill.Add(2);
            bill.Add(12.01);
            bill.Add(6);
            bill.Add(2);
            bill.Add(8.95);
            bill.Add(7.75);
            bill.Add(0);
            var billSplit = new Program();
            double[] testResult = billSplit.calculationTripExpense(bill, 0);
            double[] result = {42.00, 42.02, 83.00, 12};


            for (int i=0; i< testResult.Length; i++)
            {
                testResult[i] = Math.Round(testResult[i], 2);
            }
           
            CollectionAssert.AreEqual(result, testResult);
        }

        [TestMethod]
        public void Testbill()
        {
            var billsplit = new Program();

            double[] array = { 42, 42.02, 83 };

            ArrayList testArr = new ArrayList();
            testArr.Add(array);

            string testfile = "test.txt";

            billsplit.calculatingIndividualShare(testArr, testfile);
        }

    }
}
