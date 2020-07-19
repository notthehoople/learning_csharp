using System;
using System.IO;

namespace ExceptionHandling
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Example showing multiple catch blocks with decreasingly specific Exceptions
            try
            {
                var calculator = new Calculator();
                var result = calculator.Divide(5, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divide by Zero");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Arith exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred");
            }
            finally
            {

            }

            // Another example showing the finally block being used
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"C:\file.zip");
                var content = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred");
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Dispose();
            }

            // This can be cleaned up with the "using" statement, which creates a "finally" block under the hood:
            try
            {
                using (var streamReaderClean = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReaderClean.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred");
            }

            // Custom exceptions
            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("mark");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
