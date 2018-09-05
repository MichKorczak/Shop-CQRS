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

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper helper = factory.GetUrlHelper(ViewContext);
            TagBuilder builder = new TagBuilder("div");
            var pages = PageModel.TotalPage;
            for (int i = 1; i <= pages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = helper.Action(PageAction, new {productPage = i});
                tag.InnerHtml.Append(i.ToString());
                builder.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(builder.InnerHtml);
        }
    }
}
