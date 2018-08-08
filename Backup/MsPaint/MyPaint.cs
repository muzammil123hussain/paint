using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace MsPaint
{
   [Serializable]
    class MyPaint
    {

      
        private Point p_old;
        private Point p_cur;
        private int m_shape;
        private float m_width;
        private Color m_color;

        public MyPaint()
        {
            p_old = new Point(0, 0);
            p_cur = new Point(0, 0);
            m_shape = 0;
            m_width = 1;
            m_color = Color.Black;
        }
        public MyPaint(Point old, Point cur, int shape, float width, Color color)
        {
            p_old = old;
            p_cur = cur;
            m_shape = shape;
            m_width = width;
            m_color = color;
        }

        public Point old
        {
            get
            {
                return p_old;
            }
            set
            {
                p_old = value;
            }
        }

        public Point cur
        {
            get
            {
                return p_cur;
            }
            set
            {
                p_cur = value;
            }
        }

        public int shape
        {
            get
            {
                return m_shape;
            }
            set
            {
                m_shape = value;
            }
        }

        public float width
        {
            get
            {
                return m_width;
            }
            set
            {
                m_width = value;
            }
        }

        public Color color
        {
            get
            {
                return m_color;
            }
            set
            {
                m_color = value;
            }
        }
    }
}


