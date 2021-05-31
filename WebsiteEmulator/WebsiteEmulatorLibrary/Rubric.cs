using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteEmulatorLibrary
{
    class Rubric
    {
        public string name{get; private set;}
        internal int ID { get; private set; }
        private static int counter = 0;

        internal List<Subject> subjects { get; private set; } = null;
        internal Rubric(string rubricName)
        {
            name = rubricName;
            ID = counter;
            counter++;
        }

        internal void NewSubject(string subjectName)
        {
            if (subjects == null) subjects = new List<Subject> { new Subject(subjectName) };
            else
            {
                subjects.Add(new Subject(subjectName));
            }

        }

        internal List<string> GetSubjects()
        {
            if (subjects == null) return null;
            int n = subjects.Count;
            List<string> subjectNames = new List<string> { };
            for (int i = 0; i < n; i++)
            {
                subjectNames.Add(this.subjects[i].name);
            }
            return subjectNames;
        }

        internal Subject this[int index]
        {
            get
            {
                return subjects[index];
            }
        }

        internal void AddNews(int subjectIndex, string header, List<string> newText, List<string> tags, string date)
        {
            try
            {
                subjects[subjectIndex].NewNews(header, newText, tags, date);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        internal List<int> GetSubjectsID()
        {
            if (subjects == null) return null;
            List<int> SubjectsID = new List<int> { };
            for (int i = 0; i < subjects.Count; i ++)
            {
                SubjectsID.Add(subjects[i].ID);
            }
            return SubjectsID;
        }

        internal List<string> GetNewsInfo(int subjectIndex)
        {
            try
            {
                List<string> newsInfo = this.subjects[subjectIndex].GetNewsInfo();
                return newsInfo;
            }
            catch(IndexOutOfRangeException)
            {
                throw new Exception("Does not exists");
            }
        }

        internal List<string> GetNews(int subjectIndex, int newsIndex)
        {
            return subjects[subjectIndex].GetNews(newsIndex);
        }

        internal List<int> FindNewsPath(int newsID)
        {
            if (subjects == null) return null;
            foreach(Subject s in subjects)
            {
                int subjectID = s.FindNewsPath(newsID);
                if (subjectID != -1)
                {
                    List<int> path = new List<int> { subjectID, newsID };
                    return path;
                }
            }
            return null;
        }

        internal int FindIndexByID(int subjectID)
        {
            for (int i = 0; i < subjects.Count; i++)
                if (subjects[i].ID == subjectID) return i;
            throw new Exception("Has been not found");
        }
    }
}
