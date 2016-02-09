using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    
    public abstract class Property
    {

        public static string GetName<T>( Expression<Func<T>> propertyLambda )
        {

            MemberExpression member = propertyLambda.Body as MemberExpression;

            
            if( member == null )
            {
                throw new ArgumentException( "You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'" );
            }

            return ( member.Member.Name );

        }

    }

}
