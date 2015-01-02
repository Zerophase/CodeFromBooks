using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MenuModel
{
	public class Course : ICourse
	{
		private readonly IEnumerable<IIngredient> ingredients;

		public Course(IEnumerable<IIngredient> ingredients)
		{
			if (ingredients == null)
			{
				throw new ArgumentNullException("ingredients");
			}
			
			this.ingredients = ingredients.ToList();
		}

		public IEnumerable<IIngredient> Ingredients
		{
			get { return this.ingredients; }
		}
	}
}