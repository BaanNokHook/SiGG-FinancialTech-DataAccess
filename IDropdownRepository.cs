using GM.Model.Common;

namespace GM.DataAccess.Infrastructure
{
    public interface IDropdownRepository<T> where T : class
    {
        ResultWithModel Get(T model);
    }
}
