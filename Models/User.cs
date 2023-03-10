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
        
        // string leri birlestirirken toplama islemi kullanilmasi eger foreach dongusu icindeyse ciddi performans kaybina sebep olur
        //bu sebep ile String interpolation yontemi ile birlestirmemiz gerekiyor. String.Concat ya da string.join de kullanilabilir 
        //bu 3 unden biri olmasinda fayda var
        //https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings?redirectedfrom=MSDN
        
        get { return FirstName + " " + LastName; }
        private set { }
    }
}
