using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Communication_Net45.Test.Core.Transfer
{
    [TestClass]
    public class ReverseWordTransformTest2 : ReverseWordTransformTest
    {
        public ReverseWordTransformTest2( )
        {
            byteTransform.DataFormat = Communication.Core.DataFormat.BADC;
        }



    }
}
