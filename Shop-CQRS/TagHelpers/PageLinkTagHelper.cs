using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Shop_CQRS.Core.Response.Models;

namespace Shop_CQRS.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory factory;

        public PageLinkTagHelper(IUrlHelperFactory factory)
        {
            this.factory = factory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PagUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEneable { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper helper = factory.GetUrlHelper(ViewContext);
            TagBuilder builder = new TagBuilder("div");
            var pages = PageModel.TotalPage;
            for (int i = 1; i <= pages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                PagUrlValues["productPage"] = i;
                tag.Attributes["href"] = helper.Action(PageAction, PagUrlValues);
                if (PageClassesEneable)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                builder.InnerHtml.AppendHtml(tag);
            }

            TagBuilder tagBuilder = new TagBuilder("div");
            
            builder.InnerHtml.Append("Liczba elementów na stronie: ");
            for (int i = 2; i <= 6; i++)
            {
                if (i%2 == 0)
                {
                    TagBuilder tag =  new TagBuilder("a");
                    tag.Attributes["href"] = helper.Action(PageAction, new {pageSize = i});
                    if (PageClassesEneable)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.Append(i.ToString());
                    tagBuilder.InnerHtml.AppendHtml(tag);
                }
            }

            output.Content.AppendHtml(builder.InnerHtml);
            output.Content.AppendHtml(tagBuilder.InnerHtml);
        }


    }
}
