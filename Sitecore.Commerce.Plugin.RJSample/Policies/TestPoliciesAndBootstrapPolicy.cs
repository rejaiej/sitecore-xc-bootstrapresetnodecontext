// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SamplePolicy.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.RJSample
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a policy
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.Policy" />
    public class TestPoliciesAndBootstrapPolicy : Policy
    {
        public string Property1 { get; set; }

        public string Property2 { get; set; }

        public string Property3 { get; set; }
    }
}
