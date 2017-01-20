using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


namespace sss
{
	class MainClass
	{


		/// <summary>
		/// ALL LISTS / STRINGS DEFINED HERE
		/// </summary>

		public static List<string> initial_equation = new List<string>();
		public static List<string> equation_list_to_ones = new List<string>();
		public static List<string> equation_list = new List<string>();
		public static string[] equation_array;
		public static List<string> concat_list = new List<string>();
		public static List<string> equal_list = new List<string>();
		public static List<string> equal_table = new List<string>();
		public static List<string> addition_list = new List<string>();
		public static List<string> count_list = new List<string>();

		/// <summary>
		///  ALL MEDTHODS DEFINED BELOW
		/// </summary>

		public void set_equation()
		{
			Console.Write("Enter Equation: ");  string user_input = Console.ReadLine();
			initial_equation.Add(user_input);

		}

		public void put_equation_in_list()
		{
			string equation = initial_equation[0];
			equation_array = equation.Split(' ');
			foreach (string element in equation_array)
			{
				equation_list.Add(element);
			}
		}


	/// <summary>
	///  removes the equals sign from the list and turns each negative sign into a positive sign and vice versa.
	/// </summary>

		public void remove_and_replace_sign()
		{

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
				}
				else if (i >= count && equation_list[i] == "-")
				{
					equation_list[i] = "+";
				}

