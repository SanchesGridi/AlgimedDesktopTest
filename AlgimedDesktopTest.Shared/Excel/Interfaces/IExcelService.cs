using AlgimedDesktopTest.Shared.Excel.Models;

namespace AlgimedDesktopTest.Shared.Excel.Interfaces;

public interface IExcelService
{
    List<TEntity> LoadFromXlsx<TEntity>(ExcelOptions<TEntity> options) where TEntity : class;
}
