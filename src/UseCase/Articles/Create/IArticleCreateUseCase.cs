using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Core;

namespace UseCase.Articles.Create
{
    // https://nrslib.com/clean-architecture/
    // 単純にリクエスト/結果のパラメータだけを定義する
    // インターフェースをユースケース毎に分けておくことで、下記のメリットがある
    //  ・他の処理への影響を考慮せずに変更できる
    //  ・コードリーディング時に他の処理を見なくても良い
    //  ・テストの際にスタブに入れ替えて Presentation レイヤーで任意のデータを受け取るようにすることが可能

    public interface IArticleCreateUseCase : IUseCase<ArticleCreateRequest, ArticleCreateResponse>
    {
    }
}
