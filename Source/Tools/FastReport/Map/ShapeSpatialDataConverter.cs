using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace FastReport.Map
{
  internal class ShapeSpatialDataConverter : TypeConverter
  {
    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context,
      object value, Attribute[] attributes)
    {
      return TypeDescriptor.GetProperties(value, attributes);
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof(string))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        ShapeSpatialData data = new ShapeSpatialData();
        data.SetAsString((string)value);
        return data;
      }
      return base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string))
      {
        ShapeSpatialData data = value as ShapeSpatialData;
        if (data == null)
          return "";
        return data.GetAsString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}
