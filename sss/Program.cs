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
		public static List<string> count_list = new List<string>();



		public void perform_math()
		{

			//int i = 0;
			//foreach (string element in concat_list)
			//{
			//	Console.WriteLine(concat_list[i]);
			//	i = i + 1;

			//}
		


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









		public void join_to_string()
		{
			string joined = string.Join(" ", concat_list.ToArray());
			Console.WriteLine("-------------");
			Console.WriteLine(joined);
			Console.WriteLine("-------------");
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
			m.remove_all_spaces();
			m.add_equals_and_zero_to_end();
			m.join_to_string();


		


			foreach (string element in concat_list)
			{
			//Console.WriteLine(element);

			}

		}
	}
}
