using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class ArticlePage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public uint? NumberPage { get; set; }
        public string? TextArticlePage { get; set; }
        public byte[]? ImageData { get; set; }

        public Guid? IdArticle { get; set; }
        public virtual Article? Article { get; set; }
    }
}
