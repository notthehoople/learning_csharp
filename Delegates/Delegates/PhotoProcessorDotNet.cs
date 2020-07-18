using System;

namespace Delegates
{
    public class PhotoProcessorDotNet
    {
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            // By calling the filterHandler this method doesn't know which photo process will be applied
            // It's up to the client to define this
            filterHandler(photo);

            photo.Save();
        }
    }
}
