using RazorLight;
using System.Reflection;

namespace PhotoService.Renderes
{
    public class HtmlRenderer:IHtmlRenderer
    {
        private readonly RazorLightEngine _razorLightEngine;

        public HtmlRenderer()
        {
            _razorLightEngine = new RazorLightEngineBuilder()
                   .SetOperatingAssembly(Assembly.GetExecutingAssembly())
                   .UseEmbeddedResourcesProject(typeof(Program).Assembly, "PhotoService.EmailTemplates")
                   .UseMemoryCachingProvider()
                   .Build();
        }

        public async Task<string> RenderEmail<T>(T model)
        {
            string modelName = typeof(T).Name.ToString();
            string fileName = modelName.Remove(modelName.Length - 5);

            var htmlBody = await RenderEmailTemplateAsStringAsync(fileName, model);

            return htmlBody;
        }

        private async Task<string> RenderEmailTemplateAsStringAsync<T>(string viewName, T model)
        {
            return await _razorLightEngine.CompileRenderAsync(viewName, model);
        }
    }
}
