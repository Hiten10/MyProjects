using MvcUnityGenericRepositryDIUow.Models;
using MvcUnityGenericRepositryDIUow.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcUnityGenericRepositryDIUow.Controllers
{
    public class ValueController : ApiController
    {
        private IService<Student> service;
        private List<Student> _students;

        public ValueController()
        {           
            _students = new List<Student>
            {
                new Student{StudentID=1,Name="Student1",Email="s1@school.com",EnrollYear="2016",City="Pune",Country="India", Class="10"},
                new Student{StudentID=2,Name="Student2",Email="s2@school.com",EnrollYear="2016",City="Pune",Country="India", Class="10"},
                new Student{StudentID=3,Name="Student3",Email="s3@school.com",EnrollYear="2016",City="Pune",Country="India", Class="10"},
                new Student{StudentID=4,Name="Student4",Email="s4@school.com",EnrollYear="2016",City="Pune",Country="India", Class="10"}
            };
        }

        public ValueController(IService<Student> service)
        {            
            this.service = service; 
        }
        // GET api/value
        public IEnumerable<Student> Get()
        {
            service.ExtensionMethod();
            //return service.Get();
            return _students;
        }

        // GET api/value/5
        public Student GetStudent(int id)
        {            
            //return service.FindByID(id); ;

            return _students.Find(s=>s.StudentID.Equals(id));
        }

        // POST api/value
        public IEnumerable<Student> Post(Student student)
        {
            //if(service.FindByID(student.StudentID)!= null)
            //{
            //    service.Add(student);
            //}
            //else
            //{
            //    service.Update(student);
            //} 
            //return service.Get();
            _students.Add(student);
            return _students;            
        }

        // PUT api/value/5
        public void Put(int id, [FromBody]string value)
        {
            // Insert/Update both handled in above Post method.
        }

        // DELETE api/value/5
        public IEnumerable<Student> Delete(int id)
        {
            //_students.Remove(_students.Find(s => s.StudentID.Equals(id)));
            //return _students;

            service.Delete(id);
            return service.Get();
        }
    }
}
