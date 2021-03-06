﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Core;

namespace UseCase.Articles.Create
{
    public class ArticleCreateRequest : IRequest<ArticleCreateResponse>
    {
        public ArticleCreateRequest(string title, string body, long autherId)
        {
            Title = title;
            Body = body;
            AutherId = autherId;
        }

        public string Title { get; }
        public string Body { get; }
        public long AutherId { get; }
    }
}
