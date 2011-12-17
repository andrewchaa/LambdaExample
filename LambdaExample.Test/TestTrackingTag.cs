using LambdaExample.Domain;
using NUnit.Framework;

namespace LambdaExample.Test
{
    [TestFixture]
    public class TestTrackingTag
    {
        private const string Path = "http://www.totaljobs.com";
        private const string Twitter = "twitter";
        private const string Facebook = "facebook";

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
            track.AddPath(Path)
                .AddModule(Twitter);

            Assert.That(track.GetAllTags().Contains(Twitter), Is.True);
        }

        [Test]
        public void ShouldAddPathWithGenericMethod()
        {
            var tracking = new WebTrackingTag();
            tracking.Add(x => x.Path, Path)
                .Add(x => x.Module, Facebook);

            Assert.That(tracking.GetAllTags().Contains(Path), Is.True);
            Assert.That(tracking.GetAllTags().Contains(Facebook), Is.True);

        }




    }
}
