namespace Day_6;
class Parser
{
    public static int Parse(string filePath)
    {
        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) { break; }

            var chars = line.ToCharArray();

            var marker = new char[4];
            int j = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                marker[j] = chars[i];

                if (i >= 4)
                {
                    if (CharArrayIsUnique(marker))
                    {
                        return i + 1;
                    }
                }

                j++;
                if (j == 4)
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