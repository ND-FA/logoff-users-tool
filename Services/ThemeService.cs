using System.Drawing;
using System.Windows.Forms;

namespace LogoffUsersTool.Services;

public static class ThemeService
{
    public static Color BackColor { get; private set; }
    public static Color ForeColor { get; private set; }
    public static Color TextBoxBackColor { get; private set; }
    public static Color ButtonBackColor { get; private set; }
    public static Color InfoColor { get; private set; } // Color for standard log messages
    private static bool IsDarkTheme { get; set; }

    public static void ApplyTheme(Form form, string themeName)
    {
        IsDarkTheme = themeName == "Dark";

        if (IsDarkTheme)
        {
            BackColor = Color.FromArgb(45, 45, 48);
            ForeColor = Color.White;
            TextBoxBackColor = Color.FromArgb(60, 60, 60);
            ButtonBackColor = Color.FromArgb(70, 70, 70);
            InfoColor = Color.White;
        }
        else // Light Theme (Default)
        {
            BackColor = SystemColors.Control;
            ForeColor = SystemColors.ControlText;
            TextBoxBackColor = SystemColors.Window;
            ButtonBackColor = SystemColors.Control;
            InfoColor = Color.Black;
        }

        form.BackColor = BackColor;
        form.ForeColor = ForeColor;

        foreach (Control control in form.Controls)
        {
            ApplyThemeToControl(control);
        }
    }

    private static void ApplyThemeToControl(Control control)
    {
        control.BackColor = BackColor;
        control.ForeColor = ForeColor;

        if (control is GroupBox groupBox)
        {
            groupBox.ForeColor = ForeColor;
        }
        else if (control is TextBox || control is RichTextBox || control is NumericUpDown || control is CheckedListBox || control is ComboBox)
        {
            control.BackColor = TextBoxBackColor;
            control.ForeColor = ForeColor;
        }
        else if (control is Button button)
        {
            // Force flat style to ensure custom colors are applied.
            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false; // This is crucial.
            button.BackColor = ButtonBackColor;
            button.ForeColor = ForeColor;
            
            // Add a border in dark mode to make buttons visible.
            if (IsDarkTheme)
            {
                button.FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
                button.FlatAppearance.BorderSize = 1;
            }
            else
            {
                button.FlatAppearance.BorderSize = 0; // Or use a default border
            }
        }
        else if (control is TreeView treeView)
        {
            treeView.BackColor = TextBoxBackColor;
            treeView.ForeColor = ForeColor;
        }

        // Recursive call to apply the theme to all sub-controls.
        foreach (Control subControl in control.Controls)
        {
            ApplyThemeToControl(subControl);
        }
    }
}
