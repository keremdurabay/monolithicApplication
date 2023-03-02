using System;
using System.Collections.Generic;

namespace Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string FullName
    {
        get { return FirstName + " " + LastName; }
        private set { }
    }
}
