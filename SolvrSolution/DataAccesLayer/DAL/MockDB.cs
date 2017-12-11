using DataAccesLayer.DAL;
using SolvrLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.DAL
{
    public class MockDB : ISolvrDB
    {
        public MockDB()
        {
            FillTestData(); 
        }

        public static void CloseDB()
        {
            MockDBContainer.Instance = null;
        }

        public bool DatabaseExists()
        {
            //Rededunted code
            if (MockDBContainer.Instance != null)
                return true;
            else
                return false;
        }

        public void FillTestData()
        {
            #region Categories
            Category categorie1 = new Category
            {
                Name = "philosophy"
            };
            Category categorie2 = new Category
            {
                Name = "reduction"
            };
            Category category3 = new Category
            {
                Name = "tree"
            };
            InsertCategory(categorie1);
            InsertCategory(categorie2);
            InsertCategory(category3);
            #endregion
            #region Posts
            Post post1 = new Post
            {
                Title = "JCIDS",
                Description = "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.",
                DateCreated = new DateTime(2028, 01, 29, 09, 23, 28),
                BumpTime = new DateTime(2028, 01, 29, 09, 23, 28),
                CategoryId = 1,
                UserId = 1,
                IsDisabled = false
            };
            Post post2 = new Post
            {
                Title = "ICD-9",
                Description = "Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.",
                DateCreated = new DateTime(2031, 10, 08, 17, 46, 54),
                BumpTime = new DateTime(2031, 10, 08, 17, 46, 54),
                CategoryId = 2,
                UserId = 2,
                IsDisabled = false
            };
            Post post3 = new Post
            {
                Title = "Olfaction",
                Description = " Duis at velit eu est congue elementum. In hac habitasse platea dictumst.Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.",
                DateCreated = new DateTime(2022, 01, 07, 00, 14, 15),
                BumpTime = new DateTime(2022, 01, 07, 00, 14, 15),
                CategoryId = 3,
                UserId = 3,
                IsDisabled = false
            };
            InsertPost(post1);
            InsertPost(post2);
            InsertPost(post3);
            #endregion
            #region PhysicalPosts
            PhysicalPost physicalPost1 = new PhysicalPost
            {
                Title = "Print On Demand ",
                Description = "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.",
                BumpTime = new DateTime(2025, 09, 26, 11, 56, 51),
                DateCreated = new DateTime(2025, 09, 26, 11, 56, 51),
                CategoryId = 1,
                UserId = 1,
                IsLocked = false,
                AltDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.",
                Zipcode = "555",
                Address = "atvej 15"
            };
            PhysicalPost physicalPost2 = new PhysicalPost
            {
                Title = "Crisis Communications",
                Description = "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue.Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia.Aenean sit amet justo. Morbi ut odio.Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.",
                BumpTime = new DateTime(2031, 07, 24, 12, 03, 12),
                DateCreated = new DateTime(2031, 07, 24, 12, 03, 12),
                CategoryId = 1,
                UserId = 1,
                IsLocked = false,
                AltDescription = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor.Morbi vel lectus in quam fringilla rhoncus.Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.",
                Zipcode = "704",
                Address = "atvej 15"
            };
            PhysicalPost physicalPost3 = new PhysicalPost
            {
                Title = "Policy Writing",
                Description = "Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis.Donec semper sapien a libero.Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.",
                BumpTime = new DateTime(2018, 02, 23, 17, 58, 50),
                DateCreated = new DateTime(2018, 02, 23, 17, 58, 50),
                CategoryId = 3,
                UserId = 3,
                IsLocked = false,
                AltDescription = "Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim.",
                Zipcode = "705",
                Address = "lectusvej 456"
            };
            InsertPost(physicalPost1);
            InsertPost(physicalPost2);
            InsertPost(physicalPost3);
            #endregion
            #region Reports
            Report report1 = new Report
            {
                Title = "massa tempor convallis nulla neque",
                Description = "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.",
                ReportType = "user",
                IsResolved = true,
                DateCreated = new DateTime(2019, 07, 24, 21, 48, 58),
                UserId = 1,
                CommentId = 0,
                PostId = 0
            };
            Report report2 = new Report
            {
                Title = "eget rutrum",
                Description = "Aenean fermentum.",
                ReportType = "post",
                IsResolved = true,
                DateCreated = new DateTime(2036, 12, 10, 15, 23, 35),
                UserId = 0,
                CommentId = 0,
                PostId = 1
            };
            Report report3 = new Report
            {
                Title = "ullamcorper augue a suscipit nulla",
                Description = "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.",
                ReportType = "comment",
                IsResolved = true,
                DateCreated = new DateTime(2030, 02, 07, 17, 12, 05),
                UserId = 0,
                CommentId = 1,
                PostId = 0
            };
            InsertReport(report1);
            InsertReport(report2);
            InsertReport(report3);
            #endregion
            #region Users        
            User user1 = new User
            {
                Name = "Berte Chason",
                Email = "bchason0@theglobeandmail.com",
                Username = "ehinrichsen0",
                Password = "uvLWXF",
                IsAdmin = false,
                DateCreated = new DateTime(2028, 06, 30, 15, 07, 52)
            };
            User user2 = new User
            {
                Name = "Theo Rappaport",
                Email = "trappaport1@squidoo.com",
                Username = "breuss1",
                Password = "uvCY72YNS",
                IsAdmin = false,
                DateCreated = new DateTime(2019, 03, 05, 05, 04, 03)
            };
            User user3 = new User
            {
                Name = "Abbye Dovydenas",
                Email = "adovydenas2@smh.com.au",
                Username = "kalforde2",
                Password = "NORGZG1",
                IsAdmin = false,
                DateCreated = new DateTime(2032, 11, 28, 10, 11, 12)
            };
            InsertUser(user1);
            InsertUser(user2);
            InsertUser(user3);
            #endregion
            #region Comments
            Comment comment1 = new Comment
            {
                DateCreated = new DateTime(2036, 11, 09, 11, 21, 23),
                Text = "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.",
                UserId = 714,
                User = user1,
                Votes = new List<Vote>(),
                PostId = 1,
                CommentType = "Comment"  
            };
            Comment comment2 = new Comment
            {
                DateCreated = new DateTime(2027, 11, 20, 16, 49, 43),
                Text = "Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula.Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.Donec dapibus. Duis at velit eu est congue elementum.",
                UserId = 2,
                User = user2,
                Votes = new List<Vote>(),
                PostId = 2,
                CommentType = "Comment"
            };
            Comment comment3 = new Comment
            {
                DateCreated = new DateTime(2024, 06, 26, 14, 25, 13),
                Text = "Mauris lacinia sapien quis libero.Nullam sit amet turpis elementum ligula vehicula consequat.Morbi a ipsum.Integer a nibh.In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui.Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.",
                UserId = 3,
                User = user3,
                Votes = new List<Vote>(),
                PostId = 3,
                CommentType = "Comment"
            };
            InsertComment(comment1);
            InsertComment(comment2);
            InsertComment(comment3);
            #endregion
            #region SolvrComments
            SolvrComment solvrComment1 = new SolvrComment
            {
                DateCreated = new DateTime(2022, 05, 12, 21, 06, 16),
                Text = "Proin eu mi. Nulla ac enim.In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.Integer non velit.Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.",
                UserId = 1,
                PostId = 4,
                TimeAccepted = new DateTime(2019, 06, 15, 15, 02, 42),
                IsAccepted = false,
            };
            SolvrComment solvrComment2 = new SolvrComment
            {
                DateCreated = new DateTime(2033, 11, 28, 02, 54, 41),
                Text = "Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.Ut at dolor quis odio consequat varius.Integer ac leo.Pellentesque ultrices mattis odio. Donec vitae nisi.Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.Curabitur at ipsum ac tellus semper interdum.",
                UserId = 2,
                PostId = 5,
                TimeAccepted = new DateTime(2028, 09, 12, 01, 12, 42),
                IsAccepted = true
            };
            SolvrComment solvrComment3 = new SolvrComment
            {
                DateCreated = new DateTime(2025, 02, 06, 17, 46, 02),
                Text = "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.Suspendisse potenti. Nullam porttitor lacus at turpis.Donec posuere metus vitae ipsum.Aliquam non mauris.Morbi non lectus.Aliquam sit amet diam in magna bibendum imperdiet.",
                UserId = 2,
                PostId = 6,
                TimeAccepted = new DateTime(2029, 04, 16, 22, 28, 53),
                IsAccepted = false
            };
            InsertComment(solvrComment1);
            InsertComment(solvrComment2);
            InsertComment(solvrComment3);
            #endregion
            #region Vote
            Vote vote1 = new Vote
            {
                IsUpvoted = false,
                UserId = 1,
                CommentId = 1 
            };
            Vote vote2 = new Vote
            {
                IsUpvoted = false,
                UserId = 2,
                CommentId = 2 
            };
            Vote vote3 = new Vote
            {
                IsUpvoted = true,
                UserId = 3,
                CommentId = 3
            };
            InsertVote(vote1);
            InsertVote(vote2);
            InsertVote(vote3);
            #endregion
        }

        #region Get Methods
        public Category GetCategory(int id)
        {
            return MockDBContainer.Instance.GetCategory(id);
        }

        public List<Category> GetCategoryList()
        {
            return MockDBContainer.Instance.GetAllCategories();
        }

        public Comment GetComment(int id)
        {
            return MockDBContainer.Instance.GetComment(id);
        }

        public List<Comment> GetCommentList(int postId)
        {
            return MockDBContainer.Instance.GetAllComments(postId);
        }

        public Post GetPost(int id)
        {
            return MockDBContainer.Instance.GetPost(id);
        }

        public List<Post> GetPostList(int offSet, int loadCount)
        {
            return MockDBContainer.Instance.GetPostList(offSet, loadCount);
        }

        public Report GetReport(int id)
        {
            return MockDBContainer.Instance.GetReport(id);
        }

        public List<Report> GetReportList(bool onlyNotResolved)
        {
            return MockDBContainer.Instance.GetAllReport(onlyNotResolved);
        }

        public User GetUser(string username)
        {
            return MockDBContainer.Instance.GetUser(username);
        }

        public User GetUser(int id)
        {
            return MockDBContainer.Instance.GetUser(id);
        }

        public List<Vote> GetVoteList(int commentId)
        {
            return MockDBContainer.Instance.GetVoteList(commentId);
        }
        #endregion

        #region Insert Methods
        private Vote InsertVote(Vote vote)
        {
            return MockDBContainer.Instance.AddVote(vote);
        }

        private Category InsertCategory(Category categorie)
        {
            return MockDBContainer.Instance.AddCategory(categorie);
        }

        public Comment InsertComment(Comment comment)
        {
            return MockDBContainer.Instance.AddComment(comment);
        }

        public Post InsertPost(Post post)
        {
            return MockDBContainer.Instance.AddPost(post);
        }

        public Report InsertReport(Report report)
        {
            return MockDBContainer.Instance.AddReport(report);
        }

        public User InsertUser(User user)
        {
            return MockDBContainer.Instance.AddUser(user);
        }
        #endregion

        #region Update Methods
        public Comment UpdateComment(Comment comment)
        {
            return MockDBContainer.Instance.UpdateComment(comment);
        }

        public Post UpdatePost(Post post)
        {
            return MockDBContainer.Instance.UpdatePost(post);
        }

        public Report UpdateReport(Report report)
        {
            return MockDBContainer.Instance.UpdateReport(report);
        }
        #endregion
    }
}
