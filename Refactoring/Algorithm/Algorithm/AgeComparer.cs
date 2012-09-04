using System;
using System.Collections.Generic;

namespace Algorithm
{
	public class AgeComparer
	{
		private readonly List<Person> _persons;
		private List<Result> PersonCombinations;

		public AgeComparer(List<Person> persons)
		{
			_persons = persons;
		}

		private void GenerateCombinations()
		{
			if (_persons != null && _persons.Count > 1 && PersonCombinations == null)
			{
				PersonCombinations = GenerateCombinations(_persons);
			}
		}

		public Result FindClosest()
		{
			GenerateCombinations(); 
			return IterateWithComparer((t1, t2) => t1 < t2);
		}
		
		public Result FindFurthest()
		{
			GenerateCombinations(); 
			return IterateWithComparer((t1, t2) => t1 > t2);
		}

		private Result IterateWithComparer(Func<TimeSpan, TimeSpan, bool> compare)
		{
			if (_persons == null || _persons.Count <= 1)
			{
				return new Result();
			}
			
			Result answer = PersonCombinations[0];
			foreach (var result in PersonCombinations)
			{
				if (compare(result.Difference, answer.Difference))
				{
					answer = result;
				}
			}

			return answer;
		}




		private static List<Result> GenerateCombinations(List<Person> persons)
		{
			var personCombinations = new List<Result>();

			for (var i = 0; i < persons.Count - 1; i++)
			{
				for (var j = i + 1; j < persons.Count; j++)
				{
					var tempResult = new Result();
					if (persons[i].BirthDate < persons[j].BirthDate)
					{
						tempResult.Person1 = persons[i];
						tempResult.Person2 = persons[j];
					}
					else
					{
						tempResult.Person1 = persons[j];
						tempResult.Person2 = persons[i];
					}
					tempResult.Difference = tempResult.Person2.BirthDate - tempResult.Person1.BirthDate;
					personCombinations.Add(tempResult);
				}
			}
			return personCombinations;
		}


	}
}