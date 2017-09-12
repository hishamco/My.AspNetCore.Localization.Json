using System;
using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LocalizationSample
{
    public class LocalizationFixPageFactoryProvider : DefaultPageFactoryProvider
    {
        public LocalizationPageFactoryProvider(
            IPageActivatorProvider pageActivator,
            IModelMetadataProvider metadataProvider,
            IUrlHelperFactory urlHelperFactory,
            IJsonHelper jsonHelper,
            DiagnosticSource diagnosticSource,
            HtmlEncoder htmlEncoder,
            IModelExpressionProvider modelExpressionProvider)
            : base(pageActivator, metadataProvider, urlHelperFactory, jsonHelper, diagnosticSource, htmlEncoder, modelExpressionProvider)
        {
        }

        public override Func<PageContext, ViewContext, object> CreatePageFactory(CompiledPageActionDescriptor actionDescriptor)
        {
            var result = base.CreatePageFactory(actionDescriptor);
            return (pageContext, viewContext) =>
            {
                viewContext.ExecutingFilePath = actionDescriptor.RelativePath;
                return result(pageContext, viewContext);
            };
        }
    }
}
