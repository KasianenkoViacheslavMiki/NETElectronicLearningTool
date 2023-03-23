using NETElectronicLearningTool.Command.CommandExam;
using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.ENUM;
using NETElectronicLearningTool.Interface;
using NETElectronicLearningTool.UserControls;
using NETElectronicLearningTool.ViewModels.ExamControl;
using NETElectronicLearningTool.ViewModels.Mediator;
using NETElectronicLearningTool.ViewModels.Strategy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.ViewModels
{
    public class PassExamViewModel:ViewModelBase
    {
		ICreateControl createControl;

        IPassExam passExam = new RepositoryTest(new LearningToolContext());

        
        private ObservableCollection<BaseControl> properties;

        private UserAnswerTest currentTest;

        private Test test;

		private TestQuestion question;

		public CheckBoxControl MySelectedItem { get; set; }

        private int countQuestion;

        private int countTrueAnswers=0;

		private int numberQuestion;

		private string textAnswer;
        private string textQuestion;

        private double ballExam = 0;

		private string informationPassQuestion;
        public ICommand PassAnswer { get; set; }
        public ICommand EndTest { get; set; }
        public Test Test
        {
            get 
            { 
                return test; 
            }
            set 
            { 
                test = value; 
            }
        }
        public UserAnswerTest CurrentTest
        {
            get 
            { 
                return currentTest; 
            }
            set 
            { 
                currentTest = value;
                OnPropertyChanged(nameof(CurrentTest));
            }
        }
        public ObservableCollection<BaseControl> Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
                OnPropertyChanged(nameof(Properties));
            }
        }

        private string viewInfo;

        public string ViewInfo
        {
            get 
            {
                return viewInfo; 
            }
            set 
            { 
                viewInfo = value; 
                OnPropertyChanged(nameof(ViewInfo)); 
            }
        }
        private string message;

        public string Message
        {
            get 
            { 
                return message; 
            }
            set 
            { 
                message = value; 
                OnPropertyChanged(nameof(Message)); 
            }
        }


        public string InformationPassQuestion
        {
			get 
			{
				return informationPassQuestion; 
			}
			set 
			{ 
				informationPassQuestion = value;
                OnPropertyChanged(nameof(InformationPassQuestion));

            }
        }
        public double BallExam
        {
            get
            {
                return ballExam;
            }
            set
            {
                ballExam = value;

                OnPropertyChanged(nameof(BallExam));
                if (ballExam == 1)
                    InformationPassQuestion = "Відповідь вірна, отримано балів " + (int)ballExam;
                if (ballExam == 0.5)
                    InformationPassQuestion = "Відповідь наполовину вірна, отримано балів " + ballExam.ToString("0.0") +"\nВірні відповіді "+ stringTrueAnswer;
                if (ballExam == 0)
                    InformationPassQuestion = "Відповідь невірна, отримано балів " + (int)ballExam + "\nВірні відповіді " + stringTrueAnswer;
            }
        }

        public string TextQuestion
        {
            get
            {
                return textQuestion;
            }
            set
            {
                textQuestion = value;
                OnPropertyChanged(nameof(TextQuestion));
            }
        }

        public string TextAnswer
        {
			get 
			{ 
				return textAnswer; 
			}
			set 
			{ 
				textAnswer = value;
                OnPropertyChanged(nameof(TextAnswer));

            }
        }

		public int NumberQuestion
        {
			get 
			{ 
				return numberQuestion; 
			}
			set 
			{ 
				numberQuestion = value;
                OnPropertyChanged(nameof(NumberQuestion));

            }
        }

        private void ChangeCreateControl(ICreateControl _createControl)
        {
            createControl = _createControl;
        }
        public void ChangeQuestion(int numberQuestionCommand)
		{
            if (numberQuestion == countQuestion)
            {
                Message = "1*";
                ViewInfo = "0";
                InformationPassQuestion = "Тест був зданий на " + ballExam.ToString("0.0")+ " Правильних відповідей було "+ countTrueAnswers.ToString();
                return;
            }
            ObservableCollection<BaseControl> baseControls = new ObservableCollection<BaseControl>();
            question = (test.TestQuestions.ToArray())[numberQuestionCommand];
			var listAnswer = question.QuestionAnswers.ToList();
            TextQuestion = question.Question;

            if (question.Type==TypeQuestion.SingleAnswer)
			{
				ChangeCreateControl(new CreateRadioButton());
			}
			else if (question.Type == TypeQuestion.ManyAnswer)
			{
                ChangeCreateControl(new CreateComboBox());
            }
			else if (question.Type == TypeQuestion.TextAnswer)
			{
				ChangeCreateControl(new CreateTextBox());
			}

            foreach (var answer in listAnswer)
			{
                baseControls.Add(createControl.CreateControl(answer.Id, answer.Answer));
            }
            
            Properties =baseControls;
        }

		public async void PassQuestion()
		{
            List<QuestionAnswer> trueAnswer = question.QuestionAnswers.Where(x => x.TrueOrFalse == true).ToList();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var answer in trueAnswer)
            {
                stringBuilder.Append(answer.Answer + " ");
            }
            stringTrueAnswer = stringBuilder.ToString();

            List<(string,bool)> answers = new List<(string, bool)>();

            foreach (var item in properties)
            {
                answers.Add(item.GetData());

            }
            UserAnswer userAnswer = new UserAnswer();
            int countTrueAnswer = 0;
            if (question.Type == TypeQuestion.SingleAnswer)
            {
                countTrueAnswer = question.QuestionAnswers.Where(x => (x.TrueOrFalse == true && x.Id == Guid.Parse(answers[0].Item1) && answers[0].Item2==true)).Count();
                userAnswer.IdUserAnswerTest = CurrentTest.Id;
                userAnswer.IdQuestionAnswer = Guid.Parse(answers[0].Item1);
                await passExam.PassQuestion(Test.Id, userAnswer);
                BallExam += countTrueAnswer * 1;
            }
            else if (question.Type == TypeQuestion.ManyAnswer)
            {
                foreach (var answer in answers)
                {
                    UserAnswer manyUserAnswer = new UserAnswer();
                    countTrueAnswer += question.QuestionAnswers.Where(x => (x.TrueOrFalse == true && x.Id == Guid.Parse(answer.Item1) && answer.Item2 == true)).Count();
                    manyUserAnswer.IdUserAnswerTest = CurrentTest.Id;
                    manyUserAnswer.IdQuestionAnswer = Guid.Parse(answer.Item1);
                    await passExam.PassQuestion(Test.Id, manyUserAnswer);
                }
                BallExam += countTrueAnswer * 0.5;
            }
            else if (question.Type == TypeQuestion.TextAnswer)
            {
                countTrueAnswer = question.QuestionAnswers.Where(x => (x.TrueOrFalse == true || x.Answer == answers[0].Item1)).Count();
                userAnswer.IdUserAnswerTest = CurrentTest.Id;
                userAnswer.TextAnswer = answers[0].Item1;
                await passExam.PassQuestion(Test.Id, userAnswer);
                BallExam += countTrueAnswer *1;
            }
            countTrueAnswers += countTrueAnswer;
        }

        public PassExamViewModel(Test test, Guid user)
		{
            ViewInfo = "1*";
            Message = "0";
            Test = test;
            InitTest(Test.Id,user);
            PassAnswer = new PassAnswerCommand(this);
            EndTest = new EndTestCommands();
            countQuestion = test.TestQuestions.Count();
            NumberQuestion = 0;
            ChangeQuestion(NumberQuestion);
            
        }
        private string stringTrueAnswer;	
        private async void InitTest(Guid test, Guid user)
        {
            CurrentTest = await passExam.InitPass(test, user);
        }
    }
}
