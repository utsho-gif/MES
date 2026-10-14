using MES.DAL.Interface;
using MES.Models.Context;
using MES.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace MES.DAL.Class
{
    public class FormInfoRepository : RepositoryBase<FORM_INFO>, IFormInfoRepository
    {
        public FormInfoRepository(MESDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateFormInfo(FORM_INFO formInfo)
        {
            Create(formInfo);
        }

        public void DeleteFormInfo(FORM_INFO formInfo)
        {
            Delete(formInfo);
        }

        public IEnumerable<FORM_INFO> GetAllFormInfos()
        {
            return FindAll().Where(x => x.IS_DELETE != 1).OrderBy(x => x.ORDER_INDEX);
        }

        public FORM_INFO GetFormInfoById(int id)
        {
            return FindByID(id);
        }

        public void UpdateFormInfo(FORM_INFO formInfo, int id)
        {
            Update(formInfo);
        }
    }
}
