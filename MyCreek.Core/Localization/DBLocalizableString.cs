using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MyCreek.Localization
{
    public class DBLocalizableString : ILocalizableString
    {
        /// <summary>
        /// Unique name of the localization source.
        /// </summary>
        public virtual string SourceName { get; private set; }

        /// <summary>
        /// Unique Name of the string to be localized.
        /// </summary>
        public virtual string Name { get; private set; }

        /// <summary>
        /// Needed for serialization.
        /// </summary>
        public DBLocalizableString(string name)
        {
            Name = name;
        }
        public string Localize(ILocalizationContext context)
        {
            return this.Name;
        }

        public string Localize(ILocalizationContext context, CultureInfo culture)
        {
            return this.Name;
        }
    }
}
