using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace PointDistanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly( typeof( Program ).Assembly ).Run( args );
        }
    }

    public class BechmarkClass
    {
        static float[] arrFloatX = { 1, 3, 5, 7, 9, 11, 23, 45, 56, 87 };
        static float[] arrFloatY = { 10, 13, 15, 17, 19, 11, 32, 54, 65, 78 };

        public float floatXx = arrFloatX[  new Random().Next(0, arrFloatX.Length) ];
        public float floatXy = arrFloatX[ new Random().Next( 0, arrFloatX.Length ) ];
        public float floatYx = arrFloatY[ new Random().Next( 0, arrFloatY.Length ) ];
        public float floatYy = arrFloatY[ new Random().Next( 0, arrFloatY.Length ) ];

        static double[] arrDoubleX = { 1, 3, 5, 7, 9, 11, 23, 45, 56, 87 };
        static double[] arrDoubleY = { 10, 13, 15, 17, 19, 11, 32, 54, 65, 78 };

        public double doubleXx = arrDoubleX[ new Random().Next( 0, arrDoubleX.Length ) ];
        public double doubleXy = arrDoubleX[ new Random().Next( 0, arrDoubleX.Length ) ];
        public double doubleYx = arrDoubleY[ new Random().Next( 0, arrDoubleY.Length ) ];
        public double doubleYy = arrDoubleY[ new Random().Next( 0, arrDoubleY.Length ) ];

        public class PointClass
        {
            public float X;
            public float Y;
        }

        public struct PointStructFloat
        {
            public float X;
            public float Y;
        }
        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }

        public static float ReferenceFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt( (x * x) + (y * y) );
        }

        public static float SignificantFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt( (x * x) + (y * y) );
        }

        public static double SignificantDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt( (x * x) + (y * y) );
        }

        public static float SignificantFloatNoSqrt(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void ReferenceFloat()
        {
            var pointX = new PointClass { X = floatXx, Y = floatXy };
            var pointY = new PointClass { X = floatYx, Y = floatYy };
            ReferenceFloat( pointX, pointY );
        }

        [Benchmark]
        public void SignificantFloat()
        {
            var pointX = new PointStructFloat { X = floatXx, Y = floatXy };
            var pointY = new PointStructFloat { X = floatYx, Y = floatYy };
            SignificantFloat( pointX, pointY );
        }

        [Benchmark]
        public void SignificantDouble()
        {
            var pointX = new PointStructDouble { X = doubleXx, Y = doubleXy };
            var pointY = new PointStructDouble { X = doubleYx, Y = doubleYy };
            SignificantDouble( pointX, pointY );
        }

        [Benchmark]
        public void SignificantFloatNoSqrt()
        {
            var pointX = new PointStructFloat { X = floatXx, Y = floatXy };
            var pointY = new PointStructFloat { X = floatYx, Y = floatYy };
            SignificantFloatNoSqrt( pointX, pointY );
        }
    }
}
