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
    public class RepositoryDictionary : IGetDictionary
    {
        LearningToolContext _context;

        public RepositoryDictionary(LearningToolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MethodDiscription>> GetDictionaryOfFunctions()
        {
            return await _context.DictionaryOfFunctions.ToListAsync();
        }

        public async Task<IEnumerable<MethodDiscription>> GetDictionaryOfFunctionsByName(string name)
        {
            return await _context.DictionaryOfFunctions
                .Where(x=>x.NameFunction.StartsWith(name))
                .ToListAsync();
        }

        public async Task<MethodDiscription> GetFunctionsByGuid(Guid guid)
        {
            return await _context.DictionaryOfFunctions
                .FirstOrDefaultAsync(x => x.Id == guid);
        }
    }
}
