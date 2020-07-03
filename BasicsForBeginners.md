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

## Structs
Small difference between a struct and a class. Structs are lighter, so if you are declaring thousands of them then structs will be more efficient
```
public struct RgbColour
{
    public int Red;
    public int Green;
    public int Blue;
}
```

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

# Useful Classes
## Console
Used to interact with the console
- Console.WriteLine("x"); # Prints "x" to the Console
## Convert
 A collection of conversion methods for changing variable types
 - Convert.ToInt32(s);

# Visual Studio Shortcuts
- CMD-click on a type, method or class brings up the Assembly Browser so you can look through the available methods
- type cw <tab><tab> will fill in Console.WriteLine()