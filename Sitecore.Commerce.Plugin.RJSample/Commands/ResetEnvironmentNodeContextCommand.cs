namespace Sitecore.Commerce.Plugin.RJSample
{
    using System;
    using System.Threading.Tasks;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;

    public class ResetEnvironmentNodeContextCommand : CommerceCommand
    {
        private readonly IResetEnvironmentNodeContextPipeline _pipeline;

        public ResetEnvironmentNodeContextCommand(IResetEnvironmentNodeContextPipeline pipeline, IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            this._pipeline = pipeline;
        }

        public async Task<CommerceEntity> Process(CommerceContext commerceContext, string environmentName)
        {
            using (var activity = CommandActivity.Start(commerceContext, this))
            {
                var updatedEnvironment = await this._pipeline.Run(environmentName, new CommercePipelineExecutionContextOptions(commerceContext));

                return updatedEnvironment;
            }
        }
    }
}