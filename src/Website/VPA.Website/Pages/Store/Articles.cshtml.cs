using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VPA.Models;
using VPA.Website.Client;

namespace VPA.Website.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly ArticleClient articleClient;

        public ArticlesModel(ArticleClient articleClient)
        {
            this.articleClient = articleClient;
        }

        [BindProperty]
        public List<Article> Articles { get; private set; } = new();

        [BindProperty]
        public Article NewArticle { get; set; } = new();

        public async Task OnGetAsync(CancellationToken ct = default)
        {
            await LoadAsync(ct);
        }

        public async Task OnPostAsync(CancellationToken ct = default)
        {
            await articleClient.CreateAsync(NewArticle, ct);
            await LoadAsync(ct);
        }

        private async Task LoadAsync(CancellationToken ct = default)
        {
            Articles = await articleClient.GetAsync(ct);
        }
    }
}
