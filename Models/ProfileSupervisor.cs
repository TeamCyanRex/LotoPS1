using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.Models
{
    internal class ProfileSupervisor
    {
        public FormattedModel model = new();
        public ProfileSupervisor(PrimitiveModel primitiveModel) {
            model.welcomeModel = primitiveModel.welcomeModel;
            model.aliasesModel = primitiveModel.aliasesModel;
        }
        public string ToFormattedCode(){
            return model.welcomeModel.ToString() + "\n" + model.aliasesModel.ToString();
        }
    }
}
