using System.Collections.Generic;
using GeometricShape.Entities;

namespace GeometricShape.Comparators
{
    public class ShapeComparator : IComparer<Rectangle>
    {
        public int Compare(Rectangle x, Rectangle y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return x.Name.CompareTo(y.Name);
        }
    }
}
