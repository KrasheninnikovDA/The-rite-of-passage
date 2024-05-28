

public static class GlobalScore
{
    public static int Score { private set; get; }

    public static void AddScpre()
    {
        Score++;
    }

    public static void ResetPoints()
    {
        Score = 0;
    }

}
