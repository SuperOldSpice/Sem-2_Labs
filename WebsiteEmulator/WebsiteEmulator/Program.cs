using System;
using System.Collections.Generic;
using WebsiteEmulatorLibrary;

namespace WebsiteEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Website news = new Website("NewsSite");
            bool alive = true;
            Console.WriteLine("\nWelcome to the News Website!");
            while(alive)
            {
                Console.WriteLine("\nSelect the operation:");
                Console.WriteLine("1. Create new account \t 2. Log in existing account \t" +
                    "3. Enter as guest \n4. Exit the website");
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            CreateAccount(news);
                            break;
                        case 2:
                            LogIn(news);
                            break;
                        case 3:
                            SeeNews(news);
                            break;
                        case 4:
                            alive = false;
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);  
                }
                
            }   
        }
        
        public static void CreateAccount(Website news)
        {
            bool alive = true;
            int type = 0;
            while (alive)
            {
                Console.WriteLine("Select the tipe of Account:");
                Console.WriteLine("1. User \t 2. Moderator (you need a key)");
                type = Convert.ToInt32(Console.ReadLine());
                if (type == 1)
                {
                    alive = false;
                    break;
                }
                else if (type == 2)
                {
                    Console.WriteLine("Enter the special key:");
                    string key = Console.ReadLine();
                    if (key == "1111")
                    {
                        alive = false;
                        break;
                    }
                    else throw new Exception("Wrong key, pls try again!");
                }
                else throw new Exception("Wrong input!");
            }

            alive = true;
            string email = "";
            while (alive)
            {
                Console.WriteLine("Enter your e-mail:");
                email = Console.ReadLine();
                if (!news.EmailExist(email))
                {
                    alive = false;
                }
                else Console.WriteLine("Email adress was alredy taken!");
            }

            alive = true;
            string password = "";
            while (alive)
            {
                Console.WriteLine("Enter your password:");
                string password_1 = Console.ReadLine();
                Console.WriteLine("Confirm your password:");
                string password_2 = Console.ReadLine();
                if (password_1 == password_2)
                {
                    alive = false;
                    password = password_1;
                }
                else
                {
                    Console.WriteLine("Passwords are different, pls enter passwords again!");
                }
            }

            alive = true;
            string nickname = "";
            while (alive)
            {
                Console.WriteLine("Make a nickname:");
                nickname = Console.ReadLine();
                int ID = news.FindAccountID(nickname);
                if (ID != -1) Console.WriteLine("Name has been taken already!");
                else alive = false;
            }

            if (type == 1) news.NewAccount(AccountType.User, nickname, email, password);
            else if (type == 2) news.NewAccount(AccountType.Moderator, nickname, email, password);
            Console.WriteLine("Account was created");
        }

        public static void LogIn(Website news)
        {
            Console.WriteLine("Enter your nickname:");
            string nickname = Console.ReadLine();
            int ID = news.FindAccountID(nickname);
            if (ID != -1)
            {
                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();
                if (news.PasswordCheck(ID, password)) UserSesion(news, ID, password, nickname) ;
                else
                {
                    throw new Exception("Wrong password!");
                }
            }
            else throw new Exception("Wrong Nickname!");

        }

        public static void UserSesion(Website news, int userID, string password, string nickname)
        {
            bool alive = true;
            while (alive)
            {
                Console.WriteLine($"\nYou logged in as {nickname}");
                Console.WriteLine("Select the operation:");
                Console.WriteLine("1. See news\t 2. Make news \t3. Edit news \n" +
                    "4. Exit account\t");
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());
                    switch(command)
                    {
                        case 1:
                            SeeNews(news);
                            break;
                        case 2:
                            MakeNews(news, userID);
                            break;
                        case 3:
                            EditNews(news, userID);
                            break;
                        case 4:
                            alive = false;
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void SeeNews(Website news)
        {
            Console.WriteLine("Select the searching type:");
            Console.WriteLine("1. Search by rubrics and subjects\t 2. Search by user \t3. Search by date \n" +
                "4. Search by tags");
            try
            {
                int command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        SortNewsByRubricsNSubjects(news);
                        break;
                    case 2:
                        SortNewsByUser(news);
                        break;
                    case 3:
                        SortByDate(news);
                        break;
                    case 4:
                        SortByTags(news);
                        break;
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SortNewsByRubricsNSubjects(Website news)
        {
            if(SeeRubrics(news))
            {
                Console.WriteLine("Select the rubric:");
                try
                {
                    int rubricID = Convert.ToInt32(Console.ReadLine());
                    bool subjectExists = SeeSubjects(news, rubricID);
                    if (subjectExists)
                    {
                        Console.WriteLine("Select the subject:");
                        int subjectIndex = Convert.ToInt32(Console.ReadLine());
                        List<string> newsInfo = news.GetNewsInfo(rubricID, subjectIndex);
                        if (newsInfo == null) Console.WriteLine("There are no any news yet");
                        else
                        {
                            Console.WriteLine("\nNews:");
                            for(int i = 0; i < newsInfo.Count; i++)
                                Console.WriteLine($"{i}. {newsInfo[i]}");
                            Console.WriteLine("Select the news:");
                            int newsIndex = Convert.ToInt32(Console.ReadLine());
                            List<string> newsPrint = news.GetNews(rubricID, subjectIndex, newsIndex);
                            if(newsPrint == null)
                            {
                                Console.WriteLine("Does not exists");
                                return;
                            }
                            Console.WriteLine();
                            foreach(string text in newsPrint)
                            {
                                Console.WriteLine(text);
                            }
                        }
                    }
                    
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("ID does not exists");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void SortNewsByUser(Website news)
        {
            Console.WriteLine("Enter user name");
            string userName = Console.ReadLine();
            int userID = news.FindAccountID(userName);
            if (userID == -1) throw new Exception("User does not exists");
            List<string> newsInfo = news.GetNewsInfoByUser(userID);
            foreach (string line in newsInfo)
                Console.WriteLine(line);
            Console.WriteLine("Select the news(by ID):");
            int newsID = Convert.ToInt32(Console.ReadLine());
            List<int> path = news.GetPathByNewsID(newsID);
            List<string> newsPrint = news.GetNewsByID(path[1], path[2], newsID);
            if (newsPrint == null)
            {
                Console.WriteLine("Does not exists");
                return;
            }
            Console.WriteLine();
            foreach (string text in newsPrint)
            {
                Console.WriteLine(text);
            }
        }

        public static void SortByDate(Website news)
        {
            Console.WriteLine("Enter the date:");
            string date = Console.ReadLine();
            List<string> newsInfo = news.GetNewsInfoByDate(date);
            foreach (string info in newsInfo)
                Console.WriteLine(info);
            Console.WriteLine("Select the news (write an ID):");
            int newsID = Convert.ToInt32(Console.ReadLine());
            List<int> path = news.GetPathByNewsID(newsID);
            List<string> newsPrint = news.GetNewsByID(path[1], path[2], newsID);
            if (newsPrint == null)
            {
                Console.WriteLine("Does not exists");
                return;
            }
            Console.WriteLine();
            foreach (string text in newsPrint)
            {
                Console.WriteLine(text);
            }

        }

        public static void SortByTags(Website news)
        {
            Console.WriteLine("Enter the tags (in one string):");
            string news_tag = Console.ReadLine();
            string[] tags_arr = news_tag.Split(" ");
            List<string> tags = new List<string> { };
            foreach (string i in tags_arr)
            {
                tags.Add(i);
            }
            List<string> newsInfo = news.SearchByTags(tags);
            if(newsInfo == null)
            {
                Console.WriteLine("Does not exists");
                return;
            }
            foreach (string line in newsInfo)
                Console.WriteLine(line);
            Console.WriteLine("Select the news (write an ID):");
            int newsID = Convert.ToInt32(Console.ReadLine());
            List<int> path = news.GetPathByNewsID(newsID);
            List<string> newsPrint = news.GetNewsByID(path[1], path[2], newsID);
            if (newsPrint == null)
            {
                Console.WriteLine("Does not exists");
                return;
            }
            Console.WriteLine();
            foreach (string text in newsPrint)
            {
                Console.WriteLine(text);
            }
            
        }

        public static bool SeeRubrics(Website news)
        {
            List<string> rubrics = news.GetRubrics();
            if (rubrics == null)
            {
                Console.WriteLine("There are no any rubrics yet");
                return false;
            }
            else
            {
                Console.WriteLine("\nRubrics");
                for (int i = 0; i < rubrics.Count; i ++)
                    Console.WriteLine($"{i}. {rubrics[i]}");
                return true;
            }
        }

        public static bool SeeSubjects(Website news, int ID)
        {
            List<string> subjects = news.GetSubjects(ID);
            
            if (subjects == null)
            {
                Console.WriteLine("There are no any subjects yet");
                return false;
            
            }
            else
            {
                //List<int> subjectsID = news.GetSubjectsID(ID);
                Console.WriteLine("\nSubjects");
                for (int i = 0; i < subjects.Count; i++)
                    Console.WriteLine($"{i}. {subjects[i]}");
                return true;
            }
        }

        public static void MakeNews(Website news, int ID)
        {
            bool rubricsExists = SeeRubrics(news);
            Console.WriteLine("Select the rubric or create your own by pressing 'c' (eng):");
            try
            {
                var command = Console.ReadLine();
                if(command == "c")
                {
                    Console.WriteLine("Enter the rubric name:");
                    string name = Console.ReadLine(); ;
                    news.CreateRubric(name);
                }
                else
                {
                    if (!rubricsExists)
                    {
                        Console.WriteLine("Does not exitst");
                        return;
                    }
                    int rubricID = Convert.ToInt32(command);
                    bool rubricExists = news.CheckRubricExists(rubricID);
                    bool subjectsExists = SeeSubjects(news, rubricID);
                    Console.WriteLine("Select the subject or create your own by pressing 'c' (eng):");
                    command = Console.ReadLine();
                    if (command == "c")
                    {
                        Console.WriteLine("Enter the subject name:");
                        string name = Console.ReadLine(); ;
                        news.CreateSubject(name, rubricID);
                    }
                    else
                    {
                        if (!subjectsExists)
                        {
                            Console.WriteLine("Does not exitst");
                            return;
                        }
                        int subjectIndex = Convert.ToInt32(command);
                        bool subjectExists = news.CheckSubjectExists(rubricID, subjectIndex);
                        EnterNews(news, ID, rubricID, subjectIndex);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void EnterNews(Website news, int userID,int rubricID, int subjectIndex)
        {
            Console.WriteLine("Enter todays date");
            string date = Console.ReadLine();
            Console.WriteLine("Enter the News Header");
            string header = Console.ReadLine();
            Console.WriteLine("Enter news:");
            List<string> newText = new List<string> { };
            string str = Console.ReadLine();
            while(str != "")
            {
                newText.Add(str);
                str = Console.ReadLine();
            }
            Console.WriteLine("Enter the tags (in one string):");
            string news_tag = Console.ReadLine();
            string[] tags_arr = news_tag.Split(" ");
            List<string> tags = new List<string> { };
            foreach(string i in tags_arr)
            {
                tags.Add(i);
            }
            news.CreateNews(userID, rubricID, subjectIndex, header, newText, tags, date);
        }
    
        
        public static void EditNews(Website news, int userID)
        {
            try
            {
                Console.WriteLine("Enter news ID:");
                int newsID = Convert.ToInt32(Console.ReadLine());
                List<string> text = news.FindNews(userID, newsID);
                if (text == null)
                {
                    Console.WriteLine("Does not exists");
                    return;
                }
                foreach (string line in text)
                    Console.WriteLine(line);
                List<int> path = news.GetPathByNewsID(newsID);
                Console.WriteLine("Edit your news:");
                Console.WriteLine("Enter todays date");
                string date = Console.ReadLine();
                Console.WriteLine("Enter the News Header");
                string header = Console.ReadLine();
                Console.WriteLine("Enter news:");
                List<string> newText = new List<string> { };
                string str = Console.ReadLine();
                while (str != "")
                {
                    newText.Add(str);
                    str = Console.ReadLine();
                }
                Console.WriteLine("Enter the tags (in one string):");
                string news_tag = Console.ReadLine();
                string[] tags_arr = news_tag.Split(" ");
                List<string> tags = new List<string> { };
                foreach (string i in tags_arr)
                {
                    tags.Add(i);
                }
                news.EditNews(path[3], userID, path[1], path[2], header, newText, tags, date);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
    }
}
