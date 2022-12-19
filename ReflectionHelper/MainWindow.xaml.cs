using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReflectionHelper.core.Extensions;
using ReflectionHelper.core.Extensions.Info;
using ReflectionHelper.core.Extensions.InfoData;
using ReflectionHelper.core.Generators;
using ReflectionHelper.core.InfoData;

namespace ReflectionHelper
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    public ObservableCollection<TypeInfo> Types { get; set; } = new ObservableCollection<TypeInfo>();
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var netLib = @"D:\Dev\Programming 2022\ReflectionHelper.Wpf\NetTestClassLibrary\bin\Debug\net6.0\NetTestClassLibrary.dll";
      var frameworkLib =
        @"D:\Dev\Programming 2022\ReflectionHelper.Wpf\NetFrameworkTestClassLibrary\bin\Debug\NetFrameworkTestClassLibrary.dll";
      var a = Assembly.LoadFrom(frameworkLib);
      var types = a.GetTypes();
      foreach (var t in types)
      {
        var info = t.GetTypeInfo();
        Types.Add(info);
      }
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      TypeInfo t = (TypeInfo) ((ListView) sender).SelectedValue;
      var tData = new TypeInfoData(t);
      var nonPublicProperties = tData.Properties.GetSetMethods().NonPublic();
      var generator = new CallNonPublicGenerator();
      txtTypeInfoData.Text = generator.Generate(nonPublicProperties).LineJoin();
      txtTypeInfo.Text = t.DeclarationReport();
    }
  }
}
