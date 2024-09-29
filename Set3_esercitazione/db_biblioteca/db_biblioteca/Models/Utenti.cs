using System;
using System.Collections.Generic;

namespace db_biblioteca.Models;

public partial class Utenti
{
    public int UtenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Prestiti> Prestitis { get; set; } = new List<Prestiti>();
}
