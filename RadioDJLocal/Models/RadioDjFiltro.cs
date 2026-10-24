namespace RadioDJLocal.Models
{
    /// <summary>
    /// Representa critérios para filtrar músicas.
    /// </summary>
    /// <remarks>Use instâncias para compor consultas ou aplicar filtros em repositórios ou serviços. Converta
    /// para expressões ou predicados quando necessário.</remarks>
    /// <![CDATA[17/10/2026]]>
    public class RadioDjFiltro
    {
        #region: membros da classe
        /// <summary>
        /// Filtro de nome de artista.
        /// </summary>
        public FilterString Chk_artist { get; set; }
        /// <summary>
        /// Filtro de título da música.
        /// </summary>
        public FilterString Chk_title { get; set; }
        /// <summary>
        /// Filtro de nome do álbum.
        /// </summary>
        public FilterString Chk_album { get; set; }
        /// <summary>
        /// Filtro de categoria.
        /// </summary>
        public FilterInt Chk_category { get; set; }
        /// <summary>
        /// Filtro de subcategoria.
        /// </summary>
        public FilterInt Chk_subCategory { get; set; }
        /// <summary>
        /// Filtro de gênero.
        /// </summary>
        public FilterInt Chk_genre { get; set; }
        /// <summary>
        /// Filtro de tipo de faixa.
        /// </summary>
        public FilterInt Chk_song_type { get; set; }
        /// <summary>
        /// Filtro de data inicial de execução.
        /// </summary>
        public FilterDateTime Chk_start_de { get; set; }
        /// <summary>
        /// Filtro de data final de execução.
        /// </summary>
        public FilterDateTime Chk_end_de { get; set; }
        /// <summary>
        /// Filtro de periodo de execução.
        /// </summary>
        public FilterDateTime Chk_execucao { get; set; }
        /// <summary>
        /// Filtro pelo ID da tabela.
        /// </summary>
        public FilterInt Chk_id { get; set; }
        /// <summary>
        /// Filtro que representa o critério de ano para operações de busca e filtragem.
        /// </summary>
        public FilterString Chk_ano { get; set; }
        #endregion

        #region: opçoes
        /// <summary>
        /// Tipo de faixa.
        /// </summary>
        public List<TrackType> Song_types { get; set; }
        /// <summary>
        /// Gêneros.
        /// </summary>
        public List<Genre> Genres { get; set; }
        /// <summary>
        /// Categorias.
        /// </summary>
        public List<Category> Categories { get; set; }
        /// <summary>
        /// SubCategorias.
        /// </summary>
        public List<Subcategory> Subcategories { get; set; }
        #endregion

        /// <summary>
        /// Cria uma nova instância da classe de filtro.
        /// </summary>
        /// <![CDATA[07/07/2025]]>
        public RadioDjFiltro()
        {
            this.Chk_artist = new FilterString();
            this.Chk_title = new FilterString();
            this.Chk_album = new FilterString();
            this.Chk_category = new FilterInt();
            this.Chk_genre = new FilterInt();
            this.Chk_song_type = new FilterInt();
            this.Chk_subCategory = new FilterInt();
            this.Chk_start_de = new FilterDateTime();
            this.Chk_end_de = new FilterDateTime();
            this.Chk_execucao = new FilterDateTime();
            this.Chk_id = new FilterInt();
            this.Chk_ano = new FilterString();
            this.Song_types = new List<TrackType>();
            this.Genres = new List<Genre>();
            this.Categories = new List<Category>();
            this.Subcategories = new List<Subcategory>();
        }

        /// <summary>
        /// Retorna true, se algum filtro estiver marcado.
        /// </summary>
        /// <returns></returns>
        /// <![CDATA[07/07/2025]]>
        public bool Any()
        {
            if (this.Chk_album.Checked) return true;
            if (this.Chk_artist.Checked) return true;
            if (this.Chk_category.Checked) return true;
            if (this.Chk_genre.Checked) return true;
            if (this.Chk_song_type.Checked) return true;
            if (this.Chk_end_de.Checked) return true;
            if (this.Chk_start_de.Checked) return true;
            if (this.Chk_subCategory.Checked) return true;
            if (this.Chk_title.Checked) return true;
            if (this.Chk_execucao.Checked) return true;
            if (this.Chk_id.Checked) return true;
            if (!this.Chk_ano.Checked) return true;

            return false;
        }
    }
}
