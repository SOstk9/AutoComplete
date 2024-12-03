using System;
using System.Collections.Generic;

namespace AutoComplete.Models;

public partial class Film
{
    public int Id { get; set; }

    public string? Titel { get; set; }

    public decimal? Jahr { get; set; }

    public double? Punkte { get; set; }

    public int? Stimmen { get; set; }

    public int? Regie { get; set; }

    public virtual ICollection<Besetzung> Besetzungs { get; set; } = new List<Besetzung>();

    public virtual Person? RegieNavigation { get; set; }
}
