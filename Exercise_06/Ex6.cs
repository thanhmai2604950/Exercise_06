using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise_06
{
    internal class Ex6
    {
        static void Main()
        {
            Ex01_1();
            Ex01_2_1();
            Ex01_2_2();
            Ex01_2_3();
            Ex01_2_4();
            Ex02();
        }
        ///<summary>
        ///Ex 01
        ///1.Create a jagged array and initialize it using the following values for its rows and columns; Then, display it.
        ///1 1 1 1 1
        ///2 2
        ///3 3 3 3
        ///4 4
        /// </summary>
        static void Ex01_1()
        {
            // Tạo jagged array với 4 hàng
            int[][] jaggedArray = new int[4][];

            // Khởi tạo từng hàng
            jaggedArray[0] = new int[] { 1, 1, 1, 1, 1 };
            jaggedArray[1] = new int[] { 2, 2 };
            jaggedArray[2] = new int[] { 3, 3, 3, 3 };
            jaggedArray[3] = new int[] { 4, 4 };

            // In mảng
            Console.WriteLine("Jagged Array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
        ///<summary>
        ///2.Create a Jagged Array with random integer numbers (or by user input) by getting the number of rows and columns from the user and printing the data in the array to the user. Then, create functions to implement following tasks:
        ///1.Print the biggest number of each row and the largest number of the whole array.
        ///</summary>
        static void Ex01_2_1()
        {
            Console.Write("Nhap so hang: ");
            string? inputRows = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputRows))
            {
                Console.WriteLine("Invalid input for number of rows.");
                return;
            }
            int rows = int.Parse(inputRows);
            int[][] jaggedArray = new int[rows][];

            Random rnd = new Random();

            // Nhập số cột cho từng hàng và tạo mảng con
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Nhap so cot cho hang {i + 1}: ");
                string? inputCols = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputCols))
                {
                    Console.WriteLine("Invalid input for number of columns.");
                    return;
                }
                int cols = int.Parse(inputCols);
                jaggedArray[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = rnd.Next(1, 101); // random từ 1-100
                }
            }

            Console.WriteLine("\nMang jagged la:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Hang {i + 1}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Tìm số lớn nhất mỗi hàng
            Console.WriteLine("\nSo lon nhat cua tung hang:");
            int maxAll = int.MinValue;
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int maxRow = int.MinValue;
                foreach (int num in jaggedArray[i])
                {
                    if (num > maxRow)
                        maxRow = num;
                }
                Console.WriteLine($"Hang {i + 1}: {maxRow}");

                if (maxRow > maxAll)
                    maxAll = maxRow;
            }

            // Lớn nhất toàn bộ mảng
            Console.WriteLine($"\nSo lon nhat trong toan bo mang: {maxAll}");
        }
        ///<summary>
        ///2.Sort values ascending of each row.
        ///</summary>
        static void Ex01_2_2()
        {
            Console.Write("Nhap so hang: ");
            string? inputRows = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputRows))
            {
                Console.WriteLine("Invalid input for number of rows.");
                return;
            }
            int rows = int.Parse(inputRows);
            int[][] jaggedArray = new int[rows][];
            Random rnd = new Random();
            // Nhập số cột cho từng hàng và tạo mảng con
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Nhap so cot cho hang {i + 1}: ");
                string? inputCols = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputCols))
                {
                    Console.WriteLine("Invalid input for number of columns.");
                    return;
                }
                int cols = int.Parse(inputCols);
                jaggedArray[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = rnd.Next(1, 101); // random từ 1-100
                }
            }
            Console.WriteLine("\nMang jagged la:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Hang {i + 1}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            // Sắp xếp từng hàng
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Array.Sort(jaggedArray[i]);
            }
            Console.WriteLine("\nMang sau khi sap xep tung hang:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Hang {i + 1}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        ///<summary>
        ///3.Print items of the array that are prime.
        ///</summary>    
        static void Ex01_2_3()
        {
            Console.Write("Nhap so hang: ");
            string? inputRows = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputRows))
            {
                Console.WriteLine("Invalid input for number of rows.");
                return;
            }
            int rows = int.Parse(inputRows);
            int[][] jaggedArray = new int[rows][];
            Random rnd = new Random();
            // Nhập số cột cho từng hàng và tạo mảng con
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Nhap so cot cho hang {i + 1}: ");
                string? inputCols = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputCols))
                {
                    Console.WriteLine("Invalid input for number of columns.");
                    return;
                }
                int cols = int.Parse(inputCols);
                jaggedArray[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = rnd.Next(1, 101); // random từ 1-100
                }
            }
            Console.WriteLine("\nMang jagged la:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Hang {i + 1}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            // In số nguyên tố
            Console.WriteLine("\nCac so nguyen to trong mang:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (IsPrime(jaggedArray[i][j]))
                    {
                        Console.Write(jaggedArray[i][j] + " ");
                    }
                }
            }
        }
        // Helper method to check if a number is prime
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        ///<summary>
        ///4.Search and print all positions of a number (enter from the user).
        ///</summary>    
        static void Ex01_2_4()
        {
            Console.Write("Nhap so hang: ");
            string? inputRows = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputRows))
            {
                Console.WriteLine("Invalid input for number of rows.");
                return;
            }
            int rows = int.Parse(inputRows);

            int[][] jaggedArr = new int[rows][];
            Random rand = new Random();

            // Nhập số cột cho từng hàng và gán giá trị random
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Nhap so cot cho hang {i}: ");
                string? inputCols = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputCols))
                {
                    Console.WriteLine("Invalid input for number of columns.");
                    return;
                }
                int cols = int.Parse(inputCols);
                jaggedArr[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    jaggedArr[i][j] = rand.Next(1, 21); // random từ 1 → 20
                }
            }

            // In mảng Jagged
            Console.WriteLine("\nMang Jagged:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write(jaggedArr[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Người dùng nhập số cần tìm
            Console.Write("\nNhap so can tim: ");
            string? inputTarget = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputTarget))
            {
                Console.WriteLine("Invalid input for target number.");
                return;
            }
            int target = int.Parse(inputTarget);

            bool found = false;
            Console.WriteLine($"\nVi tri cua so {target} trong mang:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    if (jaggedArr[i][j] == target)
                    {
                        Console.WriteLine($"- Hang {i}, Cot {j}");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Khong tim thay so trong mang.");
            }
        }
        ///<summary>
        ///Ex 02
    ///▸The X company has 3 working groups; group 1 has 5 members, group 2 has 3 members, and group 3 has 6 members.The data stored for each member has an ID number, full name, and completed tasks.An ID identifies each member.
    ///▸Select an appropriate data structure to save this info.Then, write functions to perform the following tasks:
    ///1.Initialize an array with pre-assigned values ​​or values ​​entered from the keyboard.
    ///2.Print a list of all members.
    ///3.Print the information on a member when the ID is known.
    ///4.Print the member with the highest number of completed tasks.
    ///▸Create the main program with menus that allow you to select the tasks to be performed.
    ///Hint: create a jagged array to store these members in the form [id,[name, tasks]].
    ///</summary>
    static void Ex02 ()
        {
            // Tạo jagged array cho 3 nhóm (Group 1: 5, Group 2: 3, Group 3: 6)
            object[][][] groups = new object[3][][];

            // 1.Initialize an array with pre-assigned values ​​or values ​​entered from the keyboard
            groups[0] = new object[][]
            {
            new object[] {1, "Alice", 10},
            new object[] {2, "Bob", 7},
            new object[] {3, "Charlie", 12},
            new object[] {4, "David", 5},
            new object[] {5, "Emma", 8}
            };

            groups[1] = new object[][]
            {
            new object[] {6, "Frank", 15},
            new object[] {7, "Grace", 9},
            new object[] {8, "Hannah", 11}
            };

            groups[2] = new object[][]
            {
            new object[] {9, "Ian", 6},
            new object[] {10, "Jack", 13},
            new object[] {11, "Karen", 4},
            new object[] {12, "Leo", 14},
            new object[] {13, "Mona", 10},
            new object[] {14, "Nina", 16}
            };

            //2.Print a list of all members.
            Console.WriteLine("\nDanh sach tat ca thanh vien:");
            for (int g = 0; g < groups.Length; g++)
            {
                Console.WriteLine($"--- Nhom {g + 1} ---");
                for (int i = 0; i < groups[g].Length; i++)
                {
                    Console.WriteLine($"ID: {groups[g][i][0]}, Ten: {groups[g][i][1]}, Tasks: {groups[g][i][2]}");
                }
            }
            // 3.Print the information on a member when the ID is known.
            Console.Write("\nNhap ID can tim: ");
            string? inputId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputId))
            {
                Console.WriteLine("Invalid input for ID.");
                return;
            }
            int searchId = int.Parse(inputId);
            bool found = false;
            foreach (var group in groups)
            {
                foreach (var member in group)
                {
                    if ((int)member[0] == searchId)
                    {
                        Console.WriteLine($"\nThong tin thanh vien co ID {searchId}:");
                        Console.WriteLine($"ID: {member[0]}, Ten: {member[1]}, Tasks: {member[2]}");
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong tim thay thanh vien voi ID nay.");
            }

            // 4.Print the member with the highest number of completed tasks.
            object[]? top = null;
            foreach (var group in groups)
            {
                foreach (var member in group)
                {
                    if (top == null || (int)member[2] > (int)top[2])
                    {
                        top = member;
                    }
                }
            }
            if (top != null)
            {
                Console.WriteLine("\nThanh vien co so task nhieu nhat:");
                Console.WriteLine($"ID: {top[0]}, Ten: {top[1]}, Tasks: {top[2]}");
            }
            else
            {
                Console.WriteLine("\nKhong co thanh vien nao trong danh sach.");
            }
        }
    }
}
