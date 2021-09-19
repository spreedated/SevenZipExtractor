using NUnit.Framework;

namespace SevenZipExtractor.Tests
{
    [TestFixture]
    public class TestLzh : TestBase
    {
        // LZH does not provide folder as entry, only files

        [Test]
        public void TestGuessAndExtractToStream_Fails()
        {
            Assert.Throws<SevenZipException>(() =>
            {
                this.TestExtractToStream(Resources.TestFiles.lzh, this.TestEntriesWithoutFolder);
            });
        }

        [Test]
        public void TestKnownFormatAndExtractToStream_OK()
        {
            this.TestExtractToStream(Resources.TestFiles.lzh, this.TestEntriesWithoutFolder, SevenZipFormat.Lzh);
        }
    }
}