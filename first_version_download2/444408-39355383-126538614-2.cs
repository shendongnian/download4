    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.Mvc;
    namespace App.Extensions
    {
        public static class EnumExtensions
        {
            public static SelectList ToSelectList(Type enumType)
            {
                return new SelectList(ToSelectListItems(enumType));
            }
            public static List<SelectListItem> ToSelectListItems(Type enumType, Func<object, bool> itemSelectedAction = null)
            {
                var arr = Enum.GetValues(enumType);
                return (from object item in arr
                        select new SelectListItem
                        {
                            Text = ((Enum)item).GetDescriptionEx(),
                            Value = ((int)item).ToString(),
                            Selected = itemSelectedAction != null && itemSelectedAction(item)
                        }).ToList();
            }
        
            public static string GetDescriptionEx(this Enum @this)
            {
                // If no DescriptionAttribute is present, set string with following name
                // "Enum_<EnumType>_<EnumValue>" to be the default value.
                // Could also make some code to load value from resource.
                var defaultResult = $"Enum_{@this.GetType().Name}_{@this}";
                var fi = @this.GetType().GetField(@this.ToString());
                if (fi == null)
                    return defaultResult;
                var customAttributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (customAttributes.Length <= 0 || customAttributes.IsNot<DescriptionAttribute[]>())
                {
                    return defaultResult;
                }
                var attributes = (DescriptionAttribute[])customAttributes;
                var result = attributes.Length > 0 ? attributes[0].Description : defaultResult;
                return result ?? defaultResult;
            }
            public static bool IsNot<T>(this object @this)
            {
                return !(@this is T);
            }
        }
    }
