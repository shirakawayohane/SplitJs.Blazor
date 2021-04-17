using Microsoft.AspNetCore.Components;
using SplitJs.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitJs.Blazor.Components
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Horizontal : SplitAreaBase
    {

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Option.Direction = Direction.Horizontal;
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
