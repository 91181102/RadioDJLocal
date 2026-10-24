using Dapper;
using RadioDJLocal.Models;

namespace RadioDJLocal.Data;

/// <summary>
/// Camada de dados da tabela Songs.
/// Guarda as músicas do RádioDJ.
/// </summary>
public class SongRepository
{
    private readonly RadioDjConnectionFactory _factory;

    public SongRepository(RadioDjConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Song>> ListarAsync()
    {
        await using var conexao = _factory.CreateConnection();
        await conexao.OpenAsync();

        const string sql = """
            SELECT
                S.id,
                S.start_date,
                S.end_date,
                S.artist,
                S.title,
                S.album,
                S.year,
                S.track_no,
                S.publisher,
                S.album_art,
                S.buy_link,
                S.song_type,
                T.parentId AS id_category,
                T.name AS category,
                S.id_subcat,
                S.id_genre,
                COALESCE(G.name, '') AS genre,
                S.original_artist,
                S.copyright,
                S.path,
                S.enabled
            FROM songs S
            LEFT JOIN genre G
                ON G.id = S.id_genre
            LEFT JOIN subcategory T
                ON T.id = S.id_subcat
            LEFT JOIN category C
                ON C.id = T.parentId
            ORDER BY S.artist
            LIMIT 100;
            """;

        return await conexao.QueryAsync<Song>(sql);
    }

    /// <summary>
    /// Retorna uma lista de músicas filtradas de acordo com os critérios especificados.
    /// </summary>
    /// <param name="filtro">Critérios de filtragem para a busca das músicas.</param>
    /// <returns>Uma coleção assíncrona de músicas que atendem aos filtros informados.</returns>
    /// <![CDATA[20/10/2026]]>
    public async Task<IEnumerable<Song>> ListarFiltradasAsync(
        SongFiltro filtro)
    {
        await using var conexao = _factory.CreateConnection();
        await conexao.OpenAsync();

        var sql = """
        SELECT
            S.id,
            S.start_date,
            S.end_date,
            S.artist,
            S.title,
            S.album,
            S.year,
            S.track_no,
            S.publisher,
            S.album_art,
            S.buy_link,
            S.song_type,
            T.parentId AS Id_category,
            T.name AS Category,
            S.id_subcat,
            S.id_genre,
            COALESCE(G.name, '') AS Genre,
            S.original_artist,
            S.copyright,
            S.path,
            S.enabled
        FROM songs S
        LEFT JOIN genre G
            ON G.id = S.id_genre
        LEFT JOIN subcategory T
            ON T.id = S.id_subcat
        WHERE 1 = 1
        """;

        var parametros = new DynamicParameters();

        if (!string.IsNullOrWhiteSpace(filtro.Artist))
        {
            sql += " AND S.artist LIKE @Artist";
            parametros.Add("Artist", $"%{filtro.Artist}%");
        }

        if (!string.IsNullOrWhiteSpace(filtro.Album))
        {
            sql += " AND S.album LIKE @Album";
            parametros.Add("Album", $"%{filtro.Album}%");
        }

        if (filtro.Id_category.HasValue)
        {
            sql += " AND T.parentId = @Id_category";
            parametros.Add("Id_category", filtro.Id_category.Value);
        }

        if (filtro.Id_subcat.HasValue)
        {
            sql += " AND S.id_subcat = @Id_subcat";
            parametros.Add("Id_subcat", filtro.Id_subcat.Value);
        }

        if (filtro.Id_genre.HasValue)
        {
            sql += " AND S.id_genre = @Id_genre";
            parametros.Add("Id_genre", filtro.Id_genre.Value);
        }

        if (filtro.Song_type.HasValue)
        {
            sql += " AND S.song_type = @Song_type";
            parametros.Add("Song_type", filtro.Song_type.Value);
        }

        if (filtro.StartDateDe.HasValue)
        {
            sql += " AND S.start_date >= @StartDateDe";
            parametros.Add("StartDateDe", filtro.StartDateDe.Value.Date);
        }

        if (filtro.StartDateAte.HasValue)
        {
            sql += " AND S.start_date < @StartDateAte";
            parametros.Add(
                "StartDateAte",
                filtro.StartDateAte.Value.Date.AddDays(1));
        }

        if (filtro.EndDateDe.HasValue)
        {
            sql += " AND S.end_date >= @EndDateDe";
            parametros.Add("EndDateDe", filtro.EndDateDe.Value.Date);
        }

        if (filtro.EndDateAte.HasValue)
        {
            sql += " AND S.end_date < @EndDateAte";
            parametros.Add(
                "EndDateAte",
                filtro.EndDateAte.Value.Date.AddDays(1));
        }

        if (filtro.ExecucaoDe.HasValue)
        {
            sql += " AND S.end_date >= @ExecucaoDe";
            parametros.Add("ExecucaoDe", filtro.ExecucaoDe.Value.Date);
        }

        if (filtro.ExecucaoAte.HasValue)
        {
            sql += " AND S.start_date < @ExecucaoAte";
            parametros.Add(
                "ExecucaoAte",
                filtro.ExecucaoAte.Value.Date.AddDays(1));
        }

        sql += " ORDER BY S.artist LIMIT 100;";

        return await conexao.QueryAsync<Song>(sql, parametros);
    }

    /// <summary>
    /// Retorna um registro pelo Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <![CDATA[24/10/2026]]>
    public async Task<Song?> BuscarPorIdAsync(int id)
    {
        await using var conexao = _factory.CreateConnection();
        await conexao.OpenAsync();

        const string sql = """
        SELECT *
        FROM songs
        WHERE id = @Id
        LIMIT 1;
        """;

        return await conexao.QuerySingleOrDefaultAsync<Song>(
            sql,
            new { Id = id });
    }

}
