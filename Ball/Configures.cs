﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    static class Configures
    {
        public static Position InitPosition = new Position(816, 488)/2;
        public static Position InitVelocity = new Position(-10, -15);
        public static Position VectorG = new Position(0, 0.1f);

        public static double AirResistance = 0.99;
        public static double GCoefficient = 1;
        public static double Impact_Speed_Reduce = 0.8;
        public static double InitRadius = 25;
        public static double MaxSpeed = 200;
        public static double GRotateSpeed = 0;

        public static string LogFileName = Utils.GetTime_File() + ".log";
        public static string LogPath = "Logs/";
    }
}
