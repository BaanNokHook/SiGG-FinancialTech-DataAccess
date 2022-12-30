using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;

namespace GM.DataAccess.Repositories
{
    class DropdownRepository : IDropdownRepository<DropdownModel>
    {
        private readonly IUnitOfWork _uow;

        public DropdownRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Get(DropdownModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = model.ProcedureName;

            parameter.Parameters.Add(new Field { Name = "DdltTableList", Value = model.DdltTableList });

            if (model.SearchValue != null)
            {
                parameter.Parameters.Add(new Field { Name = "SearchValue", Value = model.SearchValue });
            }

            if (model.SearchValue2 != null)
            {
                parameter.Parameters.Add(new Field { Name = "SearchValue2", Value = model.SearchValue2 });
            }

            if (model.SearchValue3 != null)
            {
                parameter.Parameters.Add(new Field { Name = "SearchValue3", Value = model.SearchValue3 });
            }

            if (model.SearchValue4 != null)
            {
                parameter.Parameters.Add(new Field { Name = "SearchValue4", Value = model.SearchValue4 });
            }

            if (model.SearchValue5 != null)
            {
                parameter.Parameters.Add(new Field { Name = "SearchValue5", Value = model.SearchValue5 });
            }

            parameter.ResultModelNames.Add("DDLItems");
            parameter.Paging = model.Paging;

            return _uow.ExecDataProc(parameter);
        }
    }
}
