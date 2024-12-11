class ClientsList
{
    private List<Client> _clients =
    [
        new Client
        {
            Id = 0,
            FirstName = "Fox",
            LastName = "Mulder",
            Address = "2790 Vine Street",
        },
        new Client
        {
            Id = 1,
            FirstName = "Dana",
            LastName = "Scully",
            Address = "863rd Street 911",
        },
        new Client
        {
            Id = 2,
            FirstName = "Samantha",
            LastName = "Mulder",
            Address = "2790 Vine Street",
        },
        new Client
        {
            Id = 3,
            FirstName = "Robert",
            LastName = "Mandel",
            Address = "43 Bay Street",
        },
        new Client
        {
            Id = 4,
            FirstName = "Chris",
            LastName = "Carter",
            Address = "84 King Ave.",
        },
        new Client
        {
            Id = 5,
            FirstName = "Daniel",
            LastName = "Sackheim",
            Address = "57 Country Club Dr.",
        },
        new Client
        {
            Id = 6,
            FirstName = "Harry",
            LastName = "Longstreet",
            Address = "7505 Golf Lane",
        },
        new Client
        {
            Id = 7,
            FirstName = "Glen",
            LastName = "Morgan",
            Address = "7981 6th Rd.",
        },
        new Client
        {
            Id = 8,
            FirstName = "James",
            LastName = "Wong",
            Address = "89 Gates Street",
        },
        new Client
        {
            Id = 9,
            FirstName = "Alex",
            LastName = "Gansa",
            Address = "813 Marvon Dr.",
        },
        new Client
        {
            Id = 10,
            FirstName = "Howard",
            LastName = "Gordon",
            Address = "18 Buckingham Drive",
        },
        new Client
        {
            Id = 11,
            FirstName = "Joe",
            LastName = "Napolitano",
            Address = "880 W. Parker Street",
        },
        new Client
        {
            Id = 12,
            FirstName = "Michael",
            LastName = "Katleman",
            Address = "9421 NE. Leatherwood St.",
        },
        new Client
        {
            Id = 13,
            FirstName = "秀夫",
            LastName = "小島",
            Address = "68 Gainsway Street",
        },
        new Client
        {
            Id = 14,
            FirstName = "明",
            LastName = "森",
            Address = "8345 East Philmont Street",
        },
    ];

    public Client[] GetClients()
    {
        return [.. _clients];
    }

    //Adds client with given data to the list and returns it.
    public Client AddClient(ClientEntry newClientData)
    {
        Client newClient = new Client(newClientData);
        this._clients.Add(newClient);
        return newClient;
    }

    //Returns client with given id or null if not found
    public Client? GetClient(int id)
    {
        return this._clients.Find((client) => client.Id == id);
    }

    //Removes client from list and returns true if id is found. Otherwise returns false
    public bool DeleteClient(int id)
    {
        int removals = this._clients.RemoveAll((client) => client.Id == id);
        return removals > 0;
    }

    //Updates state of client with given id in the list and returns updated version. If the id is not found no change is made
    public Client? EditClient(int id, string? firstName, string? lastName, string? address)
    {
        Client? client = this._clients.Find((client) => client.Id == id);
        if (client != null)
        {
            if (firstName != null)
                client.FirstName = firstName;
            if (lastName != null)
                client.LastName = lastName;
            if (address != null)
                client.Address = address;
        }
        return client;
    }
}
