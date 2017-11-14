using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolvrLibrary
{
    public class Vote
    {
        [Key]
        public int VoteID { get; set; }
        public User UserVote { get; set; }
        public bool IsUpvoted { get; set; }
    }
}
