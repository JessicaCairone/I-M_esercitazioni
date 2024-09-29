using System;
using System.Collections.Generic;

namespace db_biblioteca.Models;

public partial class Prestiti
{
    public int PrestitoId { get; set; }

    public DateTime DataPrestito { get; set; }

    public DateTime DataRitorno { get; set; }

    public int UtenteRif { get; set; }

    public int LibroRif { get; set; }

    public virtual Libri LibroRifNavigation { get; set; } = null!;

    public virtual Utenti UtenteRifNavigation { get; set; } = null!;
}
