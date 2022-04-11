using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTest.Model;

namespace MVCTest.DB.DbOperation
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new MyDBEntities())
            {
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Code = model.Code,

                };

                if (model.Address != null)
                {
                    emp.Address = new Address()
                    {
                        Details = model.Address.Details,
                        State = model.Address.State,
                        Country = model.Address.Country
                    };
                }
                context.Employee.Add(emp);
                context.SaveChanges();
                return emp.Id;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new MyDBEntities())
            {
                var result = context.Employee
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Id,
                        AddressId = x.AddressId,
                        Code = x.Code,
                        Email = x.Email,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Address = new AddressModel()
                        {
                            Id = x.Address.Id,
                            Details = x.Address.Details,
                            Country = x.Address.Country,
                            State = x.Address.State
                        }
                    }).ToList();

                return result;
            }
        }

        public EmployeeModel GetSingleEmp(int id)
        {

            using (var context = new MyDBEntities())
            {
                var result = context.Employee
                    .Where(x => x.Id == id)
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Id,
                        AddressId = x.AddressId,
                        Code = x.Code,
                        Email = x.Email,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Address = new AddressModel()
                        {
                            Id = x.Address.Id,
                            Details = x.Address.Details,
                            Country = x.Address.Country,
                            State = x.Address.State
                        }
                    }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateEmp(int id, EmployeeModel model)
        {
            using (var context = new MyDBEntities())
            {
                var getemp = context.Employee.FirstOrDefault(x => x.Id == id);

                if (getemp != null)
                {
                    getemp.FirstName = model.FirstName;
                    getemp.LastName = model.LastName;
                    getemp.Email = model.Email;
                    getemp.Code = model.Code;

                    getemp.Address.Details = model.Address.Details;
                    getemp.Address.Country = model.Address.Country;
                    getemp.Address.State = model.Address.State;

                }
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmp(int id)
        {
            using (var context = new MyDBEntities())
            {
                var emp = context.Employee.FirstOrDefault(x => x.Id == id);
                if(emp!=null)
                {
                    context.Employee.Remove(emp);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}