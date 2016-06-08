using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

[assembly: InternalsVisibleTo("WeatherTest.Tests")]
namespace WeatherTest.WebApi.Infrastructure
{
    /// <summary>
    /// Contains wind direction info.
    /// </summary>
    internal sealed class WindDirection
    {
        private static String[] directionNames = { "North", "Northeast", "East", "Southeast", "South", "Southwest", "West", "	Northwest" };
        private static int directionSector = 45;
        //Half of sector. Because North lay in two ranges: 0-22.5 and 337.5 - 360.
        private static double offset = 22.5;

        #region Properties
        internal String Direction { get; private set; }

        internal int DirectonInDegrees { get; private set; }
        #endregion Properties

        internal static WindDirection Create(int directonInDegrees)
        {
            WindDirection result = null;

            if (directonInDegrees > 0 && directonInDegrees < 360)
            {
                double nameIndex = Math.Ceiling((directonInDegrees - offset) / directionSector);

                //Use first item.
                if (nameIndex > directionNames.Length - 1)
                {
                    nameIndex = 0;
                }

                String directionName = directionNames[(int)nameIndex];

                result = new WindDirection(directonInDegrees, directionName);
            }

            return result;
        }

        private WindDirection(int directonInDegrees, String direction)
        {
            DirectonInDegrees = directonInDegrees;
            Direction = direction;

        }
    }
}