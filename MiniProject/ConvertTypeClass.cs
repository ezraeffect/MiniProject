using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public enum Type : int // 자료형별 bit를 지정합니다.
    {
        BYTE = 8,   // 8bit (1 byte)
        WORD = 16,  // 16bit (2 byte)
        DWORD = 32, // 32bit (4 byte)
        QWORD = 64  // 64bit (8 byte)
    }
    internal class ConvertTypeClass
    {
    }
}
