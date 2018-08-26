using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Create;

namespace Presentation.Services
{
    public interface IArticleService
    {
        //IArticleDetailQuery DetailQuery { get; }
        //IArticleGetByAutherQuery GetByAutherQuery { get; }
        IArticleCreateUseCase CreateCommand { get; }
    }
}
