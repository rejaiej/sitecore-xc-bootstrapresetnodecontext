namespace Sitecore.Commerce.Plugin.EnvironmentProxy
{
    using System.Threading.Tasks;

    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.ServiceProxy;
    using Sitecore.Commerce.Plugin.EnvironmentProxy;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    [PipelineDisplayName(EnvironmentProxyConstants.TriggerResetEnvironmentsNodeContext)]
    public class TriggerResetEnvironmentsNodeContextBlock : PipelineBlock<string, string, CommercePipelineExecutionContext>
    {
        private readonly IGetProxyContainerPipeline _getProxyContainerPipeline;

        public TriggerResetEnvironmentsNodeContextBlock(
            IGetProxyContainerPipeline getProxyContainerPipeline,
            IStartEnvironmentPipeline startEnvironmentPipeline)
          : base(null)
        {
            this._getProxyContainerPipeline = getProxyContainerPipeline;
        }

        public override async Task<string> Run(string arg, CommercePipelineExecutionContext context)
        {
            System.Diagnostics.Debugger.Launch();
            Condition.Requires(arg).IsNotNull($"The argument can not be null");

            // get policy
            var knownApplicationEnvironmentsPolicy = context.GetPolicy<KnownApplicationEnvironmentsPolicy>();
            if (knownApplicationEnvironmentsPolicy.Environments == null)
            {
                // log goes here
                return arg;
            }

            // iterate through and reset node context on other environments
            foreach (var applicationEnvironment in knownApplicationEnvironmentsPolicy.Environments)
            {
                // get container
                var getProxyContainerArgument = new GetProxyContainerArgument(
                    applicationEnvironment.BaseUri,
                    string.Empty,
                    "GlobalEnvironment",
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    applicationEnvironment.CommerceEngineCertHeaderName,
                    applicationEnvironment.CertThumbprint,
                    applicationEnvironment.CertStoreLocation,
                    applicationEnvironment.CertStoreName);

                // get container and call reset node context command
                var container = await this._getProxyContainerPipeline.Run(getProxyContainerArgument, context).ConfigureAwait(false);
                var command = Proxy.DoCommand(container.ResetEnvironmentNodeContext(applicationEnvironment.Environment));

                // log command metadata
            }

            return arg;
        }
    }
}
