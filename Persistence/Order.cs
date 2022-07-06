namespace Persistence;
public class Order
{
    public int OrderId {get; set;}
    public DateTime Dates {get; set;}
    public string Payment_Method {get; set;}
    public int Customer_ID {get; set;}
    public int SalesmanID {get; set;}
    public int DishID {get; set;}
    public int Quantity {get; set;}

}
