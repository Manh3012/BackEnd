﻿using BAL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace xUnitTest.Attributes
{
    public class SyllabusJsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;

        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        public SyllabusJsonFileDataAttribute(string filePath)
        {
            _filePath = filePath;
        }


        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(_filePath);
            List<SyllabusViewModel> syllabus = JsonConvert.DeserializeObject<List<SyllabusViewModel>>(fileData);

            var objects = new List<object[]>();
            foreach (var obj in syllabus)
            {
                objects.Add(new object[] { obj });
            }

            return objects;

        }
    }
}
