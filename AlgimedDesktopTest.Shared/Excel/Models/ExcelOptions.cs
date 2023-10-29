using System.Data;

namespace AlgimedDesktopTest.Shared.Excel.Models;

public class ExcelOptions<TClass> where TClass : class
{
    private readonly Func<DataRow, TClass> _mapper;
    private readonly Func<DataRow, bool> _validator;

    public string? Path { get; set; }
    public string? SheetName { get; set; }
    public string[]? HeaderNames { get; set; }

    public int ColumnsCount => HeaderNames!.Length;

    public ExcelOptions(Func<DataRow, TClass> mapper, Func<DataRow, bool> validator)
    {
        _mapper = mapper;
        _validator = validator;
    }

    public Func<DataRow, TClass> GetMapper() => _mapper;

    public Func<DataRow, bool> GetValidator() => _validator;
}
