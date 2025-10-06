using System;
using System.Collections.Generic;
using System.Linq;

namespace ICETASK2_ST10375530
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Collections Assignment ===\n");

            // Task 1: Working with Dictionaries
            Task1_StudentDictionary();

            Console.WriteLine("\n");

            // Task 3: Working with Sets
            Task3_CourseCodes();

            Console.WriteLine("\n");

            // Task 4: Set Operations
            Task4_SetOperations();

            Console.WriteLine("\n=== End of Assignment ===");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void Task1_StudentDictionary()
        {
            Console.WriteLine("TASK 1: Student Dictionary");
            Console.WriteLine(new string('-', 40));

            Dictionary<int, string> students = new Dictionary<int, string>();

            // Adding mock data
            students.Add(101, "Sarah Mitchell");
            students.Add(102, "James Anderson");
            students.Add(103, "Emma Thompson");

            Console.WriteLine("Mock student records have been added.");
            Console.WriteLine("\nWould you like to add more students? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            while (response == "yes" || response == "y")
            {
                try
                {
                    Console.Write("\nEnter Student ID (number): ");
                    int studentId = int.Parse(Console.ReadLine());

                    if (students.ContainsKey(studentId))
                    {
                        Console.WriteLine($"Error: Student ID {studentId} already exists. Please use a different ID.");
                        continue;
                    }

                    Console.Write("Enter Student Name: ");
                    string studentName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentName))
                    {
                        Console.WriteLine("Error: Student name cannot be empty.");
                        continue;
                    }

                    students.Add(studentId, studentName);
                    Console.WriteLine($"Successfully added: {studentName} with ID {studentId}");

                    Console.Write("\nAdd another student? (yes/no): ");
                    response = Console.ReadLine().ToLower();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid number for Student ID.");
                    Console.Write("\nTry again? (yes/no): ");
                    response = Console.ReadLine().ToLower();
                }
            }

            Console.WriteLine("\n--- All Student Records ---");
            foreach (var student in students.OrderBy(s => s.Key))
            {
                Console.WriteLine($"ID: {student.Key} - Name: {student.Value}");
            }

            // Demonstrating lookup
            Console.Write("\nEnter a Student ID to look up (or press Enter to skip): ");
            string lookupInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(lookupInput) && int.TryParse(lookupInput, out int lookupId))
            {
                if (students.ContainsKey(lookupId))
                {
                    Console.WriteLine($"Found: {students[lookupId]}");
                }
                else
                {
                    Console.WriteLine($"No student found with ID: {lookupId}");
                }
            }
        }

        static void Task3_CourseCodes()
        {
            Console.WriteLine("TASK 3: Course Codes HashSet");
            Console.WriteLine(new string('-', 40));

            HashSet<string> courseCodes = new HashSet<string>();

            // Adding course codes
            courseCodes.Add("CLDV6212");
            courseCodes.Add("PROG7312");
            courseCodes.Add("INSY7314");

            Console.WriteLine("Course codes have been added.");
            Console.WriteLine("\nWould you like to add more course codes? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            while (response == "yes" || response == "y")
            {
                Console.Write("\nEnter Course Code (e.g., CLDV6212): ");
                string courseCode = Console.ReadLine().ToUpper().Trim();

                if (string.IsNullOrWhiteSpace(courseCode))
                {
                    Console.WriteLine("Error: Course code cannot be empty.");
                    Console.Write("\nTry again? (yes/no): ");
                    response = Console.ReadLine().ToLower();
                    continue;
                }

                bool wasAdded = courseCodes.Add(courseCode);

                if (wasAdded)
                {
                    Console.WriteLine($"Successfully added: {courseCode}");
                }
                else
                {
                    Console.WriteLine($"'{courseCode}' already exists in the system. Duplicate not added.");
                }

                Console.Write("\nAdd another course code? (yes/no): ");
                response = Console.ReadLine().ToLower();
            }

            Console.WriteLine("\n--- All Course Codes ---");
            foreach (string code in courseCodes.OrderBy(c => c))
            {
                Console.WriteLine($"  - {code}");
            }

            Console.WriteLine($"\nTotal unique courses: {courseCodes.Count}");
        }

        static void Task4_SetOperations()
        {
            Console.WriteLine("TASK 4: Set Operations with Student Names");
            Console.WriteLine(new string('-', 40));

            HashSet<string> mathClass = new HashSet<string>
            {
                "Alice Johnson",
                "Bob Smith",
                "Charlie Davis"
            };

            HashSet<string> scienceClass = new HashSet<string>
            {
                "Charlie Davis",
                "Diana Prince",
                "Frank Miller"
            };

            Console.WriteLine("Students have been added to both classes.");

            // Add students to Math class
            Console.WriteLine("\n--- Adding Students to Math Class ---");
            Console.Write("Would you like to add students to Math class? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            while (response == "yes" || response == "y")
            {
                Console.Write("Enter student name for Math class: ");
                string studentName = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(studentName))
                {
                    Console.WriteLine("Error: Student name cannot be empty.");
                    Console.Write("\nTry again? (yes/no): ");
                    response = Console.ReadLine().ToLower();
                    continue;
                }

                bool wasAdded = mathClass.Add(studentName);

                if (wasAdded)
                {
                    Console.WriteLine($"Added {studentName} to Math class.");
                }
                else
                {
                    Console.WriteLine($"{studentName} is already in Math class.");
                }

                Console.Write("\nAdd another student to Math? (yes/no): ");
                response = Console.ReadLine().ToLower();
            }

            // Add students to Science class
            Console.WriteLine("\n--- Adding Students to Science Class ---");
            Console.Write("Would you like to add students to Science class? (yes/no): ");
            response = Console.ReadLine().ToLower();

            while (response == "yes" || response == "y")
            {
                Console.Write("Enter student name for Science class: ");
                string studentName = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(studentName))
                {
                    Console.WriteLine("Error: Student name cannot be empty.");
                    Console.Write("\nTry again? (yes/no): ");
                    response = Console.ReadLine().ToLower();
                    continue;
                }

                bool wasAdded = scienceClass.Add(studentName);

                if (wasAdded)
                {
                    Console.WriteLine($"Added {studentName} to Science class.");
                }
                else
                {
                    Console.WriteLine($"{studentName} is already in Science class.");
                }

                Console.Write("\nAdd another student to Science? (yes/no): ");
                response = Console.ReadLine().ToLower();
            }

            // Display class rosters
            Console.WriteLine("\n--- Class Rosters ---");
            Console.WriteLine("\nMath Class Students:");
            foreach (string student in mathClass.OrderBy(s => s))
            {
                Console.WriteLine($"  - {student}");
            }

            Console.WriteLine("\nScience Class Students:");
            foreach (string student in scienceClass.OrderBy(s => s))
            {
                Console.WriteLine($"  - {student}");
            }

            // Intersection - students in both classes
            HashSet<string> bothClasses = new HashSet<string>(mathClass);
            bothClasses.IntersectWith(scienceClass);

            Console.WriteLine("\n--- Set Operations Results ---");
            Console.WriteLine("\nStudents in BOTH classes (Intersection):");
            if (bothClasses.Count > 0)
            {
                foreach (string student in bothClasses.OrderBy(s => s))
                {
                    Console.WriteLine($"  - {student}");
                }
            }
            else
            {
                Console.WriteLine("  No students are in both classes.");
            }

            // Difference - students only in Math
            HashSet<string> onlyMath = new HashSet<string>(mathClass);
            onlyMath.ExceptWith(scienceClass);

            Console.WriteLine("\nStudents ONLY in Math class (Difference):");
            if (onlyMath.Count > 0)
            {
                foreach (string student in onlyMath.OrderBy(s => s))
                {
                    Console.WriteLine($"  - {student}");
                }
            }
            else
            {
                Console.WriteLine("  All Math students are also in Science class.");
            }

            // Union - all students
            HashSet<string> allStudents = new HashSet<string>(mathClass);
            allStudents.UnionWith(scienceClass);

            Console.WriteLine("\nALL students (Union):");
            foreach (string student in allStudents.OrderBy(s => s))
            {
                Console.WriteLine($"  - {student}");
            }

            Console.WriteLine($"\nTotal unique students across both classes: {allStudents.Count}");
        }
    }
}
