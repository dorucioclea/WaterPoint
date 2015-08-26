using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.FluentNhibernateMappingCreator
{
    class Program
    {
        private static void Main(string[] args)
        {
            var entities = Assembly.Load("WaterPoint.Data.Entity")
                .GetTypes()
                .Where(i => i.IsClass && i.Namespace == "WaterPoint.Data.Entity.DataEntities");

            const string applicationPath = @"C:\Nihao\WaterPoint\WaterPoint.Data.DbContext.NHibernate";

            var mappingPath = string.Format(@"{0}\Mappings", applicationPath);

            var projFilePath = string.Format(@"{0}\WaterPoint.Data.DbContext.NHibernate.csproj", applicationPath);
            using (var trans = new TransactionScope())
            {
                try
                {
                    var proj = XDocument.Load(projFilePath);

                    var names = proj.Root.Name.Namespace;

                    var changed = false;

                    foreach (var t in entities)
                    {
                        CreateFiles(t, mappingPath);

                        var itemGroups = proj.Descendants(names + "ItemGroup");

                        var itemGroup = itemGroups.FirstOrDefault(i => i.Elements(names + "Compile").Any());

                        var compile = itemGroup.Elements(names + "Compile")
                            .FirstOrDefault(
                                i => i.Attribute("Include").Value == string.Format("Mappings\\{0}Map.cs", t.Name));

                        if (compile != null)
                            compile.Remove();

                        var element = new XElement(names + "Compile");
                        element.Add(new XAttribute("Include", string.Format("Mappings\\{0}Map.cs", t.Name)));

                        itemGroup.Add(element);

                        if (!changed)
                            changed = true;
                    }

                    if (changed)
                        proj.Save(projFilePath);

                    trans.Complete();
                }
                catch
                {
                    trans.Dispose();
                }
            }
        }

        private static void CreateFiles(Type t, string mappingPath)
        {
            var fileName = string.Format(@"{0}\{1}Map.cs", mappingPath, t.Name);
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var textWriter = new StreamWriter(fileName, true))
            {
                textWriter.WriteLine(@"using FluentNHibernate.Mapping;");
                textWriter.WriteLine(@"using WaterPoint.Data.Entity.DataEntities;");
                textWriter.WriteLine();
                textWriter.WriteLine(@"namespace WaterPoint.Data.DbContext.NHibernate.Mappings");
                textWriter.WriteLine(@"{");
                textWriter.WriteLine(@"    public class {0}Map : ClassMap<{0}>", t.Name);
                textWriter.WriteLine(@"    {");
                textWriter.WriteLine(@"        public {0}Map()", t.Name);
                textWriter.WriteLine(@"        {");

                foreach (var property in t.GetProperties())
                {
                    var isIdentity = property.GetCustomAttribute(typeof(IdentityAttribute), false) != null;

                    textWriter.WriteLine(@"            {1}(x => x.{0});", property.Name,
                        isIdentity ? "Id" : "Map");
                }

                textWriter.WriteLine(@"        }");
                textWriter.WriteLine(@"    }");
                textWriter.WriteLine(@"}");
            }

        }

    }
}