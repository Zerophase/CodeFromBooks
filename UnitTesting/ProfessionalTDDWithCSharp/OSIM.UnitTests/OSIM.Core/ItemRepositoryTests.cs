using NBehave.Spec.NUnit;
using NSubstitute;
using NUnit.Framework;
using NHibernate;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;
using System;

namespace OSIM.UnitTests.OSIM.Core
{
	public class When_working_with_the_item_type_repository : Specifications
	{
		protected IItemTypeRepository _itemTypeRepository;
		protected ISessionFactory _sessionFactory;
		protected ISession _session;

		protected override void Establish_context()
		{
			base.Establish_context();

			_sessionFactory = Substitute.For<ISessionFactory>();
			_session = Substitute.For<ISession>();

			_sessionFactory.OpenSession().Returns(_session);

			_itemTypeRepository = new ItemTypeRepository(_sessionFactory);
		}
	}

	public class and_saving_a_valid_item_type : 
		When_working_with_the_item_type_repository
	{
		private int _result;
		
		private ItemType _testItemType;
		private int _itemTypeID;

		protected override void Establish_context()
		{
			base.Establish_context();

			var randomNumberGenerator = new Random();
			_itemTypeID = randomNumberGenerator.Next(32000);
			
			_session.Save(_testItemType).Returns(_itemTypeID);
		}

		protected override void Because_of()
		{
			_result = _itemTypeRepository.Save(_testItemType);
		}

		[Test]
		public void IsValidItemTypeID_ValidID_ReturnsInt()
		{
			_result.ShouldEqual(_itemTypeID);
		}
	}

	public class and_saving_an_invalid_item_type :
		When_working_with_the_item_type_repository
	{
		private Exception _result;

		protected override void Establish_context()
		{
			base.Establish_context();

			_session.Save(null).Returns( e => { throw new ArgumentNullException(); });
		}

		protected override void Because_of()
		{
			try
			{
				_itemTypeRepository.Save(null);
			}
			catch (Exception e)
			{
				_result = e;
			}
		}

		[Test]
		public void IsInvalidItemType_NullException_Throws()
		{
			_result.ShouldBeInstanceOfType(typeof(ArgumentNullException));
		}
	}
}
