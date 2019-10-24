namespace Sitecore.Commerce.Plugin.RJSample
{
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.EnvironmentProxy;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    public class ConfigureSitecore : IConfigureSitecore
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config
             .AddPipeline<IResetEnvironmentNodeContextPipeline, ResetEnvironmentNodeContextPipeline>(
                configure =>
                {
                    configure.Add<ResetNodeContextBlock>();
                    configure.Add<IStartEnvironmentPipeline>();
                })
             .ConfigurePipeline<IBootstrapPipeline>(
                configure =>
                {
                    configure.Add<TriggerResetEnvironmentsNodeContextBlock>();
                })
             .ConfigurePipeline<IConfigureServiceApiPipeline>(
                configure =>
                {
                    configure.Add<ConfigureServiceApiBlock>();
                })
            );

            services.RegisterAllCommands(assembly);
        }
    }
}