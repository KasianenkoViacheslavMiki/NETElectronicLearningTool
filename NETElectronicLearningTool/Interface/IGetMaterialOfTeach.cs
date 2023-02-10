using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.Interface
{
    public interface IGetMaterialOfTeach
    {
        public Task<IEnumerable<(Guid,string)>> GetGuidAndTitleAllArticles();
        public Task<Article> GetArticle(Guid guid);
    }
}
