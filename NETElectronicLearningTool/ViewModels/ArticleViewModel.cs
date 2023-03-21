using NETElectronicLearningTool.Command.CommandArticle;
using NETElectronicLearningTool.Controllers;
using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NETElectronicLearningTool.ViewModels
{
    public class ArticleViewModel:ViewModelBase
    {
        public ICommand NextPage { get; set; }
        public ICommand PreviousPage { get; set; }
        public ICommand ChangeArticle { get; set; }

        IGetMaterialOfTeach getMaterialOfTeach = new RepositoryArticle(new LearningToolContext());

        private bool canNext = false;
        private bool canPrevious = false;

        private List<Article> articles;
        private List<ItemTree> itemsTree =new List<ItemTree>();

        Article currentArticle;

        private uint numberPage;
        private uint lastPage;
        private string textCurrent;
        private BitmapImage bitmapCurrent;

        
        public ArticleViewModel()
        {
            NextPage = new NextPageCommand(this);
            PreviousPage = new PreviousPageCommand(this);
            ChangeArticle = new ChangeArticleCommand(this);
            GetGuidAndNameArticle();
        }

        public List<Article> Articles
        {
            get 
            { 
                return articles; 
            }
            set 
            {
                articles = value;
                OnPropertyChanged(nameof(Articles));
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
        public string TextCurrent 
        {
            get
            {
                return textCurrent;
            }

            set
            {
                textCurrent = value;
                OnPropertyChanged(nameof(TextCurrent));
            }
        }
        public BitmapImage BitmapCurrent 
        {
            get
            {
                return bitmapCurrent;
            }

            set 
            { 
                bitmapCurrent = value;
                OnPropertyChanged(nameof(BitmapCurrent));
            }
        }
        public uint NumberPage 
        {
            get
            {
                return numberPage;
            }
            set
            {
                numberPage = value;
                OnPropertyChanged(nameof(NumberPage));
            } 
        }
        public uint LastPage 
        {
            get 
            { 
                return lastPage; 
            }
            set
            {
                lastPage = value;
                OnPropertyChanged(nameof(LastPage));
            }
        }
        public string PageCount
        {
            get
            {
                if (LastPage == 0) 
                    return string.Empty;
                return NumberPage+"/"+LastPage;
            }
            set
            {
                OnPropertyChanged(nameof(PageCount));
            }
        }
        public Article CurrentArticle 
        {
            get
            {
                return currentArticle;
            }
            set
            {
                currentArticle = value;
                OnPropertyChanged(nameof(CurrentArticle));
            }
        }

        public bool CanNext 
        {
            get 
            { 
                return canNext; 
            }
            set 
            { 
                canNext = value;
                OnPropertyChanged(nameof(CanNext));
            }
        }
        public bool CanPrevious 
        {
            get 
            { 
                return canPrevious; 
            }
            set 
            { 
                canPrevious = value;
                OnPropertyChanged(nameof(CanPrevious));
            }
        }

        public async void SetArticle(Guid guid)
        {
            CanNext = true;
            CanPrevious = false;
            CurrentArticle = await getMaterialOfTeach.GetArticle(guid);

            NumberPage = 1;
            LastPage = (uint) CurrentArticle.ArticlePage.Count();

            ChangePage(NumberPage);
        }
        public void ChangePage(uint number)
        {
            NumberPage = number;
            PageCount = "Update";
            ArticlePage articlePage = new ArticlePage();
            articlePage = CurrentArticle.ArticlePage?.First(x => x.NumberPage == NumberPage);
            BitmapCurrent = BitmapImageFromBytes(articlePage.ImageData);
            TextCurrent = articlePage.TextArticlePage;

            if (NumberPage == 1)
            {
                CanPrevious = false;
            }
            else CanPrevious = true;
            if (NumberPage == LastPage)
            {
                CanNext = false;
            }
            else CanNext = true;
        }

        private async void GetGuidAndNameArticle()
        {
            var items = (await getMaterialOfTeach.GetGuidAndTitleAllArticles()).ToList();
            List <ItemTree> articles = new List <ItemTree>();
            foreach (var item in items)
            {
                articles.Add(new ItemTree(item.Item1,item.Item2));
            }
            ItemsTree = articles;
        }

        private BitmapImage BitmapImageFromBytes(byte[] bytes)
        {
            var bitmapImage = new BitmapImage();
            if (bytes == null)
            {
                return bitmapImage;
            }
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            return bitmapImage;
        }
    }
    public class ItemTree
    {
        private Guid id;

        public Guid Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        private string name;

        public ItemTree(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
    }
}