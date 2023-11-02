namespace MVVM.Models;

public class DemoModel
{
    public string MyText { get; set; } = string.Empty;

    public string ReverseMyText()
    {
        var myTextReversed = "";
        for (int i = MyText.Length -1; i >= 0; i--)
        {
            myTextReversed += MyText[i];
        }

        return myTextReversed;
    }
}