using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Users.MobileClient.Helpers;

namespace Users.MobileClient.Tests
{
    [TestFixture]
    public class UsersServiceHelperTests
    {
        private const int UserId = 5;

        [Test]
        public async void VerifyGet()
        {
            // Arrange
            const int expectedDataCount = 10;

            // Act and Assert
            Assert.AreEqual(expectedDataCount, await GetUserCount());
        }

        [Test]
        public async void VerifyGetById()
        {
            // Arrange
            const string expectedName = "Chelsey Dietrich";
            const string expectedEmail = "Lucio_Hettinger@annie.ca";

            // Act
            var user = await UsersServiceHelper.Get(UserId);

            // Assert
            Assert.AreEqual(expectedName, user.Name);
            Assert.AreEqual(expectedEmail, user.Email);
        }

        [Test]
        public async void VerifyDelete()
        {
            // Arrange
            var currentDataCount = await GetUserCount();
            var expectedDataCount = currentDataCount - 1;

            // Act
            await UsersServiceHelper.Delete(UserId);
            var actualDataCount = await GetUserCount();

            // Assert
            Assert.AreEqual(expectedDataCount, actualDataCount);
        }

        [Test]
        public async void VerifyUpdate()
        {
            // Arrange
            const string expectedName = "New name";
            var user = await UsersServiceHelper.Get(UserId);

            // Act
            // Update name of the user and then get the user again from the API
            user.Name = expectedName;
            await UsersServiceHelper.Update(user);
            user = await UsersServiceHelper.Get(UserId);

            // Assert
            // Check if the name of user was indeed updated
            Assert.AreEqual(expectedName, user.Name);
        }

        private async Task<int> GetUserCount()
        {
            return (await UsersServiceHelper.Get()).Count();
        }
    }
}
