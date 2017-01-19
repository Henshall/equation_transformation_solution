using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


namespace sss
{
	class MainClass
	{



		/// define the equation
		public static string equation = "x^2 + 3.5xy + y = y^2 - xy + y";

		///  Create an equation list and parses the equation by spaces and puts each element in the list
		/// 
		/// 
		/// 
		public static	List<string> equation_list = new List<string>();
		public static	string[] equation_array;
		public void put_equation_in_list()
		{
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
			public static	List<string> equation_list_to_ones = new List<string>();

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
			equation_list_to_ones.Add("=");
			equation_list_to_ones.Add( "0");

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
		public static	List<string> concat_list = new List<string>();
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
		/// 
		public static List<string> equal_list = new List<string>();

		public static List<string> equal_table = new List<string>();
		int i = 0;
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

		public static List<string> addition_list = new List<string>();


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
			foreach (string element2 in equal_list)
			{
				if (i == 0)
				{
				}
				else
				{
					if (equal_list[i] == equal_list[i - 1])
					{
						string number_one = Regex.Replace(addition_list[i - 1], @"[+-]", "");
						string number_two = Regex.Replace(addition_list[i], @"[+-]", "");
						string sign_number_one = Regex.Replace(addition_list[i - 1], @"[^+-]", "");
						string sign_number_two = Regex.Replace(addition_list[i], @"[^+-]", "");

						float sum = float.Parse(number_one) + float.Parse(number_two);
						float subtract = float.Parse(number_one) - float.Parse(number_two);
						string sum_from_int = sum.ToString() + equal_list[i];
						string subtract_from_int = subtract.ToString() + equal_list[i];

					

						if (sign_number_one == sign_number_two)
						{
							concat_list.RemoveAt(i);
							concat_list.Insert(i, sum_from_int);
							concat_list.RemoveAt(i - 1);
						}
						else if (sign_number_one == "+")
						{
							concat_list.RemoveAt(i);
							concat_list.Insert(i, subtract_from_int);
							concat_list.RemoveAt(i-1);
						}
					}
				}
				i = i + 1;
			}
		}





		public void add_signs_and_remove_0s()
		{
			int i = 0;

			while (i < concat_list.Count)
			{

				char[] element_array = concat_list[i].ToArray();
				/// Console.WriteLine(element_array[0]);
				string first_char = element_array[0].ToString();
				if (first_char == "0")
				{
					concat_list.RemoveAt(i);
					Console.WriteLine("removed!");
				}
				else if (first_char != "+" && first_char != "+")
				{
					concat_list.Insert(i, "+" + concat_list[i]);
					concat_list.RemoveAt(i + 1);

				}


				i = i + 1;
			}








		}





		public void join_to_string()
		{

			string joined = string.Join(" ", concat_list.ToArray());
			Console.WriteLine(joined);

		}












		/// <summary>
		///  sorts the list by the first non symbol non didgit character
		/// 
		/// </summary>

		public static string equationRegex  = @"/[a - zA - Z].*/ g";
		public static string numberRegex = @"/\+([^;]*)[a-zA-z]/g";
		public static string string_after_last_didget = @"/[a-zA-Z](.*)/g";
		public static List<string> result_list = new List<string>();

		public void sort_array()

		{
			///	var valueA = a.match(equationRegex)[0];
			///	Regex equation_r = new Regex(equationRegex, RegexOptions.IgnoreCase);
			///	Regex number_r = new Regex(equationRegex, RegexOptions.IgnoreCase);
			///	List<string> resultList = files.Where(myRegex.IsMatch).ToList();
			/// 
			/// 
			// var myRegex = new Regex(string_after_last_didget);
			///	List<string> resultList = concat_list.Where(myRegex.IsMatch).ToList();
			// List<string> resultList = concat_list.Where(f => myRegex.IsMatch(f)).ToList();


			var matches = Regex.Matches("sdsdds", @"/[a-zA-Z](.*)/g");
		}


