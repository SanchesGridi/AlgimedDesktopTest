using AlgimedDesktopTest.Shared.Excel.Interfaces;
using AlgimedDesktopTest.Shared.Excel.Models;
using IronXL;

namespace AlgimedDesktopTest.Shared.Excel.Classes;

public class ExcelService : IExcelService
{
    private const string WrongColumnsCountFormat = "Is in the wrong columns count format!";
    private const string WrongHeaderNamesFormat = "Is in the wrong header names format!";

    public List<TEntity> LoadFromXlsx<TEntity>(ExcelOptions<TEntity> options) where TEntity : class
    {
        var workBook = WorkBook.Load(options.Path);
        var workSheet = workBook.GetWorkSheet(options.SheetName);

        var table = workSheet.ToDataTable(useFirstRowAsColumnNames: true);
        if (table.Columns.Count != options.ColumnsCount)
        {
            throw new InvalidOperationException($"File: [{options.Path}]\n{WrongColumnsCountFormat}");
        }
        for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
        {
            var headerName = options.HeaderNames![columnIndex];
            if (table.Columns[columnIndex].ColumnName != headerName)
            {
                throw new InvalidOperationException($"File: [{options.Path}]\n{WrongHeaderNamesFormat}");
            }
        }

        var entities = new List<TEntity>();
        for (var index = 0; index < table.Rows.Count; index++)
        {
            var row = table.Rows[index];
            if (options.GetValidator().Invoke(row))
            {
                var entity = options.GetMapper().Invoke(row);
                entities.Add(entity);
            }
        }

        return entities;
    }
}
