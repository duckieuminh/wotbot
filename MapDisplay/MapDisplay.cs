﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace TankBot
{
    public partial class MapDisplay : Form
    {
        int WIDTH = 512;
        public MapDisplay()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private List<string> _filename_items = new List<string>();
        private List<string> _fireat_items = new List<string>();
        private List<string> _startingpoint_items = new List<string>();
        private void init_file()
        {
            _filename_items.Clear();

            foreach (String t in Directory.EnumerateFiles(TBConst.jpgPath))
            {
                if (t.EndsWith("jpg"))
                {
                    String x = t.Substring(TBConst.jpgPath.Length);
                    x = x.Remove(x.Length - 4);
                    _filename_items.Add(x);
                }
            }
            listBoxMaps.DataSource = null;
            listBoxMaps.DataSource = _filename_items;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            init_file();
        }
        void load_data(string map_name)
        {

            //string[,] names = new string[5, 4];
            String file = TBConst.trajectoryPath_obsolete + map_name + ".txt";

            if (map_name[map_name.Length - 1] >= '0' && map_name[map_name.Length - 1] <= '9')
                map_name = map_name.Substring(0, map_name.Length - 1);
            img = Image.FromFile(TBConst.trajectoryPath_obsolete + map_name + ".jpg");


            mapMining = new MapMining(map_name);
            this.vScrollBar1.Minimum = 0;
            this.vScrollBar1.Maximum = mapMining.maxCount();



            //private List<string> _keypoint_items = new List<string>();
            _fireat_items.Clear();
            foreach (Point p in mapMining.firepos)
            {
                _fireat_items.Add(p.x + " " + p.y);
            }
            listBoxFireAt.DataSource = null;
            listBoxFireAt.DataSource = _fireat_items;


            _startingpoint_items.Clear();
            foreach (Point p in mapMining.startPoints)
            {
                double x = (int)(p.x * 100) / 100.0;
                double y = (int)(p.y * 100) / 100.0;
                _startingpoint_items.Add(x + " " + y);
            }


            listBoxStaringPoint.DataSource = null;
            listBoxStaringPoint.DataSource = _startingpoint_items;


            //Debug.Print(text);
        }
        Image img = null;
        protected override void OnPaint(PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.DrawImage(img, new Rectangle(0, 0, WIDTH, WIDTH));

                if (checkShowEnemyBase.Checked)
                {
                    draw_point(mapMining.enemyBase(startPoint), 10.0f, Brushes.Blue, e.Graphics);
                    draw_point(startPoint, 10.0f, Brushes.White, e.Graphics);

                    //draw_point(mapMining.getFireAt(new Point(2, 8)), 10.0f, Brushes.White, e.Graphics);
                }
                else if (checkBoxLoadRoute.Checked)
                {
                    /*
                    for(int i=0; i<WIDTH; i++)
                        for(int j=0; j<WIDTH; j++)
                            if (mapMining.tagMap[i, j] ==true)
                                draw_point(new Point(MapMining.i2d(i), MapMining.i2d(j)), 1.0f, Brushes.Blue, e.Graphics);
                    return;
                     * */
                    Trajectory t=mapMining.genRouteToFireposTagMap(this.startPoint);
                    foreach (Point p in t)
                    {
                        draw_point(p, 2.0f, Brushes.Blue, e.Graphics);
                    }
                }
                else if (checkBoxFireAt.Checked)
                {
                    foreach (Point p in mapMining.firepos)
                    {
                        draw_point(p, 10.0f, Brushes.Blue, e.Graphics);
                    }
                }
                else
                {
                }

                /*
                Point ip = mapMining.getInterestPoint(new Point(8.96, 2.89), 150);
                if (ip != null)
                {
                    
                    draw_point(ip, 50.0f, Brushes.White, e.Graphics);
                }
                Point eb = mapMining.enemyBase(new Point(8.96, 2.89));
                if (eb != null)
                {
                    
                    draw_point(eb, 50.0f, Brushes.Green, e.Graphics);
                }
                 */
            }

        }

        private void draw_point(Point p, float width, Brush brush, Graphics graphics)
        {
            float nx = (float)((p.x - 1) * WIDTH / 10.0);
            float ny = (float)((p.y - 1) * WIDTH / 10.0);
            graphics.FillEllipse(brush, nx - width / 2, ny - width / 2, width, width);
        }



        MapMining mapMining;
        private void listBoxMaps_SelectedIndexChanged(object sender, EventArgs e)
        {

            String map_name = (string)listBoxMaps.SelectedValue;
            if (map_name != null)
            {
                load_data(map_name);
                Invalidate();
            }
        }

        private void listBoxFireAt_SelectedIndexChanged(object sender, EventArgs e)
        {

            Invalidate();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }




        private void MapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > 512)
                return;
            if (e.Y > 512)
                return;
            double x = e.X * 10.0 / WIDTH + 1;
            double y = e.Y * 10.0 / WIDTH + 1;
            x = (int)(x * 100) / 100.0;
            y = (int)(y * 100) / 100.0;
            _fireat_items[listBoxFireAt.SelectedIndex] = x + " " + y;

            listBoxFireAt.DataSource = null;
            listBoxFireAt.DataSource = _fireat_items;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String map_name = (string)listBoxMaps.SelectedValue;

            System.IO.StreamWriter file = new System.IO.StreamWriter(TBConst.fireposPath + map_name + ".txt");
            foreach (string t in _fireat_items)
            {
                file.WriteLine(t);
            }
            file.Close();
        }

        Point startPoint
        {
            get
            {
                return (Point)mapMining.startPoints[listBoxStaringPoint.SelectedIndex];
            }
        }
        private void listBoxStaringPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Invalidate();
        }


        private void checkBoxHTRoute_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void checkBoxFireAt_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }


        private void checkBoxLoadRoute_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }




    }
}

