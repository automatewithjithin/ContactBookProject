using ContactBook;

namespace ContactBookTest
{
    [TestClass]
    public class PhoneNumberTests
    {
        [TestMethod]
        public void TestValid_MobileNumber()
        {
            string validNumber = "123456789";
            var contact = new ContactsBook("Steve", "Jobes", "Company", validNumber, "test@test.com", DateTime.Now);
            Assert.AreEqual(validNumber, contact.MobileNumber);

        }
        [TestMethod]
        public void TestInvalid_MobileNumber_LesserDigits()
        {
            string invalidNumber = "12345";
            Assert.ThrowsException<ArgumentException>(() => new ContactsBook("Steve", "Jobes", "Company", invalidNumber, "test@test.com", DateTime.Now));

        }
        [TestMethod]
        public void TestInvalid_MobileNumber_StartwithZero()
        {
            string invalidNumber = "012345678";
            Assert.ThrowsException<ArgumentException>(() => new ContactsBook("Steve", "Jobes", "Company", invalidNumber, "test@test.com", DateTime.Now));

        }
    }
}