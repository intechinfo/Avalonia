using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI_UITest.Models
{
    public class DataGenerator
    {
        private static Random random = new Random();
        public static List<TestProject> GenerateProjects()
        {
            List<TestProject> projects = new List<TestProject>();
            for (int i = 0; i < 4; i++)
            {
                TestProject p = new TestProject(RandomString(5));
                p.SetChlidren(GenerateClasses(p));
                projects.Add(p);
            }
            return projects;
        }
        public static IReadOnlyList<TestModel> GenerateClasses(TestProject project)
        {
            List<TestClass> classList = new List<TestClass>();
            for (int i = 0; i < 4; i++)
            {
                TestClass c = new TestClass(project, RandomString(8));
                c.SetChlidren(GenerateMethods(c));
                classList.Add(c);
            }
            return classList;
        }
        public static IReadOnlyList<TestModel> GenerateMethods(TestClass @class)
        {
            List<TestMethod> methods = new List<TestMethod>();
            for (int i = 0; i < 4; i++)
            {
                
                if (i < 2)
                {
                    TestMethod m = new TestMethod(@class, RandomString(8));
                    methods.Add(m);
                    m.SetChlidren(GenerateCase(m));
                }
                else
                {
                    TestMethod m = new TestMethod(@class, RandomString(8), true);
                    methods.Add(m);
                }
            }
            return methods;
        }

        private static IReadOnlyList<TestModel> GenerateCase(TestMethod m)
        {
            List<TestCase> cases = new List<TestCase>(); 
            for (int i = 0; i < 5; i++)
            {
                TestCase c;
                if (i < 0)
                    c = new TestCase(m, RandomString(5), false);
                else
                    c = new TestCase(m, RandomString(5), true);
                cases.Add(c);
            }
            return cases;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZazertyuiopqsdfghjklmwxcvbn";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
