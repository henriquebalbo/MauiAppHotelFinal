using System;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }

        // Corrigido nome das propriedades para DataCheckIn / DataCheckOut (grafia correta)
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        // Propriedade Estadia (número de noites). Garante no mínimo 1 noite quando as datas são válidas.
        public int Estadia
        {
            get
            {
                try
                {
                    var days = (DataCheckOut - DataCheckIn).Days;
                    return days < 1 ? 1 : days;
                }
                catch
                {
                    return 0;
                }
            }
        }

        // Propriedade que calcula o valor total da hospedagem.
        // Se QuartoSelecionado for null, assume 0.
        public double ValorTotal
        {
            get
            {
                if (QuartoSelecionado == null) return 0.0;

                double valorAdultos = QntAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valorCriancas = QntCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double totalPorDia = valorAdultos + valorCriancas;

                return totalPorDia * Estadia;
            }
        }
    }
}
