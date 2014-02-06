using BusinessLib;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    public class RegionViewModel : TreeViewItemViewModel
    {
        readonly Region _region;

        public RegionViewModel(Region region) 
            : base(null, true)
        {
            _region = region;
        }

        public string RegionName
        {
            get { return _region.RegionName; }
        }

        protected override void LoadChildren()
        {
            if (_region.RegionName == "Midwest")
            {
                foreach (City city in Database.GetIndianaCities())
                    base.Children.Add(new CityViewModel(city, null));
            }
            else if (_region.RegionName == "Northeast")
            {
                foreach (State state in Database.GetStates(_region))
                    base.Children.Add(new StateViewModel(state, this));
                foreach (City city in Database.GetMaineCities())
                    base.Children.Add(new CityViewModel(city, null));
            }
        }
    }
}