﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SevenZipExtractor.Tests
{
    public abstract class TestBase
    {
        protected IList<TestFileEntry> TestEntriesWithFolder =
        [
                new() { Name = "image1.jpg", IsFolder = false, MD5 = "b3144b66569ab0052b4019a2b4c07a31"},
                new() { Name = "image2.jpg", IsFolder = false, MD5 = "8fdd4013edcf04b335ac3a9ce0c13887"},
                new() { Name = "testFolder", IsFolder = true},
                new() { Name = "testFolder\\image3.jpg", IsFolder = false, MD5 = "24ffd227340432596fe61ef6300098ad"},
        ];

        protected IList<TestFileEntry> TestEntriesWithoutFolder =
        [
                new() { Name = "image1.jpg", IsFolder = false, MD5 = "b3144b66569ab0052b4019a2b4c07a31"},
                new() { Name = "image2.jpg", IsFolder = false, MD5 = "8fdd4013edcf04b335ac3a9ce0c13887"},
                new() { Name = "testFolder\\image3.jpg", IsFolder = false, MD5 = "24ffd227340432596fe61ef6300098ad"},
        ];

        protected void TestExtractToStream(byte[] archiveBytes, IList<TestFileEntry> expected, SevenZipFormat? sevenZipFormat = null)
        {
            MemoryStream memoryStream = new(archiveBytes);

            using (ArchiveFile archiveFile = new(memoryStream, sevenZipFormat))
            {
                foreach (TestFileEntry testEntry in expected)
                {
                    Entry entry = archiveFile.Entries.FirstOrDefault(e => e.FileName == testEntry.Name && e.IsFolder == testEntry.IsFolder);

                    Assert.IsNotNull(entry, "Entry not found: " + testEntry.Name);

                    if (testEntry.IsFolder)
                    {
                        continue;
                    }

                    using (MemoryStream entryMemoryStream = new())
                    {
                        entry.Extract(entryMemoryStream);

                        if (testEntry.MD5 != null)
                        {
                            Assert.AreEqual(testEntry.MD5, entryMemoryStream.ToArray().MD5String(), "MD5 does not match: " + entry.FileName);
                        }

                        if (testEntry.CRC32 != null)
                        {
                            Assert.AreEqual(testEntry.CRC32, entryMemoryStream.ToArray().CRC32String(), "CRC32 does not match: " + entry.FileName);
                        }
                    }
                }
            }

        }
    }
}