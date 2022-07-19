


using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CadastrosBiblioteca.Helper
{
    [HtmlTargetElement("a", Attributes = TargetAttributeName)] //Essa tagHelper se aplica somente para elementos  Html do tipo (A),OU SEJA ELEMENTOS DO TIPO LINK
    public class CssClassForCurrentLink : TagHelper
    {


        private const string TargetAttributeName = "asp-link-class";// Constante para representar asp-link-class ou taghelper (a)

        [ViewContext]
        public ViewContext? ViewContext { get; set; }// propriedade para armazenar a referencia para o contexto view para que a taghelper possa acessa-la

        [HtmlAttributeName("class")]
        public string? Classes { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var action = context.AllAttributes["asp-action"].Value.ToString();
            var controller = context.AllAttributes["asp-controller"].Value.ToString();
            //<a class="nav-link" asp-controller="Home" asp-action="Index" asp-link-class="link-ativo">Principal</a>
            var thClasses = context.AllAttributes[TargetAttributeName].Value.ToString();

            var currAction = ViewContext?.HttpContext.Request.RouteValues["action"]?.ToString();
            var currController = ViewContext?.HttpContext.Request.RouteValues["controller"]?.ToString();

            if (action == currAction && controller == currController)
                this.Classes += $" {thClasses}";

            output.Attributes.Add("class", Classes);

            var attribute = context.AllAttributes[TargetAttributeName];
            output.Attributes.Remove(attribute);
        }

    }
}

