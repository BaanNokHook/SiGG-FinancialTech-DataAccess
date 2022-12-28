using GM.Model.Common;
using System.Collections.Generic;

namespace GM.DataAccess.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        ResultWithModel Get(T model);

        ResultWithModel Find(T model);

        ResultWithModel Add(T model);

        ResultWithModel AddList(List<T> models);

        ResultWithModel Update(T model);

        ResultWithModel UpdateList(List<T> models);

        ResultWithModel Remove(T model);

        // exception it shouldn't be here just for conveninace
       
    }
}
