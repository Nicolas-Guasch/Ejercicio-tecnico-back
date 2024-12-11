public class Client
{
    private int id;
    public string? firstName,
        lastName,
        address;

    public Client(int id, string firstName, string lastName, string address)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
    }

    public Client(ClientEntry data)
    {
        this.firstName = data.FirstName;
        this.lastName = data.LastName;
        this.address = data.Address;
        this.id = (int)(DateTime.Now.Ticks % (1L << 31));
    }

    public int getId()
    {
        return this.id;
    }

    public ClientData getData()
    {
        return new ClientData
        {
            Id = this.id,
            FirstName = this.firstName,
            LastName = this.lastName,
            Address = this.address,
        };
    }
}

//JSON serializable client requires no fields and default constructor.
public record ClientData
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
}

//New client with no Id
public record ClientEntry
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
}
