public class TESTABS
{
    int count;
    string ToShow;

    public string ToShowInt()
    {
        ToShow = $"Click = {count}";
        return ToShow;
    }

    public void Click()
    {
        count++;
        ToShowInt();
    }
}
