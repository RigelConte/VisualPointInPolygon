using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace VisualPointInPolygon
{
    internal class Polygon     
    {        
        private List<Point> polygon;
        private Point pointToCheck;
        private bool isInside;
        private static Random rand = new Random();
        private static double EPSILON = 1e-10;

        public enum PoinInPolygonAlgorithms
        {
            RayCasting = 0,
            WindingNumber = 1,
            AngleSummation
        }

        public Polygon() 
        {
            GeneratePolygon();
            isInside = false;           
        }

        public void GeneratePolygon() 
        {
            int minPoints = 3;
            int maxPoints = 8;            

            int numberOfPoints = rand.Next(minPoints, maxPoints + 1);

            polygon = new List<Point>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                int x = rand.Next(0, 500);
                int y = rand.Next(0, 450);
                polygon.Add(new Point(x, y));
            }
        }

        public PointF[] PolygonPoints() 
        {
            PointF[] polygonPoints = new PointF[polygon.Count];
            for (int i = 0; i < polygon.Count; i++)
            {
                polygonPoints[i] = new PointF((float)polygon[i].X, (float)polygon[i].Y);
            }
            return polygonPoints;
        }
        
        public bool IsInside()
        {
            return isInside;
        }

        public void IsPointInside(Point pointToCheck, int algorithmToAnalyze)
        {
            switch (algorithmToAnalyze)
            {
                case (int)PoinInPolygonAlgorithms.RayCasting:
                    {
                        isInside = IsPointInPolygon_RayCasting(polygon, pointToCheck);
                        break;
                    }
                case (int)PoinInPolygonAlgorithms.WindingNumber:
                    {
                        isInside = IsPointInPolygon_WindingNumber(polygon, pointToCheck);
                        break;
                    }
                case (int)PoinInPolygonAlgorithms.AngleSummation:
                    {
                        isInside = IsPointInPolygon_AngleSummation(polygon, pointToCheck);
                        break;
                    }
                default: break;
            }
        }
        
        #region Ray Casting Algorithm

        public static bool IsPointInPolygon_RayCasting(List<Point> polygon, Point point)
        {
            int n = polygon.Count;
            bool isInside = false;

            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                    (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }

            return isInside;
        }


        #endregion

        #region Winding Number Algorithm

        public static bool IsPointInPolygon_WindingNumber(List<Point> polygon, Point point)
        {
            int n = polygon.Count;
            int windingNumber = 0;

            for (int i = 0; i < n; i++)
            {
                Point p1 = polygon[i];
                Point p2 = polygon[(i + 1) % n];

                if (p1.Y <= point.Y)
                {
                    if (p2.Y > point.Y && IsLeft(p1, p2, point) > 0)
                    {
                        windingNumber++;
                    }
                }
                else
                {
                    if (p2.Y <= point.Y && IsLeft(p1, p2, point) < 0)
                    {
                        windingNumber--;
                    }
                }
            }

            return windingNumber != 0;
        }

        private static double IsLeft(Point p1, Point p2, Point p)
        {
            return (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);
        }

        #endregion

        #region Angle Summation Algorithm

        public static bool IsPointInPolygon_AngleSummation(List<Point> polygon, Point point)
        {
            int n = polygon.Count;            
            double angleSum = 0;

            for (int i = 0; i < n; i++)
            {
                Point p1 = new Point(polygon[i].X - point.X, polygon[i].Y - point.Y);
                Point p2 = new Point(polygon[(i + 1) % n].X - point.X, polygon[(i + 1) % n].Y - point.Y);

                double angle = Math.Atan2(p2.Y, p2.X) - Math.Atan2(p1.Y, p1.X);

                if (angle >= Math.PI)
                    angle -= 2 * Math.PI;
                else if (angle <= -Math.PI)
                    angle += 2 * Math.PI;

                angleSum += angle;
            }

            return Math.Abs(angleSum) > EPSILON;
        }

        private static double AngleBetweenPoints(Point p1, Point p2, Point p3)
        {
            double d1 = Distance(p1, p2);
            double d2 = Distance(p2, p3);
            double d3 = Distance(p1, p3);
            double angle = Math.Acos((d1 * d1 + d2 * d2 - d3 * d3) / (2 * d1 * d2));
            return angle;
        }

        private static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        #endregion      
    }
}
