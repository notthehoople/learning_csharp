# C# Basics for Beginners - Notes

## CLR - Common Language Runtime
When you compile C# is compiles to IL Code (Intermediate Language). CLR then takes the IL code into machine code using Just In Time compilation. That means you can write the program on Mac, then take the IL and run it on Windows

## Namespace
A collection of Classes that are related to each other
- Database
- Storage
- etc

## Assembly
A collection of Namespaces, such as a DLL or EXE

# Primitive Types
These are the common primitive types:
- byte
- short (2 bytes)
- int (4 bytes)
- long (8 bytes)
- float (4 bytes)
- double (8 bytes)
- decimal (16 bytes)
- char (2 bytes)
- bool

## Value Types
- stored on the stack
- all primitive types, plus the struct type
- short lifespan. As soon as they go out of scope they are destroyed

## Reference Types
- stored in the heap
- any classes (Object, Array, String, Vehicle)

## Boxing & Unboxing
- have a performance penalty

### Boxing
- the process of converting a value type instance to an object reference
```
int number = 10;
object obj = number;
```
- here the number is "boxed" in an object and is stored on the heap

### Unboxing
- opposite of boxing
- a new variable on the stack is created
```
object obj = 10;
int number = (int)obj;
```

## var
Using `var` to declare variables lets C# detect the data type itself
```
char character = 'A';
var character = 'A';
```

NOTE that C# defaults to:
- int for intergers
- float for real numbers

## Operators
- % gives the remainder after division e.g. `a % b`
- postfix increment: `int a = 1; int b = a++;` gives a = 2 and b = 1
- prefix increment: `int a = 1; int b = ++a;` gives a = 2 and b = 2
- multiplication assignment: `a *= 3` (a = a * 3)
- division assignment: `a /= 3` (a = a / 3)
- NOTE: dividing 2 integers will result in an integer! You need to cast each variable to a float in order to get a float result:
```
int a = 10;
int b = 3;
Console.WriteLine(a / b);                       // Results in "3"
Console.WriteLine( (float(a) / float(b)));      // Results in "3.3333333"
```

## Overflow protection
By default there is no overflow protection. A byte variable with value 255 will overflow to 0 if it is incremented. To prevent this use the `checked` keyword to throw an exception if an overflow is detected:

```
checked
{
    byte number = 255;
    number++;
}
```

# Classes
Contain Fields and Methods
Objects are instances of Classes

```
public class Person
{
    // Fields: Variable declarations for the class
    public string Name;

    // Methods: Functions to operate on the class
    public void Introduce()
    {
        Console.WriteLine("Hi, my name is" + Name);
    }
}
```
## Objects
Person person = new Person();       # Need to allocate memory to the Object
        # Garbage Collection removes all objects that aren't used, so don't need to get rid of them

```
var person = new Person();
person.Name = "Mark";
person.Introduce();
```

## Static Modifier
`static int Add(int a, int b) {return (a + b)}`
- when we add "static" to a Method it means we can access the method through the class that holds the method. We DONT have to create an object first
- we CANNOT access static methods from objects. ONLY from the Class
- without the static modifier, each object in memory has a copy of each method
- with the static modified, there can only be a single instance of a method in memory

## Instance class member
- accessible from an object
```
var person = new Person();
person.Introduce();             // Introduce is an Instance class member
```
## Static class member
- accessible from the class directly
- used to represent concepts that are singleton e.g. there should only be one of these in the program
```
Console.WriteLine();            // WriteLine is a static class member
DateTime.Now                    // Now is a static class member
```

## Constructor
- has the same name as the class
- has initialisation code for the class
- no return type
- can pass in variables
- the compiler creates a default constructor if you don't specify one
    - if you overload the constructor with custom constructors, the compiler doesn't create a default anymore, so you need to define one
- type 'ctor' as a shortcode for creating a constructor
- ALWAYS initialise a list field to an empty list

