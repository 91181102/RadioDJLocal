namespace RadioDJLocal.Models
{
    /// <summary>
    /// Categoria de música
    /// </summary>   
    /// <![CDATA[14/10/2026]]>
    public class Category
    {
        #region: membros da classe
        /// <summary>
        /// ID da tabela Category.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Descrição do gênero.
        /// </summary>
        public string Name { get; set; }
        #endregion

        /// <summary>
        /// Cria umanova instância da classe Category.
        /// </summary>
        public Category()
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
