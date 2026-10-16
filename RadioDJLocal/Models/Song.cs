namespace RadioDJLocal.Models
{
    public class Song
    {
        #region: Membros da classe
        /// <summary>
        /// ID da tabela.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Título da música.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Nome do artista.
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// Nome do álbum.
        /// </summary>
        public string Album { get; set; }
        /// <summary>
        /// Ano de lançamento do álbum.
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// Caminho da arte do álbum.
        /// </summary>
        public string Album_art { get; set; }
        /// <summary>
        /// Tipo de faixa.
        /// </summary>
        public int Song_type { get; set; }
        /// <summary>
        /// Caminho do arquivo no disco.
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Define se o registro está ativo.
        /// </summary>
        public int Enabled { get; set; }
        /// <summary>
        /// Data em que a faixa tocou na última vez.
        /// </summary>
        public DateTime Date_played { get; set; }
        /// <summary>
        /// Data em que o artista tocou na última vez.
        /// </summary>
        public DateTime Artist_played { get; set; }        
        /// <summary>
        /// Parâmetros de duração arquivo.
        /// </summary>
        public string Cue_times { get; set; }
        /// <summary>
        /// Duração da música.
        /// </summary>
        public decimal Duration { get; set; }
        /// <summary>
        /// ID do gênero.
        /// </summary>
        public int Id_genre { get; set; }
        /// <summary>
        /// Descrição do gênero.
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// ID da subcategoria.
        /// </summary>
        public int Id_subcat { get; set; }
        /// <summary>
        /// Descrição da subcategoria.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// ID da categoria.
        /// </summary>
        public int Id_category { get; set; }
        /// <summary>
        /// Nome do compositor.
        /// </summary>
        public string Composer { get; set; }
        /// <summary>
        /// Direitos autorais.
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// Início da faixa.
        /// </summary>
        public double Sta { get { return this.Get_cue_value("sta"); } private set { } }
        /// <summary>
        /// Final da introdução da faixa.
        /// </summary>
        public double Xta { get { return this.Get_cue_value("xta"); } private set { } }
        /// <summary>
        /// Final da faixa.
        /// </summary>
        public double End { get { return this.Get_cue_value("end"); } private set { } }
        /// <summary>
        /// Fade In.
        /// </summary>
        public double Fin { get { return this.Get_cue_value("fin"); } private set { } }
        /// <summary>
        /// Fade Out.
        /// </summary>
        public double Fou { get { return this.Get_cue_value("fou"); } private set { } }
        /// <summary>
        /// Link de compra da música.
        /// </summary>
        public string Buy_link { get; set; }
        /// <summary>
        /// Número do disco.
        /// </summary>
        public int Disc_no { get; set; }
        /// <summary>
        /// Artista original da canção.
        /// </summary>
        public string Original_artist { get; set; }
        /// <summary>
        /// Nome da gravadora.
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Número da faixa.
        /// </summary>
        public int Track_no { get; set; }
        /// <summary>
        /// Quantidade de vezes em que a faixa tocou.
        /// </summary>
        public int Count_played { get; set; }
        /// <summary>
        /// Tocar por n vezes.
        /// </summary>
        public int Play_limit { get; set; }
        /// <summary>
        /// Acao do play_limit: 0 nada, 1 desativar, 2 deletar.
        /// </summary>
        public int Limit_action { get; set; }
        /// <summary>
        /// Data inicial do execução da faixa.
        /// </summary>
        public DateTime Start_date { get; set; }
        /// <summary>
        /// Data de encerramento de execução da faixa.
        /// </summary>
        public DateTime End_date { get; set; }
        /// <summary>
        /// Prioridade de execução.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Define se vai obedecer à precisão do Cue_times.
        /// </summary>
        public int Precise_Cue { get; set; }
        /// <summary>
        /// Fade In.
        /// </summary>
        public int Fade_type { get; set; }
        /// <summary>
        /// Fade Out.
        /// </summary>
        public int End_type { get; set; }
        /// <summary>
        /// Tocar como locução ou vinheta em cima de outra faixa.
        /// </summary>
        public int Overlay { get; set; }
        /// <summary>
        /// Número de registro da gravação.
        /// </summary>
        public string Isrc { get; set; }
        /// <summary>
        /// Tipo de batida da música.
        /// </summary>
        public double Bpm { get; set; }
        /// <summary>
        /// Comentários da música.
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// Lista de faixas de locução. Separados por "&".
        /// </summary>
        public string Sweepers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Tdate_played { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TArtist_played { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Retorna o objeto para valor padrão.
        /// </summary>
        public Song()
        {
            this.Id = -1;
            this.Path = string.Empty;
            this.Enabled = 1;
            this.Date_played = new DateTime(2002, 1, 1, 0, 0, 1);
            this.Artist_played = new DateTime(2002, 1, 1, 0, 0, 1);
            this.Count_played = 0;
            this.Play_limit = 0;
            this.Limit_action = 0;
            this.Start_date = new DateTime(2002, 1, 1, 0, 0, 1);
            this.End_date = new DateTime(2002, 1, 1, 0, 0, 1);
            this.Song_type = 0;
            this.Id_subcat = 0;
            this.Id_genre = 0;
            this.Weight = 50;
            this.Duration = 0;
            this.Cue_times = "&";
            this.Precise_Cue = 0;
            this.Fade_type = 0;
            this.End_type = 0;
            this.Overlay = 0;
            this.Artist = string.Empty;
            this.Original_artist = string.Empty;
            this.Title = string.Empty;
            this.Album = string.Empty;
            this.Composer = string.Empty;
            this.Year = "1900";
            this.Track_no = 0;
            this.Disc_no = 0;
            this.Publisher = string.Empty;
            this.Copyright = string.Empty;
            this.Isrc = string.Empty;
            this.Bpm = 0;
            this.Comments = string.Empty;
            this.Sweepers = string.Empty;
            this.Album_art = string.Empty;
            this.Buy_link = string.Empty;
            this.Tdate_played = new DateTime(2002, 1, 1, 0, 0, 1);
            this.TArtist_played = new DateTime(2002, 1, 1, 0, 0, 1);
            this.Genre = string.Empty;            
            this.Category = string.Empty;
            this.Id_category = 0;
        }
        #endregion

        /// <summary>
        /// Retorna a duração pelo parâmetro.
        /// </summary>
        /// <param name="cue_type"></param>
        /// <returns></returns>
        private double Get_cue_value(string cue_type)
        {
            string staField = string.Empty;
            string xtaField = string.Empty;
            string endField = string.Empty;
            string finField = string.Empty;
            string fouField = string.Empty;

            if (string.IsNullOrEmpty(this.Cue_times))
                return 0;

            string[] times = this.Cue_times.Split('&');

            if (times != null)
            {
                if (times.Length < 1)
                    return 0;

                if (times.Length == 5)
                {
                    staField = times[0].Replace("sta=", string.Empty);
                    xtaField = times[1].Replace("xta=", string.Empty);
                    endField = times[2].Replace("end=", string.Empty);
                    finField = times[3].Replace("fin=", string.Empty);
                    fouField = times[4].Replace("fou=", string.Empty);
                }
            }

            if (cue_type == "sta") return Convert.ToDouble(staField);
            if (cue_type == "xta") return Convert.ToDouble(xtaField);
            if (cue_type == "end") return Convert.ToDouble(endField);
            if (cue_type == "fin") return Convert.ToDouble(finField);
            if (cue_type == "fou") return Convert.ToDouble(fouField);
            return 0;
        }
    }
}
