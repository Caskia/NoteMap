using System;

namespace NoteMap.Elements
{
    public class Scale
    {
        private decimal _x;
        private decimal _y;
        private decimal maxScaleLevel = 5;
        private decimal minScaleLevel = 1;

        public decimal X
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

        public decimal Y
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

        private decimal LimitScaleRange(decimal scale)
        {
            return Math.Max(Math.Min(scale, maxScaleLevel), minScaleLevel);
        }
    }
}