namespace RadioDJLocal.Models;

/// <summary>
/// Faixa de locução.
/// </summary>
/// <![CDATA[31/10/2026]]>
public class Sweeper
{
    #region: membros da classe
    /// <summary>
    /// Id da tabela Songs.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Título da faixa.
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// Nome do artista.
    /// </summary>
    public string? Artist { get; set; }
    /// <summary>
    /// Duração da faixa.
    /// </summary>
    public double Duration { get; set; }
    /// <summary>
    /// Nome do álbum.
    /// </summary>
    public string? Album { get; set; }
    #endregion

    #region: construtor
    /// <summary>
    /// Cria uma nova instância da classe Sweeper.
    /// </summary>
    public Sweeper()
    {
        this.Id = 0;
        this.Title = string.Empty;
        this.Artist = string.Empty;
        this.Duration = 0;
        this.Album = string.Empty;
    }
    #endregion
}