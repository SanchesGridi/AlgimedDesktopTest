using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AlgimedDesktopTest.WpfImplementation.Extensions;

public static class MapperExtensions
{
    public static async Task<TListModel> ListFromContextAsync<TEntity, TListModel>(this IMapper @this, DbContext context) where TEntity : class where TListModel : class
    {
        var entities = await context.Set<TEntity>().ToListAsync();
        return @this.Map<TListModel>(entities);
    }
}
