using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindingLists
{
    public class Employee : INotifyPropertyChanged
    {
        private String name = String.Empty;
        public String Name { 
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private String title = String.Empty;
        public String Title {
            get
            {
                return title;
            }
            set 
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public static Employee GetEmployee()
        {
            return new Employee()
                {
                    Name = "Tom",
                    Title = "Developer"
                };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged([CallerMemberName] String caller="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public static ObservableCollection<Employee> GetEmployees()
        {
            return new ObservableCollection<Employee>
            {
                new Employee { Name = "Washington", Title = "President 1"},
                new Employee { Name = "Adams", Title = "President 2"},
                new Employee { Name = "Jefferson", Title = "President 3"},
                new Employee { Name = "Medison", Title = "President 4"},
                new Employee { Name = "Monroe", Title = "President 5"}
            };
        }


    }
}
