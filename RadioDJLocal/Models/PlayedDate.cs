namespace RadioDJLocal.Models;

/// <summary>
/// Rotação da faixa na tabela History.
/// </summary>
/// <![CDATA[31/10/2026]]>
public class PlayedDate
{
    #region: membros da classe
    /// <summary>
    /// Identificador único da entidade.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Data em que tocou a música.
    /// </summary>
    public DateTime? Date_played { get; set; }
    /// <summary>
    /// Número da faixa no álbum do artista.
    /// </summary>
    public int Track_no { get; set; }
    /// <summary>
    /// Total de ouvintes.
    /// </summary>
    public int? Listeners { get; set; }
    #endregion

    #region: construtor
    /// <summary>
    /// Cria uma nova instância da classe PlayedDate.
    /// </summary>
    public PlayedDate()
    {
        this.Id = 0;
        this.Date_played = new DateTime(2002,1,1);
        this.Track_no = 0;
        this.Listeners = 0;
    }
    #endregion
}