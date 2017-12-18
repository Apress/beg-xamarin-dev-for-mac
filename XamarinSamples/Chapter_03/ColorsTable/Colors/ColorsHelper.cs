﻿using System.Collections.Generic;
using System.Reflection;
using UIKit;

namespace ColorsTable.Colors
{
    public static class ColorsHelper
    {
        public static List<Color> GetColors()
        {
            var colors = new List<Color>();

            var uiColorType = typeof(UIColor);

            var availableColors = uiColorType.GetProperties(
                    BindingFlags.Public | BindingFlags.Static);

            foreach (var color in availableColors)
            {
                colors.Add(new Color()
                {
                    Name = color.Name,
                    Value = color.GetValue(uiColorType) as UIColor
                });
            }

            return colors;
        }
    }
}
