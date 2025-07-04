using FictitiousGamesReviewCore.Data;
using FictitiousGamesReviewCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FictitiousGamesReviewCore.Controllers
{
    /// <summary>
    /// レビュー投稿に関する処理を担当するコントローラー
    /// ※ 商品の表示や一覧は ProductsController が担当
    /// </summary>
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// コンストラクター（DIされたデータベースコンテキストを使用）
        /// </summary>
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// レビュー投稿フォームを表示する（GET）
        /// </summary>
        /// <param name="productId">レビュー対象の商品ID</param>
        /// <returns>投稿フォームビュー</returns>
        public IActionResult Create(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        /// <summary>
        /// レビュー投稿データを受け取り、データベースに保存（POST）
        /// </summary>
        /// <param name="review">送信されたレビュー情報</param>
        /// <returns>商品詳細画面へリダイレクト or 再表示</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review review)
        {
            if (ModelState.IsValid)
            {
                review.CreatedAt = DateTime.Now;

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                // 商品詳細ページへ遷移
                return RedirectToAction("Details", "Products", new { id = review.ProductId });
            }

            // バリデーションエラー時は商品IDを再設定して戻す
            ViewBag.ProductId = review.ProductId;
            return View(review);
        }
    }
}