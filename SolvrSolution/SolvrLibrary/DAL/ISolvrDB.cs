using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public interface ISolvrDB
    {
        void CreatePhysicalPost(User expectedUser, string expectedTitle, string expectedDescription, Category expectedCategory, List<string> expectedTagsList, string expectedAltDescription, string expectedZipcode, string expectedAddress);

        PhysicalPost GetLastPhysicalPost();

        void CreatePost(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList);

        Post GetLastPost();

        IEnumerable<Category> GetAllCategories();
        void CreatePost(Post post);
    }
}
