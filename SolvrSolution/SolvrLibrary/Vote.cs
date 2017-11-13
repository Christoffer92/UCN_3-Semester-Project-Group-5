using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class Vote
    {
        public User UserVote { get; set; }
        public int VoteID { get; set; }
        public bool IsUpvoted { get; set; }
    }
}
