using Microsoft.AspNetCore.Components;
using SplitJs.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitJs.Blazor.Components
{
    /// <summary>
    /// Due to limitation of 
    /// </summary>
    public partial class Vertical : SplitAreaBase
    {
        protected override void SetOptions(SplitOptions options)
        {
            options.Direction = Direction.Vertical;
        }
    }
}
