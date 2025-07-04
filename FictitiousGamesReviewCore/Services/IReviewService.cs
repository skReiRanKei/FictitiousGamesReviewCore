using FictitiousGamesReviewCore.Models;

namespace FictitiousGamesReviewCore.Services
{
    /// <summary>
    /// レビュー関連の集計処理を定義するインターフェース
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// レビューの平均点を算出
        /// </summary>
        double GetAverage(IEnumerable<Review> reviews);

        /// <summary>
        /// 評価点ごとの件数（1〜5点）を取得
        /// </summary>
        IDictionary<int, int> GetBreakdown(IEnumerable<Review> reviews);
    }
}