				i = i + 1;
			}


		}

			/// Takes everything from equation_list and adds it to a new list

		public void put_ones_in_front()
		{
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

		}


		/// <summary>
		///  adds equals sign and a 0 to the end of the equation
		/// </summary>

		public void add_equals_and_zero_to_end()

		{
			concat_list.Add("=");
			concat_list.Add( "0");

		}


		/// <summary>
		///  adds plus sign to the beginning of the equation_to_ones_list if there isnt a minus sign already. This prepares the list to be concatonated
		/// </summary>
		public void add_plus_sign()

		{
			if (equation_list_to_ones[0] != "-")
			{
				equation_list_to_ones.Insert(0, "+");
			}
		}

		/// <summary>
		///  This creates a new list and concatonated all pared element
		/// </summary>
		public void to_concat_list()
		{
			int i = 0;
			equation_list_to_ones.Add(" ");

			foreach (string element in equation_list_to_ones)

			{
				if (i < (equation_list_to_ones.Count - 1) )
				{
					string value1 = equation_list_to_ones[i];
					string value2 = equation_list_to_ones[i + 1];
					string concat_value = value1 + value2;
					concat_list.Add(concat_value);
				}

			i = i + 2;
			}
		}


		/// creates equal_tabele to use a sorting reference

		int j = 0;
		bool found = false;

		public void create_equals_table()
		{

			/// create arrays for each term to begin grouping like terms
			///String[] Array = new String[equation_list.Count];
			///List<string> count_j_table = new List<string>();

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

			string[] concat_array = concat_list.ToArray();
			string[] equal_array = equal_table.ToArray();
			Array.Sort(equal_array, concat_array);
			concat_list.Clear();

			foreach (string element in equal_array)
			{
				equal_list.Add(element);
			}

			foreach (string element in concat_array)
			{
				concat_list.Add(element);
			}
		}



		public void perform_math()
		{

			int i = 0;
			foreach (string element in equal_list)
			{
						string input = concat_list[i];
						//string result = Regex.Replace(input, @"([a-zA-Z]).*\w", "");
						string result = Regex.Replace(input, @"[a-zA-Z].*", "");
					addition_list.Add(result);

				//	Console.WriteLine(result);
				i = i + 1;
			}
			i = 0;
			int j = 0;
			concat_list.Add(" ");
			while (i < equal_list.Count)
			{
				if (equal_list[i - count_list.Count] == equal_list[i + 1 - count_list.Count] && equal_list[i - count_list.Count] != "_")
					{
						string number_one = Regex.Replace(addition_list[i - count_list.Count ], @"[a-zA-Z+-]", "");
						string number_two = Regex.Replace(addition_list[i + (1 - count_list.Count)], @"[a-zA-Z+-]", "");
						string sign_number_one = Regex.Replace(addition_list[i - count_list.Count], @"[^+-]", "");
						string sign_number_two = Regex.Replace(addition_list[i + (1 - count_list.Count)], @"[^+-]", "");

						float sum = float.Parse(number_one) + float.Parse(number_two);
						float subtract = float.Parse(number_one) - float.Parse(number_two);
						string sum_from_int = sum.ToString() + equal_list[i - count_list.Count];
						string subtract_from_int = subtract.ToString() + equal_list[i - count_list.Count];

						concat_list.Add("_");
						concat_list.RemoveAt(i - count_list.Count);
						concat_list.RemoveAt(i - count_list.Count);

						addition_list.Add("_");
						addition_list.RemoveAt(i - count_list.Count);
						addition_list.RemoveAt(i - count_list.Count);
						addition_list.Insert(i - count_list.Count, "+" + sum_from_int);

						equal_list.RemoveAt(i + 1 - count_list.Count);
						equal_list.Add("-");
						j = j + 1;

						if (sign_number_one == sign_number_two)
					{
						char[] element_array = sum_from_int.ToArray();
						/// Console.WriteLine(element_array[0]);
						string first_char = element_array[0].ToString();

						if (first_char == "-" && first_char != "0")
						{
							count_list.Add("add");

						}
						else
						{
							concat_list.Insert(i - count_list.Count, "+" + sum_from_int);
							count_list.Add("add");
						}

						///Console.WriteLine(sign_number_one);
						/// count_list.Add("add");
					}
					else if (sign_number_one == "+")
					{
						concat_list.Insert(i - count_list.Count, subtract_from_int);
						count_list.Add("add");

 					}
					}
				i = i + 1;

				}  /// while loop ending
		}
 		public void add_signs_and_remove_0s() 		{
 			int i = 0; 			while (i < concat_list.Count) 			{
 				char[] element_array = concat_list[i].ToArray(); 				/// Console.WriteLine(element_array[0]); 				string first_char = element_array[0].ToString();
				string second_char = element_array[1].ToString(); 

				if (first_char == "0")
				{
					concat_list.RemoveAt(i);
					//	Console.WriteLine("removed!");
				} else if (first_char == "+" && second_char == "-")
				{
					string element = Regex.Replace(concat_list[i], @"[^-]", "");
					concat_list.Insert(i, element);
				} 				i = i + 1; 			} 		} 
		public void remove_spaces()
		{
			int i = 0;
			while (i < concat_list.Count)
			{
				concat_list.Remove(" ");
				concat_list.Remove(" ");
				concat_list.Remove("_");
				concat_list.Remove("_");
				i = i + 1;
			}
		}

		public void join_to_string()
		{
			string joined = string.Join(" ", concat_list.ToArray());
			Console.WriteLine("-------------");
			Console.WriteLine("Result: " +  joined);
			Console.WriteLine("-------------");
		}

		public void clear_lists()
		{
			equation_list.Clear(); 			equation_list_to_ones.Clear(); 			concat_list.Clear();
			equal_list.Clear();
			equal_table.Clear();
			addition_list.Clear();
			count_list.Clear();
			initial_equation.Clear();
	
		}

		public static void Main(string[] args)
		{
	
			Console.WriteLine("Enter an equation and it will be transformed into canonical form. For example:  'x^2 + 3.5xy + y = y^2 - xy + y' will be transformed into: '+1x^2 +4.5xy -1y^2 = 0' ");
			Console.WriteLine("Note: this program doesnt allow brackets and all plus/minus signs must be seperated from the letters (ex. 2x + 3y) ");
			Console.WriteLine(" ");
			int i = 0;
			while (i < 100)
			{
				MainClass m = new MainClass(); 
				m.set_equation();  					/// gets user to type equation and uses this equation in the following steps
				m.put_equation_in_list();			/// puts the equation in equation_list
				m.remove_and_replace_sign();		/// removes equals sign and changes plus signs to minus sign in appropriate areas
				m.put_ones_in_front();				/// puts a 1 in front of any number that doesnt have it
				m.add_plus_sign();					/// adds plus sign to the beginning of the equation_to_ones_list if there isnt a minus sign already. This prepares the list to be concatonated
				m.to_concat_list();					/// puts all values (with with their signs) and adds them into the concat_list list.
				m.create_equals_table();			/// creates a list called "equals table". All of the letters are stripped from concat_table and placed into "equals_table". This is used as a reference for performing calculations.
				m.perform_math();					/// removtes and inserts elements into concat_list by referencing equal_table and addition_list.
				m.remove_spaces();					/// the perform_math method leaves us with spaves in concat_list - this removes them		
				m.add_signs_and_remove_0s();		///	its possible that we have some 0 values - this method removes them
				m.add_equals_and_zero_to_end();		/// an equals sign and a 0 are placed at the end of the list
				m.join_to_string();					/// concat_list is joined and becomes a string. This is displayed to the user
				m.clear_lists();					/// all lists are cleared for next equation.
				i = i + 1;
			}

		}
	}
}
