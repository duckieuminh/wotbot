﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;
using System.Drawing;

namespace TankBot
{
    public class Trajectory : ArrayList
    {
        public bool reversed = false;
        public Trajectory()
        {
        }
        public void add_point(Point p)
        {
            this.Add(p);
        }

        new public Point this[int i]
        {
            get { return (Point)base[i]; }
        }
        public string comment;


    }
    public class MapMining
    {
        public static int d2i(double x)
        {
            return (int)((x - 1) * WIDTH / 10.0);
        }
        public static double i2d(int x)
        {
            return (double)(x * 10.0 / WIDTH + 1);
        }

        #region definition
        public const int WIDTH = 512;
        public const int expand = 3;

        public bool[,] visit = new bool[WIDTH, WIDTH];
        public bool[,] tagMap = new bool[WIDTH, WIDTH];
        public double[,] score = new double[WIDTH, WIDTH];
        public Tuple<int, int>[,] prev = new Tuple<int, int>[WIDTH, WIDTH];


        public List<Trajectory> trajs = new List<Trajectory>();
        private string map_name;
        public List<Point> allPoints = new List<Point>();
        public int[,] heatmap = new int[WIDTH, WIDTH];


        public List<Point> firepos = new List<Point>();
        public List<Point> startPoints = new List<Point>();
        public Color frequentColor;
        #endregion


        /// <summary>
        /// initialize with map name
        /// will load all the trajectory
        /// </summary>
        /// <param name="_map_name"> for example "01_karelia" </param>
        public MapMining(string _map_name)
        {
            Helper.LogInfo("MapMing " + _map_name);
            try
            {
                if (_map_name == "")
                    return;
                this.map_name = _map_name;
                loadTrajectory();
                loadFirepos();
                loadTag();
                foreach (Trajectory t in trajs)
                {
                    if (!t.reversed)
                    {
                        startPoints.Add(t[0]);
                    }
                }
                startPoints.Sort();
            }
            catch
            {
                Helper.LogException("map ming init error");
            }
        }
        private void loadFirepos()
        {
            try
            {

                using (StreamReader sr = new StreamReader(TBConst.fireposPath + this.map_name + ".txt"))
                {
                    while (true)
                    {
                        if (sr.EndOfStream)
                            break;
                        double x, y;
                        string s = sr.ReadLine();
                        string[] sp = s.Split(' ');
                        if (sp.Length == 2)
                        {
                            x = Convert.ToDouble(sp[0]);
                            y = Convert.ToDouble(sp[1]);
                            firepos.Add(new Point(x, y));
                        }
                    }
                }
            }
            catch
            {
                Helper.LogException("load fire pos failed");
            }
        }
        private void loadTag()
        {
            try
            {
                Bitmap b = new Bitmap(TBConst.tagPath + this.map_name + ".bmp");
                Dictionary<Color, int> d = new Dictionary<Color, int>();
                for (int i = 0; i < WIDTH; i++)
                    for (int j = 0; j < WIDTH; j++)
                    {
                        Color c = b.GetPixel(i, j);
                        if (!d.ContainsKey(c))
                            d[c] = 0;
                        d[c]++;
                    }
                frequentColor = Color.FromArgb(0, 0, 0);
                foreach (Color c in d.Keys)
                {
                    if (frequentColor == Color.FromArgb(0, 0, 0))
                        frequentColor = c;
                    if (d[frequentColor] < d[c])
                        frequentColor = c;
                }
                tagMap = new bool[WIDTH, WIDTH];
                for (int i = 0; i < WIDTH; i++)
                    for (int j = 0; j < WIDTH; j++)
                    {
                        if (b.GetPixel(i, j) == frequentColor)
                            tagMap[i, j] = true;
                        else
                            tagMap[i, j] = false;
                    }
                b.Dispose();
            }
            catch
            {
                Helper.LogException("load tag failed");
            }
        }
        private void loadTrajectory()
        {
            using (StreamReader sr = new StreamReader(TBConst.trajectoryPath + this.map_name + ".txt"))
            {
                int tot_point = 0;
                while (true)
                {
                    if (sr.EndOfStream)
                        break;
                    Trajectory traj = new Trajectory();
                    string comment = sr.ReadLine(); //replay_id 19 user_id 1686
                    string line = sr.ReadLine(); // 9.8 93.15 9.9 93.0 10.05 92.8 .......
                    string[] sp = line.Split(' ');
                    for (int i = 0; i < sp.Length; i += 2)
                    {
                        double x = Convert.ToDouble(sp[i]);
                        double y = Convert.ToDouble(sp[i + 1]);
                        x = (x + 105) / 21 + 1;
                        y = (y + 105) / 21 + 1;
                        traj.add_point(new Point(x, y));
                    }
                    traj.comment = comment;
                    traj = pruneTrajectory(traj, 0.05);
                    addToHeapmap(traj);
                    traj.reversed = false;
                    trajs.Add(traj);
                    Trajectory rev = new Trajectory();
                    foreach (Point p in traj)
                    {
                        rev.add_point(p);
                    }
                    rev.Reverse();
                    rev.reversed = true;
                    trajs.Add(rev);
                    tot_point += traj.Count * 2;
                }
                Trace.WriteLine("# if trajectory " + trajs.Count);
                Trace.WriteLine("total trajectory point " + tot_point);

            }

        }
        public void addToHeatmap(int x, int y)
        {
            for (int i = -expand; i <= expand; i++)
                for (int j = -expand; j <= expand; j++)
                {
                    int nx = x + i;
                    int ny = y + j;
                    if (!available(nx, ny))
                        continue;
                    this.heatmap[nx, ny] += expand * expand * 2 - Math.Abs(i) * Math.Abs(i) - Math.Abs(j) * Math.Abs(j);
                }
        }



