using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SplitJs.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitJs.Blazor.Components
{
    public abstract class SplitAreaBase : ComponentBase
    {
        [Inject] IJSRuntime? JS { get; set; }
        [CascadingParameter(Name = "ModuleLoader")]
        public ValueTask<IJSObjectReference> ModuleLoader { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string? GutterStyle { get; set; }
        /// <summary>
        /// Default value is 8
        /// </summary>
        [Parameter]
        public float GutterSize { get; set; } = 8;

        [Parameter]
        public string? GutterAlign { get; set; }
        [Parameter]
        public int? SnapOffset { get; set; }
        [Parameter]
        public int? DragInterval { get; set; }



        protected SplitOptions Option = new();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && Children.Count > 1)
            {
                Option.GutterSize = GutterSize;
                Option.GutterAlign = GutterAlign;
                Option.SnapOffset = SnapOffset;
                Option.DragInterval = DragInterval;
                Option.Sizes = Sizes;
                Option.MinSizes = MinSizes;
                Option.MaxSizes = MaxSizes;

                await (await ModuleLoader).InvokeVoidAsync("Split",
                    Children.Select(x => '#' + x).ToArray(),
                    Option.ToInterOperable()
                    );
            }
        }

        protected List<string> Children = new();
        public void NotifyExistence(string id)
        {
            Children.Add(id);
        }

        protected List<int> Sizes = new();
        public void NotifySize(int size)
        {
            Sizes.Add(size);
        }
        protected List<int> MinSizes = new();
        public void NotifyMinSize(int minSize)
        {
            MinSizes.Add(minSize);
        }
        protected List<int> MaxSizes = new();
        public void NotifyMaxSize(int maxSize)
        {
            MaxSizes.Add(maxSize);
        }

    }
}
