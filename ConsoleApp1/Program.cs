const double PI = 3.14159;  // constant

int radius = 5;          // variable
double area = PI * radius * radius;

Console.WriteLine($"Radius: {radius}");
Console.WriteLine($"Area: {area}");

string text = "C# Programming";

Console.WriteLine(text.ToUpper());
Console.WriteLine(text.ToLower());
Console.WriteLine(text.Replace("C#", "DotNet"));
Console.WriteLine($"Length: {text.Length}");

DateTime now = DateTime.Now;
Console.WriteLine($"Current date and time: {now}");
DateTime future = now.AddDays(7);
Console.WriteLine($"One week later: {future}");

string numberText = "42";
int number = Convert.ToInt32(numberText);
double result = number * 2.5;
Console.WriteLine($"Original text: {numberText}");
Console.WriteLine($"Converted number: {number}");
Console.WriteLine($"After multiplication: {result}");

string firstName = "John";
string lastName = "Doe";
string fullName = firstName + " " + lastName;
Console.WriteLine("Full name (concatenation): " + fullName);
Console.WriteLine($"Full name (interpolation): {firstName} {lastName}");