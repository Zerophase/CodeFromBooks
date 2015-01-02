using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NBehave.Spec.NUnit;
using OSIM.UnitTests;
using NSubstitute;
using OSIM.Core.Persistence;
using OSIM.Core.Entities;
using System.Web.Mvc;
using MvcApplication1.Controllers;

namespace MvxApllication1.Tests
{
    public class when_working_with_the_item_type_controller : Specifications
    {
		protected IItemTypeRepository _itemRepository = Substitute.For<IItemTypeRepository>();
		protected ItemType _itemOne;
		protected ItemType _itemTwo;
		protected ItemType _itemThree;

		protected override void Establish_context()
		{
			_itemOne = new ItemType { Id = 1, Name = "USB drives" };
			_itemTwo = new ItemType { Id = 2, Name = "Nerf darts" };
			_itemThree = new ItemType { Id = 3, Name = "Flying Monkeys" };
			var itemTypeList = new List<ItemType>
			{
				_itemOne,
				_itemTwo,
				_itemThree
			};

			_itemRepository.GetAll.Returns(itemTypeList);
		}
    }

	public class and_trying_to_load_the_index_page :
		when_working_with_the_item_type_controller
	{
		Object _model;
		int _expectedNumberOfItemsInModel;

		protected override void Establish_context()
		{
			base.Establish_context();
			_expectedNumberOfItemsInModel = _itemRepository.GetAll.Count;
		}

		protected override void Because_of()
		{
			_model = ((ViewResult)
					new ItemTypeController(_itemRepository).Index()).ViewData.Model;
		}

		[Test]
		public void Validate_Model_ReturnsList()
		{
			_expectedNumberOfItemsInModel.ShouldEqual(((List<ItemType>)_model).Count);
			_itemOne.ShouldEqual(((List<ItemType>)_model)[0]);
			
		}
	}

	public class and_trying_tocreate_a_new_valid_item_type : when_working_with_the_item_type_controller
	{
		ItemType _newItemType;
		ItemTypeController _controller;
		RedirectToRouteResult _result;
		string _expectedRouteName;

		protected override void Establish_context()
		{
			base.Establish_context();

			_expectedRouteName = "Index";
			_newItemType = new ItemType() { Id = 99, Name = "New Item" };
			_controller = new ItemTypeController(_itemRepository);
		}

		protected override void Because_of()
		{
			_result = _controller.Create(_newItemType) as RedirectToRouteResult;
		}

		[Test]
		public void CreateNew_ItemType_ReturnsRedirect()
		{
			_result.ShouldNotBeNull();
			Assert.AreEqual(_expectedRouteName, _result.RouteName);
		}
	}
}
