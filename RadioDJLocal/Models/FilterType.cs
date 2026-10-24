namespace RadioDJLocal.Models
{
    public class FilterType
    {
    }

    /// <summary>
    /// Filtro de inteiro.
    /// </summary>
    public class FilterInt
    {
        /// <summary>
        /// Define se o filtro está ativado.
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// Valor do filtro.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Cria uma nova instância do filtro de inteiro.
        /// </summary>
        public FilterInt()
        {
            this.Checked = false;
            this.Value = 0;
        }

        /// <summary>
        /// Define o valor do filtro.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(string value)
        {
            bool valid = int.TryParse(value, out _);
            if (valid)
                this.Value = Convert.ToInt32(value);
            else
            {
                this.Value = 0;
                this.Checked = false;
            }
        }

        /// <summary>
        /// Define o valor do filtro.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(int value)
        {
            this.Value = value;
        }
    }

    /// <summary>
    /// Filtro de string.
    /// </summary>
    public class FilterString
    {
        /// <summary>
        /// Define se o filtro está ativado.
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// Valor do filtro.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Cria uma nova instância do filtro de string.
        /// </summary>
        public FilterString()
        {
            this.Checked = false;
            this.Value = string.Empty;
        }

        /// <summary>
        /// Define o valor do filtro.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(string value)
        {
            this.Value = value.Trim();
        }

        /// <summary>
        /// Retorna o valor do filtro no formato %valor%.
        /// </summary>
        /// <returns></returns>
        public string GetLikeValue()
        {
            return "%" + this.Value.Trim() + "%";
        }
    }

    /// <summary>
    /// Filtro de booleano.
    /// </summary>
    public class FilterBoolean
    {
        /// <summary>
        /// Define se o filtro está ativado.
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// Valor do filtro.
        /// </summary>
        public bool Value { get; set; }

        /// <summary>
        /// Cria uma nova instância do filtro de booleano.
        /// </summary>
        public FilterBoolean()
        {
            this.Checked = false;
            this.Value = false;
        }

        /// <summary>
        /// Define o valor do filtro.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(bool value)
        {
            this.Value = value;
        }
    }

    /// <summary>
    /// Filtro de data.
    /// </summary>
    public class FilterDateTime
    {
        /// <summary>
        /// Define se o filtro está ativado.
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// Define a data inicial.
        /// </summary>
        public DateTime De { get; set; }
        /// <summary>
        /// Define a data final.
        /// </summary>
        public DateTime Ate { get; set; }

        /// <summary>
        /// Cria uma nova instância do filtro de data.
        /// </summary>
        public FilterDateTime()
        {
            this.Checked = false;
            this.De = DateTime.Now;
            this.Ate = DateTime.Now;
        }

        /// <summary>
        /// Retorna a Data.De em formato yyyy-MM-dd.
        /// </summary>
        /// <returns></returns>
        public string GetShortDateDe()
        {
            return this.De.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Retorna a Data.Ate em formato yyyy-MM-dd.
        /// </summary>
        /// <returns></returns>
        public string GetShortDateAte()
        {
            return this.Ate.ToString("yyyy-MM-dd");
        }
    }
}
