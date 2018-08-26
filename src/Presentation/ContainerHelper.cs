using Domain.Application.Articles;
using Domain.Domain.Model.Articles;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Create;
using UseCase.Articles.GetByAuther;
using UseCase.Articles.GetDetail;
using UseCase.Core.MessageBus;

namespace Presentation
{
    // サンプルではMVCの機構を利用していたので、Form向けにSimpleInjectorに差し替え

    static class ContainerHelper
    {
        public static Container Current { get; private set; }

        public static void Setup()
        {
            var container = new Container();

            // Repository実装の定義
            container.RegisterSingleton<IArticleRepository, InMemoryDataStore.Articles.ArticleRepository>();

            // UserCase実装の定義
            var busBuilder = new UseCaseBusBuilder(container);
            busBuilder.RegisterUseCase<ArticleCreateRequest, ArticleCreateInteractor>();
            busBuilder.RegisterUseCase<ArticleGetByAutherRequest, ArticleGetByAutherInteractor>();
            busBuilder.RegisterUseCase<ArticleGetDetailRequest, ArticleGetDetailInteractor>();

            var bus = busBuilder.Build();

            container.RegisterInstance(bus);

            Current = container;
        }
    }
}
