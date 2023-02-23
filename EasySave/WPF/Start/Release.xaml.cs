using System.Windows.Controls;

namespace EasySave.WPF.Start;

public partial class Release : Page
{
    public Release()
    {
        InitializeComponent();

        ReleaseTitle.Text = LanguageTool.get("ReleaseTitle");
        V1Text.Text = LanguageTool.get("V1Text");
        V1_1Text.Text = LanguageTool.get("V1_1Text");
        V2Text.Text = LanguageTool.get("V2Text");
        V3Text.Text = LanguageTool.get("V3Text");
    }
}