        /// <summary>
        /// check whether the axis located inside 0--WIDTH range
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool available(int x, int y)
        {
            if (x < 0 || x >= WIDTH) return false;
            if (y < 0 || y >= WIDTH) return false;
            return true;
        }

        /// <summary>
        /// add line x0,y0 x1,y1 to the heat map
        /// using **** algorithm to calculat the nodes that should add
        /// expand a node to EXPAND*EXPAND area
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public void addToHeatmap(int x0, int y0, int x1, int y1)
        {
            if (!available(x0, y0)) return;


            if (!available(x1, y1)) return;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx, sy;
            if (x0 < x1) sx = 1; else sx = -1;
            if (y0 < y1) sy = 1; else sy = -1;
            double err = dx - dy;

            while (true)
            {
                addToHeatmap(x0, y0);
                //Console.WriteLine("plot " + x0 + " " + y0);

                //plot(x0,y0)
                if (x0 == x1 && y0 == y1)
                    break;
                double e2 = 2 * err;
                if (e2 > -dy)
                {
                    err = err - dy;
                    x0 = x0 + sx;
                }
                if (x0 == x1 && y0 == y1)
                {
                    addToHeatmap(x0, y0);
                    break;
                }
                if (e2 < dx)
                {
                    err = err + dx;
                    y0 = y0 + sy;
                }
            }

        }

        /// <summary>
        /// add the trajectory to the WIDTH * WIDTH heat map
        /// </summary>
        /// <param name="traj"></param>
        private void addToHeapmap(Trajectory traj)
        {
            for (int i = 1; i < traj.Count; i++)
            {
                Point p0 = traj[i - 1];
                Point p1 = traj[i];
                int x0 = d2i(p0.x);
                int y0 = d2i(p0.y);
                int x1 = d2i(p1.x);
                int y1 = d2i(p1.y);
                addToHeatmap(x0, y0, x1, y1);
            }
        }

        /// <summary>
        /// remove the nodes in trajectory in order to for sure 
        /// that the distance between any nodes are larger than threshold
        /// </summary>
        /// <param name="t"></param>
        /// <param name="threshhold"></param>
        /// <returns></returns>
        private Trajectory pruneTrajectory(Trajectory t, double threshhold = 0.1)
        {
            Trajectory xo = new Trajectory();
            foreach (Point p in t)
            {
                if (xo.Count == 0)
                {
                    xo.add_point(p);
                    continue;
                }
                double mindis = 1e10;
                foreach (Point x in xo)
                {
                    mindis = Math.Min(mindis, TBMath.distance(x, p));
                }
                if (mindis > threshhold)
                    xo.add_point(p);
            }
            return xo;
        }






        /// <summary>
        /// get maximum length of the traj in trajs
        /// </summary>
        /// <returns></returns>
        public int maxCount()
        {
            int rtn = 0;
            foreach (Trajectory t in trajs)
            {
                rtn = Math.Max(rtn, t.Count);
            }
            return rtn;
        }

