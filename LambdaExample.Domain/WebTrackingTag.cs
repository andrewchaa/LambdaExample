using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaExample.Domain
{
    public class WebTrackingTag
    {
        private Tag _trackingTag = new Tag();

        public string GetAllTags()
        {
            var properties = _trackingTag.GetType().GetProperties();
            if (properties.Length == 0)
                return string.Empty;

            string tagValue = "?webtracking=true";

            foreach (var property in properties)
            {
                string name = property.Name.ToLower();
                string value = (string)property.GetValue(_trackingTag, null);
                if (string.IsNullOrEmpty(value))
                    continue;

                tagValue += string.Format("&{0}={1}", name, value);
            }

            return tagValue;
        }

        public WebTrackingTag AddPath(string path)
        {
            _trackingTag.Path = path;

            return this;
        }

        public WebTrackingTag AddModule(string module)
        {
            _trackingTag.Module = module;

            return this;
        }

        public WebTrackingTag Add(Expression<Func<Tag, string>> tag, string value)
        {
            var propertyInfo = (tag.Body as MemberExpression).Member as PropertyInfo;
            propertyInfo.SetValue(_trackingTag, value, null);

            return this;
        }
    }
}
