using FictitiousGamesReviewCore.Data;
using FictitiousGamesReviewCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 

namespace FictitiousGamesReviewCore.Controllers
{
    /// <summary>
    /// 商品（ゲームレビュー）に関するコントローラー
    /// </summary>
    public class ProductsController : Controller
    {


        // DBコンテキストのプライベートフィールド
        private readonly ApplicationDbContext _context;
        // json 用
        private readonly IConfiguration _config;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public ProductsController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        /// <summary>
        /// 一覧表示
        /// </summary>
        /// <returns>商品リストを含むViewResult</returns>
        public async Task<IActionResult> Index()
        {
            try 
            {
                var products = await _context.Products
                                             .Include(p => p.Reviews)  
                                             .ToListAsync();

                return View(products);
            }
            catch 
            {
                ModelState.AddModelError("", "商品一覧の取得中にエラーが発生しました。");
                return View(new List<Product>()); 
            }
        }

        // GET: 商品詳細画面（レビュー一覧＋投稿フォームを表示）
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            // 商品情報とレビュー一覧を読み込む（Reviews を Include）
            var product = await _context.Products
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            // 商品情報と新しいレビュー用インスタンスをまとめて View に渡す
            var viewModel = new ProductReviewViewModel
            {
                Product = product,
                NewReview = new Review { ProductId = product.Id }
            };

            return View(viewModel);
        }

        // POST: 商品詳細画面からレビュー投稿を受け取る
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ProductReviewViewModel viewModel)
        {
            // appsettings.json の設定値を取得（コメント最大文字数）
            int charLimit = _config.GetValue<int>("SiteSettings:ReviewCharLimit");

            // 🔽 投稿コメントが制限を超えていたらエラーを追加
            if (!string.IsNullOrEmpty(viewModel.NewReview.Comment) &&
                viewModel.NewReview.Comment.Length > charLimit)
            {
                ModelState.AddModelError("NewReview.Comment", $"コメントは最大 {charLimit} 文字までです。");
            }

            if (ModelState.IsValid)
            {
                viewModel.NewReview.CreatedAt = DateTime.Now;
                _context.Reviews.Add(viewModel.NewReview);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = viewModel.NewReview.ProductId });
            }

            // バリデーションに失敗した場合は、商品情報を再取得して再表示
            viewModel.Product = await _context.Products
                                              .Include(p => p.Reviews)
                                              .FirstOrDefaultAsync(p => p.Id == viewModel.NewReview.ProductId);

            return View(viewModel);
        }


        /// <summary>
        /// 新規商品作成フォームを表示　
        /// GET：/Products/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新規商品作成フォームからデータを受け取り、DBに保存　
        /// POST: Products/Create
        /// </summary>
        /// <param name="product">商品オブジェクト</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                // モデルの状態（バリデーションルール）が有効か
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    // データベースへの変更を非同期で保存
                    await _context.SaveChangesAsync();
                    // 商品一覧ページにリダイレクト
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch 
            {

                ModelState.AddModelError("", "商品の保存中に予期せぬエラーが発生しました。システム管理者にお問い合わせください。");
            
            }
            return View(product);

        }
    }
}
