﻿namespace AngleSharp.Css.MediaFeatures
{
    using System;
    using AngleSharp.Css.Values;
    using AngleSharp.Dom.Css;

    sealed class DeviceWidthMediaFeature : MediaFeature
    {
        #region Fields

        Length _length;

        #endregion

        #region ctor

        public DeviceWidthMediaFeature(String name)
            : base(name)
        {
        }

        #endregion

        #region Methods

        internal override Boolean TrySetDefault()
        {
            return true;
        }

        internal override Boolean TrySetCustom(CssValue value)
        {
            return Converters.LengthConverter.TryConvert(value, m => _length = m);
        }

        public override Boolean Validate(RenderDevice device)
        {
            var desired = _length.ToPixel();
            var available = (Single)device.DeviceWidth;

            if (IsMaximum)
                return available <= desired;
            else if (IsMinimum)
                return available >= desired;

            return desired == available;
        }

        #endregion
    }
}
