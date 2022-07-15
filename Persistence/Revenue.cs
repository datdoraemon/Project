namespace Persistence;

public class Revenue : Order
{
    public int Count {get; set;}
    public double Sum_Revenue_Day {get; set;}
    public int Sold {get; set;}
    public double Sum_Revenue_Month {get; set;}
}