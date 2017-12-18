﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolvrDesktopClient.RemoteSolvrReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RemoteSolvrReference.ISolvrServices")]
    public interface ISolvrServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/IsConnectedToDatabase", ReplyAction="http://tempuri.org/ISolvrServices/IsConnectedToDatabaseResponse")]
        bool IsConnectedToDatabase();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/IsConnectedToDatabase", ReplyAction="http://tempuri.org/ISolvrServices/IsConnectedToDatabaseResponse")]
        System.Threading.Tasks.Task<bool> IsConnectedToDatabaseAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetUser", ReplyAction="http://tempuri.org/ISolvrServices/GetUserResponse")]
        SolvrLibrary.User GetUser(int id, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetUser", ReplyAction="http://tempuri.org/ISolvrServices/GetUserResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.User> GetUserAsync(int id, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetPost", ReplyAction="http://tempuri.org/ISolvrServices/GetPostResponse")]
        SolvrLibrary.Post GetPost(int id, bool withUsers, bool withComments, bool notDisabled);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetPost", ReplyAction="http://tempuri.org/ISolvrServices/GetPostResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Post> GetPostAsync(int id, bool withUsers, bool withComments, bool notDisabled);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetComment", ReplyAction="http://tempuri.org/ISolvrServices/GetCommentResponse")]
        SolvrLibrary.Comment GetComment(int id, bool withUser, bool withVotes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetComment", ReplyAction="http://tempuri.org/ISolvrServices/GetCommentResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Comment> GetCommentAsync(int id, bool withUser, bool withVotes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetCategory", ReplyAction="http://tempuri.org/ISolvrServices/GetCategoryResponse")]
        SolvrLibrary.Category GetCategory(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetCategory", ReplyAction="http://tempuri.org/ISolvrServices/GetCategoryResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Category> GetCategoryAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetReport", ReplyAction="http://tempuri.org/ISolvrServices/GetReportResponse")]
        SolvrLibrary.Report GetReport(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetReport", ReplyAction="http://tempuri.org/ISolvrServices/GetReportResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Report> GetReportAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetPostList", ReplyAction="http://tempuri.org/ISolvrServices/GetPostListResponse")]
        SolvrLibrary.Post[] GetPostList(int offSet, int loadCount, bool withUsers, bool withComments);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetPostList", ReplyAction="http://tempuri.org/ISolvrServices/GetPostListResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Post[]> GetPostListAsync(int offSet, int loadCount, bool withUsers, bool withComments);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetCommentList", ReplyAction="http://tempuri.org/ISolvrServices/GetCommentListResponse")]
        SolvrLibrary.Comment[] GetCommentList(int postId, bool withUsers);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetCommentList", ReplyAction="http://tempuri.org/ISolvrServices/GetCommentListResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Comment[]> GetCommentListAsync(int postId, bool withUsers);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetCategoryList", ReplyAction="http://tempuri.org/ISolvrServices/GetCategoryListResponse")]
        SolvrLibrary.Category[] GetCategoryList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetCategoryList", ReplyAction="http://tempuri.org/ISolvrServices/GetCategoryListResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Category[]> GetCategoryListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetReportList", ReplyAction="http://tempuri.org/ISolvrServices/GetReportListResponse")]
        SolvrLibrary.Report[] GetReportList(bool onlyNotResolved);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetReportList", ReplyAction="http://tempuri.org/ISolvrServices/GetReportListResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Report[]> GetReportListAsync(bool onlyNotResolved);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetVoteList", ReplyAction="http://tempuri.org/ISolvrServices/GetVoteListResponse")]
        SolvrLibrary.Vote[] GetVoteList(int commentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/GetVoteList", ReplyAction="http://tempuri.org/ISolvrServices/GetVoteListResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Vote[]> GetVoteListAsync(int commentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreateUser", ReplyAction="http://tempuri.org/ISolvrServices/CreateUserResponse")]
        SolvrLibrary.User CreateUser(SolvrLibrary.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreateUser", ReplyAction="http://tempuri.org/ISolvrServices/CreateUserResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.User> CreateUserAsync(SolvrLibrary.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreatePost", ReplyAction="http://tempuri.org/ISolvrServices/CreatePostResponse")]
        SolvrLibrary.Post CreatePost(SolvrLibrary.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreatePost", ReplyAction="http://tempuri.org/ISolvrServices/CreatePostResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Post> CreatePostAsync(SolvrLibrary.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreateComment", ReplyAction="http://tempuri.org/ISolvrServices/CreateCommentResponse")]
        SolvrLibrary.Comment CreateComment(SolvrLibrary.Comment comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreateComment", ReplyAction="http://tempuri.org/ISolvrServices/CreateCommentResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Comment> CreateCommentAsync(SolvrLibrary.Comment comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreateReport", ReplyAction="http://tempuri.org/ISolvrServices/CreateReportResponse")]
        SolvrLibrary.Report CreateReport(SolvrLibrary.Report report);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/CreateReport", ReplyAction="http://tempuri.org/ISolvrServices/CreateReportResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Report> CreateReportAsync(SolvrLibrary.Report report);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/UpdatePost", ReplyAction="http://tempuri.org/ISolvrServices/UpdatePostResponse")]
        SolvrLibrary.Post UpdatePost(SolvrLibrary.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/UpdatePost", ReplyAction="http://tempuri.org/ISolvrServices/UpdatePostResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Post> UpdatePostAsync(SolvrLibrary.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/UpdateComment", ReplyAction="http://tempuri.org/ISolvrServices/UpdateCommentResponse")]
        SolvrLibrary.Comment UpdateComment(SolvrLibrary.Comment comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/UpdateComment", ReplyAction="http://tempuri.org/ISolvrServices/UpdateCommentResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Comment> UpdateCommentAsync(SolvrLibrary.Comment comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/UpdateReport", ReplyAction="http://tempuri.org/ISolvrServices/UpdateReportResponse")]
        SolvrLibrary.Report UpdateReport(SolvrLibrary.Report report);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISolvrServices/UpdateReport", ReplyAction="http://tempuri.org/ISolvrServices/UpdateReportResponse")]
        System.Threading.Tasks.Task<SolvrLibrary.Report> UpdateReportAsync(SolvrLibrary.Report report);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISolvrServicesChannel : SolvrDesktopClient.RemoteSolvrReference.ISolvrServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SolvrServicesClient : System.ServiceModel.ClientBase<SolvrDesktopClient.RemoteSolvrReference.ISolvrServices>, SolvrDesktopClient.RemoteSolvrReference.ISolvrServices {
        
        public SolvrServicesClient() {
        }
        
        public SolvrServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SolvrServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SolvrServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SolvrServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsConnectedToDatabase() {
            return base.Channel.IsConnectedToDatabase();
        }
        
        public System.Threading.Tasks.Task<bool> IsConnectedToDatabaseAsync() {
            return base.Channel.IsConnectedToDatabaseAsync();
        }
        
        public SolvrLibrary.User GetUser(int id, string username) {
            return base.Channel.GetUser(id, username);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.User> GetUserAsync(int id, string username) {
            return base.Channel.GetUserAsync(id, username);
        }
        
        public SolvrLibrary.Post GetPost(int id, bool withUsers, bool withComments, bool notDisabled) {
            return base.Channel.GetPost(id, withUsers, withComments, notDisabled);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Post> GetPostAsync(int id, bool withUsers, bool withComments, bool notDisabled) {
            return base.Channel.GetPostAsync(id, withUsers, withComments, notDisabled);
        }
        
        public SolvrLibrary.Comment GetComment(int id, bool withUser, bool withVotes) {
            return base.Channel.GetComment(id, withUser, withVotes);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Comment> GetCommentAsync(int id, bool withUser, bool withVotes) {
            return base.Channel.GetCommentAsync(id, withUser, withVotes);
        }
        
        public SolvrLibrary.Category GetCategory(int id) {
            return base.Channel.GetCategory(id);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Category> GetCategoryAsync(int id) {
            return base.Channel.GetCategoryAsync(id);
        }
        
        public SolvrLibrary.Report GetReport(int id) {
            return base.Channel.GetReport(id);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Report> GetReportAsync(int id) {
            return base.Channel.GetReportAsync(id);
        }
        
        public SolvrLibrary.Post[] GetPostList(int offSet, int loadCount, bool withUsers, bool withComments) {
            return base.Channel.GetPostList(offSet, loadCount, withUsers, withComments);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Post[]> GetPostListAsync(int offSet, int loadCount, bool withUsers, bool withComments) {
            return base.Channel.GetPostListAsync(offSet, loadCount, withUsers, withComments);
        }
        
        public SolvrLibrary.Comment[] GetCommentList(int postId, bool withUsers) {
            return base.Channel.GetCommentList(postId, withUsers);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Comment[]> GetCommentListAsync(int postId, bool withUsers) {
            return base.Channel.GetCommentListAsync(postId, withUsers);
        }
        
        public SolvrLibrary.Category[] GetCategoryList() {
            return base.Channel.GetCategoryList();
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Category[]> GetCategoryListAsync() {
            return base.Channel.GetCategoryListAsync();
        }
        
        public SolvrLibrary.Report[] GetReportList(bool onlyNotResolved) {
            return base.Channel.GetReportList(onlyNotResolved);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Report[]> GetReportListAsync(bool onlyNotResolved) {
            return base.Channel.GetReportListAsync(onlyNotResolved);
        }
        
        public SolvrLibrary.Vote[] GetVoteList(int commentId) {
            return base.Channel.GetVoteList(commentId);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Vote[]> GetVoteListAsync(int commentId) {
            return base.Channel.GetVoteListAsync(commentId);
        }
        
        public SolvrLibrary.User CreateUser(SolvrLibrary.User user) {
            return base.Channel.CreateUser(user);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.User> CreateUserAsync(SolvrLibrary.User user) {
            return base.Channel.CreateUserAsync(user);
        }
        
        public SolvrLibrary.Post CreatePost(SolvrLibrary.Post post) {
            return base.Channel.CreatePost(post);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Post> CreatePostAsync(SolvrLibrary.Post post) {
            return base.Channel.CreatePostAsync(post);
        }
        
        public SolvrLibrary.Comment CreateComment(SolvrLibrary.Comment comment) {
            return base.Channel.CreateComment(comment);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Comment> CreateCommentAsync(SolvrLibrary.Comment comment) {
            return base.Channel.CreateCommentAsync(comment);
        }
        
        public SolvrLibrary.Report CreateReport(SolvrLibrary.Report report) {
            return base.Channel.CreateReport(report);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Report> CreateReportAsync(SolvrLibrary.Report report) {
            return base.Channel.CreateReportAsync(report);
        }
        
        public SolvrLibrary.Post UpdatePost(SolvrLibrary.Post post) {
            return base.Channel.UpdatePost(post);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Post> UpdatePostAsync(SolvrLibrary.Post post) {
            return base.Channel.UpdatePostAsync(post);
        }
        
        public SolvrLibrary.Comment UpdateComment(SolvrLibrary.Comment comment) {
            return base.Channel.UpdateComment(comment);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Comment> UpdateCommentAsync(SolvrLibrary.Comment comment) {
            return base.Channel.UpdateCommentAsync(comment);
        }
        
        public SolvrLibrary.Report UpdateReport(SolvrLibrary.Report report) {
            return base.Channel.UpdateReport(report);
        }
        
        public System.Threading.Tasks.Task<SolvrLibrary.Report> UpdateReportAsync(SolvrLibrary.Report report) {
            return base.Channel.UpdateReportAsync(report);
        }
    }
}