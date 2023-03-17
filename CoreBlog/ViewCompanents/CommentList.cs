using CoreBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewCompanents
{
    public class CommentList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Ferhat",
                },
                new UserComment
                {
                    ID = 2,
                    Username = "Betül",
                },
                new UserComment
                {
                    ID = 3,
                    Username = "Harun",
                },
            };
            return View(commentvalues);
        }
    }
}
