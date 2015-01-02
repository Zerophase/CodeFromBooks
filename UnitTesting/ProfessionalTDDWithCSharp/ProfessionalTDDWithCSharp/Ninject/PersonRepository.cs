using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalTDDWithCSharp.Ninject.Interfaces;

namespace ProfessionalTDDWithCSharp.Ninject
{
	public class PersonRepository : IPersonRepository
	{
		private readonly IList<Person> _personList;

		public Person GetPerson(int personId)
		{
			return _personList.Where(person => person.Id == personId).FirstOrDefault();
		}

		public PersonRepository()
		{
			_personList = new List<Person>
							{
								new Person{ Id = 1, FirstName = "John",
												LastName = "Doe"},
								new Person {Id = 2, FirstName = "Ricard",
												LastName = "Roe"},
								new Person { Id = 3, FirstName = "Amy",
												LastName = "Adams"}
							};
		}
	}
}
