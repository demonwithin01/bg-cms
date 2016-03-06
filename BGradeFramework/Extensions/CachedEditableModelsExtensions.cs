using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework
{
    public static class CachedEditableModelsExtensions
    {
        public static SelectList AsSelectList( this Dictionary<string, CachedEditableModel> list, string selectedValue )
        {
            var selectList = list.Select( s => new
            {
                Value = s.Value.ModelName,
                Text = s.Value.ModelName.HumanReadable()
            } );

            return new SelectList( selectList, "Value", "Text", selectedValue );
        }
    }
}
