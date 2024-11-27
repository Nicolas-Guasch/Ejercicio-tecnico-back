class ClientsList
{
    private List<Client> _clients = [
        new Client(0, "Fox", "Mulder", "Vine Street 2790"),
        new Client(1, "Dana", "Scully", "863rd Street 911"),
        new Client(2, "Samantha", "Mulder", "Vine Street 2790"),
        ];

    public Client[] GetClients()
    {
        return this._clients.ToArray();
    }

    public void AddClient(ClientData newClient)
    {
        this._clients.Add(new Client(newClient.firstName, newClient.lastName, newClient.address));
    }

    public Client? GetClient(int id)
    {
        return this._clients.Find((client) => client.getId() == id);
    }
    public void DeleteClient(int id)
    {
        this._clients.RemoveAll((client) => client.getId() == id);
    }

    public void EditClient(int id, string firstName, string lastName, string address)
    {
        Client? client = this._clients.Find((client) => client.getId() == id);
        if (client != null)
        {
            client.firstName = firstName;
            client.lastName = lastName;
            client.address = address;
        }
    }

}