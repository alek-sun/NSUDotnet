using System.Collections.Generic;

namespace task3
{
    class JavaCommentStructure : CommentStructure
    {     
        public JavaCommentStructure()
        {
            CommentBeginBin = "/*";
            CommentEndBin = "*/";
            CommentBegin = "//";
            Extensions = new List<string> (new string[] {
                ".c", ".cpp", ".java"
            });
        }        
    }
}
