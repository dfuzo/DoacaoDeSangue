using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;
using Trabalho_BD.Data.Models;
using Document = QuestPDF.Fluent.Document;

namespace Trabalho_BD.Data.Services
{
    public class PdfService
    {
        public byte[] GenerateComprovante(Transfusao transfusao)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.Header()
                        .Text("Comprovante de Transfusão")
                        .FontSize(20)
                        .Bold()
                        .AlignCenter();

                    page.Content().Column(col =>
                    {
                        col.Item().Text($"Asseguramos que a transfusão de id {transfusao.IdTransfusao}" +
                            $" foi feita com a coleta: {transfusao.IdColeta} para o receptor de CPF " +
                            $"{transfusao.CpfReceptor} pelo funcionário de ponto {transfusao.PontoFuncionario}");
                        col.Item().Text($"Data da Transfusão: {transfusao.DataTransfusao}");
                        col.Item().Text($"Volume: {transfusao.Volume} mL");
                        col.Item().Text($"ID Hemocentro: {transfusao.IdHemocentro}");
                        col.Item().Text($"Tipo Sanguíneo: {transfusao.IdTipoSanguineo}");
                        col.Item().PaddingTop(20).Text("Assinatura: _________________________");
                    });

                    page.Footer()
                        .Text("Gerado automaticamente pelo sistema")
                        .FontSize(10)
                        .AlignCenter();
                });
            }).GeneratePdf();
        }
    }
}
