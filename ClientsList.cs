class ClientsList
{
    private List<Client> _clients = [
        new Client(0, "Fox", "Mulder", "Vine Street 2790"),
        new Client(1, "Dana", "Scully", "863rd Street 911"),
        new Client(2, "Samantha", "Mulder", "Vine Street 2790"),
        ];

    public ClientData[] GetClients()
    {
        ClientData[] clients = new ClientData[this._clients.Count];
        for (int i = 0; i < this._clients.Count; i++)
        {
            clients[i] = _clients[i].getData();
        }
        return clients;
    }

    public void AddClient(ClientEntry newClient)
    {
        this._clients.Add(new Client(newClient));
    }

    public ClientData? GetClient(int id)
    {
        return this._clients.Find((client) => client.getId() == id)?.getData();
    }
    public void DeleteClient(int id)
    {
        this._clients.RemoveAll((client) => client.getId() == id);
    }

    public void EditClient(int id, string? firstName, string? lastName, string? address)
    {
        Client? client = this._clients.Find((client) => client.getId() == id);
        if (client != null)
        {
            if (firstName != null) client.firstName = firstName;
            if (lastName != null) client.lastName = lastName;
            if (address != null) client.address = address;
        }
    }

}