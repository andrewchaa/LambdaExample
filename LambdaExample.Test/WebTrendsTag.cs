using System.Collections;
using System.Collections.Generic;

namespace LambdaExample.Test
{
    public class WebTrendsTag
    {
        private IList<Tag> tags = new List<Tag>();

        public void AddPath(string path)
        {
            tags.Add(new Tag { Key = "path", Value = path });
        }

        public string GetAllTags()
        {
            if (tags.Count == 0)
                return string.Empty;

            string tagValue = "?webtrends=true";
            foreach (var tag in tags)
            {
                tagValue += string.Format("&{0}={1}", tag.Key, tag.Value);
            }

            return tagValue;
        }
    }

    public class Tag
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
