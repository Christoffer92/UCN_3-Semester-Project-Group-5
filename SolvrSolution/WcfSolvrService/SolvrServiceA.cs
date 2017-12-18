using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SolvrLibrary;
using DataAccesLayer;

namespace WcfSolvrService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SolvrServiceA : ISolvrServiceA
    {
        public Post[] GetPostList(int offSet, int loadCount, bool withUsers, bool withComments)
        {
            DataAccesController Dac = new DataAccesController();
            Post[] MyList = Dac.GetPostList(offSet, loadCount, withUsers, withComments).ToArray();
            return MyList;
        }
    }
}
