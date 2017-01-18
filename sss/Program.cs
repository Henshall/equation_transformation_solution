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
			int count2 = 0;
			/// element = value in reference list
			/// subelement = value in equation list
			/// 
			/// 
			List<int> addition_list = new List<int>();  //// creates an addition list where the numbers will be added
			List<int> sum_list = new List<int>();  //// creates an sum list where our values will be sumed


			foreach (int element in reference_list)

			{
				if (element == 0)
				{
				}
				else
				{
					
					/// uses reference list position and values to addition_list. We will be able to use this list in the next step to perform the algebra
					int ref_list_position = i;
					int ref_list_number = reference_list[i];
					addition_list.Add(ref_list_position);
					string element2 = element.ToString();
					string[] element3 = element2.Split();     

					foreach (string character in element3)
					{
						int element4 = int.Parse(character);
						addition_list.Add(element4);
					}



					/// here we take the numbers from the equation_list and put them in the sum_list

					foreach (int add_value in addition_list)

					{

						// Get the numbers and put them in a sum_table
						string whole_value = equation_list_to_ones[add_value];

						string[] whole_value_array = whole_value.Split();
						i = 0;
						 count2 = 0;
						foreach (string whole_value_element in whole_value_array)
						{
							if (whole_value_element == "a" || whole_value_element == "b" || whole_value_element == "c" || whole_value_element == "d" || whole_value_element == "e" || whole_value_element == "f" || whole_value_element == "g" || whole_value_element == "h" || whole_value_element == "i" || whole_value_element == "j" || whole_value_element == "k" || whole_value_element == "l" || whole_value_element == "m" || whole_value_element == "n" || whole_value_element == "o" || whole_value_element == "p" || whole_value_element == "q" || whole_value_element == "r" || whole_value_element == "s" || whole_value_element == "t" || whole_value_element == "u" || whole_value_element == "v" || whole_value_element == "w" || whole_value_element == "x" || whole_value_element == "y" || whole_value_element == "z")
							{
								count2 = i;
								break;
							}

							i = i + 1;
						}

						/// make amalgomation list to grab the correct values out of the whole values array
						i = 0;
						List<string> amalgomation_list = new List<string>();
						foreach (string string_element in whole_value_array)
						{
							if (i <= count2)
							{
								amalgomation_list.Add(string_element);
							}
							i = i + 1;
						}


						/// join the amalgomation list into one variable and add it to sum_list
						string amalgomation = string.Join("", amalgomation_list.ToArray());

					///	int amalgomation_int = int.Parse(amalgomation);

					///	sum_list.Add(amalgomation_int);
					
					}

				

					/// 
					foreach (int addition in sum_list)
					{

					}





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













			foreach (string element in equation_list_to_ones )
			{
				Console.WriteLine(element);

			}


			//foreach (int element in reference_list)
			//{
			//Console.WriteLine(element);

			//}
			/// why cant I override variables?
				
		}
	}
}
