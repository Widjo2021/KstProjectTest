using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Testing
{
 public class NamaVM
    {
        public int nomer { get; set; }
        public string text { get; set; }
    }
class ReadFromFile
{
	
    static void Main()
    {
		List<NamaVM> source = new List<NamaVM>();
		List<NamaVM> lastname = new List<NamaVM>();
		string text = File.ReadAllText(@"unsorted-names-list.txt", Encoding.UTF8);
		string path = @"sorted-names-list.txt";
		Console.Clear();
		Console.WriteLine("\t" +text); 
		Console.WriteLine("");
        string[] myarr = text.Split(',');  
		//string[] test3 = text2.Split(',');  
		List<string> result = new List<string>();
		List<string> myarr2 = new List<string>();
		int i=0;
		foreach (var item in myarr)
		{
			source.Add(new NamaVM
			{
				nomer = i+1,
				text = item
			});
			string mylast = takelast(item);
			myarr2.Add(mylast);
			lastname.Add(new NamaVM
			{
				nomer = i+1,
				text = mylast
			});
			
			i = i+1;
		}
		String[] myarr3 = myarr2.ToArray();
		Array.Sort(myarr3);
		foreach (var item2 in myarr3)
		{
			int ismatch = 0;
			foreach (var item in source)
			{
				string words1 = item.text;
				ismatch = findword(words1,item2);
				if (ismatch == 1) {
					result.Add(words1);
				}
			}
		}
		
		int Lengthstring = myarr.Length;
		string lineadd = "";
		if (File.Exists(path))  
		{    
			// If file found, delete it    
			File.Delete(path);    
			//Console.WriteLine("File deleted.");    
		} 
		for (int k = 0; k <Lengthstring; k++) {
			if (k<(Lengthstring-1))
				lineadd = result[k] + ", ";
			else 
				lineadd = result[k];
			Console.WriteLine(lineadd);
			if (!File.Exists(path))
			{
				// Create a file to write to.
				string createText = lineadd + ", " + Environment.NewLine;
				File.WriteAllText(path, lineadd);
			}
			else {
				File.AppendAllText(path, lineadd);
			}
		}
    }
	public static string takelast(string text)
	{
		string[] myarr = text.Split(' '); 
		return myarr[myarr.Length-1];
	}
	
	public static int findword(string text1,string text2)
	{
		
		//Console.WriteLine("{0}, {1}",text1,text2);
		string[] myarr1 = text1.Split(' '); 
		if ((myarr1[myarr1.Length-1])==text2)
		   return 1;
	   else
		   return 0;
	   
	}
}
}