### Constructor Overloading
- overloading makes constructing easier
```
public class Customer
{
    public Customer() { ... }
    public Customer(string name) { ... }
    public Customer(int id, string name) { ... }
}
```
- use : this() on the constructor declaration to reference higher level constructors and avoid having to duplicate code:
- BEST PRACTICE: only use constructors when a field REALLY needs to be initialised to avoid future exceptions e.g. creating a list in the object fields.
```
        public Customer()
        {
            Orders = new List<Order>();
        }
            
        public Customer(int id)
            : this()                    // References Customer()
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)                  // References Customer(int id)
        {
            this.Name = name;
        }
```
### Object Initialisers
- a syntax for quickly initialising an object without the need to call one of its constructors
- avoids needing to create multiple constructors
- the default constructor is called, THEN the object initialisation code is used
- example of an initialiser is as follows:
```
var person = new Person {
    FirstName = "Mark",
    LastName = "Bradshaw"
};
```
## Methods

### Signature of a Method
- name
- number and type of parameters

### Overloading Methods
- having a method with the same name but different signatures
- a method can have a varying number of parameters:
```
public int Add(int[] numbers) {}
```
- this isn't great though as you need to declare an array every time you call the Method

### Params Modifier
- gets over the problem highlighted above
```
public int Add(params int[] numbers) {}
```
- can then call this with `var result = calculator.Add(1,2,3,4);`

### Ref Modifier - DON'T USE THIS
```
public void DoAWeirdThing(ref int a)
{
    a += 2;
}
var a = 1;
weirdo.DoAWeirdThing(ref a);
```
- changes the parameter to a REFERENCE instead of a copy. 'a' will be modified here
- this is against the way things work in C#

### Out Modifier - DON'T USE THIS
```
public void MyMethod (out int result)
{
    result = 1;
}
int a;
myClass.MyTheod(out a);
```
- let's you return values through the result
- note that the method is a 'void'
- breaks the convention of using a return type and a specific `return` code

### Method Overriding
- modify the implementation of an inherited method
- checkout "BadShapeImplementation" and "GoodShapeImplementation" for an example
- use `virtual` in the declaration of the base class method
- use `override` in the declaration of the sub class method
```
public class Shape
{
    public virtual void Draw() { // Default implementation }
}
public class Circle : Shape
{
    public override void Draw() { // New implementation }
}
```

## Fields

### Initialisation
- preferred way to initialise is like this, creating and assigning the field in one go instead of definiing the field as `List<Order> Orders` then relying on the constructor to assign a new List to it.
- note that some developers don't like this approach and prefer to rely on the constructor
```
public class Customer
{
    List<Order> Orders = new List<Order>();
}
```
### Read only Fields
- must be assigned within the constructor method
- can only be initialised once. In this example once Orders has been declared it can't be declared again later. Avoids the possibility of a bug causing data loss
```
public class Customer
{
    readonly List<Order> Orders = new List<Order>();
}
```

# Access Modifers
- a way to control access to a class and/or its members
## public
- accessible from everywhere
## private
- accessible only from the class
## protected
- accessible only from the class and its derived classes
- similar to "private"
- sometimes considered bad practice as exposes internal workings to other classes
## internal
- accessible only from the same asssembly
- e.g. make a class available to other classes in an assembly
## protected internal
- accessible only from the same assembly or any derived classes
- BAD practice!

# Abstract Modifier
- indicates that a class or a member is missing implementation
- inherently 'virtual'
```
public abstract class Shape
{
    public abstract void Draw();
}
```
## Abstract Members
- if you declare a method as 'abstract' then the class needs to be declared 'abstract' as well
- a member class MUST implement ALL abstract methods in the base abstract class
- abstract classes CANNOT be instantiated `var shape = new Shape(); // won't compile`

### Why Abstract?
- when you want to provide some common behavious, while forcing other developers to follow your design
- e.g. example for Shape above FORCES another developer to implement the Draw method for their member class

# Sealed Modifier
- applied tp a class or class member
- opposite of abstract
- prevents derivation of classes or overriding of methods
```
public sealed class Circle : Shape { ... }
public sealed override void Draw() { ... }
```

