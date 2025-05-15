using Vakantiepark_Area42.Models.Views.Base;

namespace Vakantiepark_Area42.Models.Views
{
    public class ArticleLocationStockView : EntityView
    {
        public string ArticleName { get; set; }
        public string StoreLocationName { get; set; }
        public int Amount { get; set; }
    }
}
