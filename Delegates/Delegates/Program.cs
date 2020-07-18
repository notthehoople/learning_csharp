using System;

namespace Delegates
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var processor = new Photoprocessor();
            var filters = new PhotoFilters();

            Photoprocessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            Console.WriteLine("============================");
            Console.WriteLine("Running with custom delegate");
            processor.Process("photo.jpg", filterHandler);

            // Now let's use the .NET framework delegates instead of a custom one
            var processorDotNet = new PhotoProcessorDotNet();
            var filtersDotNet = new PhotoFilters();

            Action<Photo> filterHandlerDotNet = filters.ApplyBrightness;
            filterHandlerDotNet += filters.ApplyContrast;
            filterHandlerDotNet += RemoveRedEyeFilter;

            Console.WriteLine("============================");
            Console.WriteLine("Running with DotNet delegate");
            processorDotNet.Process("photo.jpg", filterHandlerDotNet);

        }

        // Can extend the framework by adding our own custom filters
        // The signature of the method needs to match the delegate definition in Photoprocessor.cs
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RedEye removal");
        }
    }
}
