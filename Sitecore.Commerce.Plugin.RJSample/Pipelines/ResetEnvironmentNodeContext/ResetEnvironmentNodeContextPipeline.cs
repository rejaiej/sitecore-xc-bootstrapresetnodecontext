namespace Sitecore.Commerce.Plugin.RJSample
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    public class ResetEnvironmentNodeContextPipeline : CommercePipeline<string, CommerceEnvironment>, IResetEnvironmentNodeContextPipeline
    {
        public ResetEnvironmentNodeContextPipeline(
             IPipelineConfiguration<IResetEnvironmentNodeContextPipeline> configuration,
             ILoggerFactory loggerFactory)
             : base(configuration, loggerFactory)
        {
        }
    }
}

