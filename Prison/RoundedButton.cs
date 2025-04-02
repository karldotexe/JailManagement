using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    public int BorderRadius { get; set; } = 20; // Adjust the radius size

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
        path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
        path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
        path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
        path.CloseFigure();

        this.Region = new Region(path);

        using (Pen pen = new Pen(this.FlatAppearance.BorderColor, 1))
        {
            pevent.Graphics.DrawPath(pen, path);
        }
    }
}
