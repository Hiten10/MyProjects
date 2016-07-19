using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcUnityGenericRepositryDIUow;
using MvcUnityGenericRepositryDIUow.Controllers;
using MvcUnityGenericRepositryDIUow.Service;
using MvcUnityGenericRepositryDIUow.Models;
using Moq;
using System.Data.Entity;
using MvcUnityGenericRepositryDIUow.DAL;

namespace MvcUnityGenericRepositryDIUow.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {        
        private Mock<IService<Student>> _studentMock;
        private HomeController _controller;
        private List<Student> _students;
        [TestInitialize]
        public void Init()
        {
            _studentMock = new Mock<IService<Student>>();
            _students = new List<Student>
            {
                new Student { Name = "Test1", StudentID = 100, Email = "s@c.com", EnrollYear = "2016", City = "Pune", Class = "10", Country = "India" },
                new Student { Name = "Test2", StudentID = 101, Email = "s@c.com", EnrollYear = "2016", City = "Pune", Class = "11", Country = "India" },
                new Student { Name = "Test3", StudentID = 102, Email = "s@c.com", EnrollYear = "2016", City = "Pune", Class = "12", Country = "India" }
            };
        }

        [TestMethod]
        public void Index()
        {
            // Arrange           
            _controller = new HomeController(_studentMock.Object);
           
            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
             _controller = new HomeController(_studentMock.Object);

            // Act
            ViewResult result = _controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            _controller = new HomeController(_studentMock.Object);

            // Act
            ViewResult result = _controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NewStudent()
        {

            Mock<IGenericRepository<Student>> mock1 = new Mock<IGenericRepository<Student>>();
            mock1.Setup(m => m.Get()).Returns(_students);

            //mock1.Setup(m => m.Insert(It.IsAny<Student>())).Returns((Student target) =>
            //    {
            //        var original = _students.FirstOrDefault(q => q.StudentID == target.StudentID);

            //        if (original != null)
            //        {
            //            return false;
            //        }

            //        _students.Add(target);
            //        return true;
            //    });

            mock1.Setup(m => m.Insert(It.IsAny<Student>())).Callback<Student>(c => _students.Add(c));

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            //mock.SetupProperty(m => m.MyRepo<Student>()).SetReturnsDefault(mock1.Object);
            mock.Setup(m => m.MyRepo<Student>()).Returns(mock1.Object);

            Service<Student> service = new Service<Student>(mock.Object);
            service.Add(new Student{StudentID=104,Name="Test4", City="Pune", Class="12", Country="India", EnrollYear="2016", Email=""});

            var result = service.Get();
            var newStudent = result.FirstOrDefault(t => t.StudentID == 104);

            Assert.AreEqual(_students.Count(), result.Count());
            Assert.AreEqual("Test4",newStudent.Name );
            Assert.AreEqual("", newStudent.Email);
        }

        [TestMethod]
        public void GetAll()
        {
            List<Student> s = new List<Student>
            {
                 new Student
            {
                Name = "Test",
                StudentID = 100,
                Email = "s@c.com",
                EnrollYear = "2016",
                City = "Pune",
                Class = "10",
                Country = "India"
            }
            };
            _studentMock.Setup(o => o.Get()).Returns(s).Verifiable();
            _controller = new HomeController(_studentMock.Object);


            ViewResult result = _controller.Students() as ViewResult;
        }
    }
}
