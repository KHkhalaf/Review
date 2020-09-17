using Review.Models;
using Review.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Review.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Employee> _employees;
        public List<Employee> employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public EmployeeViewModel()
        {
            _ = InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var employeeServices = new EmployeeServices();
            employees = await employeeServices.GetEmployeesAsync();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
