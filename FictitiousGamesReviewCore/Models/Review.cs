using System.ComponentModel.DataAnnotations;

namespace FictitiousGamesReviewCore.Models
{
    /// <summary>
    /// レビュー情報を表すエンティティクラス
    /// </summary>
    public class Review
    {
        /// <summary>
        /// レビューID（主キー）
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// レビュアーの表示名（必須）
        /// </summary>
        [Required]
        public string? ReviewerName { get; set; }

        /// <summary>
        /// 評価（1〜5の整数、必須）
        /// </summary>
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }  // 1〜5の評価

        /// <summary>
        /// コメント（任意）
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// レビュー投稿日時（初期値は現在時刻）
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 関連付けられた商品ID（外部キー）
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 関連する商品エンティティ（ナビゲーションプロパティ）
        /// </summary>
        public Product? Product { get; set; }
    }
}