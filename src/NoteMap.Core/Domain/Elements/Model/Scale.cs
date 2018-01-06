using System;

namespace NoteMap.Elements
{
    public class Scale
    {
        private double _x;
        private double _y;
        private double maxScaleLevel = 5;
        private double minScaleLevel = 1;

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = LimitScaleRange(value);
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = LimitScaleRange(value);
            }
        }

        private double LimitScaleRange(double scale)
        {
            return Math.Max(Math.Min(scale, maxScaleLevel), minScaleLevel);
        }
    }
}