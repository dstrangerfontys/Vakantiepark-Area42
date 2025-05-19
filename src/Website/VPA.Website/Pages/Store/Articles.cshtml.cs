using Microsoft.AspNetCore.Mvc.RazorPages;
using VPA.Models;
using VPA.Website.Client;

namespace VPA.Website.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly ArticleClient ArticleClient;

        public ArticlesModel(ArticleClient ArticleClient)
        {
            this.ArticleClient = ArticleClient;
        }

        public List<Article> Articles { get; private set; } = new();

        public async Task OnGetAsync(CancellationToken ct = default)
        {
            Articles = await ArticleClient.GetAsync(ct);
        }

        public async Task CreateAsync(CancellationToken ct = default)
        {
            Article Article = new Article
            {
                Name = "Nieuw artikel",
                Price = 0,
            };

            await ArticleClient.CreateAsync(Article, ct);
        }
    }
}
