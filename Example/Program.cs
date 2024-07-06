#pragma warning disable IDE0060

using SevenZipExtractor;
using System;
using System.IO;

namespace Example
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            using (ArchiveFile archiveFile = new(@"Archive.arj"))
            {
                // extract all
                archiveFile.Extract("Output");
            }

            using (ArchiveFile archiveFile = new("archive.arj"))
            {
                foreach (Entry entry in archiveFile.Entries)
                {
                    Console.WriteLine(entry.FileName);

                    // extract to file
                    entry.Extract(entry.FileName);

                    // extract to stream
                    MemoryStream memoryStream = new();
                    entry.Extract(memoryStream);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
