using System.Collections.Generic;

namespace srdceZeZeleza;

public class Statistics
{
    public int Soft { get; set; }
    public int Hard { get; set; }
    public int Air { get; set; }
    public int Hp { get; set; }
    public int Org { get; set; }
}

public class Requirements
{
    public int Manpower { get; set; }
    public Dictionary<string, int> Equipment { get; set; } = new Dictionary<string, int>();
}

public class Battalion
{
    public Statistics Stats { get; set; }
    public Requirements Req { get; set; }
}