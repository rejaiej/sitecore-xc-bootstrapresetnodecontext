// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.RJSample
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.OData;

    using Microsoft.AspNetCore.Mvc;

    using Sitecore.Commerce.Core;

    [Microsoft.AspNetCore.OData.EnableQuery]
    [Route("api")]
    public class CommandsController : CommerceController
    {
        public CommandsController(
            IServiceProvider serviceProvider,
            CommerceEnvironment globalEnvironment)
            : base(serviceProvider, globalEnvironment)
        {
        }

        [HttpPost]
        [Route("ResetEnvironmentNodeContext")]
        [Microsoft.AspNetCore.OData.EnableQuery]
        public async Task<IActionResult> ResetEnvironmentNodeContext([FromBody] ODataActionParameters value)
        {
            System.Diagnostics.Debugger.Launch();
            if (!value.ContainsKey("environmentName"))
            {
                return new BadRequestObjectResult(value);
            }

            string environmentName = value["environmentName"].ToString();
            ResetEnvironmentNodeContextCommand command = this.Command<ResetEnvironmentNodeContextCommand>();
            await command.Process(this.CurrentContext, environmentName).ConfigureAwait(false);

            return new ObjectResult(command);
        }
    }
}