### Why Sealed?
- sealed classes are slightly faster because of some run-time optimisations
- very rarely used, possibly an anti-pattern

# Object Oriented Programming
## Enclapsulation
- hide fields that do not need to be available externally
- private fields should start with an underscore as shown below
- provide getter/setter methods as public to manipulate the fields
```
public class Person
{
    private string _name;
    public void SetName(string name) {
        if (!String.IsNullOrEmpty(name))
            this._name = name;
    }
    public string GetName()
    {
        return _name;
    }
}
```
## Properties
- a class member that encapsulates a getter/setter for accessing a field
```
private DateTime _birthdate;
public DateTime Birthdate
{
    get { return _birthdate; }
    set { _birthdate = value; }
}
```
### Auto-implemented Properties
- compiler recognises this special case and creates the field for you
```
public class Person
{
    public DateTime Birthdate { get; set; }
}
```
### Viewing partially compiled code
- on Windows, `ildasm`
- on Mac, use either `monodis` or `ikdasm`

# Indexers
- a way to access elements in a class that represents a list of values
```
cookie["name"] = "Mark";            // Using an indexer
cookie.SetItem("name", "Mark");     // Same code but not using an indexer

var name = cookie["name"];          // Using an indexer
var name = cookie.GetItem("name");  // Same code but not using an indexer
```
- it is basically a property:
```
public class HttpCookie
{
    public string this[string key]  // use "this" keyword
    {
        get { ... }
        set { ... }
    }
}
```
# Class Coupling
## Tightly Coupled
- this is BAD
- it is when a change in one class affects a large number of interlinked classes
- a minor class change can have a major application change

## Loosely Coupled
- this is GOOD
- changing a class affects only that class
- no class should know about the *implementation* of another class
- important: encapsulation, relationship between classes, interfaces

# Inheritance Class relationship
- Is-a relationship
- PROs: Code re-use, easier to understand
- CONs: tightly coupled, fragile, can be abused
```
public class PresentationObject
{
    // Common shared code
}
public class Text : PresentationObject
{
    // Code Specific to Text
}
```
- base class constructors are executed first
- base class constructors are not inherited
```
public class Vehicle
{
    private string _registrationNumber;
    public Vehicle(string registrationNumber)
    {
        _registrationNumber = registrationNumber;
    }
}

public class Car : Vehicle
{
    public Car(string registrationNumber)
        : base(registrationNumber)
    {
        // initialise fields specific to the Car class
    }
}
```
- if the constructor of the base class needs a parameter, you need to deal with this in your sub class as well
- :base lets you access the base contructor class

## Upcasting / Downcasting
- conversion from a derived class to a base class
```
public class Shape { }
public class Circle : Shape { }

Circle circle = new Circle();
Shape shape = circle;                   // Upcasting. No conversion is required. Upcasting is implicit
Circle anotherCircle = (Circle)shape;   // Downcasting. Explicit cast required
```
- will get an InvalidCastException if you try to explicit cast to a different class
- in the example above, both "shape" and "circle" point to the same object but present different views of it

- Downcasting is frequently needed when using libraries as the types can be set to "object". Downcast to the type you need so you can access Methods you need

### The "as" keyword
- prevents exceptions when the cast can't be done
- use this when you're not sure what the runtime class of an object is going to be
```
Car car = (Car) obj;                    // Can throw an exception in this explicit cast

Car car = obj as Car;                   // Safer. Will return null if fails
if (car != null) { ... }
```
### The "is" keyword
- test if an object is a particular class
```
if (obj is Car) { ... }
```

# Composition Class relationship
- a kind of relationship between 2 classes that allows one to contain the other
- Has-a relationship
- PROs: code re-use, great flexibility, loose coupling
- CONs: harder to understand
- Example: Car has an Engine
- Example: many classes need a way to log information.
    - DBMigrator --> Logger
    - Installer --> Logger
