using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LambdaExample.Test
{
    [TestFixture]
    public class TestTrackingTag
    {
        private const string Path = "http://www.totaljobs.com";
        private const string Module = "twitter";

        [Test]
        public void ShouldAddPath()
        {
            var track = new WebTrackingTag();
            track.AddPath(Path);

            Assert.That(track.GetAllTags().Contains(Path), Is.True);
        }

        [Test]
        public void ShouldAddModule()
        {
            var track = new WebTrackingTag();
            track.AddPath(Path).AddModule(Module);

            Assert.That(track.GetAllTags().Contains(Module), Is.True);
        }

        [Test]
        public void ShouldAddPathWithGenericMethod()
        {
            var tracking = new WebTrackingTag();
            tracking.Add(x => x.Path, Path)
                .Add(x => x.Module, Module);


            Assert.That(tracking.GetAllTags().Contains(Path), Is.True);
            Assert.That(tracking.GetAllTags().Contains(Module), Is.True);

        }




    }
}
