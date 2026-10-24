namespace RadioDJLocal.Models
{
    /// <summary>
    /// Representa uma subcategoria contendo identificador e nome.
    /// </summary>
    /// <![CDATA[14/10/2026]]>
    public class Subcategory
    {
        #region: membros da classe
        /// <summary>
        /// ID da tabela Subcategory.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Descrição do gênero.
        /// </summary>
        public string Name { get; set; }
        #endregion

        /// <summary>
        /// Cria umanova instância da classe Subcategory.
        /// </summary>
        public Subcategory()
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
