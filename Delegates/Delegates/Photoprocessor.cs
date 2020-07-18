namespace Delegates
{
    public class Photoprocessor
    {

        // As defined this code isn't extensible. To add a new filter, this code needs to be added and re-compiled
        // Could be achieved using Interfaces or Delegates
        //
        //public void Process(string path)
        //{
        // var photo = Photo.Load(path);

            //var filters = new PhotoFilters();
            //filters.ApplyBrightness(photo);
            //filters.ApplyContrast(photo);
            //filters.Resize(photo);

            //photo.Save();
        //}

        // Delegate definition
        // An instance of this PhotoFilterHandler can hold a pointer to a function or group of functions with this signature
        // To make the method above extensible it needs to be changed to use a delegate method

        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Photo.Load(path);

            // By calling the filterHandler this method doesn't know which photo process will be applied
            // It's up to the client to define this
            filterHandler(photo);

            photo.Save();
        }
    }
}
