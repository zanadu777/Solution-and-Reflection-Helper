using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using SolutionHelper.Core.Extensions;
using SolutionHelper.Core.Vs;

namespace SolutionHelper
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

    private void btAnalyzeSolution_Click(object sender, RoutedEventArgs e)
    {
      var soln = new VsSolution(new FileInfo(txtSolutionPath.Text));
      var projects = soln.FrameworkProjects;
      var refs = projects.DistinctReferences().ToList();

      foreach (var r in projects[0].References)
      {
        Debug.WriteLine(r.HintPath);
      }
    }

  }
}
