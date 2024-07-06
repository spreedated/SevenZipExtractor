using System;

namespace SevenZipExtractor
{
    /// <summary>
    /// Custom exception class for SevenZipExtractor
    /// </summary>
    public class SevenZipException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public SevenZipException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SevenZipException(string message) : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public SevenZipException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}