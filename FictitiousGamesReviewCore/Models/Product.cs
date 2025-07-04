
using System.ComponentModel.DataAnnotations;

namespace FictitiousGamesReviewCore.Models
{
    /// <summary>
    /// 商品一覧クラス
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// 商品名
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 商品の説明
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 商品の値段
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 画像のリンクURL
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// 平均評価
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// レビュー内容
        /// </summary>
        public ICollection<Review>? Reviews { get; set; }

    }
}
