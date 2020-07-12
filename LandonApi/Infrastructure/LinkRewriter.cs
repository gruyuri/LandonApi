using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Infrastructure
{
    public class LinkRewriter
    {
        private readonly IUrlHelper urlHelper;

        public LinkRewriter(IUrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;
        }

        public Link Rewrite(Link original)
        {
            if (original == null)
                return null;

            return new Link
            {
                Href = urlHelper.Link(original.RouteName, original.RouteValues),
                Method = original.Method,
                Relations = original.Relations
            };
        }
    }
}
