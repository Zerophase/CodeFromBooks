using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommerceSqlDataAccess;
using DomainModel.Baskets;
using UserInterface.Controllers;
using Xunit;


namespace IntegrationTests
{
	// NOTE How to monitor tight Coupling
	// Write Integration tests to insure assemblies that should
	// stay seperate remain seperate.
	// For Instance here we don't want the the UserInterface coupling
	// CommerceSqlDataAccess to DomainModel, or DomainModel coupling
	// itself to CommerceSqlDataAccess.
	// Domain model should act as an inbetween between the two assbemblies.
    public class ArchitectureConstraints
    {
		[Fact]
		public void PresentationModuleShouldNotReferenceSqlDataAccess()
		{
			// Fixture setup
			Type presentationRepresentative =
				typeof(HomeController);
			Type sqlRepresentative =
				typeof(SqlProductRepository);
			// Exercise system
			var references =
				presentationRepresentative.Assembly
				.GetReferencedAssemblies();
			// Verify outcome
			AssemblyName sqlAssemblyName =
				sqlRepresentative.Assembly.GetName();
			AssemblyName presentationAssemblyName =
				presentationRepresentative.Assembly.GetName();

			Assert.False(references.Any(a =>
				AssemblyName.ReferenceMatchesDefinition(
					sqlAssemblyName, a)),
				string.Format(
					"{0} should not be referenced by {1}",
					sqlAssemblyName,
					presentationAssemblyName));
			// Teardown
		}

		[Fact]
		public void DomainModuleShouldNotReferenceSqlDataAccess()
		{
			// Fixture setup
			Type domainRepresentative = typeof(Basket);
			Type sqlRepresentative =
				typeof(SqlProductRepository);
			// Exercise system
			var references =
				domainRepresentative.Assembly
				.GetReferencedAssemblies();
			// Verify outcome
			AssemblyName sqlAssemblyName =
				sqlRepresentative.Assembly.GetName();
			AssemblyName presentationAssemblyName =
				domainRepresentative.Assembly.GetName();

			Assert.False(references.Any(a =>
				AssemblyName.ReferenceMatchesDefinition(
					sqlAssemblyName, a)),
				string.Format(
					"{0} should not be referenced by {1}",
					sqlAssemblyName, presentationAssemblyName));
			// Teardown
		}
    }
}
