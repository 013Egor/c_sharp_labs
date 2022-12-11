using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Labs.Lab2_BattleShip.Views
{
    public static class GraphicsExtensions
    {
        private static Brush backgroundBrush = new SolidBrush(Color.Aqua);
        private static Pen cellBorderPen = new Pen(Color.Black, 2);

        private static Brush shotBrush = new SolidBrush(Color.Red);

        private static Brush conflictShipBrush = new SolidBrush(Color.Yellow);
        private static Brush shipBrush = new SolidBrush(Color.Blue);
        private static Pen shipPen = new Pen(Color.Purple, 4);

        private static Pen lightShipPen = new Pen(Color.LightBlue, 4);

        public static void DrawBackground(this Graphics graphics, int width, int height)
        {
            graphics.FillRectangle(backgroundBrush, 0, 0, width, height);
        }

        public static void DrawEmptyCell(this Graphics graphics, Rectangle rectangle)
        {
            graphics.DrawRectangle(cellBorderPen, rectangle);
        }

        public static void DrawShipCell(this Graphics graphics, Rectangle rectangle,
            bool isShot = false, bool inConflict = false, bool useLight = false)
        {
            var brush = inConflict ? conflictShipBrush : shipBrush;
            var pen = useLight ? lightShipPen : shipPen;

            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(pen, rectangle);

            if (isShot)
            {
                graphics.DrawLine(shipPen, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
                graphics.DrawLine(shipPen, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Top);
            }
        }

        public static void DrawShotCell(this Graphics graphics, Rectangle rectangle)
        {
            graphics.FillEllipse(shotBrush,
                rectangle.X + 3 * rectangle.Width / 8,
                rectangle.Y + 3 * rectangle.Height / 8,
                rectangle.Width / 4,
                rectangle.Height / 4);
        }
    }
}
