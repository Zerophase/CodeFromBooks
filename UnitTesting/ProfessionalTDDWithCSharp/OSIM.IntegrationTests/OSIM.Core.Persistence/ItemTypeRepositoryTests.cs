using NBehave.Spec.NUnit;
using Ninject;
using NUnit.Framework;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;
using OSIM.UnitTests;
using System;

namespace OSIM.IntegrationTests.OSIM.Core.Persistence
{
	public class when_using_the_item_type_repository : Specifications
	{
		protected StandardKernel _kernel;
		protected IItemTypeRepository _itemTypeRepository;

		protected override void Establish_context()
		{
			base.Establish_context();

			_kernel = new StandardKernel(new IntegrationTestModule());
			_itemTypeRepository = _kernel.Get<IItemTypeRepository>();
		}
	}

	public class and_attempting_to_save_and_read_a_value_from_a_datastore : 
		when_using_the_item_type_repository
	{
		private ItemType _result;
		private ItemType _expected;

		protected override void Establish_context()
		{
			base.Establish_context();

			_expected = new ItemType { Name = Guid.NewGuid().ToString() };
		}

		protected override void Because_of()
		{
			var itemTypeId = _itemTypeRepository.Save(_expected);
			_result = _itemTypeRepository.GetById(itemTypeId);
		}

		[Test]
		public void SaveAndRetrieve_ValidDatabaseHandling_RetrievedEqualsItemTypeSaved()
		{
			_result.Id.ShouldEqual(_expected.Id);
			_result.Name.ShouldEqual(_expected.Name);
		}
	}
}
