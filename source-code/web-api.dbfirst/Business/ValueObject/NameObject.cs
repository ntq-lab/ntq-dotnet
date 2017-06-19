using Interface;

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
            return string.Format("{0} / {1} / {2}", Title, FirstName, LastName);
        }
    }
}
