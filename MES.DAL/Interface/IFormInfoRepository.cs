using MES.Models.Models;
using System.Collections.Generic;

namespace MES.DAL.Interface
{
    public interface IFormInfoRepository : IRepositoryBase<FORM_INFO>
    {
        IEnumerable<FORM_INFO> GetAllFormInfos();
        FORM_INFO GetFormInfoById(int id);
        void CreateFormInfo(FORM_INFO formInfo);
        void UpdateFormInfo(FORM_INFO formInfo, int id);
        void DeleteFormInfo(FORM_INFO formInfo);
    }
}
