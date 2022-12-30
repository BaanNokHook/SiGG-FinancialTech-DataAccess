using GM.DataAccess.Infrastructure;
using GM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;

namespace GM.DataAccess.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IDbConnection _connection;
        private readonly IUnitOfWork _uow;

        public TestRepository(IUnitOfWork uow)
        {
            _uow = uow;
            //_connection = connection;
        }

        public ResultWithModel TestCreate()
        {
            BaseParameterModel paramModel = new BaseParameterModel();
            //paramModel.Parameters.Add(new Field{Name = "@Id", Value = "234"});
            //paramModel.Parameters.Add(new Field { Name = "@Name", Value = "234" });

            //_uow.ExecNonQuery(@"INSERT INTO [Table_1] ([id],[name]) VALUES (@Id,@Name)", paramModel);

            paramModel.ProcedureName = "GM_Holiday_830004_List_Proc";
            paramModel.Parameters.Add(new Field { Name = "year", Value = 2018 });
            paramModel.Parameters.Add(new Field { Name = "cur", Value = "THB" });
            paramModel.ResultModelNames.Add("HolidayResultModel");
            paramModel.Paging.PageNumber = 1;
            paramModel.Paging.RecordPerPage = 366;

            var t =_uow.ExecDataProc(paramModel);

            return t;
        }

        public void Add(Test entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> Find(Expression<Func<Test, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Test Get(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Test entity)
        {
            throw new NotImplementedException();
        }

        public Test Update(Test entity)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(Test model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(Test model)
        {
            throw new NotImplementedException();
        }

        ResultWithModel IRepository<Test>.Add(Test model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<Test> model)
        {
            throw new NotImplementedException();
        }

        ResultWithModel IRepository<Test>.Update(Test model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<Test> model)
        {
            throw new NotImplementedException();
        }

        ResultWithModel IRepository<Test>.Remove(Test model)
        {
            throw new NotImplementedException();
        }
    }
}
