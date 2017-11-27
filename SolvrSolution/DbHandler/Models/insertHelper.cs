using SolvrLibrary;
using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * This class uses the <T> to know which data to insert from the insertData folder.
 * It its generic and therefor it can be used to to all the data in the folder, though if a new txt file is added,
 * there must be a new method for creating it. Also if its a class that derives from another one
 * it needs to be teaking care of in InsertObjectsIntoDB(), just like with PhysicalPost and SolvrComment.
 * */
namespace DbHandler.Models
{
    public static class InsertHelper<T>
    {
        //This is the main method that inserts all the objects into the database. Notice the argument in 
        //the method call to ReadLinesFromFile, is set to 50. 
        public static void InsertObjectsIntoDB()
        {
            //This sets the FilePath of which txt file to use in InsertData. \.. is used to go back a dir.
            string txtFileName = typeof(T).Name;
            string filePath = Environment.CurrentDirectory + @"\..\..\InsertData\" + typeof(T).Name + ".txt";
            

            Boolean isDone = false;
            
            using (System.IO.StreamReader streamRdr = new StreamReader(filePath))
            {
                while (!isDone)
                {
                    List<T> objects = ReadLinesFromFile(50, streamRdr);

                    //Here the list objects is set into the database. The if statements are used to take care of 
                    //the special cases 
                    using (var context = new SolvrDB())
                    {
                        foreach (T obj in objects)
                        {
                            Console.WriteLine("Inserting " + obj + " on submit.");
                            if (typeof(T) == typeof(PhysicalPost))
                            {
                                context.Posts.InsertOnSubmit((PhysicalPost)(object)obj);
                            }
                            else if (typeof(T) == typeof(SolvrComment))
                            {
                                context.Comments.InsertOnSubmit((SolvrComment)(object)obj);
                            }
                            
                            else 
                            {
                                context.GetTable(obj.GetType()).InsertOnSubmit(obj);
                            }
                        }
                        context.SubmitChanges();
                    }

                    if (objects.Count < 50)
                    {
                        isDone = true;
                    }
                }
          }
    }
        
        /*Open op the txt file and reads one line at a time. This line is seperated into subStrings at the
         character | it thens build the deseried object and adds it to a list whihc is returned after it have read
         the lines of amountToRead or there is no more lines to read.*/
        private static List<T> ReadLinesFromFile(int amountToRead, StreamReader streamRdr)
        {
            List<T> objects = new List<T>();
            Console.WriteLine(streamRdr.BaseStream);
            for (int i = 0; i <= amountToRead; i++)
            {
                if (streamRdr.EndOfStream)
                {
                    break;
                }

                string line = streamRdr.ReadLine();
                string[] subStrings = line.Split('|');


                //Figures out which type T is and adds it to the objects list.
                if (typeof(T) == typeof(User))
                {
                    T obj = CreateUser(subStrings);
                    objects.Add(obj);
                }
                if (typeof(T) == typeof(Category))
                {
                    T obj = CreateCategory(subStrings);
                    objects.Add(obj);
                }
                if (typeof(T) == typeof(Post))
                {
                    T post = CreatePost(subStrings);
                    objects.Add(post);
                }
                if (typeof(T) == typeof(Comment))
                {
                    T comment = CreateComment(subStrings);
                    objects.Add(comment);
                }
                if (typeof(T) == typeof(PhysicalPost))
                {
                    T physicalPost = CreatePhysicalPost(subStrings);
                    objects.Add(physicalPost);
                }
                if (typeof(T) == typeof(SolvrComment))
                {
                    T solvrComment = CreateSolvrComment(subStrings);
                    objects.Add(solvrComment);
                }
                if (typeof(T) == typeof(Vote))
                {
                    T vote = CreateVote(subStrings);
                    objects.Add(vote);
                }
                if (typeof(T) == typeof(Report))
                {
                    T report = CreateReport(subStrings);
                    objects.Add(report);
                }

            }
            return objects;
        }

