using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] objProperty = objType.GetProperties();

            foreach (PropertyInfo property in objProperty)
            {
                object propertyValue = property.GetValue(obj);

                foreach (CustomAttributeData attributeData in property.CustomAttributes)
                {
                    Type attributeType = attributeData.AttributeType;
                    object attributeObjInstance = property.GetCustomAttribute(attributeType);

                    MethodInfo attributeMethod = attributeType.GetMethods().FirstOrDefault(x => x.Name == "IsValid");
                    bool result = (bool)attributeMethod.Invoke(attributeObjInstance, new object[] { propertyValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
