using System.Windows.Controls;
using BusinessLib;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    public partial class LoadOnDemandDemoControl : UserControl
    {
        public LoadOnDemandDemoControl()
        {
            InitializeComponent();

            Region[] regions = Database.GetRegions();
            CountryViewModel viewModel = new CountryViewModel(regions);
            base.DataContext = viewModel;
        }
    }
}