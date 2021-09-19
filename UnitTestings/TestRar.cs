using NUnit.Framework;

namespace SevenZipExtractor.Tests
{
    [TestFixture]
    public class TestRar : TestBase
    {
        [Test]
        public void TestGuessAndExtractToStream_OK()
        {
            this.TestExtractToStream(Resources.TestFiles.rar, this.TestEntriesWithFolder);
        }

        [Test]
        public void TestKnownFormatAndExtractToStream_OK()
        {
            this.TestExtractToStream(Resources.TestFiles.rar, this.TestEntriesWithFolder, SevenZipFormat.Rar5);
        }
    }
}