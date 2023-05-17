using Microsoft.EntityFrameworkCore;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF
{
    public class RepositoryTest : IGetTest, IPassExam, ISetLevel
    {
        LearningToolContext _context;

        public RepositoryTest(LearningToolContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
        }
        public async Task<Test> GetTest(Guid guid)
        {
            return await _context.Tests.Where(x => x.Id == guid).Include(x=>x.TestQuestions).ThenInclude(x=>x.QuestionAnswers).FirstAsync();
        }

        public async Task<IEnumerable<Test>> GetTests()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<UserAnswer> PassQuestion(Guid IdTest, UserAnswer userAnswer)
        {
            userAnswer.Id = Guid.NewGuid();
            await _context.UserAnswers.AddAsync(userAnswer);
            await _context.SaveChangesAsync();
            return await _context.UserAnswers.FirstAsync(x => x.Id == userAnswer.Id);
        }

        public async Task<UserAnswerTest> InitPass(Guid testGuid, Guid user)
        {
            UserAnswerTest userAnswerTest = new UserAnswerTest();
            userAnswerTest.Id = Guid.NewGuid();
            userAnswerTest.IdTest = testGuid;
            userAnswerTest.IdUser = user;
            var l = await _context.UserAnswerTests.AddAsync(userAnswerTest);
            await _context.SaveChangesAsync();
            return await _context.UserAnswerTests.FirstAsync(x => x.Id == userAnswerTest.Id);
        }

        public async Task<LevelKnowledge> SetLevelKnowledge(Guid? IdElementLearning,Guid? IdUser, float level)
        {
            LevelKnowledge levelKnowledge = new LevelKnowledge
            {
                Id = Guid.NewGuid(),
                IdElementLearning = IdElementLearning,
                IdUser = IdUser,
                LvlKnowledge = level
            };
            await _context.LevelKnowledge.AddAsync(levelKnowledge);
            await _context.SaveChangesAsync();
            return levelKnowledge;
        }
    }
}
