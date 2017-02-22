using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Project.Common
{
    public class AliasAttribute : Attribute
    {

        private string _alias;
        public AliasAttribute(string _alias)
        {
            this._alias = _alias;
        }
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

        public static string  EnumAlias(System.Enum _enum)
        {

            Type type = _enum.GetType();
            FieldInfo fd = type.GetField(_enum.ToString());
            if (fd == null) return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(AliasAttribute), false);
            string name = string.Empty;
            foreach (AliasAttribute attr in attrs)
            {
                name = attr.Alias;
            }
            return name;
        }

      
    }
}
