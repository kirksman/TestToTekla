using System;
using System.Collections.Generic;
using System.Drawing;
using s =  System.Windows.Shapes;

namespace TestToTekla.classes
{
    public interface IDrawShape
    {
        /// <summary>
        /// количество ребер
        /// </summary>
        int NumOfRibs { get; }
        
    }

    /// <summary>
    /// координаты 
    /// </summary>
    sealed class Coordinates
    {
        /// <summary>
        /// Координаты середины окружности
        /// </summary>
        public PointS CenterCircule;
        /// <summary>
        /// Отправная точка в радианах
        /// </summary>
        public double StartingPoint;
        /// <summary>
        /// Внешний радиус
        /// </summary>
        public double OuterRadius;
        /// <summary>
        /// Количество точек
        /// </summary>
        public int NumberOfSides;
        public List<PointS> Points { get; private set; }
        /// <summary>
        /// Инициализация класса координат
        /// </summary>
        /// <param name="centerCircule">Координаты середины окружности</param>
        /// <param name="startingPoint">Отправная точка в радианах</param>
        /// <param name="outerRadius">Внешний радиус</param>
        /// <param name="numOfSides">Количество точек</param>
        public Coordinates(PointS centerCircule,double startingPoint,double outerRadius,int numOfSides)
        {
            this.CenterCircule = centerCircule;
            this.StartingPoint = startingPoint;
            this.OuterRadius = outerRadius;
            this.NumberOfSides = numOfSides;
            Points = ReturnPoints();
        }
        /// <summary>
        /// Расчет координат в правильной окружности на основе внешнего радиуса
        /// </summary>
        /// <returns>Коллекция коорнанат на окружности</returns>
        private List<PointS> ReturnPoints()
        {
            List<PointS> points = new List<PointS>();
            for (int i = 1; i <= NumberOfSides; i++)
            {
                PointS rePoint2 = new PointS();
                int CoefficientK = (NumberOfSides - i) > 0 ? NumberOfSides - i : 0;// Понижение коэф


                rePoint2.X = Math.Round(CenterCircule.X + OuterRadius * Math.Cos(StartingPoint + (2 * Math.PI * CoefficientK) / NumberOfSides));
                rePoint2.Y = Math.Round(CenterCircule.Y + OuterRadius * Math.Sin(StartingPoint + (2 * Math.PI * CoefficientK) / NumberOfSides));
                points.Add(rePoint2);
            }
            return points;
        }
        
    }
    /// <summary>
    /// Структура для оси 
    /// </summary>
    public struct PointS
    {
        /// <summary>
        /// Ось x
        /// </summary>
        public double X;
        /// <summary>
        /// Ось y
        /// </summary>
        public double Y;
    }

   

    
}
