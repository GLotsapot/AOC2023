using System.IO;
using System.Text.RegularExpressions;

Regex regex = new Regex(@"\d");
int answer = 0;

var input = File.ReadLines("input.txt");
foreach (var line in input)
{
    var matches = regex.Matches(line);
    var first = Int32.Parse(matches.First().Value);
    var last = Int32.Parse(matches.Last().Value);
    answer += first * 10 + last;
} 
Console.WriteLine(answer);