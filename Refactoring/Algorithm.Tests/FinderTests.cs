using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
	public class FinderTests
	{
		Person person01_Oldest = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
		Person person02_2ndOldest = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
		Person person03_2ndYoungest = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
		Person person04_Youngest = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };

		[Fact]
		public void FindThrowsNullReferenceException_WhenEmptyList()
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
			var list = new List<Person>() { person01_Oldest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindClosest();

			Assert.Null(result.Person1);
			Assert.Null(result.Person2);
		}

		[Fact]
		public void Returns_Closest_Two_For_Two_People()
		{
			var list = new List<Person>() { person01_Oldest, person02_2ndOldest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindClosest();

			Assert.Same(person01_Oldest, result.Person1);
			Assert.Same(person02_2ndOldest, result.Person2);
		}

		[Fact]
		public void Returns_Furthest_Two_For_Two_People()
		{
			var list = new List<Person>() { person02_2ndOldest, person03_2ndYoungest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindFurthest();

			Assert.Same(person02_2ndOldest, result.Person1);
			Assert.Same(person03_2ndYoungest, result.Person2);
		}

		[Fact]
		public void Returns_Furthest_Two_For_Four_People()
		{
			var list = new List<Person>() { person02_2ndOldest, person03_2ndYoungest, person04_Youngest, person01_Oldest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindFurthest();

			Assert.Same(person01_Oldest, result.Person1);
			Assert.Same(person04_Youngest, result.Person2);
		}

		[Fact]
		public void Returns_Closest_Two_For_Four_People()
		{
			var list = new List<Person>() { person02_2ndOldest, person03_2ndYoungest, person04_Youngest, person01_Oldest };
			var ageComparer = new AgeComparer(list);

			var result = ageComparer.FindClosest();

			Assert.Same(person01_Oldest, result.Person1);
			Assert.Same(person02_2ndOldest, result.Person2);
		}

	  
	}
}