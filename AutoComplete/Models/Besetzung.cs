using System;
using System.Collections.Generic;

namespace AutoComplete.Models;

public partial class Besetzung
{
    public int Filmid { get; set; }

    public int Persid { get; set; }

    public int? Ord { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual Person Pers { get; set; } = null!;
}
