using Microsoft.AspNetCore.Mvc;
using dotnet_excel.Models;
using OfficeOpenXml;

namespace dotnet_excel.Controllers;

public class PurchaseController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Data()
    {
        // Specify the path to your Excel file
        string filePath = "Data/vodus-test-excel.xlsx";

        List<Purchase> excelDataList = ReadExcel(filePath);

        return Json(excelDataList);
    }

    private List<Purchase> ReadExcel(string filePath)
    {
        List<Purchase> excelDataList = new List<Purchase>();

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                excelDataList.Add(new Purchase
                {
                    Id = int.Parse(worksheet.Cells[row, 1].Value?.ToString()),
                    Image = worksheet.Cells[row, 2].Value?.ToString(),
                    Name = worksheet.Cells[row, 3].Value?.ToString(),
                    OrderDate = DateTime.Parse(worksheet.Cells[row, 4].Value?.ToString()),
                    Price = decimal.Parse(worksheet.Cells[row, 5].Value?.ToString()),
                    DiscountedPrice = decimal.Parse(worksheet.Cells[row, 6].Value?.ToString())
                });
            }
        }

        return excelDataList;
    }
}
