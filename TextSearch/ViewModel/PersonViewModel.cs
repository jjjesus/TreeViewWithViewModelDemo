using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using BusinessLib;

namespace TreeViewWithViewModelDemo.TextSearch
{
    /// <summary>
    /// A UI-friendly wrapper around a Person object.
    /// </summary>
    public class PersonViewModel :  INotifyPropertyChanged
    {
        #region Data

        readonly ReadOnlyCollection<PersonViewModel> _children;
        readonly PersonViewModel _parent;
        readonly Person _person;

        bool _isExpanded;
        bool _isSelected;

        #endregion // Data

        #region Constructors

        public PersonViewModel(Person person)
            : this(person, null)
        {
        }

        private PersonViewModel(Person person, PersonViewModel parent)
        {
            _person = person;
            _parent = parent;

            _children = new ReadOnlyCollection<PersonViewModel>(
                    (from child in _person.Children
                     select new PersonViewModel(child, this))
                     .ToList<PersonViewModel>());
        }

        #endregion // Constructors

        #region Person Properties

        public ReadOnlyCollection<PersonViewModel> Children
        {
            get { return _children; }
        }

        public string Name
        {
            get { return _person.Name; }
        }

        #endregion // Person Properties

        #region Presentation Members

        #region IsExpanded

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;
            }
        }

        #endregion // IsExpanded

        #region IsSelected

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        #endregion // IsSelected

        #region NameContainsText

        public bool NameContainsText(string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(this.Name))
                return false;

            return this.Name.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) > -1;
        }

        #endregion // NameContainsText

        #region Parent

        public PersonViewModel Parent
        {
            get { return _parent; }
        }

        #endregion // Parent

        #endregion // Presentation Members        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}