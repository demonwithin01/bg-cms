using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework
{
    
    
    public static class AutoMap
    {

        public static void Map<TSource, TDestination>( TSource source, TDestination destination )
        {

            Type sourceType = ObjectContext.GetObjectType( source.GetType() );
            Type destinationType = ObjectContext.GetObjectType( destination.GetType() );

            Mapper.CreateMap( sourceType, destinationType ).IgnoreProperties( destinationType ).MapToMembers( sourceType, destinationType ).MapFromMembers( sourceType, destinationType );
            Mapper.Map( source, destination );

        }

        public static IMappingExpression IgnoreProperties( this IMappingExpression expression, Type mappingType )
        {

            var properties = mappingType.GetProperties().Where( p => p.GetCustomAttributes( typeof( AutoMapIgnoreAttribute ), true ).OfType<AutoMapIgnoreAttribute>().Count() > 0 );

            foreach ( PropertyInfo property in properties )
            {
                expression.ForMember( property.Name, opt => opt.Ignore() );
            }

            return expression;

        }

        public static IMappingExpression MapToMembers( this IMappingExpression expression, Type source, Type destination )
        {

            var properties = source.GetProperties().Where( p => p.GetCustomAttributes( typeof( MapsToAttribute ), true ).OfType<MapsToAttribute>().Count() > 0 );

            foreach ( PropertyInfo property in properties )
            {
                expression.ForMember( property.GetCustomAttributes( typeof( MapsToAttribute ), true ).OfType<MapsToAttribute>().First().MapsTo, opt => opt.MapFrom( property.Name ) );
            }

            return expression;

        }

        public static IMappingExpression MapFromMembers( this IMappingExpression expression, Type source, Type destination )
        {

            var properties = destination.GetProperties().Where( p => p.GetCustomAttributes( typeof( MapsFromAttribute ), true ).OfType<MapsFromAttribute>().Count() > 0 );

            foreach ( var property in properties )
            {
                expression.ForMember( property.Name, opt => opt.MapFrom( property.GetCustomAttributes( typeof( MapsFromAttribute ), true ).OfType<MapsFromAttribute>().First().MapsFrom ) );
            }

            return expression;

        }

    }

}
