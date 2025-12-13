// Source - https://stackoverflow.com/a
// Posted by summer
// Retrieved 2025-12-08, License - CC BY-SA 4.0

using static System.Net.Mime.MediaTypeNames;

public partial class NewPage1 : ContentPage
{
    public string Text { get; set; } = "";
    public NewPage1(string t)
    {
        Text = t;
        InitializeComponent();
    }

    // Fix for CS0103: Add a stub for InitializeComponent if not using XAML
    private void InitializeComponent()
    {
        // If you are not using XAML, this method can be left empty or used to initialize controls manually.
        // If you are using XAML, ensure that the .xaml file exists and is properly linked to this class.
    }
}