        /// <summary>
        /// get the enemy base's location according to the start location and all other guy's starting location
        /// </summary>
        /// <param name="startPoint"></param>
        /// <returns></returns>
        public Point enemyBase(Point startPoint)
        {
            ArrayList points = new ArrayList();
            foreach (Trajectory t in trajs)
            {
                if (TBMath.distance(t[0], startPoint) > 4)
                {
                    points.Add(t[0]);
                }
            }
            if (points.Count == 0)
                return new Point(0, 0);
            double[] px = new double[points.Count];
            double[] py = new double[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                px[i] = ((Point)points[i]).x;
                py[i] = ((Point)points[i]).y;
            }
            Array.Sort(px);
            Array.Sort(py);
            return new Point(px[px.Length / 2], py[py.Length / 2]);
        }

        /// <summary>
        /// get the key point I would like to go 
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Point getFirepos(Point start)
        {
            double mindis = 1e10;
            Point rtn = new Point();
            for (int i = 0; i < firepos.Count; i++)
            {
                if (mindis > TBMath.distance(firepos[i], start))
                {
                    mindis = TBMath.distance(firepos[i], start);
                    rtn = firepos[i];
                }
            }
            return rtn;
        }



        public void dijkstra(int sx, int sy, int threshhold = 2, bool usingTagMap = false)
        {
            visit = new bool[WIDTH, WIDTH];
            score = new double[WIDTH, WIDTH];
            prev = new Tuple<int, int>[WIDTH, WIDTH];
            OrderedBag<Tuple<double, Tuple<int, int>>> q = new OrderedBag<Tuple<double, Tuple<int, int>>>();
            q.Add(new Tuple<double, Tuple<int, int>>(1, new Tuple<int, int>(sx, sy)));


            List<int> dx = new List<int>();
            List<int> dy = new List<int>();
            for (int i = -threshhold; i <= threshhold; i++)
                for (int j = -threshhold; j <= threshhold; j++)
                {
                    dx.Add(i);
                    dy.Add(j);
                }
            int loop = 0;
            while (q.Count > 0)
            {
                Tuple<double, Tuple<int, int>> min = q.GetFirst();

                int x = min.Item2.Item1;
                int y = min.Item2.Item2;
                if (visit[x, y])
                {
                    q.RemoveFirst();
                    continue;
                }
                loop++;
                //if (loop % 100 == 0)
                //Trace.WriteLine(loop + " " + q.Count);


                visit[x, y] = true;
                for (int i = 0; i < dx.Count; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];
                    if (nx < 0) continue;
                    if (nx >= WIDTH) continue;
                    if (ny < 0) continue;
                    if (ny >= WIDTH) continue;
                    if (visit[nx, ny])
                        continue;
                    int dis;
                    if (usingTagMap)
                    {
                        if (tagMap[nx, ny])
                            dis = 1;
                        else
                            dis = 1000;
                    }
                    else
                    {
                        dis = 1000 - heatmap[nx, ny];
                        if (heatmap[nx, ny] == 0)
                            dis = 3000;
                        if (dis < 0) dis = 0;
                    }
                    double newscore = score[x, y] + dis;
                    double oldscore = score[nx, ny];
                    if (oldscore == 0 || oldscore > newscore)
                    {
                        score[nx, ny] = newscore;
                        prev[nx, ny] = new Tuple<int, int>(x, y);
                        q.Add(new Tuple<double, Tuple<int, int>>(newscore, new Tuple<int, int>(nx, ny)));
                    }
                }
                q.RemoveFirst();
            }
        }
        private Trajectory backtrace(Point source, Point target)
        {
            int endx = d2i(target.x);
            int endy = d2i(target.y);

            int fx = 0, fy = 0;
            for (int step = 0; ; step++)
            {
                for (int i = -step; i <= step; i++)
                    for (int j = -step; j <= step; j++)
                    {
                        if (endx + i < 0) return new Trajectory();
                        if (endy + j < 0) return new Trajectory();

                        if (endx + i >= WIDTH) return new Trajectory();
                        if (endy + j >= WIDTH) return new Trajectory();

                        if (visit[endx + i, endy + j])
                        {
                            fx = endx + i;
                            fy = endy + j;
                            goto brk;
                        }
                    }
            }
        brk:
            Trajectory t = new Trajectory();
            while (true)
            {
                if (fx == d2i(source.x) && fy == d2i(source.y))
                    break;
                t.add_point(new Point(i2d(fx), i2d(fy)));
                Tuple<int, int> pre = prev[fx, fy];
                fx = pre.Item1;
                fy = pre.Item2;
            }
            Trajectory rt = new Trajectory();
            for (int i = t.Count - 1; i >= 0; i--)
            {
                rt.add_point(t[i]);
            }
            return rt;
        }
        public Trajectory genRouteTagMap(Point source, Point target)
        {

            dijkstra(d2i(source.x), d2i(source.y), 1, true);
            return backtrace(source, target);
        }
        public Trajectory genRouteToFireposTagMap(Point source)
        {
            return genRouteTagMap(source, getFirepos(source));
        }





