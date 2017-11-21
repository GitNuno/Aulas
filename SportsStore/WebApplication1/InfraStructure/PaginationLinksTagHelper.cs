using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SportStore.InfraStructure
{

    // isto é um tag helper Ex: asp-action
    // vai-me gerar os botões e os links de pag. para pagina, onde vou aplicar o tag helper(div) 
    // Attributes > page-model == PageModel
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationLinksTagHelper : TagHelper // vai-me gerar os links da paginação
    {
        // vai guardar o link criado
        private IUrlHelperFactory urlHelperFactory;

        public static int MaxLinksBeforeAndAfterCurrentPage = 7;

        //IUrlHelperFactory fabrica de links o MVC vai-me providenciar um serviço
        PaginationLinksTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        // [ViewContext] necessita de import
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        // PageModel vai ser o que vai ser escrito na DIV
        public PagingInfo PageModel { get; set; }
        // qual a acção que quero chamar
        public string PageAction { get; set; }

        // codigo para gerar link: qts pag.s vou pôr e que está em PagingInfo PageModel
        // metodo_override de TagHelper
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // para gerar os url
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            // criar a tag <div>
            TagBuilder result = new TagBuilder("div");

            // para balizar o nº max. de links
            int initial = PageModel.CurrentPage - MaxLinksBeforeAndAfterCurrentPage;
            if (initial < 1) initial = 1;

            int final = PageModel.CurrentPage + MaxLinksBeforeAndAfterCurrentPage;
            if (final > PageModel.TotalPages) final = PageModel.TotalPages;

            for (int p = initial; p <= PageModel.TotalPages; p++)
            {
                // criar a tag <a> hiperligacao
                TagBuilder pageLink = new TagBuilder("a");
                // PageAction
                pageLink.Attributes["href"] = urlHelper.Action(PageAction, new { page = p });
                // numero que vejo
                pageLink.InnerHtml.Append(p.ToString());

                result.InnerHtml.AppendHtml(pageLink);
            }
            // é o que vejo dentro da div
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