/*obsolete
              
                if (checkBoxReachable.Checked)
                {

                    int m=0;
                    for (int i = 0; i < MapMining.WIDTH; i++)
                    {
                        for (int j = 0; j < MapMining.WIDTH; j++)
                        {
                            m = Math.Max(m, mapMining.heatmap[i, j]);
                        }
                    }

                    for (int i = 0; i < MapMining.WIDTH; i++)
                    {
                        for (int j = 0; j < MapMining.WIDTH; j++)
                        {
                            if (mapMining.heatmap[i, j] > 0 )
                            {
                                int c=mapMining.heatmap[i,j] * 255 / 80;
                                if (c > 255)
                                    c = 255;
                                Brush b= new SolidBrush(Color.FromArgb(c,c,c));
                                draw_point(new Point(MapMining.i2d(i), MapMining.i2d(j)), 1.0f, b, e.Graphics);
                            }
                        }
                    }

                }

                  else if (checkBoxTag.Checked)
                {
                    Point startPoint = (Point)mapMining.startPoints[listBoxStaringPoint.SelectedIndex];
                    Trajectory t = mapMining.genRouteToFireposTagMap(startPoint);


                    draw_point(startPoint, 10.0f, Brushes.White, e.Graphics);
                    foreach (Point p in t)
                    {
                        draw_point(p, 3.0f, Brushes.Blue, e.Graphics);

                    }
                }
                else if (checkBoxHTRoute2.Checked)
                {
                    Trajectory t = mapMining.genRouteToFirepos_osbolete(startPoint);

                    draw_point(startPoint, 10.0f, Brushes.White, e.Graphics);
                    foreach (Point p in t)
                    {
                        draw_point(p, 3.0f, Brushes.Blue, e.Graphics);

                    }
                }

                else if (checkBoxDispSpecificTime.Checked)
                {
                    foreach (Trajectory t in mapMining.trajs)
                    {
                        if (t.reversed == false)
                            if (vScrollBar1.Value < t.Count)
                            {
                                Point p = (Point)t[vScrollBar1.Value];
                                if(mapMining.withinTagMap(p))
                                {
                                    draw_point(p, 5.0f, Brushes.Blue, e.Graphics);
                                }
                                else
                                {
                                       draw_point(p, 10.0f, Brushes.Red, e.Graphics);
                                }
                            }
                    }
                }

*/