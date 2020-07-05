using CSharpFundamentals.Math;
using CSharpFundamentals.Files;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharpFundamentals
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    };

    class MainClass
    {
        public static void Main(string[] args)
        {
            ObjectExample();
            CalculatorExample();
            RandomExamples();
            EnumExamples();
            ReferenceAndValueTypes();
            WorkingWithArrays();
            WorkingWithLists();
            DatesAndTime();
            WorkingWithStrings();
            StringCodingExample();
            WorkingWithStringBuilder();
            WorkingWithFiles();
        }

        private static void WorkingWithFiles()
        {
            var path = "/Volumes/MacBooty/Repos/Training/learning_csharp/test.file";
            //File.Copy("/this/that/pic.jpg", "/this/that/mynewfile.jpg", true);      // "true" - if file exists do I overwrite or not?
            //File.Delete(path);
            //if (File.Exists(path))
            //{
            // Do something with the file
            //}
            //var content = File.ReadAllText(path);

            var fileInfo = new FileInfo(path);
            //fileInfo.CopyTo("...");
            //fileInfo.Delete();
            //if (fileInfo.Exists)
            //{
            // Do something with the file
            //}
            // NOTE: ReadAllText() doesn't exist for FileInfo
            var fileUtility = new FileUtility();

            Console.WriteLine("Word Count: " + fileUtility.WordCount(path));
        }

        private static void WorkingWithStringBuilder()
        {
            var builder = new StringBuilder();
            builder.Append('=', 7);        // Add 7 equals to the string
            builder.Append(" StringBuilder ");
            builder.Append('=', 7);        // Add 7 equals to the string
            builder.AppendLine();
            builder.Append("Header");
            builder.AppendLine();
            builder.Append('-', 10);
            Console.WriteLine(builder);

            builder.Replace('=', '+');
            Console.WriteLine(builder);

            builder.Remove(0, 7);
            builder.Insert(0, new string('-', 7));
            Console.WriteLine(builder);
        }

        private static void StringCodingExample()
        {
            var sentence = "Congratulations you are now officially on the start line for the Dixons Carphone Virtual Race to the Stones! Now is the time to get yourself in the zone and fully prepared, ready for when the challenge starts on 6th July";
            var summary = StringUtility.SummariseText(sentence, 40);
            Console.WriteLine("======= String Coding Example ========");
            Console.WriteLine("Summary is:");
            Console.WriteLine(summary);
        }

        private static void WorkingWithStrings()
        {
            var fullName = "Mark Bradshaw ";

            Console.WriteLine("======= Strings ========");

            Console.WriteLine("Trim: '{0}'", fullName.Trim());
            Console.WriteLine("ToUpper: '{0}'", fullName.Trim().ToUpper());

            // Simple Split
            Console.WriteLine("Spit: '{0}' '{1}'", fullName.Split(' '));
            // Clearer Split
            var names = fullName.Split(' ');
            Console.WriteLine("Split First Name: " + names[0]);
            Console.WriteLine("Split Last Name: " + names[1]);

            // More complex split
            var index = fullName.IndexOf(' ');
            var firstName = fullName.Substring(0, index);
            var lastName = fullName.Substring(index + 1);
            Console.WriteLine("Substring First Name: {0} Last Name: {1}", firstName, lastName);

            Console.WriteLine("Replace: " + fullName.Replace("Mark", "Git"));

            // Testing for null or empty space
            var emptyString = " ";
            if (String.IsNullOrWhiteSpace(emptyString))
                Console.WriteLine("Empty string is invalid");
        }

        private static void DatesAndTime()
        {
            // Creating
            var timeSpan = new TimeSpan(1, 2, 3);           // One hour, two minutes, three seconds

            var timeSpan1 = new TimeSpan(1, 0, 0);          // Specify only one hour
            var timeSpan2 = TimeSpan.FromHours(1);          // same as timeSpan1 definition

            Console.WriteLine("======= Dates and Time ========");

            var start = DateTime.Now;
            var end = DateTime.Now.AddMinutes(2);
            var duration = end - start;
            Console.WriteLine("Duration: " + duration);

            // Properties
            Console.WriteLine("Minutes: " + timeSpan.Minutes);
            Console.WriteLine("Total Minutes: " + timeSpan.TotalMinutes);

            // Add
            Console.WriteLine("Add Example: " + timeSpan.Add(TimeSpan.FromMinutes(8)));
            Console.WriteLine("Subtrace Example: " + timeSpan.Subtract(TimeSpan.FromMinutes(2)));

            // ToString conversion
            var stringTime = timeSpan.ToString();
            Console.WriteLine("ToString: " + stringTime);
            
            // Parse
            Console.WriteLine("Parse: " + TimeSpan.Parse("01:02:03"));
        }

        private static void WorkingWithLists()
        {
            var numbers = new List<int>() { 1, 2, 3, 4 };

            Console.WriteLine("======= Lists ========");
            numbers.Add(1);                                 // Add an element to the list
            numbers.AddRange(new int[3] { 5, 1, 7 });       // Add multiple elements to a list

            foreach (var number in numbers)
                Console.WriteLine("Full List: " + number);

            Console.WriteLine("First Index of 1: " + numbers.IndexOf(1));
            Console.WriteLine("Last Index of 1: " + numbers.LastIndexOf(1));

            Console.WriteLine("Count of elements: " + numbers.Count);

            numbers.Remove(1);                              // Remove first occurrance of "1"
            foreach (var number in numbers)
                Console.WriteLine("Removed first 1. Element: " + number);

            // Remove all occurrances of 1
            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == 1)
                    numbers.Remove(numbers[i]);
            }

            foreach (var number in numbers)
                Console.WriteLine("Removed all 1s. Element: " + number);

            numbers.Clear();
            Console.WriteLine("Count of elements after Clear(): " + numbers.Count);
        }

        private static void WorkingWithArrays()
        {
            var numbers = new int[] { 3, 7, 9, 1, 14, 6 };      // "int" isn't needed as the type will be worked out

            Console.WriteLine("======= Arrays ========");

            Console.WriteLine("Length: " + numbers.Length);

            var index = Array.IndexOf(numbers, 9);
            Console.WriteLine("Index of 9 is " + index);

            // Clear: set elements to 0
            Array.Clear(numbers, 0, 2);
            foreach (var n in numbers)
                Console.WriteLine("Cleared Element {0}", n);

            var destinationArray = new int[3];
            Array.Copy(numbers, destinationArray, 3);
            foreach (var n in destinationArray)
                Console.WriteLine("Copied Element {0}", n);

            Array.Sort(numbers);
            foreach (var n in numbers)
                Console.WriteLine("Sorted Element {0}", n);

            Array.Reverse(numbers);
            foreach (var n in numbers)
                Console.WriteLine("Reversed Element {0}", n);
        }

        private static void ReferenceAndValueTypes()
        {
            // Reference and Value types example
            var playingWithTypes = new PlayingWithTypes();
            playingWithTypes.DoStuff();
        }

        private static void ObjectExample()
        {
            // Object example
            Person mark = new Person();
            mark.FirstName = "Mark";
            mark.LastName = "Bradshaw";
            mark.Introduce();
        }

        private static void CalculatorExample()
        {
            // Namespace example (note that we've added "using CSharpFundamentals.Math" at the top)
            Calculator calculator = new Calculator();
            var result = calculator.Add(1, 2);

            Console.WriteLine("Result of add: " + result);
        }

        private static void EnumExamples()
        {
            Console.WriteLine("======================");
            // enum examples
            var method = ShippingMethod.Express;
            Console.WriteLine("Enum examples");
            // print the shipping method
            Console.WriteLine(method);
            // print the integter that represents the Shipping method
            Console.WriteLine((int)method);

            // Cast back from an integer to the ShippingMethod
            var externalMethodId = 2;
            Console.WriteLine((ShippingMethod)externalMethodId);

            // Take a string representation of the shipping method and map it onto the enum
            var methodName = "Express";
            var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine("======================");
        }

        private static void RandomExamples()
        {
            // Random character
            Console.WriteLine("======================");
            var random = new Random();
            Console.WriteLine("Random character: " + (char)random.Next((int)'a', (int)'z'));
            Console.WriteLine("Random character: " + (char)('a' + random.Next(0, 26)));

            const int passwordLength = 10;
            var buffer = new char[passwordLength];
            for (var i = 0; i < passwordLength; i++)
                buffer[i] = (char)('a' + random.Next(0, 26));

            var password = new string(buffer);
            Console.WriteLine("Password is: " + password);
            Console.WriteLine("======================");
        }
    }
}