        private static T CreateReport(string[] subStrings)
        {
            Report report = new Report
            {
                Title = subStrings[0],
                Description = subStrings[1],
                DateCreated = SubstringToDateTime(subStrings[2]),
                UserId = Int32.Parse(subStrings[3]),
                CommentId = Int32.Parse(subStrings[4]),
                PostId = Int32.Parse(subStrings[5])
            };

            return (T)(object)report;
        }

        private static T CreateVote(string[] subStrings)
        {
            Vote vote = new Vote
            {
                IsUpvoted = StringToBoolean(subStrings[0]),
                UserId = Int32.Parse(subStrings[1]),
                CommentId = Int32.Parse(subStrings[2]),
            };
            return (T)(object)vote;
        }

        private static T CreateSolvrComment(string[] subStrings)
        {
            SolvrComment solvrComment = new SolvrComment
            {
                DateCreated = SubstringToDateTime(subStrings[0]),
                Text = subStrings[1],
                UserId = Int32.Parse(subStrings[2]),
                PostId = Int32.Parse(subStrings[3]),
                TimeAccepted = SubstringToDateTime(subStrings[4]),
                IsAccepted = StringToBoolean(subStrings[5])
            };
            return (T)(object)solvrComment;
        }

        private static T CreatePhysicalPost(string[] subStrings)
        {
            PhysicalPost physicalPost = new PhysicalPost
            {
                Title = subStrings[0],
                Description = subStrings[1],
                BumpTime = SubstringToDateTime(subStrings[2]),
                DateCreated = SubstringToDateTime(subStrings[3]),
                CategoryId = Int32.Parse(subStrings[4]),
                UserId = Int32.Parse(subStrings[5]),
                IsLocked = StringToBoolean(subStrings[6]),
                AltDescription = subStrings[7],
                Zipcode = subStrings[8],
                Address = subStrings[9]
            };

            return (T)(object)physicalPost;
        }

        private static T CreateComment(string[] subStrings)
        {
            Comment comment = new Comment
            {
                DateCreated = SubstringToDateTime(subStrings[0]),
                Text = subStrings[1],
                UserId = Int32.Parse(subStrings[2]),
                PostId = Int32.Parse(subStrings[3])
            };
            return (T)(object)comment;
        }

        private static T CreateCategory(string[] subStrings)
        {
            Category category = new Category()
            {
                Name = subStrings[0]
            };
            return (T)(object)category;
        }

        private static T CreateUser(string[] subStrings)
        {
            User user = new User
            {
                Name = subStrings[0],
                Email = subStrings[1],
                Username = subStrings[2],
                Password = subStrings[3],
                IsAdmin = StringToBoolean(subStrings[4]),
                DateCreated = SubstringToDateTime(subStrings[5])
            };
            return (T)(object)user;
        }

        private static bool StringToBoolean(string s)
        {
            if (s.Equals("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static DateTime SubstringToDateTime(string s)
        {
            s.Trim(' ');
            string[] subStrings = s.Split(',');

            int year = Int32.Parse(subStrings[0]);
            int month = Int32.Parse(subStrings[1]);
            int day = Int32.Parse(subStrings[2]);
            int hour = Int32.Parse(subStrings[3]);
            int minute = Int32.Parse(subStrings[4]);
            int second = Int32.Parse(subStrings[5]);

            return new DateTime(year, month, day, hour, minute, second);
        }

        private static T CreatePost(string[] subStrings)
        {
            Post post = new Post
            {
                Title = subStrings[0],
                Description = subStrings[1],
                BumpTime = SubstringToDateTime(subStrings[2]),
                DateCreated = SubstringToDateTime(subStrings[3]),
                CategoryId = Int32.Parse(subStrings[4]),
                UserId = Int32.Parse(subStrings[5])
            };

            return (T)(object)post;
        }
    }
}