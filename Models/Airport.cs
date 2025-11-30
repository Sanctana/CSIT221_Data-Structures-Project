namespace Models;

public class Airport
{
    public required string Code { get; set; }      
    public required string Name { get; set; }      
    public required string Country { get; set; }   
    public required string City { get; set; }     

    public override string ToString()
    {
        return $"{City} ({Code}) - {Name}";
    }
}
