namespace Stealer
{ 
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        private Type classType;
        private StringBuilder result;

        public Spy()
        {
            this.result = new StringBuilder();
        }

        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            this.classType = Type.GetType(classToInvestigate);

            this.result.AppendLine($"Class under investigation: {this.classType}");

            Object classInstance = Activator.CreateInstance(this.classType);

            foreach(var field in fieldsToInvestigate)
            {
                FieldInfo fieldInfo = this.classType.GetField(field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (fieldInfo != null)
                {
                    this.result.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
                }
            }


            return this.result.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            this.classType = Type.GetType(className);
            var fieldsInfo = this.classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            foreach (var fieldInfo in fieldsInfo)
            {
                if (!fieldInfo.IsPrivate)
                {
                    this.result.AppendLine($"{fieldInfo.Name} must be private!");
                }
            }

            var nonPublicMethods = this.classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var nonPublicMethod in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                this.result.AppendLine($"{nonPublicMethod.Name} have to be public");
            }

            var publicMethods = this.classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (MethodInfo publicMethod in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                this.result.AppendLine($"{publicMethod.Name} have to be private!");
            }

            return this.result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            this.classType = Type.GetType(className);
            this.result.AppendLine($"All Private Methods of Class: {classType}");

            Type baseType = this.classType.BaseType;
            this.result.AppendLine($"Base Class: {baseType.Name}");

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var privateMethod in privateMethods)
            {
                result.AppendLine(privateMethod.Name);
            }

            return this.result.ToString().TrimEnd();
        }
    }
}
