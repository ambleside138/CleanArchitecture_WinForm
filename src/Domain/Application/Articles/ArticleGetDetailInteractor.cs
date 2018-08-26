using Domain.Domain.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Common;
using UseCase.Articles.GetDetail;

namespace Domain.Application.Articles
{
    public class ArticleGetDetailInteractor : IArticleGetDetailUseCase
    {
        private readonly IArticleRepository articleRepository;

        public ArticleGetDetailInteractor(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public ArticleGetDetailResponse Handle(ArticleGetDetailRequest request)
        {
            var articleId = new ArticleId(request.ArticleId);
            var article = articleRepository.Find(articleId);

            if(article == null)
            {
                return new ArticleGetDetailResponse(new NullArticleDto(articleId.Value));
            }
            else
            {
                var transformer = new ArticleToDtoTransformer();
                var dto = article.Transform(transformer);
                return new ArticleGetDetailResponse(dto);
            }

        }
    }
}
