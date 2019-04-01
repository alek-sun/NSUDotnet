using System;
using System.Collections.Generic;
using System.Text;

namespace task3
{
    abstract class CommentStructure
    {
        protected string CommentBeginBin;
        protected string CommentEndBin;
        protected string CommentBegin;
        protected List<string> Extensions;

        public string GetCommentBegin()
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
        }

        public List<string> GetExtensions()
        {
            return Extensions;
        }
    }
}
