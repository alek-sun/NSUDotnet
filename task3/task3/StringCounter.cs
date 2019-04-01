using System.IO;

namespace task3
{
    class StringCounter
    {
        readonly CommentStructure CommentStructure;

        public StringCounter(CommentStructure structure)
        {
            CommentStructure = structure;
        }

        public int GetStringsCount(string path)
        {
            StreamReader sr = File.OpenText(path);
            string s;
            int stringsCount = 0;
            bool commentStarted = false;

            while ((s = sr.ReadLine()) != null)
            {
                s = s.Trim();

                if (!commentStarted && !(s.Contains(CommentStructure.GetCommentBegin())
                    || s.Contains(CommentStructure.GetCommentBeginBin()) || s.Contains(CommentStructure.GetCommentEndBin())))
                {
                    stringsCount++;
                    continue;
                }

                if (s.Contains(CommentStructure.GetCommentBegin()) 
                    || s.Contains(CommentStructure.GetCommentBeginBin()))
                {   
                    if (s.Contains(CommentStructure.GetCommentBeginBin())){
                        commentStarted = true;
                    }                    
                   
                    if (!(s.StartsWith(CommentStructure.GetCommentBegin())
                    || s.StartsWith(CommentStructure.GetCommentBeginBin())))
                    {
                        stringsCount++;
                    }

                }

                if (s.Contains(CommentStructure.GetCommentEndBin())){
                    commentStarted = false;
                    if (!s.EndsWith(CommentStructure.GetCommentEndBin()))
                    {
                        stringsCount++;
                    }
                }

                
            }
            return stringsCount;
        }
    }
}
