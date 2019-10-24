namespace Sitecore.Commerce.Plugin.RJSample
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    [PipelineDisplayName(RJSampleConstants.ResetEnvironmentNodeContextPipeline)]
    public interface IResetEnvironmentNodeContextPipeline : IPipeline<string, CommerceEnvironment, CommercePipelineExecutionContext>, IPipelineBlock<string, CommerceEnvironment, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
