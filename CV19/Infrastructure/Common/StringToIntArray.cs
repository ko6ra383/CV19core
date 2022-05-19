using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CV19.Infrastructure.Common
{
    [MarkupExtensionReturnType(typeof(int[]))]
    public class StringToIntArray : MarkupExtension
    {
        [ConstructorArgument("Str")]
        public string Str { get; set; }
        public char Separator { get; set; } = ';';
        public StringToIntArray(){}
        public StringToIntArray(string str)
        {
            Str = str;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) =>
            Str.Split(new[] {Separator}, StringSplitOptions.RemoveEmptyEntries)
                .DefaultIfEmpty()
                .Select(int.Parse)
                .ToArray();
        
    }
}
