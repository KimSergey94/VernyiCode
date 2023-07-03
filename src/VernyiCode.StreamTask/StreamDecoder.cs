using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VernyiCode.StreamTask
{
    public class StreamDecoder : IStreamDecoder
    {
        private char _messageEndingSymbol = ';';
        private int _bufferSize = 256;
        private Stream _stream = null;

        public StreamDecoder (Stream stream)
        {
            _stream = stream;
        }

        private byte[] ReadBytes()
        {
            byte[] buffer = new byte[_bufferSize];
            int bytesRead = _stream.Read(buffer, 0, _bufferSize);
            return buffer;
        }

        public StreamDecoder SetBufferSize(int bufferSize)
        {
            _bufferSize = bufferSize;
            return this;
        }

        public StreamDecoder SetMessageEndingSymbol(char symbol)
        {
            _messageEndingSymbol = symbol;
            return this;
        }

        public string GetMessageByByteArray()
        {
            var bytes = ReadBytes();
            var nullIndex = Array.IndexOf(bytes, (byte)0);
            nullIndex = nullIndex != -1 && bytes[nullIndex - 1] == _messageEndingSymbol ? nullIndex - 1 : bytes.Length;
            return Encoding.UTF8.GetString(bytes, 0, nullIndex);
        }

        public byte[] GetBytes()
        {
            byte[] buffer = new byte[_bufferSize];
            _stream.Read(buffer, 0, _bufferSize);
            return buffer;
        }
    }
}
