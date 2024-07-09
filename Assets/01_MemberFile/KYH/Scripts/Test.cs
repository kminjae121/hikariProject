
public static class Test 
{
    public static string Kimyeonho(this int i)
    {
        if (i > 10)
        {
            if (string.IsNullOrEmpty(""))
            {
                string str = string.Format("{0}{1}", "abc", 2);
            }
            return "이런 10이 넘었네요";
            //Act(3, 4, 54, 5, 5, 45, 4,73, 33, 3, 3, 3, 3, 3, 5);
        }
        else return "10보다 작네요";
    }

    public static void Act(params int[] abc)
    {
        
    }
}

public class Program
{
    int i = 3;

    void Act()
    {
        string i2 = i.Kimyeonho();
    }
}
