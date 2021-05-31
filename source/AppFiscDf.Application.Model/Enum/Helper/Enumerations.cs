using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AppFiscDf.Application.Model.Enum.Helper
{
    public static class Enumerations
    {
        public static string GetDescription(System.Enum value)
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
        }
    }
}