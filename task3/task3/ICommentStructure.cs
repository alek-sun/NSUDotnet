using System;
using System.Collections.Generic;
using System.Text;

namespace task3
{
    interface ICommentStructure
    {
        string CommentBeginBin { get; }
        string CommentEndBin{ get; }
        string CommentBegin { get; }
        List<string> Extensions { get; }
    }
}
