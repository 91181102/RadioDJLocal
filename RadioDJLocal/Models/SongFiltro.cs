
namespace RadioDJLocal.Models;

public class SongFiltro
{
    public string? Artist { get; set; }
    public string? Album { get; set; }

    public int? Id_category { get; set; }
    public int? Id_subcat { get; set; }
    public int? Id_genre { get; set; }
    public int? Song_type { get; set; }

    public DateTime? StartDateDe { get; set; }
    public DateTime? StartDateAte { get; set; }

    public DateTime? EndDateDe { get; set; }
    public DateTime? EndDateAte { get; set; }

    public DateTime? ExecucaoDe { get; set; }
    public DateTime? ExecucaoAte { get; set; }
}
