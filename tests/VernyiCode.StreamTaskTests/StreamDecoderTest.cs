using System.Text;
using VernyiCode.StreamTask;

namespace VernyiCode.StreamTaskTests
{
    public class StreamDecoderTest
    {
        [Fact]
        public void Test1()
        {
            string testMessage = "Test message here;";

            using (var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes(testMessage)))
            {
                var streamDecoder = new StreamDecoder(test_Stream);
                var streamMessage = streamDecoder.SetBufferSize(256).SetMessageEndingSymbol(';').GetMessageByByteArray();
                Assert.Equal(testMessage.Substring(0, testMessage.Length - 1), streamMessage);
            }
        }
    }
}