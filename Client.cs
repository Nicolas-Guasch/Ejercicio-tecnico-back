class Client
{
    private int id;
    public string firstName, lastName, address ;

    public Client(int id, string firstName, string lastName, string address) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
    }

    public Client(string firstName, string lastName, string address) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.id = (int)DateTime.Now.Ticks;
    }

    public int getId() {
        return this.id;
    }
}
