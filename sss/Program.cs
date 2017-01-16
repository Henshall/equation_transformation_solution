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

			equation_list.Insert(equation_list.Count, "=");
			equation_list.Insert(equation_list.Count, "0");


			/// Algebra Time :) 



			/// create arrays for each term to begin grouping like terms

			i = 0;
			int j = 0;

			bool found = false;
			String[] Array = new String[equation_list.Count];
			List<string> equal_table = new List<string>();
			List<string> count_j_table = new List<string>();


			foreach (string element in equation_list)

			{ 
									

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

					if (found && (i == 0))
					{
							string last_chars2 = string.Join("", last_chars_list.ToArray());
							Console.WriteLine(last_chars2);
							equal_table.Add(last_chars2);
					}

				}


				i = i + 1;
			}










			//foreach (string element in equation_list)
			//{
				
			//	Array[i] = (element).ToString();

				   
			//	foreach (char sub_element in element)
			//	{
			//		/// put if statement here to convert the char to either a string if its a letter or an integer
			//		/// 
			//		/// 

			//		if (Char.IsLetter(sub_element))
			//		{
						
			//			Console.WriteLine(sub_element);


			//		}
				
			//	}
			


			//	i = i + 1;
			//}




			/// put like terms in each collection
			 i = 0;
				foreach (string element in equation_list)
			{
				i = i + 1;

			}




			foreach (string element in equation_list)
			{
			///	System.Console.WriteLine(element);
			}


			/// why cant I override variables?
				
		}
	}
}
