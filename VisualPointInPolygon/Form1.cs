namespace VisualPointInPolygon
{
    public partial class Form1 : Form
    {
        Polygon polygon;
        int op = 0;
        public Form1()
        {
            InitializeComponent();

            polygon = new Polygon();
            polygon.PolygonPoints();
            pointToCheck = new Point(0, 0);
            cbbAlgorithms.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw the polygon
            g.DrawPolygon(Pens.Aquamarine, polygon.PolygonPoints());

            // Draw the point
            Brush pointBrush = polygon.IsInside() ? Brushes.Green : Brushes.Red;
            g.FillEllipse(pointBrush, (float)pointToCheck.X - 3, (float)pointToCheck.Y - 3, 6, 6);

            // Display text
            string message = polygon.IsInside() ? "The point is inside the polygon." : "The point is outside the polygon.";            
            lblStatus.Text = message;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            pointToCheck = new Point(e.X, e.Y);            
            polygon.IsPointInside(pointToCheck, op);
            pnlCanvas.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            op = cbbAlgorithms.SelectedIndex;
            pnlCanvas.Invalidate();
        }

        private void btnRegeneratePolygon_Click(object sender, EventArgs e)
        {
            polygon.GeneratePolygon();
            polygon.IsPointInside(pointToCheck, op);
            pnlCanvas.Invalidate();
        }
    }
}
