using ClosedXML.Excel;

namespace Burikaigi.Server
{
    public class ExcelReader
    {
        public static Dictionary<string, Dictionary<string, string>[]> ReadExcel(string path)
            => ReadExcel(new XLWorkbook(path));

        static Dictionary<string, Dictionary<string, string>[]> ReadExcel(XLWorkbook wb)
        {
            var tables = new Dictionary<string, Dictionary<string, string>[]>();

            using (wb)
            {
                foreach (var ws in wb.Worksheets)
                {
                    var rowsData = new List<Dictionary<string, string>>();
                    foreach (var row in ws.RowsUsed())
                    {
                        var cellsData = new Dictionary<string, string>();
                        foreach (var cell in row.CellsUsed())
                        {
                            cellsData.Add(cell.Address.ColumnLetter, cell.Value.ToString());
                        }
                        rowsData.Add(cellsData);
                    }
                    tables.Add(ws.Name, rowsData.ToArray());
                }
            }
            return tables;
        }
    }
}
