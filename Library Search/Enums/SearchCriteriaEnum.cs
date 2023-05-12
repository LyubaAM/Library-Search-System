using Library_Search.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SearchCriteriaEnum
    {
        [Description("Title & Author")]
        TitleAuthor,
        [Description("Advanced Search")]
        AdvancedSearch
    }
}
