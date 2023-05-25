using System;
using System.Drawing;
using System.Windows.Forms;
 
public abstract class App
{
    Bitmap bmp = null;
    Graphics g = null;
    PointF cursor = PointF.Empty;
    PointF? grabStart = null;
    PointF? grabDesloc = null;
    bool isDown = false;
    int frame = 0;
 
    public void Run()
    {
        ApplicationConfiguration.Initialize();
 
        var form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;
 
        PictureBox pb = new PictureBox();
        pb.Dock = DockStyle.Fill;
        form.Controls.Add(pb);

        System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
        tm.Interval = 10;
 
        pb.MouseDown += (o, e) =>
        {
            isDown = true;
        };
 
        pb.MouseUp += (o, e) =>
        {
            isDown = false;
            grabDesloc = null;
            grabStart = null;
        };
 
        pb.MouseMove += (o, e) =>
        {
            cursor = e.Location;
        };
 
        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            pb.Image = bmp;
 
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pb.Refresh();
 
            tm.Start();
        };
 
        form.KeyDown += (o, e) =>
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        };
 
        tm.Tick += delegate
        {
            g.Clear(Color.White);
 
            frame++;
            OnFrame(isDown, cursor);
 
            pb.Refresh();
        };
 
        Application.Run(form);
    }
 
    public void DrawImage(Bitmap img, RectangleF location)
    {
        if (img == null)
            throw new Exception("Imagem não pode ser nula");
 
        g.DrawImage(img, location);
    }
 
    public void DrawText(string text, Color color, RectangleF location)
    {
        var format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;
 
        var brush = new SolidBrush(color);
 
        g.DrawString(text, SystemFonts.MenuFont, brush, location, format);
    }
 
    public RectangleF DrawPiece(RectangleF location,
        int attack, int life, int experience, int tier,
        bool isGraspable,
        string name, Bitmap image = null)
    {
        float realWidth = .6f * location.Height;
        var realSize = new SizeF(realWidth, location.Height);
 
        var deslocX = grabDesloc?.X ?? 0;
        var deslocY = grabDesloc?.Y ?? 0;
        var position = new PointF(location.X + deslocX, location.Y + deslocY);
        RectangleF rect = new RectangleF(position, realSize);
 
        bool cursorIn = rect.Contains(cursor);
 
        if (!cursorIn && (deslocX != 0 || deslocY != 0))
            rect = new RectangleF(location.Location, realSize);
 
        var pen = new Pen(cursorIn ? Color.Cyan : Color.Black, 4f);
        var yellowPen = new Pen(Color.Yellow, 3f);
        var whitePen = new Pen(Color.Yellow, 2f);
 
        g.FillRectangle(Brushes.Brown, rect);
        g.DrawRectangle(pen, rect.X, rect.Y, realWidth, rect.Height);
 
        if (image == null)
            DrawText(name, Color.White, rect);
        else DrawImage(image, rect);
 
        var attackRect = new RectangleF(rect.X, rect.Y + .8f * rect.Height, realWidth / 3, realWidth / 3);
        g.FillEllipse(Brushes.Red, attackRect);
        g.DrawEllipse(yellowPen, attackRect);
        DrawText(attack.ToString(), Color.White, attackRect);
 
        var lifeRect = new RectangleF(rect.X + 2 * realWidth / 3, rect.Y + .8f * rect.Height, realWidth / 3, realWidth / 3);
        g.FillEllipse(Brushes.Blue, lifeRect);
        g.DrawEllipse(yellowPen, lifeRect);
        DrawText(life.ToString(), Color.White, lifeRect);
 
        RectangleF expRect = new RectangleF(rect.X + realWidth / 3 - 10, rect.Y + 20, 2 * realWidth / 3, realWidth / 6);
        int level = 1 + experience / 3;
        int crrExp = experience % 3;
        for (int i = 0; i < crrExp; i++)
            g.FillRectangle((Brushes.White), expRect.X + i * expRect.Width / 3, expRect.Y, expRect.Width / 3, expRect.Height);
        for (int i = 0; i < 3; i++)
            g.DrawRectangle(whitePen, expRect.X + i * expRect.Width / 3, expRect.Y, expRect.Width / 3, expRect.Height);
 
        var levelRect = new RectangleF(rect.X, rect.Y + 10, realWidth / 3, realWidth / 3);
        g.FillEllipse(Brushes.Green, levelRect);
        g.DrawEllipse(yellowPen, levelRect);
        DrawText(level.ToString(), Color.White, levelRect);
 
        var tierRect = new RectangleF(rect.X + realWidth / 3, rect.Y + .8f * rect.Height, realWidth / 3, realWidth / 3);
        DrawText(tier.ToString(), Color.Orange, tierRect);
 
        if (!cursorIn || !isDown)
            return rect;
         
        if (grabStart == null)
        {
            grabStart = cursor;
            return rect;
        }
 
        grabDesloc = new PointF(cursor.X - grabStart.Value.X, cursor.Y - grabStart.Value.Y);
 
        return rect;
    }
 
    public bool DrawButton(RectangleF location, string text)
    {
        if (location.Contains(cursor))
        {
            if (isDown)
            {
                g.FillRectangle(Brushes.Red, location);
                DrawText(text, Color.Black, location);
                return true;
            }
            else
            {
                g.FillRectangle(Brushes.BlueViolet, location);
                DrawText(text, Color.White, location);
                return false;
            }
        }
        else
        {
            g.FillRectangle(Brushes.Blue, location);
            DrawText(text, Color.White, location);
            return false;
        }
    }
 
    public abstract void OnFrame(bool IsDown, PointF cursor);
}