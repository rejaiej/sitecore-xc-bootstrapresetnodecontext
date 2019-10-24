namespace Sitecore.Commerce.Plugin.EnvironmentProxy
{
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    public class ConfigureSitecore : IConfigureSitecore
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(
                config =>
                    config
                        .AddPipeline<IGetProxyContainerPipeline, GetProxyContainerPipeline>(c =>
                        {
                            c.Add<GetProxyContainerBlock>();
                        }, "main", 1000)
                        .ConfigurePipeline<IRunningPluginsPipeline>(c =>
                        {
                            c.Add<RegisteredPluginBlock>().After<RunningPluginsBlock>();
                        }, "main", 1000)
            );

            services.RegisterAllCommands(assembly);
        }
    }
}