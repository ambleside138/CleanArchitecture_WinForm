using Domain.Application.Articles;
using Domain.Domain.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Create;

namespace Presentation.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        //public IArticleDetailQuery DetailQuery => new ArticleDetailQuery(articleRepository);
        //public IArticleGetByAutherQuery GetByAutherQuery => new ArticleGetByAutherQuery(articleRepository);
        public IArticleCreateUseCase CreateCommand => new ArticleCreateInteractor(articleRepository);
    }
}