```
public class Installer
{
    private Logger _logger;
    public Installer(Logger logger)
    {
        _logger = logger;
    }
}
```
## Composition over Inheritance
- Problems with inheritance
    - easily abused by amataur designers / developers
    - leads to large hierarchives
    - fagility
    - tight coupling
- Composition
    - any inheritance relationship can be modelled with Composition
    - great flexibility
    - eventually loose coupling
- Inheritance is not necessarily a bad thing
- Use both inheritance and composition

# Interfaces
- Similar to a class in syntax, but is fundamentally different
- interface members don't have implementations, just definitions
- interface members don't have modifiers (e.g. public, private, etc)
- used for building extensible, testable and loosely coupled applications
```
public interface ITaxCalculator
{
    int Calculate();
}
```

## Interfaces and Extensibility
- useful to define classes that you haven't implemented yet

# Structs
Small difference between a struct and a class. Structs are lighter, so if you are declaring thousands of them then structs will be more efficient
```
public struct RgbColour
{
    public int Red;
    public int Green;
    public int Blue;
}
```

# Dictionary (System.Collections.Generic)
- a way of storing data in a key, pair combination (e.g. like a map in Go)
- use a List<> for an ordered list of items

# Arrays
- Arrays are classes
- Arrays have a fixed size, and need memory to be allocated to them:
```
int[] numbers = new int[3];
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
```
or:
```
int[] numbers = new int[3] { 1, 2, 3 };
```
## Multi Dimension Arrays
Two types:
- rectangular: each row has the same number of columns
- jagged: number of columns can be different for each row. An array of arrays

### Rectangular
```
var matrix = new int[<ROW>, <COLUMN>];
var matrix = new int[3, 5];
var matrixValues = new int[3, 5]
{
    { 1, 2, 3, 4, 5 },
    { 6, 7, 8, 9, 10 },
    { 11, 12, 13, 14, 15}
};
var element = matrixValues[0, 0];

// 3 dimensional array
var colours = new int[3, 5, 4];
```
### Jagged
We don't declare the size of the column (second element)
```
var array = new int[3][];       // Leave the second element empty
array[0] = new int[4];
array[1] = new int[5];
array[2] = new int[3];
array[0][0] = 1;
```
### Arrays are classes
Field: Length
Methods:
- Clear()
- Copy()
- IndexOf()
- Reverse()
- Sort()

## Lists
- Similar to arrays, but have a dynamic size
- MOst of the time we use Lists instead of Arrays
```
var numbers = new List<int>();      // int specifies the type of the list
var numbers = new List<int>() { 1, 2, 3, 4 };
```
- can create a list of any type, including userdefined types
- Methods:
    - Add()
    - AddRange()
    - Remove()      # Note: we can't remove elements in a foreach loop
    - RemoveAt()
    - IndexOf()
    - Contains()
    - Count

# Strings
- "String" class and "string" type are exactly the same
- strings are classes
- Strings can be concatented. Use the string.Format method as shown to make the output easier to visualise
- Strings are immutable. Once created, they cannot be changed
- All methods that manipulate strings create new strings in the background
- Special characters need to be escaped with "\" e.g. "\\", "\n", "\t"

```
string firstName = "mark";
string lastName = "bradshaw";
string name = firstName + " " + lastName;
string otherName = string.Format("{0} {1}", firstName, lastName);
```

```
var numbers = new int[3] { 1, 2, 3};
string list = string.Join(",", numbers);
```

```
string name = "Mark";
char firstChar = name[0];       // Will be set to 'M'
```

