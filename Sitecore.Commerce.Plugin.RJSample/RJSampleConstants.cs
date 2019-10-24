namespace Sitecore.Commerce.Plugin.RJSample
{
    public static class RJSampleConstants
    {
        public static class Prefixes
        {
            public const string CommerceBlock = "Commerce.RJSample.block.";

            public const string CommercePipeline = "Commerce.RJSample.pipeline.";
        }

        public const string ResetEnvironmentNodeContextPipeline = Prefixes.CommerceBlock + "ResetEnvironmentNodeContextPipeline";

        public const string GetProxyContainerPipeline = Prefixes.CommercePipeline + "GetProxyContainerPipeline";

        public const string RegisteredPluginBlock = Prefixes.CommerceBlock + "RegisteredPlugin";

        public const string ResetNodeContextBlock = Prefixes.CommerceBlock + "ResetNodeContextBlock";
    }
}
