using Review.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Review.Services
{
    public class EmployeeServices
    {
        private const string url = "";

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            RestClient<Employee> restClient = new RestClient<Employee>(url);
            var employees = await restClient.GetAsync();

            return employees;
        }
    }
}
