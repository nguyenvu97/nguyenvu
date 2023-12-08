namespace API.Model;

public class OderDetailDto
{
    public int PriceTotal { get; set; }
    public int Quantity { get; set; }
    public List<int> ProductIds { get; set; }
}