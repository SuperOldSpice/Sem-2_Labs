using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteEmulatorLibrary
{
    class News
    {
        internal string header { get; private set; }
        internal int ID { get; private set; }
        private static int counter  = 0;
        internal string date { get; private set; }
        internal List<string> text { get; private set; } 
        internal List<string> tags { get; private set; }
        public News(string newHeader, List<string> newText, List <string> newTags, string newDate)
        {
            header = newHeader;
            ID = counter;
            counter++;
            text = newText;
            tags = newTags;
            date = newDate; 
        }

        internal string GetNewsInfo()
        {
            string information = "ID:" + ID + "  " + header;
            return information;
        }

        internal List<string> GetNews()
        {
            List<string> news = new List<string> { };
            news.Add("Date: " + date);
            news.Add("ID:" + ID);
            news.Add(header + "\n");
            news.Add("*************");
            foreach(string str in text)
            {
                news.Add(str);
            }
            news.Add("*************");
            news.Add("\n");
            string tagsString = "tags: ";
            foreach (string str in tags)
            {
                tagsString += str + " ";
            }
            news.Add(tagsString);
            return news;
        }

        internal void EditNews(string newHeader, List<string> newText, List<string> newTags, string newDate)
        {
            header = newHeader;
            text = newText;
            tags = newTags;
            date = newDate;
        }

        internal static int GetLastID()
        {
            return counter - 1;
        }
    }
}
