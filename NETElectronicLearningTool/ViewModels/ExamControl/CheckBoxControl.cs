using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels.ExamControl
{
    public class CheckBoxControl:BaseControl
    {
        public override (string, bool) GetData()
        {
            return base.GetData().Item1 == "" ? (id.ToString(),isSelected):("", false);
        }

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

        public CheckBoxControl(Guid id, string name,bool isSelected)
        {
            Id = id;
            Name = name;
            IsSelected = isSelected;
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
        private bool isSelected;

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
            }
        }

    }
}
