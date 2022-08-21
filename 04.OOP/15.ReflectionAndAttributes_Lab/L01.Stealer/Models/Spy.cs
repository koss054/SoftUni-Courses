namespace Stealer
{ 
    using System;
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


            return result.ToString().Trim();
        }
    }
}
