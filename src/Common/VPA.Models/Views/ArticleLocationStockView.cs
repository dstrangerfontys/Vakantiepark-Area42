namespace VPA.Models
{
    public class ArticleLocationStockView : EntityView
    {
        public string ArticleName { get; set; }
        public string LocationName { get; set; }
        public int Amount { get; set; }
    }
}
