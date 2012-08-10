using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
	public class FinderTests
	{
		Person sueAge01Oldest = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
		Person gregAge02 = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
		Person mikeAge03 = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
		Person sarahAge04Youngest = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };

		[Fact]
		public void FindThrowsNullReferenceException68()
		{
			List<Person> list = new List<Person>(new Person[2]);
			AgeComparer ageComparer = new AgeComparer(list);
			Assert.Throws<NullReferenceException>(() => ageComparer.FindClosest());
		}
		
		[Fact]
		public void Returns_Empty_Results_When_Given_Empty_List()
		{
			var ageComparer = new AgeComparer(new List<Person>());

			var result = ageComparer.FindClosest();

			Assert.Null(result.Person1);
			Assert.Null(result.Person2);
		}

		[Fact]
		public void Returns_Empty_Results_When_Given_One_Person()
		{
			var list = new List<Person>() { sueAge01Oldest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindClosest();

			Assert.Null(result.Person1);
			Assert.Null(result.Person2);
		}

		[Fact]
		public void Returns_Closest_Two_For_Two_People()
		{
			var list = new List<Person>() { sueAge01Oldest, gregAge02 };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindClosest();

			Assert.Same(sueAge01Oldest, result.Person1);
			Assert.Same(gregAge02, result.Person2);
		}

		[Fact]
		public void Returns_Furthest_Two_For_Two_People()
		{
			var list = new List<Person>() { gregAge02, mikeAge03 };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindFurthest();

			Assert.Same(gregAge02, result.Person1);
			Assert.Same(mikeAge03, result.Person2);
		}

		[Fact]
		public void Returns_Furthest_Two_For_Four_People()
		{
			var list = new List<Person>() { gregAge02, mikeAge03, sarahAge04Youngest, sueAge01Oldest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindFurthest();

			Assert.Same(sueAge01Oldest, result.Person1);
			Assert.Same(sarahAge04Youngest, result.Person2);
		}

		[Fact]
		public void Returns_Closest_Two_For_Four_People()
		{
			var list = new List<Person>() { gregAge02, mikeAge03, sarahAge04Youngest, sueAge01Oldest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindClosest();

			Assert.Same(sueAge01Oldest, result.Person1);
			Assert.Same(gregAge02, result.Person2);
		}

	  
	}
}