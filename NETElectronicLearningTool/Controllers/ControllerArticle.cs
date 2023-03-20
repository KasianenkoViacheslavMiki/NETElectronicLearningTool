using NETElectronicLearningTool.EF.Model;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

namespace NETElectronicLearningTool.Controllers
{
    public class ControllerArticle
    {
        public event Action OnLastPage;
        public event Action OnFirstPage;

        public event Action<string,BitmapImage,uint,uint> OnChangePage;

        Article article;

        private uint numberPage;
        private uint lastPage;
        private string textCurrent;
        BitmapImage bitmapCurrent;
        public void NextPage()
        {
            numberPage++;
            ArticlePage nextPage = ChangePage(numberPage);
            textCurrent = nextPage.TextArticlePage;
            bitmapCurrent = BitmapImageFromBytes(nextPage.ImageData);

            OnChangePage?.Invoke(textCurrent, bitmapCurrent, numberPage, lastPage);

            if (numberPage == lastPage)
            {
                OnLastPage?.Invoke();
            }
        }
        public void PrevPage()
        {
            numberPage--;
            ArticlePage nextPage = ChangePage(numberPage);
            textCurrent = nextPage.TextArticlePage;
            bitmapCurrent = BitmapImageFromBytes(nextPage.ImageData);

            OnChangePage?.Invoke(textCurrent, bitmapCurrent, numberPage, lastPage);

            if (numberPage == 1)
            {
                OnFirstPage?.Invoke();
            }

        }
        public void ChangeArticle(Article _article)
        {
            article = _article;
            numberPage = 1;
            lastPage = (uint) _article.ArticlePage.Count();
            ArticlePage nextPage = new ArticlePage();

            nextPage = ChangePage(numberPage);

            textCurrent = nextPage.TextArticlePage;
            bitmapCurrent = BitmapImageFromBytes(nextPage.ImageData);

            OnChangePage?.Invoke(textCurrent, bitmapCurrent, numberPage, lastPage);

            if (numberPage == 1)
            {
                OnFirstPage?.Invoke();
            }

            if (numberPage == lastPage)
            {
                OnLastPage?.Invoke();
            }
        }

        private ArticlePage ChangePage(uint numberPage)
        {
            ArticlePage nextPage = new ArticlePage();
            try
            {
                nextPage = article.ArticlePage.Where(x => x.NumberPage == numberPage).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.Yes);
            }
            return nextPage;
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
}
