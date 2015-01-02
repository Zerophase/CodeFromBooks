using FluentNHibernate.Mapping;
using OSIM.Core.Entities;

namespace OSIM.Core.Persistence.Mappings
{
	public class ItemTypeMap : ClassMap<ItemType>
	{
		public ItemTypeMap()
		{
			Id(itemType => itemType.Id);
			Map(itemType => itemType.Name);
		}
	}
}
