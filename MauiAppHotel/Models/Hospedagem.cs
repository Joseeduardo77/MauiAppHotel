﻿namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }

        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public int QtdPetz { get; set; }

        public DateTime DataCheckIn { get; set; }

        public DateTime DataCheckOut { get; set; }

        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }
        public double ValorTotal
        {
            get
            {
                double valor_adultos = QtdAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QtdCriancas * QuartoSelecionado.ValorDiariaCrianca;
                double valor_petz = QtdPetz * QuartoSelecionado.ValorDiariaPetz;

                double total = (valor_adultos + valor_criancas + valor_petz) * Estadia;

                return total;
            }
        }
    }
}