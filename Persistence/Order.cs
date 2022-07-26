namespace Persistence;
public class Order : Salesman
{
    public int OrderId {get; set;}
    public DateTime Dates {get; set;}
    public string Payment_Method {get; set;}
    public string Customer_Name {get; set;}
    public string Salesman_Name {get; set;}
    public string Dish_Name {get; set;}
    public int Quantity {get; set;}
    public double Total {get; set;}
    public string Status {get; set;}
    

}
