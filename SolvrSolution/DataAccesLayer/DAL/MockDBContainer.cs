using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DataAccesLayer.DAL
{
    class MockDBContainer
    {
        private static MockDBContainer _Instance;

        public static MockDBContainer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MockDBContainer();
                }

                return _Instance;
            }

            set
            {
                _Instance = value;
            }
        }

        private List<Post> Posts;
        private List<User> Users;
        private List<Comment> Comments;
        private List<Category> Categories;
        private List<Report> Reports;
        private List<Vote> Votes;

        private MockDBContainer()
        {
            Users = new List<User>();
            Posts = new List<Post>();
            Categories = new List<Category>();
            Reports = new List<Report>();
            Comments = new List<Comment>();
            Votes = new List<Vote>();
        }

        #region Add methods

        internal User AddUser(User _user)
        {
            if (Users.Count == 0)
            {
                _user.Id = 1;
            }
            else
            {
                _user.Id = Users.Last().Id + 1;
            }

            Users.Add(_user);
            return _user;
        }

        internal Post AddPost(Post _post)
        {
            if (Posts.Count == 0)
            {
                _post.Id = 1;
            }
            else
            {
                _post.Id = Posts.Last().Id + 1;
            }

            Posts.Add(_post);
            return _post;
        }

        internal Category AddCategory(Category _category)
        {
            if (Categories.Count == 0)
            {
                _category.Id = 1;
            }
            else
            {
                _category.Id = Categories.Last().Id + 1;
            }

            Categories.Add(_category);
            return _category;
        }

        internal Report AddReport(Report _report)
        {
            if (Reports.Count == 0)
            {
                _report.Id = 1;
            }
            else
            {
                _report.Id = Reports.Last().Id + 1;
            }

            Reports.Add(_report);
            return _report;
        }

        internal Comment AddComment(Comment _comment)
        {
            if (Comments.Count == 0)
            {
                _comment.Id = 1;
            }
            else
            {
                _comment.Id = Comments.Last().Id + 1;
            }

            Comments.Add(_comment);
            return _comment;
        }

        internal Vote AddVote(Vote _vote)
        {
            if (Votes.Count == 0)
            {
                _vote.Id = 1;
            }
            else
            {
                _vote.Id = Votes.Last().Id + 1;
            }

            Votes.Add(_vote);
            return _vote;
        }

        #endregion

        #region Get methods
        internal Category GetCategory(int id)
        {
            Category cat = null;

            foreach (Category item in Categories)
            {
                if (item.Id == id)
                {
                    cat = item;
                }
            }
            return cat;
        }

        internal Post GetPost(int id)
        {
            Post p = null;

            foreach (Post item in Posts)
            {
                if (item.Id == id)
                {
                    p = item;
                }
            }
            return p;
        }

        internal Comment GetComment(int id)
        {
            Comment comment = null;
            foreach (Comment item in Comments)
            {
                if (item.Id == id)
                    comment = item;
            }
            return comment;
        }

        internal List<Category> GetAllCategories()
        {
            List<Category> CatList = new List<Category>();

            foreach (Category cat in Categories)
            {
                CatList.Add(cat);
            }

            return CatList;
        }


        internal List<Comment> GetAllComments(int postId)
        {
            List<Comment> commentList = new List<Comment>();

            foreach(var item in Comments)
            {
                if (item.PostId == postId)
                {
                    commentList.Add(item);
                }
            }

            return commentList;
        }

        internal List<Post> GetPostList(int offSet, int loadCount)
        {
            List<Post> postList = new List<Post>();

            foreach (var item in Posts)
            {
                postList.Add(item);
            }

            return postList;
        }

        internal Report GetReport(int id)
        {
            Report report = null;
            foreach (Report item in Reports)
            {
                if (item.Id == id)
                    report = item;
            }
            return report;
        }

        internal List<Report> GetAllReport(bool onlyNotResolved)
        {
            List<Report> reportList = new List<Report>();

            if (!onlyNotResolved)
            {
                foreach (var item in Reports)
                {
                    reportList.Add(item);
                }
                return reportList;
            }
            else
            {
                foreach (var item in Reports)
                {
                    if (!item.IsResolved)
                        reportList.Add(item);
                }
                return reportList;
            }
        }

        internal User GetUser(string username)
        {
            User user = null;
            foreach (var item in Users)
            {
                if (item.Username.Equals(username))
                    user = item;
            }
            return user;
        }

        internal User GetUser(int id)
        {
            User user = null;
            foreach (var item in Users)
            {
                if (item.Id == id)
                    user = item;
            }
            return user;
        }

        internal List<Vote> GetVoteList(int commentId)
        {
            List<Vote> voteList = new List<Vote>();
            foreach (var item in Votes)
            {
                if (item.CommentId == commentId)
                    voteList.Add(item);
            }
            return voteList;
        }

        internal Comment UpdateComment(Comment newComment)
        {
            for (int i = 0; i < Comments.Count; i++)
            {
                if (newComment.Id == Comments[i].Id)
                {
                    Comments[i] = newComment;
                    return Comments[i];
                }
            }
            return null;
        }

        internal Post UpdatePost(Post newPost)
        {
            for (int i = 0; i < Posts.Count; i++)
            {
                if (newPost.Id == Posts[i].Id)
                {
                    Posts[i] = newPost;
                    return Posts[i];
                }
            }
            return null;
        }

        internal Report UpdateReport(Report newReport)
        {
            for (int i = 0; i < Reports.Count; i++)
            {
                if (newReport.Id == Reports[i].Id)
                {
                    Reports[i] = newReport;
                    return Reports[i];
                }
            }
            return null;
        }
        #endregion
    }
}
