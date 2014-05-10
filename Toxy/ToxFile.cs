using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toxy
{
    struct ToxFile
    {
        public readonly int FriendNumber;
        public readonly int FileNumber;

        public ToxFile(int friendnumber, int filenumber)
        {
            FriendNumber = friendnumber;
            FileNumber = filenumber;
        }
    }
}
