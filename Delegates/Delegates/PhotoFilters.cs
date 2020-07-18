using System;

namespace Delegates
{
    public class PhotoFilters
    {
        internal void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        internal void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }

        internal void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }
    }
}
