using System;
using System.IO;
using System.Text.RegularExpressions;

Regex regex = new(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))");
int answer = 0;

var input = File.ReadLines("input1.txt");
foreach (var line in input)
{
    var matches = regex.Matches(line);
    var first = GetValue(matches.First().Groups[1].Value);
    var last = GetValue(matches.Last().Groups[1].Value);
    var result = first * 10 + last;
    answer += result;

    Console.WriteLine(line);
    Console.WriteLine("- {0} {1} = {2} ({3})", first, last, result, answer);
} 

static int GetValue(string input)
{
    if(!int.TryParse(input, out var answer))
    {
        switch (input)
        {
            case "one": answer = 1; break;
            case "two": answer = 2; break;
            case "three": answer = 3; break;
            case "four": answer = 4; break;
            case "five": answer = 5; break;
            case "six": answer = 6; break;
            case "seven": answer = 7; break;
            case "eight": answer = 8; break;
            case "nine": answer = 9; break;
            default:
                Console.WriteLine("Could not figure out what '{0}' is.", input);
                break;
        }
    }

    return answer;

}
Console.WriteLine(answer);