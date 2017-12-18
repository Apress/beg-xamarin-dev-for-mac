﻿using System.Text.RegularExpressions;
using NUnit.Framework;
using Persons.Common.Models;

namespace Persons.Tests
{
	[TestFixture]
	public class PersonTests
    {
		[Test]
		public void VerifyPublicProperties()
		{
			// Arrange
			const string expectedFirstName = "Dawid";
			const string expectedLastName = "Borycki";
			const string expectedEmail = "dawid@borycki.com.pl";
			const int expectedAge = 34;

			// Act
			var person = new Person()
			{
				FirstName = expectedFirstName,
				LastName = expectedLastName,
				Email = expectedEmail,
				Age = expectedAge
			};

			// Assert
			Assert.AreEqual(expectedFirstName, person.FirstName, "Incorrect first name");
			Assert.AreEqual(expectedLastName, person.LastName, "Incorrect last name");
			Assert.AreEqual(expectedEmail, person.Email, "Incorrect e-mail");
			Assert.AreEqual(expectedAge, person.Age, "Incorrect age");
		}

		[Test]
		public void VerifyFullName()
		{
			// Arrange
			const string expectedFirstName = "Dawid";
			const string expectedLastName = "Borycki";

			string expectedFullName = $"{expectedFirstName} {expectedLastName}";

			// Act
			var person = new Person()
			{
				FirstName = expectedFirstName,
				LastName = expectedLastName
			};

			// Assert
			Assert.AreEqual(expectedFullName, person.FullName());
		}

		[Test]
		public void VerifyEmail()
		{
			// Arrange
			const string email = "dawid@";

			// Act
			var isValid = EmailCheck(email);

			// Assert
			Assert.AreEqual(isValid, Person.IsEmailValid(email));
		}

		private bool EmailCheck(string email)
		{
			const string emailPattern = "[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}";

			return Regex.IsMatch(email, emailPattern);
		}
	}
}
