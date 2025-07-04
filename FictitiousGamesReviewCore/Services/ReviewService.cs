using FictitiousGamesReviewCore.Models;

namespace FictitiousGamesReviewCore.Services
{
    /// <summary>
    /// レビュー集計のロジックを担当するサービスクラス
    /// </summary>
    public class ReviewService : IReviewService
    {
        /// <summary>
        /// レビューの評価点の平均を計算する
        /// </summary>
        /// <param name="reviews">レビューのコレクション</param>
        /// <returns>平均点（レビューが0件なら0）</returns>
        public double GetAverage(IEnumerable<Review> reviews) =>
            reviews.Any() ? reviews.Average(r => r.Rating) : 0;

        /// <summary>
        /// 1〜5の各評価点に対する件数の内訳を辞書形式で返す
        /// </summary>
        /// <param name="reviews">レビューのコレクション</param>
        /// <returns>評価点（キー）と件数（値）の辞書</returns>
        public IDictionary<int, int> GetBreakdown(IEnumerable<Review> reviews) =>
            Enumerable.Range(1, 5)
                .ToDictionary(i => i, i => reviews.Count(r => r.Rating == i));
    }
}