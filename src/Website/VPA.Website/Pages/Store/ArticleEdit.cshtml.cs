using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VPA.Website.Pages.Store
{
    public class ArticleEditModel : PageModel
    {
        public void OnGetAsync(int? id)
        {
            // If there is an id, we are editing an existing article

            // If there is no id, we are creating a new article

        }
    }
}
