using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.ENUM;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels
{
    public class ExamViewModel:ViewModelBase
    {
        IGetTest getTest = new RepositoryTest(new LearningToolContext());

        private PassExamViewModel passExam = null;

        private List<ItemTree> itemsTree;

        private string informationTest;

        private Test selectedTest;


        public string InformationTest
        {
            get 
            { 
                return informationTest; 
            }
            set 
            {
                OnPropertyChanged(nameof(PassExam));
            }
        }

        public Test SelectedTest
        {
            get
            {
                return selectedTest;
            }
            set
            {
                selectedTest = value;
                OnPropertyChanged(nameof(SelectedTest));
            }
        }
        public PassExamViewModel PassExam
        {
            get 
            { 
                return passExam; 
            }
            set 
            { 
                passExam = value;
                OnPropertyChanged(nameof(PassExam));
            }
        }

        public List<ItemTree> ItemsTree
        {
            get
            {
                return itemsTree;
            }
            set
            {
                itemsTree = value;
                OnPropertyChanged(nameof(ItemsTree));
            }
        }
        public void StartTest()
        {
            Test testRandom = new Test();

            int countQuestionForExamSingle = SelectedTest.CountQuestionForExamSingle;
            int countQuestionForExamMany = SelectedTest.CountQuestionForExamMany;
            int countQuestionForExamText = SelectedTest.CountQuestionForExamText;

            int countQuestion = SelectedTest.TestQuestions.Count();

            List<TestQuestion> randomQuestions = new List<TestQuestion>();

            List<TestQuestion> testQuestion = SelectedTest.TestQuestions.ToList();

            randomQuestions.AddRange(RandomQuestion(TypeQuestion.ManyAnswer, countQuestionForExamMany, testQuestion));
            randomQuestions.AddRange(RandomQuestion(TypeQuestion.SingleAnswer, countQuestionForExamSingle, testQuestion));
            randomQuestions.AddRange(RandomQuestion(TypeQuestion.TextAnswer, countQuestionForExamText, testQuestion));

            testRandom.TestQuestions = randomQuestions;
            testRandom.Id = SelectedTest.Id;


            PassExam = new PassExamViewModel(testRandom);
        }

        private IEnumerable<TestQuestion> RandomQuestion(TypeQuestion typeQuestion, int countQuestion, List<TestQuestion> testQuestions)
        {
            Random random = new Random();

            List<TestQuestion> filterQuestions = testQuestions.Where(x=>x.Type== typeQuestion).ToList();
            int countRandom = 0;
            for(int i = 0; i < countQuestion; i++)
            {
                countRandom = random.Next(0, countQuestion - 1);
                yield return filterQuestions[countRandom];
                filterQuestions.Remove(filterQuestions[countRandom]);
            }
        }

        private async void GetGuidAndNameArticle()
        {
            var items = (await getTest.GetTests()).ToList();
            List<ItemTree> articles = new List<ItemTree>();
            foreach (var item in items)
            {
                articles.Add(new ItemTree(item.Id, item.Name));
            }
            ItemsTree = articles;
        }

    }
}
