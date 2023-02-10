using NETElectronicLearningTool.Controllers;
using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NETElectronicLearningTool.UserControls
{
    /// <summary>
    /// Interaction logic for Teach.xaml
    /// </summary>
    public partial class Teach : UserControl
    {
        IGetMaterialOfTeach getMaterialOfTeach;
        ControllerArticle controllerArticle;

        public Teach()
        {
            controllerArticle = new ControllerArticle();

            
            getMaterialOfTeach = new RepositoryArticle(new LearningToolContext());
            
            InitializeComponent();

            InitializeData();

            InitializeEvent();
        }

        private async void InitializeData()
        {
            var list = await getMaterialOfTeach.GetGuidAndTitleAllArticles();
            foreach (var article in list)
            {
                TreeViewItem newChild = new TreeViewItem();
                newChild.Header = article.Item2;
                newChild.Tag = article.Item1;
                TreeArticle.Items.Add(newChild);
            }
        }
        private void InitializeEvent()
        {
            controllerArticle.OnLastPage += ControllerArticle_OnLastPage;
            controllerArticle.OnFirstPage += ControllerArticle_OnFirstPage;
            controllerArticle.OnChangePage += ControllerArticle_OnChangePage;
        }

        private void ControllerArticle_OnChangePage(string text, BitmapImage image,uint numberPage,uint numberLastPage)
        {
            numberPageArticle.Content = numberPage+"/"+numberLastPage;
            textPage.Text = text;
            imagePage.Source = image;
            Back.IsEnabled = true;
            Forward.IsEnabled = true;
        }

        private void ControllerArticle_OnFirstPage()
        {
            Back.IsEnabled = false;
        }

        private void ControllerArticle_OnLastPage()
        {
            Forward.IsEnabled = false;
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            controllerArticle.NextPage();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            controllerArticle.PrevPage();
        }

        private async void TreeArticle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var article = (TreeViewItem) TreeArticle.SelectedItem;
            if (article != null)
            {
                var result = await getMaterialOfTeach.GetArticle((Guid)article.Tag);
                controllerArticle.ChangeArticle(result);
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
