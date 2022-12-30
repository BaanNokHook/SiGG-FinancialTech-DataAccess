using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.GLProcess;
using GM.DataAccess.UnitOfWork;
using GM.Model.GLProcess;

namespace GM.DataAccess.Repositories
{
    public class GLProcessRepository
    {
        public IRepository<GLAccountCodeModel> GLAccountCode { get; }
        public IRepository<GLAdjustModel> GLAdjust { get; }

        public GLProcessRepository(IUnitOfWork uow)
        {
            GLAccountCode = new GLAccountCodeRepository(uow);
            GLAdjust = new GLAdjustRepository(uow);
        }
    }
}
