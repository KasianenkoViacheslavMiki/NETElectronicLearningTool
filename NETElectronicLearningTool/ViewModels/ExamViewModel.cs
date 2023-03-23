using Microsoft.Identity.Client;
using NETElectronicLearningTool.Command.CommandArticle;
using NETElectronicLearningTool.Command.CommandExam;
using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.ENUM;
using NETElectronicLearningTool.Interface;
using NETElectronicLearningTool.ViewModels.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NETElectronicLearningTool.ViewModels
{
    public class ExamViewModel:ViewModelBase
    {
        private readonly Guid userStub = Guid.Parse("D0FC5BB2-3EA4-4105-B0CD-765984808188");

        IGetTest getTest = new RepositoryTest(new LearningToolContext());

        enum onOffPass
        {
            off=0,
            on=450
        }
        private int rowMenuExam = 450;
        private int rowExam =0 ;

        private PassExamViewModel passExam = null;

        private List<ItemTree> itemsTree;

        private string informationTest;

        private Test selectedTest;

        public ICommand StartTest_Begin { get; set; }
        public ICommand ChangeTest { get; set; }

        public ExamViewModel()
        {
            EventSystem.Subscribe<ToggleMessage>(ToggleBar);
            RowMenuExam = (int)onOffPass.on;
            RowExam = (int)onOffPass.off;
            GetGuidAndNameArticle();
            StartTest_Begin = new StartTestCommand(this);
            ChangeTest = new ChangeTestCommand(this);
        }
        public bool HasSelectedTest
        {
            get
            {
                return selectedTest != null;
            }
        }
        public int RowMenuExam
        {
            get
            {
                return rowMenuExam;
            }
            set
            {
                rowMenuExam = value;
                OnPropertyChanged(nameof(RowMenuExam));
            }
        }
        public int RowExam
        {
            get
            {
                return rowExam;
            }
            set
            {
                rowExam = value;
                OnPropertyChanged(nameof(RowExam));
            }
        }
        public string InformationTest
        {
            get 
            { 
                return informationTest; 
            }
            set 
            {
                informationTest = value;
                OnPropertyChanged(nameof(InformationTest));
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

            int? countQuestionForExamSingle = SelectedTest.CountQuestionForExamSingle;
            int? countQuestionForExamMany = SelectedTest.CountQuestionForExamMany;
            int? countQuestionForExamText = SelectedTest.CountQuestionForExamText;

            int countQuestion = SelectedTest.TestQuestions.Count();

            List<TestQuestion> randomQuestions = new List<TestQuestion>();

            List<TestQuestion> testQuestion = SelectedTest.TestQuestions.ToList();

            randomQuestions.AddRange(RandomQuestion(TypeQuestion.ManyAnswer,(int) countQuestionForExamMany, testQuestion));
            randomQuestions.AddRange(RandomQuestion(TypeQuestion.SingleAnswer, (int)countQuestionForExamSingle, testQuestion));
            randomQuestions.AddRange(RandomQuestion(TypeQuestion.TextAnswer, (int)countQuestionForExamText, testQuestion));

            testRandom.TestQuestions = randomQuestions;
            testRandom.Id = SelectedTest.Id;

            RowMenuExam = (int) onOffPass.off;
            RowExam = (int) onOffPass.on;

            EventSystem.Publish(new ToggleMessage() { message="Hide"});
            PassExam = new PassExamViewModel(testRandom,userStub);

        }

        public async void SetTest(Guid id)
        {
            selectedTest = await getTest.GetTest(id);
            InformationTest = selectedTest.Name+ " Кількість запитань: "+ (selectedTest.CountQuestionForExamMany+ selectedTest.CountQuestionForExamSingle+ selectedTest.CountQuestionForExamText);
        }

        private IEnumerable<TestQuestion> RandomQuestion(TypeQuestion typeQuestion, int countQuestion, List<TestQuestion> testQuestions)
        {
            Random random = new Random();

            List<TestQuestion> filterQuestions = testQuestions.Where(x=>x.Type== typeQuestion).ToList();

            int numberForRandom = filterQuestions.Count();

            int countRandom = 0;
            for(int i = 0; i < countQuestion; i++)
            {
                countRandom = random.Next(0, numberForRandom - 1);
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
        public void ToggleBar(ToggleMessage msg)
        {
            if (msg.message == "Show")
            {
                RowMenuExam = (int)onOffPass.on;
                RowExam = (int)onOffPass.off;
                passExam = null;
                return;
            }
        }
    }
}
