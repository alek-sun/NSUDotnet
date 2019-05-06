using System.IO;

namespace task3
{
    class StringCounter
    {
        readonly ICommentStructure CommentStructure;

        public StringCounter(ICommentStructure structure)
        {
            CommentStructure = structure;
        }

        public int GetStringsCount(string path)
        {
            using (var sr = File.OpenText(path))
            {
                string s;
                int stringsCount = 0;
                bool commentStarted = false;

                while ((s = sr.ReadLine()) != null)
                {
                    s = s.Trim();

                    if (!commentStarted && !(s.Contains(CommentStructure.CommentBegin)
                        || s.Contains(CommentStructure.CommentBeginBin) || s.Contains(CommentStructure.CommentEndBin)))
                    {
                        stringsCount++;
                        continue;
                    }

                    if (s.Contains(CommentStructure.CommentBegin)
                        || s.Contains(CommentStructure.CommentBeginBin))
                    {
                        if (s.Contains(CommentStructure.CommentBeginBin))
                        {
                            commentStarted = true;
                        }

                        if (!(s.StartsWith(CommentStructure.CommentBegin)
                        || s.StartsWith(CommentStructure.CommentBeginBin)))
                        {
                            stringsCount++;
                        }

                    }

                    if (s.Contains(CommentStructure.CommentEndBin))
                    {
                        commentStarted = false;
                        if (!s.EndsWith(CommentStructure.CommentEndBin))
                        {
                            stringsCount++;
                        }
                    }


                }
                return stringsCount;
            }
        }
    }
}
