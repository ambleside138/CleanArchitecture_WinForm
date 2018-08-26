using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Model.Articles
{
    /// <summary>
    /// 任意の記事オブジェクトをclassTにコンバートするメソッドを提供する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArticleDataTransformer<T>
    {
        long Id { set; }
        string Title { set; }
        string Body { set; }

        T Build();
    }
}
