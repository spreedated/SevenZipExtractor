using NUnit.Framework;

namespace SevenZipExtractor.Tests
{
    [TestFixture]
    public class Test7Zip : TestBase
    {
        // 7Z does not provide folder as entry, only files

        [Test]
        public void TestGuessAndExtractToStream_OK()
        {
            this.TestExtractToStream(Resources.TestFiles.SevenZip, this.TestEntriesWithoutFolder);
        }


        [Test]
        public void TestKnownFormatAndExtractToStream_OK()
        {
            this.TestExtractToStream(Resources.TestFiles.SevenZip, this.TestEntriesWithoutFolder, SevenZipFormat.SevenZip);
        }
    }
}