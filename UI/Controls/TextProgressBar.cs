
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LogoffUsersTool.UI.Controls
{
    public class TextProgressBar : ProgressBar
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomText { get; set; } = "";

        public TextProgressBar()
        {
            // Use double buffering to reduce flicker
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the background of the progress bar
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, ClientRectangle);

            // Only draw the fill and text if the value is greater than 0
            if (Value > 0)
            {
                // Calculate the rectangle for the progress fill
                Rectangle fillRectangle = new Rectangle(1, 1, (int)((double)Value / Maximum * (ClientRectangle.Width - 2)), ClientRectangle.Height - 2);
                e.Graphics.FillRectangle(Brushes.DodgerBlue, fillRectangle);

                // Define the text to display
                string text = string.IsNullOrEmpty(CustomText) ? $"{Value}%" : CustomText;

                // Draw the text in the center of the control
                using (Font f = new Font(Font.FontFamily, 8, FontStyle.Bold))
                {
                    SizeF textSize = e.Graphics.MeasureString(text, f);
                    Point location = new Point(
                        (int)((Width - textSize.Width) / 2),
                        (int)((Height - textSize.Height) / 2)
                    );
                    e.Graphics.DrawString(text, f, Brushes.Black, location);
                }
            }
        }
    }
}
