using System;
using System.Collections.Generic;
using System.Text;

namespace task3
{
    class JavaCommentStructure : CommentStructure
    {
        readonly string CommentBeginBin;
        readonly string CommentEndBin;
        readonly string CommentBegin;
        readonly List<string> Extensions;
        

        public JavaCommentStructure()
        {
            CommentBeginBin = "/*";
            CommentEndBin = "*/";
            CommentBegin = "//";
            Extensions = new List<string> (new string[] {
                ".c", ".cpp", ".java"
            });
        }

        /*public string GetCommentBegin()
        {
            return CommentBegin;
        }

        public string GetCommentBeginBin()
        {
            return CommentBeginBin;
        }

        public string GetCommentEndBin()
        {
            return CommentEndBin;
        }*/
    }
}
