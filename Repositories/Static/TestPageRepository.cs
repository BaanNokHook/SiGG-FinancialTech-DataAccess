using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class TestPageRepository : IRepository<TestPageModel>
    {
        private readonly IUnitOfWork _uow;

        public TestPageRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(TestPageModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<TestPageModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(TestPageModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(TestPageModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Test_Page_List_Proc";
            parameter.Parameters.Add(new Field { Name = "text", Value = !string.IsNullOrEmpty(model.text) ? model.text.Trim() : model.text });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(TestPageModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(TestPageModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<TestPageModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
