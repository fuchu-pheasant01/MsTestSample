using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace MsTestSample
{
    public interface ISampleClass
    {
        public int Kingaku(int su);

        public string Shohin { get; set; }

        public void ThrowUp();
    }
}
