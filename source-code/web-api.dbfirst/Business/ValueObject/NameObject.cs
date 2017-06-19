using System;
using System.Linq;
using Interface;
using UtilityServices.ConstantValue;

namespace Business.ValueObject
{
    public class NameObject : IValidator
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(FirstName);
        }

        public string GetFullName()
        {
            return Title + Characters.Separating + FirstName + Characters.Separating + LastName;
        }

        public NameObject FromFullName(string fullName)
        {
            if (fullName.IndexOf(Characters.Separating, StringComparison.Ordinal) < 0)
            {
                return new NameObject()
                {
                    FirstName = fullName
                };
            }

            var fullNames = fullName.Split(new [] {Characters.Separating}, StringSplitOptions.RemoveEmptyEntries);
            return new NameObject()
            {
                Title = fullNames[0],
                FirstName = fullNames[1],
                LastName = fullNames[2]
            };
        }
    }
}