		public static void Main(string[] args)
		{
			MainClass m = new MainClass();
			m.put_equation_in_list();
			m.remove_and_replace_sign();
			m.put_ones_in_front();
			m.add_plus_sign();
			m.to_concat_list();
			m.create_equals_table();
			m.perform_math();
			m.add_signs_and_remove_0s();
			m.add_equals_and_zero_to_end();
			m.join_to_string();


			//	Array.Sort(concat_array);
			// m.sort_array();
			///equation_list_to_ones.Sort();

			foreach (string element in equation_list_to_ones)

			{
				///Console.WriteLine(element);
			}










		




				/// create a reference list which groups like terms

			//	List<int> reference_list = new List<int>();
			//	 i = 1;
			//foreach (string element in equal_table)
			//{

			//	 j = 1;
			//	foreach (string subelement in equal_table)
			//	{
			//		if (j == i)
			//		{

			//		}
			//		else if (subelement == element)
						
			//		{
			//			reference_list.Add(j);
			//			break;
			//		}
			//		else if(j == 6)

			//		{
						
			//			reference_list.Add(0);
			//		}
			//						j = j + 1;
			//	}
			//	i = i + 1;
			//}

			/////   Add like terms 		 
			///// grabs second non-operator string in equation list

			//i = 0;  /// reference list number
			//j = 0;  /// equation list number (includs all values)
			//int k = 0;  /// equation list number (excludes operators)
			//int count2 = 0;
			///// element = value in reference list
			///// subelement = value in equation list
			///// 
			///// 
			//List<int> addition_list = new List<int>();  //// creates an addition list where the numbers will be added
			//List<int> sum_list = new List<int>();  //// creates an sum list where our values will be sumed


			//foreach (int element in reference_list)

			//{
			//	if (element == 0)
			//	{
			//	}
			//	else
			//	{
					
			//		/// uses reference list position and values to addition_list. We will be able to use this list in the next step to perform the algebra
			//		int ref_list_position = i;
			//		int ref_list_number = reference_list[i];
			//		addition_list.Add(ref_list_position);
			//		string element2 = element.ToString();
			//		string[] element3 = element2.Split();     

			//		foreach (string character in element3)
			//		{
			//			int element4 = int.Parse(character);
			//			addition_list.Add(element4);
			//		}



			//		/// here we take the numbers from the equation_list and put them in the sum_list

			//		foreach (int add_value in addition_list)

			//		{

			//			// Get the numbers and put them in a sum_table
			//			string whole_value = equation_list_to_ones[add_value];

			//			string[] whole_value_array = whole_value.Split();
			//			i = 0;
			//			 count2 = 0;
			//			foreach (string whole_value_element in whole_value_array)
			//			{
			//				if (whole_value_element == "a" || whole_value_element == "b" || whole_value_element == "c" || whole_value_element == "d" || whole_value_element == "e" || whole_value_element == "f" || whole_value_element == "g" || whole_value_element == "h" || whole_value_element == "i" || whole_value_element == "j" || whole_value_element == "k" || whole_value_element == "l" || whole_value_element == "m" || whole_value_element == "n" || whole_value_element == "o" || whole_value_element == "p" || whole_value_element == "q" || whole_value_element == "r" || whole_value_element == "s" || whole_value_element == "t" || whole_value_element == "u" || whole_value_element == "v" || whole_value_element == "w" || whole_value_element == "x" || whole_value_element == "y" || whole_value_element == "z")
			//				{
			//					count2 = i;
			//					break;
			//				}

			//				i = i + 1;
			//			}

			//			/// make amalgomation list to grab the correct values out of the whole values array
			//			i = 0;
			//			List<string> amalgomation_list = new List<string>();
			//			foreach (string string_element in whole_value_array)
			//			{
			//				if (i <= count2)
			//				{
			//					amalgomation_list.Add(string_element);
			//				}
			//				i = i + 1;
			//			}


						/// join the amalgomation list into one variable and add it to sum_list
				///		string amalgomation = string.Join("", amalgomation_list.ToArray());

					///	int amalgomation_int = int.Parse(amalgomation);

					///	sum_list.Add(amalgomation_int);
					
				///	}

				

					/// 
					//foreach (int addition in sum_list)
					//{

					//}





					//foreach (string subelement in equation_list)
					//{
					//	if (subelement == "-" || subelement == "+")
					//	{
					//		///Console.WriteLine(subelement);

					//	}
					//	else
					//	{
					//		if (k == i)
					//		{

								/// subelement = 3.5xy
								/// element = 5

								///string value_one = subelement;
								///string value_two = equation_list[element];

						 ///    Console.WriteLine(subelement);
							///	Console.WriteLine(value_two);
			//				}
			//					k = k + 1;
			//			}
			//			j = j + 1;
			//		}




			//	}
			//	i = i + 1;
			//}






		///	PrintKeysAndValues(myKeys, myValues);






			foreach (string element in concat_list)
			{
		//	Console.WriteLine(element);

			}


			//foreach (int element in reference_list)
			//{
			//Console.WriteLine(element);

			//}
			/// why cant I override variables?
				
		}
	}
}
