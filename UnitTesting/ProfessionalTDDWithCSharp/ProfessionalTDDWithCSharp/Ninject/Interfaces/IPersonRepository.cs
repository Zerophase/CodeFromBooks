using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalTDDWithCSharp.Ninject.Interfaces
{
	public interface IPersonRepository
	{
		Person GetPerson(int personId);
	}
}
