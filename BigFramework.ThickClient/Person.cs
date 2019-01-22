using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFramework.ThickClient
{
  public class Person:INotifyPropertyChanged
    {

        public Person()
        {
            _firstname = "Nirav";
            _lastname = "Daraniya";
        }
        private string _firstname;
        public string FirstName
        {
            get { return _firstname ; }
            set 
            {
                _firstname = value;
                OnPropertyRaised("FirstName");
                OnPropertyRaised("FullName");
            }
        }

        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set 
            { 
                _lastname = value;
                OnPropertyRaised("LastName");
                OnPropertyRaised("FullName");
            }
        }


        private string _fullname;
        public string FullName
        {
            get { return _firstname + " "+_lastname; }
            set 
            { 
                _fullname = value;
                OnPropertyRaised("FullName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname)); 
            }
        }
    }

}
