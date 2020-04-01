using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace BillSplitters
{
    public class Program
    {
        public double[] calculationTripExpense(List<double> testList, int iteration)
        {
            // function to calculate the sum of amount paid by individual member during the trip
            //returns an array of sum
            try
            {
                int numberOfPerson = Convert.ToInt32(testList[iteration]);
                int sizeofArray = numberOfPerson + 1;
                double[] expenseArray = new double[sizeofArray];

                for (int i = 0; i < numberOfPerson; i++)
                {
                    iteration++;
                    int count = Convert.ToInt32(testList[iteration]);
                    double sum = 0;

                    for (int j = 0; j < count; j++)
                    {
                        iteration++;

                        sum = sum + testList[iteration];
                    }
                    // Assigning the value of individual shares to an expenseArray.
                    expenseArray[i] = sum;

                }
                expenseArray[expenseArray.Length - 1] = iteration;
                return expenseArray;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Index Out Of Range Exception in calculationTripExpense: " + e.Message);
                return new double[0];
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Invalid Cast Exception in calculationTripExpense: " + e.Message);
                return new double[0];
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in calculationTripExpense: " + e.Message);
                return new double[0];
            }
        }


        public void calculatingIndividualShare(ArrayList myList, String textfile)
        {
            //This function calculates the individual shares that needs to be paid or received and writes it to output file.
            try
            {
                //Output file will be generated during runtime from where the program is running.
                //open the file in write mode
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(textfile + ".out"))
                {
                    foreach (double[] obj in myList)
                    {
                        double totalExpenditure = 0;
                        double individualShare = 0;
                        int arrSize = obj.Length;
                        foreach (double i in obj)
                        {
                            //total expenditure of the trip by all members of the trip
                            totalExpenditure = totalExpenditure + i;
                        }
                        //calculating individual shares from the trip that is average value
                        individualShare = totalExpenditure / arrSize;

                        double share = 0;

                        foreach (double i in obj)
                        {
                            share = i - individualShare;
                            share = Math.Round(share, 3);       // rounding the share value to 3 digit after decimal
                            if (share < 0)
                            {
                                share = Math.Abs(share);        // taking absolute value of the share
                                file.WriteLine("{$" + share + "}");     // writing the share value to output file
                            }
                            else
                            {
                                file.WriteLine("$" + share);        // writing the share value to output file
                            }

                        }
                        file.WriteLine("");         // Adding a blank line to differentiate between 2 trips to output file

                    }
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Index Out Of Range Exception in calculatingIndividualShare: " + e.Message);
            }
           catch(FileNotFoundException e) 
            {
                Console.WriteLine("File Not Found Exception in calculatingIndividualShare: " + e.Message);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Divide by Zero Exception in calculatingIndividualShare: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception in calculatingIndividualShare: " + e.Message);
            }
        }

        static void Main(string[] args)
        {
            //Creating object of Class Program
            var prog = new Program();
            try
            {
                //Reading the name of file from the arguments
                String textfile = args[0];
                List<double> testList = new List<double>();         
                int iteration = 0;

                //Reading the text file 
                if (File.Exists(textfile))
                {
                    int counter = 0;
                    using (StreamReader file = new StreamReader(textfile))
                    {

                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            //Storing the value from text file to a list and counting the number 
                            //of number of element in list
                            testList.Add(Convert.ToDouble(ln));
                            counter++;
                        }
                    }

                    //Calling function calculationTripExpense to calculate the sum of amount paid by individual member during the trip

                    double[] sumArray = prog.calculationTripExpense(testList, iteration);

                    ArrayList finalSumArray = new ArrayList();
                    int lastItem = Convert.ToInt32(sumArray[sumArray.Length - 1]);
                    Array.Resize(ref sumArray, sumArray.Length - 1);

                    // SToring the result of calculationTripExpense function to a list of array
                    finalSumArray.Add(sumArray);

                    while (lastItem < counter - 2)
                    {
                        lastItem++;
                        sumArray = prog.calculationTripExpense(testList, lastItem);
                        lastItem = Convert.ToInt32(sumArray[sumArray.Length - 1]);
                        Array.Resize(ref sumArray, sumArray.Length - 1);
                        finalSumArray.Add(sumArray);
                    }

                    //calling calculatingIndividualShare for calculating the amount to be paid or 
                    //received from the trip and writing it to text file.
                    prog.calculatingIndividualShare(finalSumArray, textfile);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Index Out Of Range Exception in Main Method: " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found Exception in Main Method: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Main Method: " + e.Message);
            }

        }
        }

    }

