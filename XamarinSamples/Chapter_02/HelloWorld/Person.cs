using System.IO;
using System.Text;
using Foundation;

namespace HelloWorld
{
    public class Person : NSCoding
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private string archiveLocation = Path.Combine(Path.GetTempPath(), "person");

        private const string firstNameArchiveKey = "FirstName";
        private const string lastNameArchiveKey = "LastName";

        public Person() { }

		[Export("initWithCoder:")]
		public Person(NSCoder coder)
		{
		    FirstName = DecodeString(coder, firstNameArchiveKey);
		    LastName = DecodeString(coder, lastNameArchiveKey);
		}

		public override void EncodeTo(NSCoder encoder)
		{
		    EncodeString(encoder, FirstName, firstNameArchiveKey);
		    EncodeString(encoder, LastName, lastNameArchiveKey);
		}

		public void StoreValues()
		{
		    NSKeyedArchiver.ArchiveRootObjectToFile(this, archiveLocation);
		}

		public void RestoreValues()
		{
		    if (NSKeyedUnarchiver.UnarchiveFile(archiveLocation) is Person retrievedPersonData)
		    {
		        FirstName = retrievedPersonData.FirstName;
		        LastName = retrievedPersonData.LastName;
		    }
		}

        private void EncodeString(NSCoder encoder, string property, string propertyKey)
        {
            var buffer = Encoding.UTF8.GetBytes(property);
            encoder.Encode(buffer, propertyKey);
        }

        private string DecodeString(NSCoder coder, string propertyKey)
        {
            var result = string.Empty;

            var bytes = coder.DecodeBytes(propertyKey);
            if (bytes != null)
            {
                result = Encoding.UTF8.GetString(bytes);
            }

            return result;
        }
    }
}
