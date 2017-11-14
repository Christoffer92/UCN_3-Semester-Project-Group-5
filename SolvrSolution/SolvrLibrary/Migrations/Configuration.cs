namespace SolvrLibrary.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SolvrLibrary.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SolvrLibrary.ModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var Users = new List<User>
            {
                new User{Name = "John", AdminUser = false, Email = "john@mail.dk", Password = "hemmeligkodexD", UserName = "john123" },
                new User{Name = "Tim", AdminUser = true, Email = "TimKongen@mail.dk", Password = "deterikkeminkode", UserName = "KongenTim" },
                new User{Name = "Nick", AdminUser = false, Email = "Nick@mail.dk", Password = "notreally", UserName = "NickName" },
                new User{Name = "Else", AdminUser = false, Email = "Else@mail.dk", Password = "hvadskaljegskriveher", UserName = "hvaderusername" },
                new User{Name = "Leonardo", AdminUser = false, Email = "davinci@mail.dk", Password = "Mona", UserName = "Lisa" },
                new User{Name = "Niels", AdminUser = false, Email = "Niels@mail.dk", Password = "NielsLouisen", UserName = "NilsMaster" },
                new User{Name = "johan", AdminUser = false, Email = "johan@mail.dk", Password = "12354", UserName = "johansen" }
            };
            Users.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();

            var Categories = new List<Category>
            {
                new Category{CategoryName = "Computer"},
                new Category{CategoryName =  "DIY"},
                new Category{CategoryName = "Hobby"},
                new Category{CategoryName =  "Food"},
                new Category{CategoryName = "Art"},
                new Category{CategoryName = "Mechanic"},
                new Category{CategoryName = "Sickness"},
                new Category{CategoryName = "Sport"}
            };
            Categories.ForEach(s => context.Categories.AddOrUpdate(p => p.CategoryName, s));
            context.SaveChanges();
            var Posts = new List<Post>
            {
                new Post{Tite = "How does my microwave work?", Description = "There is a lot of buttons, what do i do?", Tags = new List<string>{"Tesla", "Einstein","clueless"} },
                new Post{Tite = "How do i open a can", Description = "i cant punch through metal, what do you guys do?", Tags = new List<string>{"NotHulk", "CantFistIt","clueless"} },
                new Post{Tite = "Why do so many believe the earth is round?", Description = "if it was round, how come when i put a ball on the floor it doesnt roll?", Tags = new List<string>{"NewtonIsDum", "FlatEarthers","clueless"} },
                new Post{Tite = "Why are the alphabets in the order that they are?", Description = "Is it so that you can sing it?", Tags = new List<string>{"ABC", "BCA","clueless"} },
                new Post{Tite = "Did noah have woodpeckers on the ark?", Description = "i would imagine that is proof the story of noahs ark is false, as they would go through the hull and sink it", Tags = new List<string>{"ChristianityBusted", "Atheism","clueless"} },
            };
            Posts.ForEach(s => context.Posts.AddOrUpdate(p => p.Tite, s));
            context.SaveChanges();

            var PhysicalPosts = new List<PhysicalPost>
            {
                new PhysicalPost{Tite = "Help me move furniture", Description = "My sofa and loudspeakers are to heavy for me to lift on my own, so i would love an accomplice to help me", Tags = new List<string>{"Lifting","Appartment"}, Address = "the strip 1", AltDescription = "", Locked = false, ZipCode = "9020" },
                new PhysicalPost{Tite = "I need help to wash my windows", Description = "My back is broken and i dont like dirty windows", Tags = new List<string>{"PityHelp","FreshNClean"}, Address = "anemonevej 33", AltDescription = "My key for the shed is placed under the vase infront of the entrance, all window cleaning tools are in the shed", Locked = true, ZipCode = "9320" },
                new PhysicalPost{Tite = "Help watching my dog for a week", Description = "I am looking for a dog friendly family that is able to take care of my dog for a week", Tags = new List<string>{"Bark","Dog"}, Address = "Farmroad 1", AltDescription = "It need a pill once a day, which i will include. I will pay 100$ for the caretaking", Locked = false, ZipCode = "9020" },
            };
            PhysicalPosts.ForEach(s => context.PhysicalPosts.AddOrUpdate(p => p.Tite, s));
            context.SaveChanges();

            var Comments = new List<Comment>
            {
                new Comment{Text = "The buttons should have descriptive text on them, else read the users manual" },
                new Comment{Text = "buy a can opener, they are widely available" },
                new Comment{Text = "Become iron fist, and you should be able to punch it open" },
                new Comment{Text = "Because there is alot of scientific evidence that proves its round, none that proves otherwise" },
                new Comment{Text = "If its flat, where is the end of the world?" },
                new Comment{Text = "I dont think there is a specific reason to it" },
                new Comment{Text = "Noah's ark is a story, understand the meaning, not the factual" },
                new Comment{Text = "I can help move the furniture, i bench 300kg and have 30 inch biceps" },
                new Comment{Text = "I can watch your dog" },
                new Comment{Text = "I'll help watch your dog, i have a dog myself. So the family is used to dogs" }
            };
            Comments.ForEach(s => context.Comments.AddOrUpdate(p => p.Text, s));
            context.SaveChanges();

            var Votes = new List<Vote>
            {
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = false},
                new Vote{IsUpvoted = false},
                new Vote{IsUpvoted = false},
                new Vote{IsUpvoted = false},
                new Vote{IsUpvoted = false},
                new Vote{IsUpvoted = false},
                new Vote{IsUpvoted = false},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = true},
                new Vote{IsUpvoted = false}
            };
            /*
             * Mangler en id til users i modellaget for at opbygges (UserId)
            Votes.ForEach(s => context.Votes.AddOrUpdate(p => p.UserId, s));
            context.SaveChanges();
            */

            var Reports = new List<Report>
            {
                new Report{ Title = "He is going against our one and only true religion", Description = "writing stupid things about noahs ark" },
                new Report{ Title = "Obvious troll", Description = "not needed" },
                new Report{ Title = "Unserious comment", Description = "Iron fist does not exist, and is a comic character" },
            };
        }
    }
}
