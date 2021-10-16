using CodeReview_HepsiBurada.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeReview_HepsiBurada.Objects
{
    public class Pozition
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Directions Direction { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, GetDirectionCode(Direction));
        }

        private string GetDirectionCode(Enums.Directions direction)
        {
            if (direction == Directions.East)
            {
                return "E";
            }
            else if (direction == Directions.North)
            {
                return "N";
            }
            else if (direction == Directions.South)
            {
                return "S";
            }
            else
            {
                return "W";
            }
        }
    }
}
