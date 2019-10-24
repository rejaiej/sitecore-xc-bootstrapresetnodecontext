namespace Sitecore.Commerce.Plugin.RJSample
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Serilog;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    [PipelineDisplayName(RJSampleConstants.ResetNodeContextBlock)]
    public class ResetNodeContextBlock : PipelineBlock<string, string, CommercePipelineExecutionContext>
    {
        private readonly NodeContext _nodeContext;

        public ResetNodeContextBlock(NodeContext nodeContext)
        {
            this._nodeContext = nodeContext;
        }

        public override Task<string> Run(string arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires<string>(arg).IsNotNullOrEmpty(this.Name + ": the environment name cannot be null or empty.");
            Log.Logger.Information("Resetting Node Context for environment '" + arg + "|" + this._nodeContext.CorrelationId + "'. Triggered by " + this.Name + ".");

            var environmentEntityId = arg.ToEntityId<CommerceEnvironment>();
            CommerceEnvironment commerceEnvironment = this._nodeContext.GetEntities<CommerceEnvironment>().FirstOrDefault(p => p.Id.Equals(arg, StringComparison.OrdinalIgnoreCase));
            if (commerceEnvironment != null)
            {
                commerceEnvironment.DisposeMinions();
                this._nodeContext.RemoveEntity(commerceEnvironment);
            }
            EnvironmentContext environmentContext = this._nodeContext.GetObject<EnvironmentContext>(e => e.CorrelationId.Equals(arg, StringComparison.OrdinalIgnoreCase));
            if (environmentContext != null)
                this._nodeContext.RemoveObject(environmentContext);

            return Task.FromResult(arg);
        }
    }
}
