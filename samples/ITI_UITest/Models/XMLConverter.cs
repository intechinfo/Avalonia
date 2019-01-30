using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ITI_UITest.Models
{
    public class XMLConverter
    {
        List<TestProject> _projects = new List<TestProject>();
        bool _isOnMethod;
        public UITestModel CreateUITestModel(string xmlPath)
        {
            ReadXlm(xmlPath);
            return new UITestModel(_projects);
        }
        private void ReadXlm(string xmlPath)
        {
            using (XmlReader reader = XmlReader.Create(xmlPath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "A":
                                _projects.Add(new TestProject(reader["Name"]));
                                break;
                            case "F":
                                _projects.Last().AddChild(new TestClass(_projects.First(), reader["Name"]));
                                _isOnMethod = false;
                                break;
                            case "M":
                                _projects.Last().Children.Last().AddChild(new TestMethod(_projects.Last().Children.Last() as TestClass, reader["Name"]));
                                _isOnMethod = true;
                                break;
                            case "C":
                                if(reader["Kind"] != "TestCase")
                                    _projects.Last().Children.Last().Children.Last().AddChild(new TestCase(_projects.Last().Children.Last().Children.Last() as TestMethod, reader["Name"], null));
                                break;
                            case "Runs":
                                if (_isOnMethod && !reader.IsEmptyElement && reader["Skip"] == null)
                                    (_projects.Last().Children.Last().Children.Last() as TestMethod).Run(true);
                                break;
                            case "Console":
                                (_projects.Last().Children.Last().Children.Last() as TestMethod).SetConsoleResult(reader.Value);
                                break;
                            case "Exception":
                                if (reader["Message"] != null)
                                    (_projects.Last().Children.Last().Children.Last() as TestMethod).SetErrorsResult(reader["Message"] + Environment.NewLine + reader["Type"]);
                                break;
                            case "Stack":
                                (_projects.Last().Children.Last().Children.Last() as TestMethod).SetErrorsResult(reader.Value);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
