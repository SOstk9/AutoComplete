using System;
using System.Collections.Generic;

namespace AutoComplete.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Besetzung> Besetzungs { get; set; } = new List<Besetzung>();

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