## Verbatim String
- no need to escape special characters
```
string path1 = "c:\\projects\\project1\\folder1";
string path2 = @"c:\projects\project1\folder1";
```
## Formatting
- ToLower()                     # Returns lower case string
- ToUpper()                     # Returns upper case string
- Trim()                        # Removes whitespace
- IndexOf('a')                  # Searches the string for the first occurrance of 'a'
- LastIndexOf("Hello")          # Searches the string for the last occurrance of "Hello"
- Substring(startIndex)         # From startIndex to end of string
- Substring(startIndex, length) # From startIndex for amount of length
- Replace('a', '!')             # Replace single character
- Replace('mark', 'marky')      # Replace entire string
- String.IsNullOrEmpty(str)
- String.IsNullOrWhiteSpace(str)
- String.Join(" ", words)       # Joins the strings in the list words using " " as deliminator
- str.Split(' ')                # Split string by space
- int i = int.Parse(str)        # Convert string to integer. Exception on null string
- int j = Convert.ToInt32(str)  # Does the same thing: covert string to integer. Safer
- Coverting numbers to strings:
```
int i = 1234;
string s = i.ToString();        // "1234"
string t = i.ToString("C");     // "$1,234.00"
string t = i.ToString("C0");    // "$1,234"
```
### Format Strings
Each format string can take a number after it to signify number of places
- c or C: Currency      123456(C) -> $123,456
- d or D: Decimal       1234(D6) -> 001234
- e or E: Exponential   1052.0329112756(E) -> 1.052033E+003
- f or F: Fixed Point   1234.567(F1) -> 1234.5
- x or X: Hexadecimal   255(X) -> FF

## StringBuilder
using System.Text
- optimised for string manipulation
- not for searching so can't find substrings inside a start string
- no methods for IndexOf, LastIndexOf, Contains, StartsWith
- includes Append, Insert, Remove, Replace, Clear
- can still index individual characters `myString[0]`
- can chain methods together e.g.

```
var myString = new StringBuilder();
myString
    .Append('-', 10)
    .AppendLine()
    .Append("Header")
    .AppendLine()
    .Append('-', 10)
    .Replace('-', '+')
    .Insert(0, new string('-', 10));
```

# Enumeration Types (enum)
A value type defined by a set of named constants of "int". Instead of multiple contstants e.g.
```
const int RegularAirMail = 1;
const int RegisteredAirMail = 2;
const int Express = 3;
```
use an enum covering Shipping Methods:
```
public enum Shipping Method
{
    RegularAirMail = 1,
    RegisteredAirMail = 2,
    Express = 3;
}

var method = ShippingMethod.Express;
```

# User Input
To get user input from the console use `Console.ReadLine()`
# Control Flow

## Switch
You can collapse cases if the code is the same. In the following example the case for Season.Autumn will fall into the code for Season.Summer:
```
switch (season)
{
    case Season.Autumn:
    case Season.Summer:
        Console.WriteLine("Sales promotion time!");
        break;
    default:
        Console.WriteLine("Normal pricing");
        break;
}
```
## Conditional Operator
Conditional operator is `condition` ? <if true> : <if false>. It is short hand for a simple if..else condition.
```
bool isGoldCustomer = true;
float price = (isGoldCustomer) ? 19.95f : 29.95f;
```

# Working with Files
- FileInfo: provides instance methods
    - faster
- File: provides static methods
    - security checks are done every time a static method is used
    - if you call static methods many, many times the overhead is significant
- File, FileInfo Methods
    - Create()
    - Copy()
    - Delete()
    - Exists()
    - GetAttributes()
    - Move()
    - ReadAllText()             # Reads all the text in a file
- Directory, DirectoryInfo
    - GetLogicalDrives()        # Logical drives of your hard disk (C:, D:, etc)
    - GetCurrentDirectory()
    - GetFiles()                # Can provide filters
- Path
    - GetDirectoryName()
    - GetFileName()
    - GetExtension()
    - GetTempPath()

# Iteration Statements
## For loops
```
for (var i = 0; i < 10; i++)
{
    ...
}
```
## Foreach loops
Used to iterate over a list, array or string
```
var name = "John Smith";
foreach (var character in name)
{
    ...
}
```
## While loop
Can be used in the same situations as the for loop, but much better to use it when we don't know how many times round the loop we'll go.
```
var i = 0;
while (i < 10)
{
    ...
    i++;
}
```
## Do-While loops
The loop is executed at least once as the condition is evaluated at the end of the loop
```
do
{
    ...
    i++;
} while (i < 10);
```
## Break and Continue
- break: jumps out of the loop
- continue: jumps to the next iteration of the loop

