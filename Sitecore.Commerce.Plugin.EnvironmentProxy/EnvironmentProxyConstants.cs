namespace Sitecore.Commerce.Plugin.EnvironmentProxy
{
    public static class EnvironmentProxyConstants
    {
        public static class Prefixes
        {
            public const string CommerceBlock = "Commerce.EnvironmentProxy.block.";

            public const string CommercePipeline = "Commerce.EnvironmentProxy.pipeline.";
        }

        public const string GetProxyContainerBlock = Prefixes.CommerceBlock + "GetProxyContainerBlock";

        public const string GetProxyContainerPipeline = Prefixes.CommercePipeline + "GetProxyContainerPipeline";

        public const string RegisteredPluginBlock = Prefixes.CommerceBlock + "RegisteredPlugin";

        public const string TriggerResetEnvironmentsNodeContext = Prefixes.CommerceBlock + "TriggerResetEnvironmentsNodeContext";
    }
}
