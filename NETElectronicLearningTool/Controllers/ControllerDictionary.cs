using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.Controllers
{
    public class ControllerDictionary
    {

        IEnumerable<MethodDiscription> methodDiscriptions;

        public ControllerDictionary(IEnumerable<MethodDiscription> methodDiscriptions)
        {
            this.methodDiscriptions = methodDiscriptions;
        }

        MethodDiscription? currentMethod;

        public string NameFunction
        {
            get
            {
                return currentMethod.NameClass+"."+ currentMethod.NameFunction;
            }
        }
        public string Discription
        {
            get 
            { 
                return currentMethod.DiscriptionFunction; 
            }
        }

        public IEnumerable<MethodDiscription> ListMethod
        {
            get
            {
                return methodDiscriptions;
            }
        }
        public IEnumerable<MethodDiscription> Filter (string name)
        {
            return methodDiscriptions.Where(x => x.NameFunction.StartsWith(name)).ToList();
        }
        public void ChangeFunction(MethodDiscription methodDiscription)
        {
            currentMethod = methodDiscription;
        }
        public void ChangeFunction(Guid methodDiscription)
        {
            currentMethod = methodDiscriptions.First(x=>x.Id==methodDiscription);
        }
    }
}
