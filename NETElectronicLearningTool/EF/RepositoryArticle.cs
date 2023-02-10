using Microsoft.EntityFrameworkCore;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NETElectronicLearningTool.EF
{
    public class RepositoryArticle : IGetMaterialOfTeach
    {
        LearningToolContext _context;

        public RepositoryArticle(LearningToolContext context)
        {
            _context = context;
        }

        public async Task<Article> GetArticle(Guid guid)
        {
            return await _context.Articles.Where(x=>x.Id == guid)
                .Include(x=>x.ArticlePage)
                .FirstAsync();
        }

        public async Task<IEnumerable<(Guid, string)>> GetGuidAndTitleAllArticles()
        {
            List<(Guid, string)> result = new List<(Guid, string)>();
            var list =  await _context.Articles.ToListAsync();

            foreach (var article in list)
            {
                result.Add((article.Id,article.TitleArticle));
            }
            return result;
        }
    }
}
