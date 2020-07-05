using System;
using System.IO;

namespace CSharpFundamentals.Files
{
    public class FileUtility
    {
        public int WordCount(string fileName)
        {
            char[] charSeparators = new char[] { ' ', '\n' };

            if (fileName == null || fileName.Length == 0)
                return 0;

            FileInfo fileInfo = new FileInfo(fileName);

            if (!fileInfo.Exists)
                return 0;

            var fileText = File.ReadAllText(fileName);
            var words = fileText.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            var wordCount = 0;
            foreach (var word in words)
            {
                Console.WriteLine("Word: " + word);
                wordCount++;
            }

            return wordCount;
        }
    }
}
