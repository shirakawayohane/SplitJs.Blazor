using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitJs.Blazor.Data
{
    public class SplitOptions
    {
        public ICollection<int>? Sizes;
        public ICollection<int>? MinSizes;
        public ICollection<int>? MaxSizes;
        public string? GutterStyle;
        public bool? ExpandToMin;
        public float? GutterSize;
        public string? GutterAlign;
        public int? SnapOffset;
        public int? DragInterval;
        public Direction Direction;

        public object ToInterOperable()
        {
            return new
            {
                sizes = Sizes,
                minSize = MinSizes,
                maxSize = MaxSizes,
                expandToMin = ExpandToMin,
                gutterSize = GutterSize,
                gutterAlign = GutterAlign,
                snapOffset = SnapOffset,
                dragInterval = DragInterval,
                direction = Direction.ToString().ToLower(),
            };
        }
    }
    public enum Direction
    {
        Horizontal,
        Vertical
    }
}
