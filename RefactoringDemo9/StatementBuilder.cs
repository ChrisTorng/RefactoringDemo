using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Nito.AsyncEx;
using RazorLight;

namespace RefactoringDemo9
{
    public static class StatementBuilder
    {
        private static readonly RazorLightEngine Engine = CreateEngine();
        private static readonly Dictionary<string, ITemplatePage> TemplatePages =
            new Dictionary<string, ITemplatePage>();

        private static readonly AsyncLock AsyncLock = new AsyncLock();

        private static RazorLightEngine CreateEngine()
        {
            string templateBasePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Statements");
            return new RazorLightEngineBuilder()
                .UseFileSystemProject(templateBasePath)
                .UseMemoryCachingProvider()
                .Build();
        }

        public static async Task BuildTemplate(string path)
        {
            using (await AsyncLock.LockAsync())
            {
                if (!TemplatePages.ContainsKey(path))
                {
                    ITemplatePage templatePage = await Engine.CompileTemplateAsync(path);
                    TemplatePages.Add(path, templatePage);
                }
            }
        }

        public static async Task<string> BuildResult(string path, StatementData data)
        {
            using (await AsyncLock.LockAsync())
            {
                if (!TemplatePages.ContainsKey(path))
                {
                    throw new InvalidOperationException("Call BuildTemplate() before BuildResult().");
                }

                return await Engine.RenderTemplateAsync(TemplatePages[path], data);
            }
        }
    }
}
