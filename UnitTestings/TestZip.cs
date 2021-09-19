using NUnit.Framework;

namespace SevenZipExtractor.Tests
{
    [TestFixture]
    public class TestZip : TestBase
    {
        [Test]
        public void TestGuessAndExtractToStream_OK()
        {
            this.TestExtractToStream(Resources.TestFiles.zip, this.TestEntriesWithFolder);
        }

        [Test]
        public void TestKnownFormatAndExtractToStream_OK()
        {
            this.TestExtractToStream(Resources.TestFiles.zip, this.TestEntriesWithFolder, SevenZipFormat.Zip);
        }
    }
}