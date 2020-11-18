using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gov_il
{
    [TestClass]
    public class TestCase
    {
        [TestMethod]
        public void CheckLanguageTitle()
        {
            GetApi getApi = new GetApi();
            getApi.GetLanguageTitle();
        }
    }
}
