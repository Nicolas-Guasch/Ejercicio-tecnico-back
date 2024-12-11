class ClientsList
{
    private List<Client> _clients =
    [
        new Client(0, "Fox", "Mulder", "2790 Vine Street"),
        new Client(1, "Dana", "Scully", "863rd Street 911"),
        new Client(2, "Samantha", "Mulder", "2790 Vine Street"),
        new Client(3, "Robert", "Mandel", "43 Bay Street"),
        new Client(4, "Chris", "Carter", "84 King Ave."),
        new Client(5, "Daniel", "Sackheim", "57 Country Club Dr."),
        new Client(6, "Harry", "Longstreet", "7505 Golf Lane"),
        new Client(7, "Glen", "Morgan", "7981 6th Rd."),
        new Client(8, "James", "Wong", "89 Gates Street"),
        new Client(9, "Alex", "Gansa", "813 Marvon Dr."),
        new Client(10, "Howard", "Gordon", "18 Buckingham Drive"),
        new Client(11, "Joe", "Napolitano", "880 W. Parker Street"),
        new Client(12, "Michael", "Katleman", "9421 NE. Leatherwood St."),
        new Client(13, "秀夫", "小島", "68 Gainsway Street"),
        new Client(14, "明", "森", "8345 East Philmont Street"),
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

    public ClientData AddClient(ClientEntry newClientData)
    {
        Client newClient = new Client(newClientData);
        this._clients.Add(newClient);
        return newClient.getData();
    }

    public ClientData? GetClient(int id)
    {
        return this._clients.Find((client) => client.getId() == id)?.getData();
    }

    public bool DeleteClient(int id)
    {
        int removals = this._clients.RemoveAll((client) => client.getId() == id);
        return removals > 0;
    }

    public ClientData? EditClient(int id, string? firstName, string? lastName, string? address)
    {
        Client? client = this._clients.Find((client) => client.getId() == id);
        if (client != null)
        {
            if (firstName != null)
                client.firstName = firstName;
            if (lastName != null)
                client.lastName = lastName;
            if (address != null)
                client.address = address;
        }
        return client?.getData();
    }
}
