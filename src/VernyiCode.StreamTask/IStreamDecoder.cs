using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VernyiCode.StreamTask
{
    public interface IStreamDecoder
    {
        StreamDecoder SetMessageEndingSymbol(char symbol);
        StreamDecoder SetBufferSize(int bufferSize);
        string GetMessageByByteArray();
    }
}
