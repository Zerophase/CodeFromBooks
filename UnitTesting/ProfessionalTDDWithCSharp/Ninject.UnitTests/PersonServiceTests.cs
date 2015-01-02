using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ProfessionalTDDWithCSharp.Ninject;
using ProfessionalTDDWithCSharp.Ninject.Interfaces;
using Ninject;

namespace Ninject.UnitTests
{
	[TestFixture]
    public class PersonServiceTests
    {
		[Test]
		public void Call_PersonService_GetPerson()
		{
			var expected = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
			var personRepositoryMock = Substitute.For<IPersonRepository>();
			personRepositoryMock.GetPerson(1).
				Returns<Person>(new Person { Id = 1, FirstName = "Bob", LastName = "Joe" });

			var kernel = new StandardKernel(new CoreModule());
			var personService = new PersonService(personRepositoryMock);
			var actual = personService.GetPerson(expected.Id);

			// The fact Test fails proves the Mock Object is being used instead of the actual implementaiton.
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.FirstName, actual.FirstName);
			Assert.AreEqual(expected.LastName, actual.LastName);
		}
    }
}
