using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public static class EntityMapper
    {
        public static void MapFields<TEntity, TDto>(TEntity entity, TDto dto, params Expression<Func<TEntity, object>>[] propertySelectors)
            where TEntity : class
            where TDto : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (propertySelectors == null || !propertySelectors.Any()) throw new ArgumentException("At least one property selector must be provided.");

            foreach (var selector in propertySelectors)
            {
                // Extract the property name from the selector
                var memberExpression = (MemberExpression)selector.Body;
                var propertyName = memberExpression.Member.Name;

                // Get the value from the DTO
                var dtoProperty = typeof(TDto).GetProperty(propertyName);
                if (dtoProperty == null)
                {
                    throw new ArgumentException($"Property '{propertyName}' not found on DTO of type '{typeof(TDto).Name}'.");
                }

                var value = dtoProperty.GetValue(dto);

                // Set the value to the entity
                var entityProperty = typeof(TEntity).GetProperty(propertyName);
                if (entityProperty == null)
                {
                    throw new ArgumentException($"Property '{propertyName}' not found on entity of type '{typeof(TEntity).Name}'.");
                }

                if (entityProperty.CanWrite)
                {
                    if (entityProperty.PropertyType.IsAssignableFrom(dtoProperty.PropertyType))
                    {
                        entityProperty.SetValue(entity, value);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Property type mismatch for property '{propertyName}'.");
                    }
                }
            }
        }
    }
}
