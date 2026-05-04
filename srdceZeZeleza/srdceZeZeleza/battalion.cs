using System.Collections.Generic;

namespace srdceZeZeleza;

public class Statistics
{
    public int Soft { get; private set; }
    public int Hard { get; private set; }
    public int Air { get; private set; }
    public int Hp { get; private set; }
    public int Org { get; private set; }
}

public class Requirements
{
    public int Manpower { get; private set; }
    public Dictionary<string, int> Equipment { get; private set; } = new Dictionary<string, int>();
}

public class Battalion
{
    public Statistics Stats { get; private set; }
    public Requirements Req { get; private set; }
}