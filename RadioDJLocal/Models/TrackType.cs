namespace RadioDJLocal.Models
{
    public class TrackType
    {
        #region: membros da classe
        /// <summary>
        /// Id do tipo de faixa.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do tipo de faixa.
        /// </summary>
        public string Name { get; set; }
        #endregion

        /// <summary>
        /// Cria uma nova instância da classe TrackType..
        /// </summary>
        public TrackType()
        {
            this.Id = 0;
            this.Name = string.Empty;
        }

        /// <summary>
        /// Cria uma nova instância da classe TrackType.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public TrackType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Retorna o ID.
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return this.Id;
        }

        /// <summary>
        /// Retorna uma lista.
        /// </summary>
        /// <returns></returns>
        /// <![CDATA[07/07/2025]]>
        public static List<TrackType> GetLista()
        {
            var lista = new List<TrackType>();
            lista.Add(new TrackType(0, "Música"));
            lista.Add(new TrackType(1, "Vinheta"));
            lista.Add(new TrackType(2, "Swepper"));
            lista.Add(new TrackType(3, "Locução"));
            lista.Add(new TrackType(4, "Comercial"));
            lista.Add(new TrackType(5, "Transmissão Via Internet"));
            lista.Add(new TrackType(6, "Outro"));
            lista.Add(new TrackType(7, "Arquivo de Duração Variável"));
            lista.Add(new TrackType(8, "Podcast"));
            lista.Add(new TrackType(9, "Solicitado"));
            lista.Add(new TrackType(10, "Notícias"));
            lista.Add(new TrackType(11, "Evento Playlist"));
            lista.Add(new TrackType(12, "Arquivo Por Data"));
            lista.Add(new TrackType(13, "Mais Recente da Pasta"));
            lista.Add(new TrackType(14, "Teaser"));

            lista = lista.OrderBy(o => o.Name).ToList();
            return lista;
        }
    }
}
