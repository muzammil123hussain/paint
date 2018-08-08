using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MsPaint
{
    public partial class MsPaint : Form
    {
        private ArrayList ds;
        private Point mold;
        private Point mcur;
        private int mshape;
        private float mwidth;
        private Color mcolor;
        public MsPaint()
        {
            InitializeComponent();
            ds = new ArrayList();
            mshape = 0;
            mwidth = 1;
            mcolor = Color.Black;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross;
       
            if (e.Button == MouseButtons.Left)
            {
                mold = e.Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mcur = e.Location;
                Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            MyPaint a = new MyPaint(mold, mcur, mshape, mwidth, mcolor);
            ds.Add(a);
        }

        private Rectangle rec(Point p1, Point p2)
        {
            Rectangle a = new Rectangle();
            a.X = (p1.X > p2.X ? p2.X : p1.X);
            a.Y = (p1.Y > p2.Y ? p2.Y : p1.Y);
            a.Width = Math.Abs(p1.X - p2.X);
            a.Height = Math.Abs(p1.Y - p2.Y);
            return a;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (MyPaint a in ds)
            {
                draw(e.Graphics, a.old, a.cur, a.shape, a.width, a.color);
            }
            draw(e.Graphics, mold, mcur, mshape, mwidth, mcolor);
        
        }
        private void draw(Graphics e, Point mold, Point mcur, int mshape, float mwidth, Color mcolor)
        {
            Pen p = new Pen(mcolor, mwidth);

            switch (mshape)
            {
                case 0:

                    e.DrawLine(p, mold, mcur);
                    break;
                case 1:
                    e.DrawRectangle(p, rec(mold, mcur));
                 
                    break;
                case 2:
                    e.DrawEllipse(p, rec(mold, mcur));
                    break;
            }
        }



        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            mshape = 0;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            mshape = 1;
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            mshape = 2;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(dlg.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                ds = (ArrayList)bf.Deserialize(f);
                Invalidate();
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(dlg.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, ds);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsPaint frm = new MsPaint();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            mwidth = 1;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            mwidth = 3;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            mwidth = 5;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            mwidth = 7;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            mwidth = 10;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(dlg.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                ds = (ArrayList)bf.Deserialize(f);
                Invalidate();
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(dlg.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, ds);
            }
        }

        private void viemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = mcolor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mcolor = dlg.Color;
            }
        }

        private void MsPaint_Load(object sender, EventArgs e)
        {

        }
    }
}