        #region obsolete

        /// <summary>
        /// generate the route from start point to 
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public Trajectory genRouteToFirepos_osbolete(Point from)
        {
            Trajectory t = genRoute_osbolete(from, getFirepos(from));
            return t;
        }
        public Trajectory genRoute_obsolete(Point source, Point target, int threshhold)
        {

            dijkstra(d2i(source.x), d2i(source.y), threshhold);
            return backtrace(source, target);
        }

        public Trajectory genRoute_osbolete(Point source, Point target)
        {
            Trajectory t = genRoute_obsolete(source, target, 2);
            return t;
        }
        public Trajectory getHTRoute_deprecated(Point start)
        {
            Trajectory x = this.gen_route_obsolete(start, getFirepos(start)).Item1;
            Point enemy = this.enemyBase(start);
            //return x;
            Trajectory y = this.gen_route_obsolete(getFirepos(start), enemy).Item1;
            foreach (Point p in y)
            {
                x.add_point(p);
            }
            return x;
        }

        public Trajectory gen_random_route_obsolete(Point start, Point end)
        {

            ArrayList possible = new ArrayList();
            foreach (Trajectory t in trajs)
            {
                if (TBMath.distance(t[0], start) < 0.1)
                {
                    possible.Add(t);
                }
            }
            Random random = new Random();
            if (possible.Count > 0)
            {
                Trajectory pruned = (Trajectory)possible[random.Next(possible.Count)];
                return pruned;
            }
            else
            {
                return gen_route_obsolete(start, end).Item1;
            }
        }
        public Tuple<Trajectory, double> gen_route_obsolete(Point start, Point end)
        {
            Trajectory rtn = new Trajectory();
            double dist = 1e10;
            foreach (Trajectory traj in trajs)
            {
                Tuple<double, int, int> tmp = distance_obsolete(start, end, traj);
                if (dist > tmp.Item1)
                {
                    dist = tmp.Item1;
                    rtn.Clear();
                    for (int i = tmp.Item2; i <= tmp.Item3; i++)
                    {
                        rtn.add_point(traj[i]);
                    }
                }
            }
            return new Tuple<Trajectory, double>(rtn, dist);
        }

        public Point getInterestPoint_obsolete(Point start, int skip = 100, double threshhold = 0.5, double start_point_threshhold = 1)
        {
            ArrayList points = new ArrayList();
            foreach (Trajectory t in trajs)
            {
                if (t.Count > skip && TBMath.distance(t[0], start) < start_point_threshhold)
                {
                    points.Add(t[skip]);
                }
            }
            ArrayList score = new ArrayList();
            foreach (Point t in points)
            {
                int cnt = 0;
                foreach (Point bb in points)
                {
                    if (TBMath.distance(t, bb) < threshhold)
                    {
                        cnt++;
                    }
                }
                score.Add(cnt);
            }
            if (score.Count == 0)
                return null;
            int val = score.OfType<int>().Max();
            int idx = score.IndexOf(val);
            return (Point)points[idx];
        }
        private double trajLength_osbolete(Trajectory traj, int start, int end)
        {
            double rtn = 0;
            for (int i = start + 1; i < end; i++)
            {
                rtn += TBMath.distance(traj[i], traj[i - 1]);
            }
            return rtn;
        }
        public Tuple<double, int, int> distance_obsolete(Point start, Point end, Trajectory traj)
        {
            Tuple<double, int> a = distance_obsolete(start, traj);
            Tuple<double, int> b = distance_obsolete(end, traj, a.Item2);
            double len = trajLength_osbolete(traj, a.Item2, b.Item2);
            return new Tuple<double, int, int>(a.Item1 + b.Item1 + len * 0.1, a.Item2, b.Item2);

        }

        public Tuple<double, int> distance_obsolete(Point p, Trajectory traj, int start = 0)
        {

            double min_dist = 1e10;
            int idx = 0;
            for (int i = start; i < traj.Count; i++)
            {
                if (min_dist > TBMath.distance(p, traj[i]))
                {
                    min_dist = TBMath.distance(p, traj[i]);
                    idx = i;
                }
            }
            return new Tuple<double, int>(min_dist, idx);
        }
        #endregion



        /// <summary>
        /// return whether point p is Tagged as reachable in tagmap
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool withinTagMap(Point p)
        {
            int x = d2i(p.x);
            int y = d2i(p.y);
            return tagMap[x, y];
        }
    }
}
