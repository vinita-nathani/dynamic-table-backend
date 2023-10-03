using System;
using System.Collections.Generic;
using System.Linq;
using dynamic_table_backend.Controllers;

namespace dynamic_table_backend.Services
{
    public class generateTimetableService
    {
        private Dictionary<string, int> subjectAndHrs = new Dictionary<string, int>();
        private int noOfWorkingDays = 0;
        private int noOfSubjectPerDay = 0;
        private string[,] timeTable;    

        public List<List<string>> GenerateTimeTable(Form request)
        {
            // Calculate the total hours for the week
            int totalHrsForWeek = request.WorkingDays * request.TotalSubjects;
            Console.WriteLine("Total hours for the week: " + totalHrsForWeek);

            // or (int i = 0; i < request.TotalSubjects; i++)
            // {
            //    Console.Write("Enter Subject-" + (i + 1) + " name: ");
            //    string subName = Console.ReadLine();
            //    Console.Write("Enter Subject-" + (i + 1) + " Hrs per week: ");
            //    string subHrs_String = Console.ReadLine();
            //    int subHrs = int.Parse(subHrs_String);

            //    subjectAndHrs[subName] = subHrs;
            // }

            foreach (var i in request.SubjectAndHrs)
            {
                // Add or update the dictionary with student ID and name
                subjectAndHrs[i.SubName] = i.SubHrs;
            }


            List<int> keysList = subjectAndHrs.Values.ToList();
            // Validation
            if (keysList.Sum() != totalHrsForWeek)
            {
                Console.WriteLine("Please validate total hours.");
                return null; // Or an appropriate error code
            }

            // Initialize the timetable array with new and updated dimensions
            noOfWorkingDays = request.WorkingDays;
            noOfSubjectPerDay = request.TotalSubjects;
            timeTable = new string[noOfWorkingDays, noOfSubjectPerDay];

            for (int i = 0; i < noOfWorkingDays; i++)
            {
                for (int j = 0; j < noOfSubjectPerDay; j++)
                {
                    if (i < timeTable.GetLength(0) && j < timeTable.GetLength(1))
                    {
                        Console.WriteLine($"Enter value for element at row {i + 1}, column {j + 1}: ");
                        timeTable[i, j] = RandomGen();
                    }
                    else
                    {
                        Console.WriteLine("The timetable array dimensions are exceeded.");
                        // Handle this case as needed
                    }
                }
            }

            var resultList = new List<List<string>>();
            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                var rowList = new List<string>();
                for (int j = 0; j < timeTable.GetLength(1); j++)
                {
                    rowList.Add(timeTable[i, j]);
                }
                resultList.Add(rowList);
            }

            return resultList;
        }

        private string RandomGen()
        {
            List<string> subjectsKeys = new List<string>(subjectAndHrs.Keys);
            Random random = new Random();

            // Generate a random index.
            int randomSubjects = random.Next(subjectsKeys.Count);

            // Get the random key and its corresponding value from the dictionary.
            string randomKey = subjectsKeys[randomSubjects];
            subjectAndHrs[randomKey] -= 1;
            if (subjectAndHrs[randomKey] == 0)
            {
                subjectAndHrs.Remove(randomKey);
            }

            return randomKey;
        }
        //private void PrintTimeTable()
        //{
        //    for (int i = 0; i < timeTable.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < timeTable.GetLength(1); j++)
        //        {
        //            Console.Write(timeTable[i, j] + "\t");
        //        }
        //        Console.WriteLine(); // Move to the next row
        //    }
        //}
    }
}
