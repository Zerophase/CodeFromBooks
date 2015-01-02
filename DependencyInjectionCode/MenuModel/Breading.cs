using System;

namespace MenuModel
{
	public class Breading : IIngredient
	{
		private readonly IIngredient ingredient;

		public Breading(IIngredient ingredient)
		{
			if (ingredient == null)
			{
				throw new ArgumentNullException("ingredient");
			}

			this.ingredient = ingredient;
		}

		public IIngredient Ingredient
		{
			get { return this.ingredient; }
		}
	}
}