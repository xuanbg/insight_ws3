using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security;

namespace FastReport.Code
{
  internal class ExpressionDescriptor
  {
    private string FMethodName;
    private MethodInfo FMethodInfo;
    private AssemblyDescriptor FAssembly;
    
    public string MethodName
    {
      get { return FMethodName; }
      set { FMethodName = value; }
    }
    
    public object Invoke(object[] parameters)
    {
      if (FAssembly == null || FAssembly.Instance == null)
        return null;
      if (FMethodInfo == null)
        FMethodInfo = FAssembly.Instance.GetType().GetMethod(MethodName, BindingFlags.Instance | BindingFlags.NonPublic);
      if (FMethodInfo == null)
        return null;
      
      PermissionSet restrictions = FAssembly.Report.ScriptRestrictions;
      if (restrictions != null)
        restrictions.PermitOnly();
      try
      {
        return FMethodInfo.Invoke(FAssembly.Instance, parameters);
      }
      finally
      {
        if (restrictions != null)
          CodeAccessPermission.RevertPermitOnly();
      }  
    }
    
    public ExpressionDescriptor(AssemblyDescriptor assembly)
    {
      FAssembly = assembly;
    }
  }
}
