using System;
using System.Collections.Generic;

namespace sss
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			/// define the equation
			string equation = "x^2 + 3.5xy + y = y^2 - xy + y";


			///  parse values and put into list
			string[] equation_array;
			equation_array = equation.Split(' ');
		
			List<string> equation_list = new List<string>();
			foreach (string element in equation_array)
			{
				equation_list.Add(element);
			}


			/// finds position of equal sign and assign it to 'count' variable
			int i = 0;
			foreach (string element in equation_array)
			{
				if (element == "=")
				{
					break;				
				}
				i = i + 1;
			}
			int count = i;

			/// removes equals sign and replaces it with correct symbol ///
			equation_list.RemoveAt(count);
			if (equation_list[count] == "-")
			{
			}
			else
			{
				equation_list.Insert(count, "+");
			}
	
			/// puts equals sign to the end and adds 0

		
			/// changes all signs after the equals sign
			i = 0;
			while (i < equation_list.Count)
			{
				if (i >= count && equation_list[i] == "+")
				{
					equation_list[i] = "-";
				} else if  (i >= count && equation_list[i] == "-")
				{
					equation_list[i] = "+";
				}

				i = i + 1;
			}






			/// Algebra Time :) 



			/// create arrays for each term to begin grouping like terms

			i = 0;
			int j = 0;

			bool found = false;
			String[] Array = new String[equation_list.Count];
			List<string> equal_table = new List<string>();
			List<string> count_j_table = new List<string>();


				foreach (string subelement in equation_list)

				{

					j = 0;
					/// checks each line, if a letter is found, found = true. if j is 0, a letter was not found
					foreach (char subsubelement in subelement)
					{

						found = false;
						if (Char.IsLetter(subsubelement))
						{
							found = true;
							break;
						}
						else if (subelement.Length == 1 && (Char.IsNumber(subsubelement) || Char.IsSymbol(subsubelement)))
						{
							break;
						}
						j = j + 1;
					}



					/// creates new list  and adds characters from current line of elements list
			
					List<char> last_chars = new List<char>();
					foreach (char character in subelement)
					{
						last_chars.Add(character);

					}


					///  create a list of the elements of like terms
					List<char> last_chars_list = new List<char>();
					int check = 0;
					foreach (char subsubelement2 in last_chars)
					{
						if (check >= j && found)
						{
							last_chars_list.Add(subsubelement2);
						}
						check = check + 1;
					}

					if (found)
					{
							string last_chars2 = string.Join("", last_chars_list.ToArray());
							/// Console.WriteLine(last_chars2);
							equal_table.Add(last_chars2);
					}

				}




		



			/// creates new list where a number one will be added
			List<string> equation_list_to_ones = new List<string>();

			foreach (string element in equation_list)
			{
				if (element.StartsWith("a") || element.StartsWith("b") || element.StartsWith("c") || element.StartsWith("d") || element.StartsWith("e") || element.StartsWith("f") || element.StartsWith("g") || element.StartsWith("h") || element.StartsWith("i") || element.StartsWith("j") || element.StartsWith("k") || element.StartsWith("l") || element.StartsWith("m") || element.StartsWith("n") || element.StartsWith("o") || element.StartsWith("p") || element.StartsWith("q") || element.StartsWith("r") || element.StartsWith("s") || element.StartsWith("t") || element.StartsWith("u") || element.StartsWith("v") || element.StartsWith("w") || element.StartsWith("x") || element.StartsWith("y") || element.StartsWith("z"))
			///	if (element != "+" || element != "-")
				{
					string new_element = string.Concat("1", element);
					equation_list_to_ones.Add(new_element);
					///Console.WriteLine(new_element);
						
				}
				else if (element != "+" || element != "-")
				{
					equation_list_to_ones.Add(element);
					///
				}


			}


			///equation_list_to_ones.Sort();










			foreach (string element in equation_list_to_ones)

			{

				///Console.WriteLine(element);


			}










			equation_list.Insert(equation_list.Count, "=");
			equation_list.Insert(equation_list.Count, "0");




				/// create a reference list which groups like terms

				List<int> reference_list = new List<int>();
			i = 1;
			foreach (string element in equal_table)
			{

				j = 1;
				foreach (string subelement in equal_table)
				{
					if (j == i)
					{

					}
					else if (subelement == element)
						
					{
						reference_list.Add(j);
						break;
					}
					else if(j == 6)

					{
						
						reference_list.Add(0);
					}
									j = j + 1;
				}
				i = i + 1;
			}

			///   Add like terms 		 
			/// grabs second non-operator string in equation list

			i = 0;  /// reference list number
			j = 0;  /// equation list number (includs all values)
			int k = 0;  /// equation list number (excludes operators)
			/// element = value in reference list
			/// subelement = value in equation list
			foreach (int element in reference_list)

			{
				if (element == 0)
				{
				}
				else
				{

					int ref_list_position = i;
					int ref_list_number = reference_list[i];



					///	Console.WriteLine(value_one);
				Console.WriteLine(value_two);





					foreach (string subelement in equation_list)
					{
						if (subelement == "-" || subelement == "+")
						{
							///Console.WriteLine(subelement);

						}
						else
						{
							if (k == i)
							{

								/// subelement = 3.5xy
								/// element = 5

								///string value_one = subelement;
								///string value_two = equation_list[element];

						 ///    Console.WriteLine(subelement);
							///	Console.WriteLine(value_two);
							}
								k = k + 1;
						}
						j = j + 1;
					}




				}
				i = i + 1;
			}

			foreach (string element in equal_table )
			{
			///	Console.WriteLine(element);

			}


			//foreach (int element in reference_list)
			//{
			//Console.WriteLine(element);

			//}
			/// why cant I override variables?
				
		}
	}
}