# Useful
## IList<>
- a list of Interfaces
- lets you use 1 or more interfaces
```
public class Video
{
    private readonly IList<INotificationChannel> _notificationChannels;
    public VideoEncoder()
    {
        _notificationChannels = new List<INotificationChannel>();
    }
    public void Encode(Video video)
    {
        foreach (var channel in _notificationChannels)
            channel.Send(new Message());
    }
    public void RegisterNotificationChannel(INotificationChannel channel)
    {
        _notificationChannels.Add(channel);
    }
}
- See "Polymorphism example" in github
```

# Generics
- created to get away from having to create a class for a list of different types OR creating a class for storing "object" which leads to boxing/unboxing
- generics mean that at runtime the lists are actually the defined types instead of being just objects and needing to be boxed/unboxed
- C# has many built in generic types in System and System.Collection.Generic and you'll ususally use one of these instead of create your own generic like the code below
- For example, System.Nullable<>
```
public class GenericList<T>
{
    public void Add(T value)
    {

    }

    public T this[int index]
    {
        get { throw new }
    }
}

var numbers = new GenericList<int>();
numbers.Add(10);

var books = new GenericList<Book>();
books.Add(new Book());
```
# Delegates
- an object that knows how to call a method (or a group of methods)
- a reference (or a pointer) to a function
- why?
    - for designing extensible and flexible applications (e.g. frameworks)
- code example: delegate project

- in .NET framework there are 2 delegates that can be used instead of needing a custom delegate: "action" and "func"
    - System.Action<> returns void
    - System.Func<> returns a value
- only needed where we need lots of flexibility or extensibility
- use a delegate when:
    - an eventing design pattern is used
    - the caller doesn't need to access other properties or methods ont the object implementing the method

# Lambda Expression
- an anonymouse method (no access modifier; no name; no return statement)
## Why do we use them?
- convenience
- makes code more readable
- args "goes to" expression
```
// args => expression
number => number * number;
// equivalent to:
public int Square(int number)
{
    return number * number;
}
```
- you can also define a delegate using a lambda expression:
```
Func<int, int> square = number => number * number;

Console.WriteLine("Square of 5 is " + square(5));
```
- here, Func's parameter types are <input_type, result_type>
- square is the name of the delegate
- `number => number * number` is what it will do
## Expressions of different types
- no arguments: `() => ...`
- one argument: `x => ...`
- multiple: `(x, y, z) => ...`

## Predicate
- a predicate is a delegate that returns a bool telling you if the condition is satisfied
- can do this using a lambda as well:
```
var cheapBooks = books.FindAll(book => book.Price < 10);
// Will return all books with a price less than 10
```

# Events
- a mechanism for communicating between objects
- used in building Loosely Coupled Applications
- helps extending applications
- class A is the publisher and sends events. It knows nothing of the subscribers
- class B is the subscriber and receives events
```
// Subscriber creates an event handler along the following lines:
public void OnVideoEncoded(object source, EventArgs e) { ... }
```
- delegates are used:
    - agreement / contract between Publisher and Subscriber
    - determines the signature of the event handler method in Subscriber

# Extension Methods
- add methods to an existing class without
    - changing it's source code
    - creating a new class that inherits from it
- use extension methods sparingly
- defnied as static methods but are called by using instance method syntax
- need to add `using System.Linq;`
- first parameter specifies which type the method operates on. The parameter is preceded by the "this" modifier
```
public static class StringExtensions
{
    public static string Shorten(this String str, int numberOfWords)
    {
        ...
    }
}
...
string post = "Lots and lots of words"
var shortenedPost = post.Shorten(5);
```

# LINQ
- stands for Language Integrated Query
- Lets you query objects
- objects in memory (LINQ to Objects), databases (LINQ to Entities), XML (LINQ to XML), ADO.NET data sets (LINQ to Data Sets)
- add `using System.Linq` for LINQ

