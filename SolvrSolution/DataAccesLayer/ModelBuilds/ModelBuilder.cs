﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;


namespace DataAccesLayer.ModelBuilds
{
    public class ModelBuilder
    {
        public User BuildUser(int PrimaryKey)
        {
            User CreatedUser = null;
            using (var Context = new SolvrDB()) {
                var Query = (from user in Context.Users where user.Id == PrimaryKey select user).First();
                CreatedUser = new User {
                                        Id = Query.Id,
                                        DateCreated = Query.DateCreated,
                                        Email = Query.Email,
                                        IsAdmin = Query.IsAdmin,
                                        Name = Query.Name,
                                        Username = Query.Username,
                                        Password = Query.Password };
                    };
            return CreatedUser;
        }

        public Category BuildCategory(int PrimaryKey)
        {
            Category CreatedCategory = null;

            using(var Context = new SolvrDB())
            {
                var Query = (from category in Context.Categories where category.Id == PrimaryKey select category).First();
                CreatedCategory = new Category
                {
                    Id = Query.Id,
                    Name = Query.Name
                };
            }

            return CreatedCategory;
        }

        public T BuildPost<T>(int PrimaryKey)
        {
            T CreatedPost;

            using(var Context = new SolvrDB())
            {
                if (typeof(T) == typeof(Post))
                {
                    var Query = (from post in Context.Posts where post.Id == PrimaryKey select post).First();
                    var CommentQuery = from comment in Context.Comments where comment.PostId == PrimaryKey && comment.CommentType == "Comment" select comment;
                    List<string> Tags = new List<string>();
                    Tags.Add("TODO");
                    var CommentList = new List<Comment>();
                    foreach (var comment in CommentQuery)
                    {
                        CommentList.Add(BuildComment<Comment>(comment.Id));
                    }

                    CreatedPost = (T)(object)new Post
                    {
                        Id = Query.Id,
                        Title = Query.Title,
                        DateCreated = Query.DateCreated,
                        BumpTime = Query.BumpTime,
                        Comments = CommentList,
                        CategoryId = Query.CategoryId,
                        Category = BuildCategory(Query.CategoryId),
                        Description = Query.Description,
                        UserId = Query.UserId,
                    }; 
                }
                else if(typeof(T) == typeof(PhysicalPost))
                {
                    var Query = (from post in Context.Posts.OfType<PhysicalPost>() where post.Id == PrimaryKey select post).First();
                    var SolvrCommentQuery = from comment in Context.Comments where comment.PostId == PrimaryKey select comment;
                    List<string> Tags = new List<string>();
                    Tags.Add("TODO");
                    var CommentList = new List<SolvrComment>();
                    foreach (var comment in SolvrCommentQuery)
                    {
                        CommentList.Add(BuildComment<SolvrComment>(comment.Id));
                    }
                    CreatedPost = (T)(object) new PhysicalPost
                    {
                        Id = Query.Id,
                        Title = Query.Title,
                        DateCreated = Query.DateCreated,
                        BumpTime = Query.BumpTime,
                        SolvrComments = CommentList,
                        CategoryId = Query.CategoryId,
                        Category = BuildCategory(Query.CategoryId),
                        Description = Query.Description,
                        UserId = Query.UserId,
                        Address = Query.Address,
                        AltDescription = Query.AltDescription,
                        IsLocked = Query.IsLocked,
                        Zipcode = Query.Zipcode
                    };
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
            return CreatedPost;
        }
        
        public T BuildComment<T>(int PrimaryKey)
        {
            T CreatedComment;

            using(var context = new SolvrDB())
            {
                if (typeof(T) == typeof(Comment))
                {
                    var Query = (from comment in context.Comments.OfType<Comment>() where comment.Id == PrimaryKey select comment).First();
                    var VoteQuery = from vote in context.Votes where vote.CommentId == PrimaryKey select vote;
                    var Votes = new List<Vote>();
                    foreach(var vote in VoteQuery)
                    {
                        Votes.Add(BuildVote(Query.Id));
                    }
                    CreatedComment = (T)(object)new Comment
                    {
                        Id = Query.Id,
                        DateCreated = Query.DateCreated,
                        Text = Query.Text,
                        UserId = Query.UserId,
                        User = BuildUser(Query.UserId),
                        Votes = Votes

                    }; 
                }
                else if(typeof(T) == typeof(SolvrComment))
                {
                    var Query = (from comment in context.Comments.OfType<SolvrComment>() where comment.Id == PrimaryKey select comment).First();
                    CreatedComment = (T)(object)new SolvrComment
                    {
                        Id = Query.Id,
                        DateCreated = Query.DateCreated,
                        Text = Query.Text,
                        UserId = Query.UserId,
                        User = BuildUser(Query.UserId),
                        IsAccepted = Query.IsAccepted,
                        TimeAccepted = Query.TimeAccepted
                    };
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
            
            return CreatedComment;
        }

        public Vote BuildVote(int PrimaryKey)
        {
            Vote CreatedVote = null;

            using (var Context = new SolvrDB())
            {
                var Query = (from vote in Context.Votes where vote.Id == PrimaryKey select vote).First();
                CreatedVote = new Vote
                {
                    Id = Query.Id,
                    UserId = Query.UserId,
                    CommentId = Query.CommentId,
                    IsUpvoted = Query.IsUpvoted
                };
            }

            return CreatedVote;
        }

        public Report BuildReport(int PrimaryKey)
        {
            Report CreatedReport = null;
            using (var Context = new SolvrDB())
            {
                var Query = (from report in Context.Reports where report.Id == PrimaryKey select report).First();
                CreatedReport = new Report
                {
                    Id = Query.Id,
                    DateCreated = Query.DateCreated,
                    Description = Query.Description,
                    Title = Query.Title
                };
                switch (Query.ReportType)
                {
                    case "Comment":
                        CreatedReport.Comment = BuildComment<Comment>(Query.CommentId);
                        break;

                    case "SolvrComment":
                        CreatedReport.Comment = BuildComment<SolvrComment>(Query.CommentId);
                        break;

                    case "Post":
                        CreatedReport.Post = BuildPost<Post>(Query.PostId);
                        break;

                    case "PhysicalPost":
                        CreatedReport.Post = BuildPost<PhysicalPost>(Query.PostId);
                        break;

                    case "User":
                        CreatedReport.User = BuildUser(Query.UserId);
                        break;
                    default:
                        break;
                }
            }

            return CreatedReport;
        }
    }
}