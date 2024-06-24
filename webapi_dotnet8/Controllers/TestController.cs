using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace webapi_dotnet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("DownloadPdf")]
        public async Task<IActionResult> DownloadPdf()
        {
            string excelFilePath = "C:\\Users\\User\\Desktop\\excel.xlsx";
            string pdfFilePath = "C:\\Users\\User\\Desktop\\excel.pdf";

            if (!System.IO.File.Exists(excelFilePath))
            {
                return NotFound($"Excel file not found at {excelFilePath}");
            }

            // 加载 Excel 文件
            using (var workbook = new XLWorkbook(excelFilePath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    // 创建一个 PDF 文档
                    Document pdfDoc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(pdfFilePath, FileMode.Create));

                    pdfDoc.Open();

                    // 遍历 Excel 文件中的每个工作表
                    foreach (IXLWorksheet worksheet in workbook.Worksheets)
                    {
                        PdfPTable table = new PdfPTable(worksheet.ColumnsUsed().Count());

                        // 添加表头
                        foreach (IXLCell cell in worksheet.FirstRow().CellsUsed())
                        {
                            table.AddCell(new Phrase(cell.Value.ToString()));
                        }

                        // 添加表格数据
                        foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                        {
                            foreach (IXLCell cell in row.CellsUsed())
                            {
                                table.AddCell(new Phrase(cell.Value.ToString()));
                            }
                        }

                        pdfDoc.Add(table);
                        pdfDoc.NewPage();
                    }

                    pdfDoc.Close();
                }
            }

            return Ok();
        }
    }
}
