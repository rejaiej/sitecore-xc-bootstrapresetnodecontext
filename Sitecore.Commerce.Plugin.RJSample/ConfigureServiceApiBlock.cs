namespace Sitecore.Commerce.Plugin.RJSample
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.OData.Builder;

    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    [PipelineDisplayName("RJSamplePluginConfigureServiceApiBlock")]
    public class ConfigureServiceApiBlock : PipelineBlock<ODataConventionModelBuilder, ODataConventionModelBuilder, CommercePipelineExecutionContext>
    {
        public override Task<ODataConventionModelBuilder> Run(ODataConventionModelBuilder modelBuilder, CommercePipelineExecutionContext context)
        {
            Condition.Requires(modelBuilder).IsNotNull($"{this.Name}: The argument cannot be null.");

            var configuration = modelBuilder.Action("ResetEnvironmentNodeContext");
            configuration.Parameter<string>("environmentName");
            configuration.ReturnsFromEntitySet<CommerceCommand>("Commands");

            return Task.FromResult(modelBuilder);
        }
    }
}
