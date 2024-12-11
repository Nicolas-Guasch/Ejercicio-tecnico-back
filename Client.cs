/*
 Client con propiedades públicas en vez de campos es serializable por el JsonSerializer
 La clase adaptadora ClientData es redundante con estos cambios
*/
public class Client
{
    public int Id { get; init; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }

    public Client()
    {
        this.Id = 0;
        this.FirstName = null;
        this.LastName = null;
        this.Address = null;
    }

    public Client(ClientEntry data)
    {
        this.FirstName = data.FirstName;
        this.LastName = data.LastName;
        this.Address = data.Address;
        this.Id = (int)(DateTime.Now.Ticks % (1L << 31));
    }
}

//New client with no Id given yet
public record ClientEntry
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
}
