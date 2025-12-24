
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LogoffUsersTool.UI.Controls
{
    public class TextProgressBar : ProgressBar
    {
        private string _customText = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomText
        {
            get => _customText;
            set
            {
                if (_customText != value)
                {
                    _customText = value;
                    this.Invalidate(); // Force the control to repaint
                }
            }
        }

        public TextProgressBar()
        {
            // Use double buffering to reduce flicker
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the background of the progress bar
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, ClientRectangle);

            // Only draw the fill if the value is greater than 0
            if (Value > 0)
            {
                // Calculate the rectangle for the progress fill
                Rectangle fillRectangle = new Rectangle(0, 0, (int)((double)Value / Maximum * ClientRectangle.Width), ClientRectangle.Height);
                e.Graphics.FillRectangle(Brushes.DodgerBlue, fillRectangle);
            }

            // Only draw text if CustomText is not empty.
            if (!string.IsNullOrEmpty(CustomText))
            {
                // Draw the text in the center of the control
                using (Font f = new Font(Font.FontFamily, 8, FontStyle.Bold))
                {
                    SizeF textSize = e.Graphics.MeasureString(CustomText, f);
                    Point location = new Point(
                        (int)((Width - textSize.Width) / 2),
                        (int)((Height - textSize.Height) / 2)
                    );
                    e.Graphics.DrawString(CustomText, f, Brushes.Black, location);
                }
            }
        }
    }
}
