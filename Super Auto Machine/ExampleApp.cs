using System.Drawing;
using System.Windows.Forms;
 
public class ExampleApp : App
{
    bool fundiu = false;
    bool clicked = false;
    RectangleF rect1 = RectangleF.Empty;
    RectangleF rect2 = RectangleF.Empty;
    public override void OnFrame(bool isDown, PointF cursor)
    {
        if (rect1.Contains(cursor) && rect2.Contains(cursor) && !isDown)
            fundiu = true;
 
        if (!fundiu)
        {
            rect1 = DrawPiece(new RectangleF(50, 50, 200, 200), 1, 3, 1, 1, true, "CNC");
            rect2 = DrawPiece(new RectangleF(300, 50, 200, 200), 2, 4, 2, 1, true, "CNC");
        }
        else
        {
            DrawPiece(new RectangleF(50, 50, 200, 200), 3, 5, 3, 1, true, "CNC");
        }
 
        if (!clicked)
        {
            clicked = DrawButton(new RectangleF(400, 400, 200, 100), "Iniciar");
            if (clicked)
                MessageBox.Show("Clicou");
        }
    }
}