## LINQ Extension Methods
- LINQ expressions can also be chained. Here we'll pull out the cheap books, then sort by title
```
var cheapBooksLINQ = books.Where(b => b.Price < 10).OrderBy(b => b.Title);
```

- To order a collection by something, use LINQ with a lamba:
```
books.OrderBy(b => b.Title);
```

- To select one of more properties from an object use Select(). Here we just pick the title so the result will be a string
```
books.OrderBy(b => b.Title).Select(b => b.Title);
```

- To select a single result:
```
var book = books.Single(b => b.Title == "ASP.NET MVC");
```
    - Single method expects there to be one and only one result. Otherwise throws an exception
    - If you're not sure, use SingleOrDefault:
```
var book = books.SingleOrDefault(b => b.Title == "ASP.NET MVC++");
// Since this might be null, we check for book being null when printing
// This will print "True" if book is null, otherwise "False"
Console.WriteLine(book == null);
```

- First() gets the first item found in a list
- Last() gets the last item in a list
```
var book = books.First(b => b.Title == "C# Advanced Topics");
var book = books.FirstOrDefault(b => b.Title == "C# Advanced Topics");
var book = books.Last(b => b.Title == "C# Advanced Topics");
var book = books.LastOrDefault(b => b.Title == "C# Advanced Topics");
```

- Skip() skips the number of entries specified
- Take() takes the number of entries specified
```
// Skip the first 2 entries, then return the next 3
var pagedBooks = books.Skip(2).Take(3);
```

- Count() counts the number of list entries
- Max() returns the maximum of something. You will have to define what Max means for your list
- Min() returns the minimum of something
```
// Returns the highest price in the list
var highPrice = books.Max(b => b.Price);
```

- Sum() returns the sum of all the defined entries
```
var totalPricing = books.Sum(b => b.Price);
```

### LINQ Extension Methods summary
```
books.Where();
books.Single();
books.SingleOrDefault();

books.First();
books.FirstOrDefault();

books.Last();
books.LastOrDefault();

books.Min();
books.Max();
books.Count();
books.Sum();
books.Average(b => b.Price);

books.Skip(5).Take(3);
```

## LINQ Query Operators
```
var cheaperBooks = from b in books
                   where b.Price < 10
                   orderby b.Title
                   select b.Title;
```

# Nullable types
- Value Types cannot be Null
- In some situations you need a null (e.g. Customer.Birthday (datetime NULL))
- Nullable<> is a generic type in the System namespace
```
Nullable<DateTime> date = null;     // Longhand
DateTime? date = null;              // Shorthand
```
- Methods of the Nullable type:
    - .GetValueOrDefault - preferred way of getting the value. You either get the value, or you get the default value for the type
    - .HasValue - true / false depending on whether there's a set value
    - .Value - will get an exception if the value is null

```
DateTime? date = new DateTime(2014, 1, 1);
DateTime date2 = date.GetValueOrDefault();      // Need to set to value to get away from Nullable
DateTime? date3 = date2;                        // This is fine. No need for a cast
```

## Null Coalescing Operator

```
if (date != null)
    date2 = date.GetValueOrDefault();
else
    date2 = DateTime.Today;
```

Can be replaced by the null coalescing operator:

```
DateTime date2 = date ?? DateTime.Today;
```
- means: if date is not null set date2 = date. If date is null then set date2 = DateTime.Today
- Similar approach to tertiary operator:

```
DateTime date3 = (date != null) ? date.GetValueOrDefault() : DateTime.Today;
```

# Dynamics
- Statically-typed languages: C#, Java (type resolution is done at compile time)
    - PRO: early feedback
- Dynamically-typed languages: Ruby, Javascript, Python (type resolution at run time)
    - easier and faster to code

- .NET 4 added the dynamic capability to improve interoperability with:
    - COM (e.g. writing office applications)
    - Dynamic Languages in .NET (IronPython)
