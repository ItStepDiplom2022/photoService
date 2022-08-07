using System.Text.RegularExpressions;
/// <summary>
/// This class implements string comparison algorithm
/// based on character pair similarity
/// Source: http://www.catalysoft.com/articles/StrikeAMatch.html
/// </summary>
public static class SimilarityTool
{
    /// <summary>
    /// Compares the two strings based on letter pair matches
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns>The percentage match from 0.0 to 1.0 where 1.0 is 100%</returns>
    public static float CompareStrings(string str1, string str2)
    {
        List<string> pairs1 = WordLetterPairs(str1.ToUpper());
        List<string> pairs2 = WordLetterPairs(str2.ToUpper());

        int intersection = 0;
        int union = pairs1.Count + pairs2.Count;

        for (int i = 0; i < pairs1.Count; i++)
        {
            for (int j = 0; j < pairs2.Count; j++)
            {
                if (pairs1[i] == pairs2[j])
                {
                    intersection++;
                    pairs2.RemoveAt(j);//Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success

                    break;
                }
            }
        }

        return (2.0f * intersection) / union;
    }

    /// <summary>
    /// Gets all letter pairs for each
    /// individual word in the string
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private static List<string> WordLetterPairs(string str)
    {
        List<string> AllPairs = new List<string>();

        // Tokenize the string and put the tokens/words into an array
        string[] Words = Regex.Split(str, @"\s");

        // For each word
        for (int w = 0; w < Words.Length; w++)
        {
            if (!string.IsNullOrEmpty(Words[w]))
            {
                // Find the pairs of characters
                String[] PairsInWord = LetterPairs(Words[w]);

                for (int p = 0; p < PairsInWord.Length; p++)
                {
                    AllPairs.Add(PairsInWord[p]);
                }
            }
        }

        return AllPairs;
    }

    /// <summary>
    /// Generates an array containing every 
    /// two consecutive letters in the input string
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private static string[] LetterPairs(string str)
    {
        int numPairs = str.Length - 1;

        string[] pairs = new string[numPairs];

        for (int i = 0; i < numPairs; i++)
        {
            pairs[i] = str.Substring(i, 2);
        }

        return pairs;
    }
}