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
        private Stream _stream;
        private int _bufferSize;
        byte[] _buffer;

        public StreamDecoder (Stream stream, int bufferSize = 256, char messageEndingSymbol = ';')
        {
            _stream = stream;
            _bufferSize = bufferSize;
            _messageEndingSymbol = messageEndingSymbol;
            _buffer = new byte[_bufferSize];
            _stream.Read(_buffer, 0, _bufferSize);
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
            var nullIndex = Array.IndexOf(_buffer, (byte)0);
            nullIndex = nullIndex != -1 && _buffer[nullIndex - 1] == _messageEndingSymbol ? nullIndex - 1 : _buffer.Length;
            return Encoding.UTF8.GetString(_buffer, 0, nullIndex);
        }

        public byte[] GetBytes()
        {
            byte[] buffer = new byte[_bufferSize];
            _stream.Read(buffer, 0, _bufferSize);
            return buffer;
        }
    }
}
