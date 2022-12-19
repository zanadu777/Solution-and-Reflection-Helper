using System;
using System.Collections.Generic;
using System.Text;

namespace TestShared
{
  public class WithProperties
  {
    public int? NullableInt { get; set; }

    private string publicNameOnlySet;
    public string PublicName { get; set; }

    public string PublicNameOnlySet
    {
      set => publicNameOnlySet = value;
    }

    public string PublicNameOnlyGet { get; }
    private string PrivateName { get; set; }
    protected string ProtectedName { get; set; }
    internal string InternalName { get; set; }
    public string PublicNameWithPrivateSet { get; private set; }
    public string PublicNameWithPrivateGet { private get; set; }
    public string PublicNameWithProtectedSet { get; protected set; }
    public string PublicNameWithProtectedGet { protected get; set; }
    public string PublicNameWithInternalSet { get; internal set; }
    public string PublicNameWithInternalGet { internal get; set; }
    internal string InternalNameWithPrivateSet { get; private set; }
    internal string InternalNameWithPrivateGet { private get; set; }
    protected string ProtectedNameWithPrivateSet { get; private set; }
    protected string ProtectedNameWithPrivateGet { private get; set; }

    
  }
}
