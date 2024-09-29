using System;
using System.Collections.Generic;

namespace db_biblioteca.Models;

public partial class Libri
{
    public int LibroId { get; set; }

    public string Titolo { get; set; } = null!;

    public int AnnoPubblicazione { get; set; }

    public bool Disponibilita { get; set; }

    public virtual ICollection<Prestiti> Prestitis { get; set; } = new List<Prestiti>();
}
