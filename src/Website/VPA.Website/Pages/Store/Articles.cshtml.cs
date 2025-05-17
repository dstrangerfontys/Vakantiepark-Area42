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

        public List<Article> Articles { get; private set; } = new();

        public async Task OnGetAsync(CancellationToken ct = default)
        {
            Articles = await articleClient.GetAsync(ct);
        }

        public async Task CreateAsync(CancellationToken ct = default)
        {
            Article article = new Article
            {
                Name = "Nieuw artikel",
                Price = 0,
            };

            await articleClient.CreateAsync(article, ct);
        }
    }
}
