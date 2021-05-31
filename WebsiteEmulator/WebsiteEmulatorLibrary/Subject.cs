using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteEmulatorLibrary
{
    class Subject
    {
        internal string name { get; private set; }
        internal int ID { get; private set; }
        private static int counter = 0;
        internal List<News> news { get; private set; } = null;
        internal Subject(string subjectName)
        {
            name = subjectName;
            ID = counter;
            counter++;
        }

        internal void NewNews(string header, List<string> newText, List<string> tags, string date)
        {
            if (news == null) news = new List<News> { new News(header, newText, tags, date) };
            else
            {
                news.Add(new News(header, newText, tags, date));
            }

        }

        internal List<string> GetNewsInfo()
        {
            try
            {
                if (news == null) return null;
                List<string> newsInfo = new List<string> { };
                if (news == null) return null;
                foreach (News i in news)
                {
                    newsInfo.Add(i.GetNewsInfo());
                }
                return newsInfo;
            }
            catch(IndexOutOfRangeException)
            {
                throw new Exception("Does not exists");
            }
        }

        internal List<string> GetNews(int newsIndex)
        {
            if (news == null || newsIndex > counter - 1) return null;
            return news[newsIndex].GetNews();
        }

        internal int FindNewsPath(int newsID)
        {
            if (news == null) return -1;
            foreach(News n in news)
            {
                if (n.ID == newsID)
                    return ID;
            }
            return -1;
        }

        internal int FindIndexByID(int newsID)
        {
            for (int i = 0; i < news.Count; i++)
                if (news[i].ID == newsID) return i;
            throw new Exception("Has not been found");
        }

    }
}
