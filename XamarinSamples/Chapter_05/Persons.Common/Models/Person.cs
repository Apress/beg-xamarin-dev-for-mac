namespace Persons.Common.Models
{
    public class Person
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }

        #endregion

        #region Methods

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public static bool IsEmailValid(string email)
        {
            return email.Contains("@");
        }

		public static Person Default()
		{
		    return new Person
		    {
				FirstName = "Dawid",
		        LastName = "Borycki",
		        Age = 34,
		        Email = "dawid@borycki.com.pl"
			};
		}

        #endregion
    }
}
