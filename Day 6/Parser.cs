namespace Day_6;
class Parser
{
    public static int Parse(string filePath, int uniqueCharacters)
    {
        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) { break; }

            var chars = line.ToCharArray();

            var marker = new char[uniqueCharacters];
            int j = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                marker[j] = chars[i];

                if (i >= uniqueCharacters)
                {
                    if (CharArrayIsUnique(marker))
                    {
                        return i + 1;
                    }
                }

                j++;
                if (j == uniqueCharacters)
                {
                    j = 0;
                }
            }
        }

        return -1;
    }

    private static bool CharArrayIsUnique(char[] array)
    {
        var isUnique = true;

        for(int i = 0; i < array.Length; i++)
        {
            if(array.Where(x => x == array[i]).Count() > 1)
            {
                isUnique = false;
                break;
            }
        }

        return isUnique;
    }
}