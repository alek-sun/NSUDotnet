using System.Collections.Generic;

namespace task3
{
    class JavaCommentStructure : ICommentStructure
    {
        public string CommentBeginBin { get { return "/*"; } }
        public string CommentEndBin => "*/";
        public string CommentBegin => "//";
        public List<string> Extensions => new List<string> {
                ".c", ".cpp", ".java"
            };  
    }
}
