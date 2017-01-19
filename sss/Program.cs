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











//		var equation = ["+2x", "+1y", "-1x", "+2y"];
//		var equationRegex = /[a - zA - Z].*/ g;
//		var numberRegex = /\+([^;]*)[a-zA-z]/g; // Make this the right regex, should match the number part and the sign e.g +3.5

//function sortEquation(a, b)
//		{
//			var valueA = a.match(equationRegex)[0];
//			var valueB = b.match(equationRegex)[0];

//			if (valueA < valueB)
//			{
//				return -1;
//			}
//			if (valueA > valueB)
//			{
//				return 1;
//			}
//			// a must be equal to b
//			return 0;
//		}


//		function reduceEquation(accumulator, currentValue, i, array)
//		{
//			var prevValue = array[i - 1];
//			var splitCurrentValue = currentValue.match(equationRegex);
//			var splitPreviousValue = prevValue.match(equationRegex);

//			var splitCurrentNumber = currentValue.match(numberRegex);
//			var splitPreviousNumber = prevValue.match(numberRegex);

//			if (splitCurrentValue[0] === splitPreviousValue[0])
//			{
//				var total = Number(splitCurrentNumber[0]) + Number(splitPreviousNumber[0]);
//				var signedTotal = total > 0 ? "+" + total : String(total);

//				return signedTotal + splitCurrentValue[1];
//			}

//			return accumulator;
//		}

//		var finalAnswer = equation
//			.sort(sortEquation)
//			.reduce(reduceEquation);

//		console.log(finalAnswer + " = 0");




























		public static void Main(string[] args)
		{
			MainClass m = new MainClass();
			m.put_equation_in_list();
			m.remove_and_replace_sign();
			m.put_ones_in_front();
			m.add_plus_sign();
			m.to_concat_list();

		

		//	Array.Sort(concat_array);



			// m.sort_array();



		


	
			/// create arrays for each term to begin grouping like terms

			int i = 0;
			int j = 0;


			bool found = false;
			///String[] Array = new String[equation_list.Count];
			List<string> equal_table = new List<string>();
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




		




			///equation_list_to_ones.Sort();










			foreach (string element in equation_list_to_ones)

			{

				///Console.WriteLine(element);


			}










		




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








			string[] concat_array = concat_list.ToArray();
			string[] equal_array = equal_table.ToArray();



			Array.Sort(equal_array, concat_array);

		///	PrintKeysAndValues(myKeys, myValues);



			m.add_equals_and_zero_to_end();


			foreach (string element in concat_array)
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
