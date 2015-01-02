using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalTDDWithCSharp.Ninject.Interfaces;

namespace ProfessionalTDDWithCSharp.Ninject
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepository;

		public PersonService(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public Person GetPerson(int personId)
		{
			return _personRepository.GetPerson(personId);
		}
	}
}
