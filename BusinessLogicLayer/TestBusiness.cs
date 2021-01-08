using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TestBusiness
    {
        public static void AddTest(Test test)
        {
            TestDAL.AddTest(test);
        }
        public static void DeleteTest(Test test)
        {
            TestDAL.DeleteTest(test);
        }

        public static Test GetTest(string key)
        {
            return TestDAL.GetTest(key);
        }
        public static Test GetTest(int id)
        {
            return TestDAL.GetTest(id);
        }
        public static List<Test> GetTestList(int id)
        {
            return TestDAL.GetTestList(id);
        }
        public static List<Test> GetAllTestList()
        {
            return TestDAL.GetTestList();
        }
    }
}