```
dynamic excelObject = "Mark";
excelObject.Optimize();

dynamic name = "Mark";
name = 10;                  // This is fine. The type of "name" changes as it is assinged to

dynamic a = 10;
dynamic b = 5;
var c = a + b;              // c will end up dynamic because a and b are also dynamic
```

- type casts happen automatically to dynamic variables, as long as it's implicitly convertable

# Exception Handling
- we put the code that might throw an exception in a try / catch block
- catch block code runs when an exception occurs in the try block
- in the catch block we have a choice:
    - catch the exception and deal with it
    - pass the exception to the calling routine
- in general, the main program level should always be inside a try / catch block
- can have multiple catch blocks, going from most to least specific. The order is important

```
try
{

}
catch (Exception ex)
{
    throw;
}
finally
{

}
```

- `System.Exception` is the top level type of call exceptions
    - .Message: the exception text
    - .Source: the place where the exception happened
    - .StackTrace: the stack trace up to when the exception happened
    - .TargetSite: The exact place where the exception happened
- `finally` block
    - used to manually do a clean-up of unmanaged resources
    - `IDisposable` disposes of these e.g. a StreamReader to close open files
- `using` statement negates the need for a `finally` block:
```
try
{
    using (var streamReader = new StreamReader(@"c:\file.zip"))
    {
        var content = streamReader.ReadToEnd();
    }
}
catch (Exception ex)
    ...
```

## Custom Exceptions
- create a class that derives from Exception:
- just need to pass the message and exception to the base
```
public class YouTubeException : Exception
{
    public YoutubeException(string message, Exception innerException)
        : base(message, innerException)
    {
        ...
    }
}

// To use this can call YouTubeException:
throw new YouTubeException("Could not fetch videos from YouTube", ex);
```

## Stack Trace
A stack trace shows the history of calls that happened before the exception, in reverse order. The stack trace is show along with the exception.

# Useful Classes
## Console
Used to interact with the console
- Console.WriteLine("x"); # Prints "x" to the Console
## Convert
A collection of conversion methods for changing variable types
- Convert.ToInt32(s);
## DateTime (System)
- DateTime objects are immutable. Once they are set they cannot be changed
- DateTime.Now          # The time now
- DateTime.Today        # Today's date
```
var now = DateTime.Now;
var today = DateTime.Today;
Console.WriteLine("Hour: " + now.Hour);
Console.WriteLine("Minute: " + now.Minute);
```
- there are many methods beginning with "Add" which change the dates
```
var tomorrow = now.AddDays(1);
var yesterday = now.AddDays(-1);
Console.WriteLine(now.ToLongDateString());      // Long format, date only
Console.WriteLine(now.ToShortDateString());     // Short format, date only
Console.WriteLine(now.ToLongTimeString());      // Long format, time only
Console.WriteLine(now.ToShortTimeString());     // Short format, time only
Console.WriteLine(now.ToString("yyyy-MM-dd"));  // Convert the date to a string, with format
```
## TimeSpan
```
var timeSpan = new TimeSpan(1, 2, 3);           // One hour, two minutes, three seconds
var timeSpan1 = new TimeSpan(1, 0, 0);           // Specify only one hour
```
It's not clear what these numbers mean. TimeSpan has methods for clarity
```
var timeSpan2 = TimeSpan.FromHours(1);          // same as timeSpan1 definition
```
Working with TimeSpan:
```
var start = DateTime.Now;
var end = DateTime.Now.AddMinutes(2);
var duration = end - start;
Console.WriteLine("Duration: " + duration);
```
## Random
`random.Next();`
- returns a non-negative random number

`random.Next(minValue, maxValue)`
- random numbers between minValue and maxValue
- can use this to generate random characters by casting to char:
```
var random = new Random();
Console.WriteLine("Random character: " + (char)random.Next((int)'a', (int)'z'));
Console.WriteLine("Random character: " + (char)('a' + random.Next(0, 26)));
```

# Visual Studio Shortcuts
- CMD-click on a type, method or class brings up the Assembly Browser so you can look through the available methods
- type cw <tab><tab> will fill in Console.WriteLine()