using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.TestModels
{
    public enum TestEnumModel
    {
        [Description("Ok")]
        Ok = 1,
        Error = 400
    }
}
