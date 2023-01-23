namespace Lines
{
    public partial class Form1 : Form
    {
        Point a, b, c, d;
        PointF a2, b2, c2, d2;

        Bitmap bmp;
        Graphics g;
        Pen pen;
        int centerx, centery, angle, segments;
        double radians;


        public Form1()
        {
            InitializeComponent();
            centerx = pictureBox1.Width / 2;
            centery= pictureBox1.Height / 2;

            a = new Point(0,0);
            b = new Point(0,100);
            c = new Point(100,100);
            d = new Point(100, 0);


            bmp =new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Color.White, 1);
            g= Graphics.FromImage(bmp);
            pictureBox1.Image= bmp;
        }

        public void DrawCircle(Graphics g, Pen pen,
                                  float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public void Render(double angle)
        {

            a2 = new PointF(centerx + a.X, centery - a.Y);
            a2.X = centerx+(float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            a2.Y = centery-(float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));

            b2 = new PointF(centerx + b.X, centery - b.Y);
            b2.X = centerx+(float)((b.X * Math.Cos(angle)) - (b.Y * Math.Sin(angle)));
            b2.Y = centery-(float)((b.X * Math.Sin(angle)) + (b.Y * Math.Cos(angle)));
            

            c2=new PointF(centerx+c.X, centery-c.Y);
            c2.X = centerx+(float)((c.X * Math.Cos(angle)) - (c.Y * Math.Sin(angle)));
            c2.Y = centery - (float)((c.X * Math.Sin(angle)) + (c.Y * Math.Cos(angle)));


            d2 = new PointF(centerx+d.X, centery-d.Y);
            d2.X = centerx+ (float)((d.X * Math.Cos(angle)) - (d.Y * Math.Sin(angle)));
            d2.Y = centery - (float)((d.X * Math.Sin(angle)) + (d.Y * Math.Cos(angle)));

            g.DrawLine(Pens.Gray, a2, b2);
            g.DrawLine(Pens.Gray, b2, c2);
            g.DrawLine(Pens.Gray, c2, d2);
            g.DrawLine(Pens.Gray, d2, a2);

            pictureBox1.Refresh();
        }

        double DegreesToRadians(int angle)
        {
            return angle * Math.PI / 180;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            angle =int.Parse(textBox1.Text);
            radians=DegreesToRadians(angle);
            Render(radians);
            //Render2(a, b, radians);
            DrawCircle(g, pen, centerx, centery, 141);
            DrawCircle(g, pen, centerx, centery, 100);
            //g.DrawLine(Pens.Gray, x0, x1);
            //g.DrawLine(Pens.Gray, y0, y1);
            pictureBox1.Refresh();

        }

        private void Pattern(int segments)
        {
            angle = 360 / segments;
            for (int i = 0; i < 360; i = i + angle) 
            {
                radians = DegreesToRadians(i);
                Render(radians);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DrawCircle(g, pen, centerx, centery, 141);
            DrawCircle(g, pen, centerx, centery, 100);
            segments = int.Parse(textBox2.Text);
            Pattern(segments);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            pictureBox1.Refresh();
        }
    }
}