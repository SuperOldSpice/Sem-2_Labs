using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteEmulatorLibrary
{
  
    public enum AccountType
    {
        User,
        Moderator
    }

    public class Website
    {
        /// <summary>
        /// news handler
        /// </summary>

        List<Rubric> rubrics = null;
        private int counter = 0;

        internal List<List<int>> path { get; private set; } = null;

        public void CreateRubric(string name)
        {
            if (rubrics == null) rubrics = new List<Rubric> { new Rubric(name) };
            else rubrics.Add(new Rubric(name));
            counter++;
        }

        public void CreateSubject(string name, int rubricID)
        {
            rubrics[rubricID].NewSubject(name);
        }

        public void CreateNews(int userID, int rubricID, int subjectIndex, string newHeader, List<string> newText, List<string> newTags, string date)
        {

            rubrics[rubricID].AddNews(subjectIndex, newHeader, newText, newTags, date);
            int newsID = News.GetLastID();
            int subjectID = rubrics[rubricID].subjects[subjectIndex].ID;
            path.Add(new List<int> { userID, rubricID, subjectID, newsID });
            accounts[userID].AddNewsID(newsID);
        }

        public List<string> GetRubrics()
        {
            if (rubrics == null) return null;
            int n = rubrics.Count;
            List<string> rubricNames = new List<string> { };
            for (int i = 0; i < n; i++)
            {
                rubricNames.Add(rubrics[i].name);
            }
            return rubricNames;
        }

        public List<string> GetSubjects(int rubricID)
        {
            if (rubrics == null) return null;
            if (rubricID > rubrics.Count - 1) return null;
            try
            {
                return rubrics[rubricID].GetSubjects();
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Does not exists");
            }
        }

        public List<string> GetNews(int rubricID, int subjectIndex, int newsIndex)
        {

            return rubrics[rubricID].GetNews(subjectIndex, newsIndex);
        }

        public List<string> GetNewsByID(int rubricID, int subjectID, int newsID)
        {
            int subjectIndex = rubrics[rubricID].FindIndexByID(subjectID);
            int newsIndex = rubrics[rubricID].subjects[subjectIndex].FindIndexByID(newsID);
            return rubrics[rubricID].GetNews(subjectIndex, newsIndex);
        }

        public List<int> GetSubjectsID(int rubricID)
        {
            return rubrics[rubricID].GetSubjectsID();
        }

        public List<string> GetNewsInfo(int rubricID, int subjectIndex)
        {
            try
            {
                return rubrics[rubricID].GetNewsInfo(subjectIndex);
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Does not exists");
            }
        }

        public List<string> FindNews(int userID, int newsID)
        {
            if (path == null) return null;
            if (!accounts[userID].PermissionCheck(newsID)) throw new Exception("Permission denied");
            List<string> text = null;
            foreach (List<int> way in path)
                if (way[3] == newsID)
                    text = this.GetNewsByID(way[1], way[2], way[3]);
            return text;
        }

        public List<int> GetPathByNewsID(int newsID)
        {
            if (path == null) throw new Exception("Does not exists");
            List<int> position = null;
            foreach (List<int> way in path)
                if (way[3] == newsID)
                    position = way;
            if (position == null) throw new Exception("Does not exists");
            return position;
        }

        public void EditNews(int newsID, int userID, int rubricID, int subjectID, string newHeader, List<string> newText, List<string> newTags, string date)
        {
            int subjectIndex = rubrics[rubricID].FindIndexByID(subjectID);
            int newsIndex = rubrics[rubricID].subjects[subjectIndex].FindIndexByID(newsID);
            if (News.GetLastID() < newsID) throw new Exception("Does not exists");
            if (!accounts[userID].PermissionCheck(newsID)) throw new Exception("Permission denied");
            rubrics[rubricID].subjects[subjectIndex].news[newsIndex].EditNews(newHeader, newText, newTags, date);
        }

        public List<string> GetNewsInfoByUser(int userID)
        {
            List<string> newsInfo = null;
            foreach (int newsID in accounts[userID].userNewsID)
            {
                List<int> path = GetPathByNewsID(newsID);
                int rubricIndex = path[1];
                int subjectIndex = rubrics[rubricIndex].FindIndexByID(path[2]);
                int newsIndex = rubrics[rubricIndex].subjects[subjectIndex].FindIndexByID(path[3]);
                string info = rubrics[rubricIndex].subjects[subjectIndex].news[newsIndex].GetNewsInfo();
                if (newsInfo == null) newsInfo = new List<string> { info };
                else newsInfo.Add(info);
            }
            if (newsInfo == null) throw new Exception("User does not have any news");
            return newsInfo;
        }

        public List<string> GetNewsInfoByDate(string date)
        {
            List<string> newsInfo = null;
            if (rubrics != null)
                foreach (Rubric rubric in rubrics)
                    if (rubric.subjects != null)
                        foreach (Subject subject in rubric.subjects)
                            if (subject.news != null)
                                foreach (News news in subject.news)
                                    if (date == news.date)
                                    {
                                        if (newsInfo == null) newsInfo = new List<string> { news.GetNewsInfo() };
                                        else
                                            newsInfo.Add(news.GetNewsInfo());
                                    }


            if (newsInfo == null) throw new Exception("There no any news with that creation date");
            return newsInfo;
        }

        public List<string> SearchByTags(List<string> tags)
        {
            List<string> newsInfo = null;
            if (rubrics != null)
                foreach (Rubric rubric in rubrics)
                    if (rubric.subjects != null)
                        foreach (Subject subject in rubric.subjects)
                            if (subject.news != null)
                                foreach (News news in subject.news)
                                    foreach (string tag in tags)
                                        foreach (string newsTag in news.tags)
                                            if (tag == newsTag)
                                            {
                                                if (newsInfo == null) newsInfo = new List<string> { news.GetNewsInfo() };
                                                else newsInfo.Add(news.GetNewsInfo());
                                                break;
                                            }              
            return newsInfo;
        }


        public bool CheckRubricExists(int rubricID)
        {
            if (rubricID > counter - 1) throw new Exception("Rubric does not exists");
            else return true;
        }

        public bool CheckSubjectExists(int rubricID, int subjectIndex)
        {
            if (rubrics[rubricID].subjects == null) throw new Exception("Subject does not exists");
            int i = 0;
            foreach (Subject sub in rubrics[rubricID].subjects)
                i++;
            if (i >= subjectIndex) return true;
            else throw new Exception("Subject does not exists");
        }
        /// <summary>
        /// account handler
        /// </summary>

        List<Account> accounts = null;
        public string Name { get; private set; }
        public Website(string name)
        {
            Name = name;
            path = new List<List<int>> { };
        }

        public void NewAccount(AccountType accountType, string name, 
            string email, string password)
        {
            Account newAccount = null;

            switch(accountType)
            {
                case AccountType.Moderator:
                    newAccount = new Moderator(name, email, password) as Account;
                    break;

                case AccountType.User:
                    newAccount = new User(name, email, password) as Account;
                    break;
            }

            if (newAccount == null)
                throw new Exception("Account creation error");

            if (accounts == null)
                accounts = new List<Account> { newAccount };
            else
                accounts.Add(newAccount);
        }

        public int FindAccountID (string nickname)
        {
            if (accounts == null) return -1;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].NickCheck(nickname)) return accounts[i].ID;
            }
            return -1;
        }

        public bool PasswordCheck(int ID, string password)
        {
            if (accounts[ID].CheckPassword(password)) return true;
            else return false;
        }

        public bool EmailExist(string email)
        {
            if (accounts == null) return false;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].EmailCheck(email)) return true;
            }
            return false;
        }

   
    }
}
