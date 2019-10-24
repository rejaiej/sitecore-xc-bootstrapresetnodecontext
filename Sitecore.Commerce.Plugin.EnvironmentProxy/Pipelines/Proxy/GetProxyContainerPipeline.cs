namespace Sitecore.Commerce.Plugin.EnvironmentProxy
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    using CommerceProxy.Sitecore.Commerce.Engine;

    public class GetProxyContainerPipeline : CommercePipeline<GetProxyContainerArgument, Container>, IGetProxyContainerPipeline
    {
        public GetProxyContainerPipeline(
             IPipelineConfiguration<IGetProxyContainerPipeline> configuration,
             ILoggerFactory loggerFactory)
             : base(configuration, loggerFactory)
        {
        }
    }
}

