# 🎮 Fictitious Games Review - ASP.NET Core MVCで作る商品レビューサイト

---

## 📌 概要

このアプリは、ゲーム商品のレビュー投稿・閲覧ができるWebアプリケーションです。  
ASP.NET Core MVCとEntity Framework Coreをベースに構築されており、**CoreのDI・構成ファイル管理・モデルバインディング制御**などの設計特性を学びながら実装しています。

---

## 🎯 開発の目的

- WinFormsからWeb開発へのスキル移行に挑戦
- ASP.NET Core MVCの基本構造と設計思想を体験
- appsettings.jsonやサービス層を活かしたモダンなWebアプリの構築
- Coreらしさを意識した設計とREADMEでの発信

---

## 🛠 機能概要

- 商品一覧画面（画像・価格・説明）
- 商品詳細画面（平均評価・評価内訳・レビュー一覧・投稿フォーム）
- レビュー投稿（名前・評価・コメント・バリデーション付き）
- コメントの最大文字数制限（appsettings.jsonから設定可能）
- サービス層での集計処理分離（平均点・評価分布）

---

## ✨ 工夫点

| 工夫内容 | 説明 |
|----------|------|
| **設定ファイルの活用** | `appsettings.json` から最大文字数・デバッグモードなどを柔軟に切り替え |
| **サービス層（ReviewService）の導入** | コントローラーから集計ロジックを切り離し、再利用可能・テスト可能な設計へ |
| **バリデーション制御** | `[ValidateNever]` により、投稿に不要な `Product` プロパティの検証を無効化 |
| **TagHelperでのビュー記述** | `asp-for`, `asp-validation-for`, `asp-action` などを使い、シンプルで視認性の高いビューに |
| **エラー時の状態復元** | 投稿失敗時も `Product` を再取得し、画面を整合性のある状態で再表示 |

---

## 🧪 技術スタック

- ASP.NET Core MVC（.NET 6 / .NET 7）
- Entity Framework Core（Code First）
- Razor View（TagHelper構文）
- Bootstrap（レイアウト・UI）
- C# / LINQ / 非同期プログラミング
- appsettings.json / IConfiguration による構成管理
- Dependency Injection（DI）によるサービス設計

---

## 🔮 今後の展望

- 投稿されたレビューの編集・削除機能の追加（管理者用）
- `ILogger<T>` によるログ出力機能の導入
- `EnableDebug` 設定による開発支援表示の切り替え
- 商品カテゴリやタグによるフィルター機能の実装
- ASP.NET Identity を用いたユーザー登録と認証
- Web API との切り替えによるSPA対応（Blazor等も視野）

---

## 🖼 主要画面のキャプチャ


- 商品一覧ページ  
  ![一覧画面](./Image/products-index.png)

- 商品詳細（レビュー統計）  
  ![レビュー統計](./Image/product-details.png)

- 商品詳細（レビュー投稿）  
  ![レビュー投稿](./Image/review-breakdown.png)

---
