using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LambdaExample.Test
{
    [TestFixture]
    public class TestWebTrendsTag
    {
        [Test]
        public void ShouldAddCurrentPath()
        {
            var webTrends = new WebTrendsTag();
            string tag = webTrends.GetAllTags();

            Assert.That(tag, Is.EqualTo(string.Empty));
        }
    }
}
