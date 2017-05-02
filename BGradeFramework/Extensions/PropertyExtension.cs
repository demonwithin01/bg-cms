using System;
using System.Linq.Expressions;

namespace ContentManagementSystem.Framework
{
    // TODO: Find use or remove.
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
