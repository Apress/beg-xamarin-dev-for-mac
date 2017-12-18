using System.Linq;
using NUnit.Framework;
using Persons.Common.Models;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace Persons.UITests
{
    [TestFixture]
    public class Tests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the iOS app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif
            app = ConfigureApp
                .iOS
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                //.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/Persons.UITests.iOS.app")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void VerifyDisplayDataButton()
        {
            // Arrange
            var defaultPerson = Person.Default();

            // Act
            app.Tap(b => b.Button());

            var actualFirstName = GetTextFieldText("TextFieldFirstName");
            var actualLastName = GetTextFieldText("TextFieldLastName");
            var actualEmail = GetTextFieldText("TextFieldEmail");
            var actualAge = GetTextFieldText("TextFieldAge");

			// Assert
			Assert.AreEqual(defaultPerson.FirstName, actualFirstName);
			Assert.AreEqual(defaultPerson.LastName, actualLastName);
			Assert.AreEqual(defaultPerson.Email, actualEmail);
			Assert.AreEqual(defaultPerson.Age.ToString(), actualAge);
        }

        private string GetTextFieldText(string textFieldAccessibilityId)
        {
            var result = string.Empty;

            if (app.Query(c => c.Id(textFieldAccessibilityId)).FirstOrDefault()
               is AppResult matchedTextField)
            {
                result = matchedTextField.Text;
            }

            return result;
        }
    }
}
