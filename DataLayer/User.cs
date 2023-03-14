using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string FullName
    {
        get { return string.Concat(FirstName, " ", LastName); }
        private set { }
    }
}
