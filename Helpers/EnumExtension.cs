using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Meta.IntroApp.Helpers
{
    public static class EnumExtension
    {
        public static string GetDisplayValue(Enum value, CultureInfo uiCulture = null)
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes[0].ResourceType != null)
                return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name, uiCulture ?? CultureInfo.CurrentUICulture);

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        public static List<SelectListItem> GetAsSelectList(Type type, string selectedValue = null)
        {
            return Enum.GetValues(type).Cast<object>().Select(c => new SelectListItem()
            {
                Value = c.ToString(),
                Text = GetDisplayValue((Enum)c),
                Selected = c.ToString() == selectedValue
            }).ToList();
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey, CultureInfo uiCulture = null)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey, uiCulture ?? CultureInfo.CurrentUICulture);
                }
            }
            return resourceKey; // Fallback with the key name
        }
    }
}