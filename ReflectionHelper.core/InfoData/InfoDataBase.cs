namespace ReflectionHelper.core.InfoData
{
  public abstract  class InfoDataBase
  {
    public string Name { get; set; }
    public string? NameSpace { get; set; }

    public string Visibility { get; set; }

    public abstract string Declaration { get; }
  }
}
