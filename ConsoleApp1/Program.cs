using System.ComponentModel;
using System.Diagnostics;
using MyConsoleApp;

Console.WriteLine("===========================");
// const double PI = 3.14159;  // constant

// int radius = 5;          // variable
// double area = PI * radius * radius;

// Console.WriteLine($"Radius: {radius}");
// Console.WriteLine($"Area: {area}");

// string text = "C# Programming";

// Console.WriteLine(text.ToUpper());
// Console.WriteLine(text.ToLower());
// Console.WriteLine(text.Replace("C#", "DotNet"));
// Console.WriteLine($"Length: {text.Length}");

// DateTime now = DateTime.Now;
// Console.WriteLine($"Current date and time: {now}");
// DateTime future = now.AddDays(7);
// Console.WriteLine($"One week later: {future}");

// string numberText = "42";
// int number = Convert.ToInt32(numberText);
// double result = number * 2.5;
// Console.WriteLine($"Original text: {numberText}");
// Console.WriteLine($"Converted number: {number}");
// Console.WriteLine($"After multiplication: {result}");

// string firstName = "John";
// string lastName = "Doe";
// string fullName = firstName + " " + lastName;
// Console.WriteLine("Full name (concatenation): " + fullName);
// Console.WriteLine($"Full name (interpolation): {firstName} {lastName}");

// Statement s = new Statement();
// s.sample();


// int c = 5;
// c += 9; // c = c + 9;
// Console.WriteLine("c = " + c);
// c -= 2; // c = c - 2;
// Console.WriteLine("c = " + c); 

// int a = 5, b = 10;
// Console.WriteLine("a > b = " + (a > b));
// Console.WriteLine("a < b = " + (a < b));
// Console.WriteLine("a >= b = " + (a >= b));
// Console.WriteLine("a <= b = " + (a <= b));
// Console.WriteLine("a == b = " + (a == b));
// Console.WriteLine("a != b = " + (a != b));

// bool isAdult = true;
// bool isStudent = false;
// Console.WriteLine("isAdult && isStudent = " + (isAdult && isStudent));
// Console.WriteLine("isAdult || isStudent = " + (isAdult || isStudent));
// Console.WriteLine("!isAdult = " + !isAdult);

// bool x = true, y = true, z = false;
// bool a = !(x && z);
// Console.WriteLine(a);
// a = !x && x;
// Console.WriteLine(a);
// a = !x || !y && y;
// Console.WriteLine(a);
// a = y && !y || !x;
// Console.WriteLine(a);

// int a = 10, b = 20;
// string message = (a > b) ? "a is larger than b" : "a is smaller than b";

//print triangle
// for (int i = 0; i < 6; i++)
// {
//     string row = "";
//     for (int j = 0; j <= i; j++) {
//         row += " *";
//     }
//     Console.WriteLine(row);
// }

//print empty ractangle
// for (int i = 0; i < 4; i++)
// {
//     string row = "";
//     if (i == 0 || i == 3)
//     {
//         for (int j = 0; j <= 6; j++)
//         {
//             row += " *";
//         }
//     }
//     else
//     {
//         for (int j = 0; j <= 6; j++)
//         {
//             if (j == 0 || j == 6)
//             {
//                 row += " *";
//             }
//             else
//             {
//                 row += "  ";
//             }
//         }
//     }
//     Console.WriteLine(row);
// }

// int[] a = new int[6];

// int[] b = new int[] { 2, 4, 5, 12, 16, 18 };
// for (int i = 0; i < b.Length; i++)
// {
//     Console.WriteLine(b[i]);
// }

// int[] c = { 2, 4, 5, 12, 16, 18 };
// Console.WriteLine(c[3]);
// Console.WriteLine(c.GetValue(2));

// int[,] numbers = new int[3, 4]
// {
//     {11, 12, 13, 14 },
//     {21, 22, 23, 24 },
//     {31, 32, 33, 34 }
// };
// Console.WriteLine(numbers.Length);  //total 12 items
// Console.WriteLine(numbers.GetLength(0));    //3 rows
// Console.WriteLine(numbers.GetLength(1));    //4 columns
// for (int row = 0; row < numbers.GetLength(0); row++)
// {
//     for (int col = 0; col < numbers.GetLength(1); col++)
//     {
//         Console.WriteLine(numbers[row, col]);
//     }
// }

// StringProgram sp = new StringProgram();
// sp.sample();

// char[] letters = { 'H', 'e', 'l', 'l', 'o' };
// string greeting = new string(letters, 0, 2);

// string myName = "Micheal Jackson";
// string aaa = new string('a', 10);

// string myFullname = "Micheal" + " " + "Jackson";
// string myFullnameAndAge = myFullname + " 38";

// Console.WriteLine(myFullname[9]);
// Console.WriteLine(myFullname.Length);

// char c = 'x';
// string aString = "abcd";
// string newString = "";
// for (int i = 0; i < aString.Length; i++)
// {
//     newString += aString[i] + c.ToString();
// }
// Console.WriteLine(newString);
