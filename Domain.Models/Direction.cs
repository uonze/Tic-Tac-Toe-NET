namespace TicTacToe.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public enum Compass
    {
        North = 0,
        Northeast = 1,
        East = 2,
        Southeast = 3,
        South = 4,
        Southwest = 5,
        West = 6,
        Northwest = 7,
    }

    public class Direction
    {
        public static IEnumerable<Compass> GetCompassDirections()
        {
            return Enum.GetValues(typeof(Compass)).Cast<Compass>(); ;
        }

        public static Point GetDirectionVector(Compass compass)
        {
            switch (compass)
            {
                case Compass.North: return new Point(0, 1);
                case Compass.Northeast: return new Point(1, 1);
                case Compass.East: return new Point(1, 0);
                case Compass.Southeast: return new Point(1, -1);
                case Compass.South: return new Point(0, -1);
                case Compass.Southwest: return new Point(-1, -1);
                case Compass.West: return new Point(-1, 0);
                case Compass.Northwest: return new Point(-1, 1);
                default: return new Point(0, 0);
            }
        }
    }
}