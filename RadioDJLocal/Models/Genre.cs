namespace RadioDJLocal.Models
{
    /// <summary>
    /// Gêneros de música.
    /// </summary>
    /// <![CDATA[14/10/2026]]>
    public class Genre
    {
        #region: membros da classe
        /// <summary>
        /// ID da tabela GENRE.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Descrição do gênero.
        /// </summary>
        public string Name { get; set; }
        #endregion

        /// <summary>
        /// Cria umanova instância da classe Genre.
        /// </summary>
        public Genre()
        {
            this.Id = 0;
            this.Name = string.Empty;
        }

        /// <summary>
        /// Retorna o ID.
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return this.Id;
        }
    }
}
