using Microsoft.AspNetCore.Mvc.RazorPages;
using VPA.Models;
using VPA.Website.Client;

namespace VPA.Website.Pages
{
    public class ArticlesPage : PageModel
    {
        private readonly ArticleClient articleClient;

        public ArticlesPage(ArticleClient articleClient)
        {
            this.articleClient = articleClient;
        }

        public async Task OnGetAsync(CancellationToken ct = default)
        {
            // Get the list of articles from the API
            List<Article> articles = await articleClient.GetAsync(ct);
            // Check if the response is successful
        }
    }
}
