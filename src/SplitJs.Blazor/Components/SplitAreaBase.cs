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
        [CascadingParameter(Name = "CascadingOptions")]
        public SplitOptions? CascadingOptions { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string? GutterStyle { get; set; }
        public string EmitGuttereStyle => GutterStyle != null ? ".gutter{" + GutterStyle + '}' : "";
        [Parameter]
        public float? GutterSize { get; set; }

        [Parameter]
        public string? GutterAlign { get; set; }
        [Parameter]
        public int? SnapOffset { get; set; }
        [Parameter]
        public int? DragInterval { get; set; }

        private SplitOptions Options = new();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && Children.Count > 1)
            {
                if (CascadingOptions != null)
                {
                    this.Options = CascadingOptions;
                }

                if (GutterSize != null)
                    Options.GutterSize = GutterSize;
                if (GutterAlign != null)
                    Options.GutterAlign = GutterAlign;
                if (SnapOffset != null)
                    Options.SnapOffset = SnapOffset;
                if (DragInterval != null)
                    Options.DragInterval = DragInterval;
                if (Sizes != null)
                    Options.Sizes = Sizes;
                if (MinSizes != null)
                    Options.MinSizes = MinSizes;
                if (MaxSizes != null)
                    Options.MaxSizes = MaxSizes;

                SetOptions(Options);

                await (await ModuleLoader).InvokeVoidAsync("Split",
                    Children.Select(x => '#' + x).ToArray(),
                    Options.ToInterOperable()
                    );
            }
        }
        protected abstract void SetOptions(SplitOptions options);

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
