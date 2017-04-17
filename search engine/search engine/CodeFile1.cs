using System;
class searching
{
    string search_engine_input = "";
    string codes = "france england america uk usa south africa";
    private int num = 0;
    private int m,n;
    static int i=0;
   
  
    private void kmp(string pattern)
    {
        
        int k = -1;
       
        
        int[] table = new int[50];
        if (i == 0)
        {
            table[0] = k;
            for (int j = 1; j < n; j++)
            {
                while (k > -1 && pattern[k + 1] != pattern[j])
                {
                    k = table[k];
                }
                if (pattern[j] == pattern[k + 1])
                {
                    k++;
                }

            }
        }

        k = -1;
        for (i=0; i < m; i++)
        {
            Console.Write("k=" + k);
            while (k > -1 && pattern[k + 1] != codes[i])
            {
                k = table[k];
            }
         
            if (codes[i] == pattern[k + 1])
            {
                k++;
            }
            if (k == n - 1)// that is k reached at the end of the pattern
            {
                Console.WriteLine("this word is found= " + pattern);
                num++;
                return;
            }
        }
        return;
    }
    private static void Main()
    {
        searching obj = new searching();
        string[] words=new string[20];
        char[] c=new char[50];
        Console.WriteLine("\nEnter the search_engine_input: ");
        obj.search_engine_input=Console.ReadLine();
        obj.m = obj.search_engine_input.Length;
        Console.WriteLine("m= " + obj.m);
        int p=0,wi=0,num_of_words=0;
        while (p < obj.search_engine_input.Length)
        {
            if (obj.search_engine_input[p] != ' ')
            {
                c[wi] = obj.search_engine_input[p];
                wi++;
            }
            else 
            {
                //c[wi] = '\0';
                int k = 0;
                char[] ch = new char[wi];
                while (k <wi)
                {
                    ch[k] = c[k];
                    k++;
                }
                
                words[num_of_words] = new string(ch);
                num_of_words++;
                wi = 0;
            }
            p++;
        }
        //c[wi] = '\0';
        int k2 = 0;
        char[] ch2 = new char[wi];
        while (k2 <wi)
        {
            ch2[k2] = c[k2];
            k2++;
        }
        words[num_of_words] = new string(ch2);
        num_of_words++;
        p = 0;
        Console.WriteLine("num of words=" + (num_of_words));
        obj.m = obj.search_engine_input.Length;
        while (p<num_of_words)
        {
            Console.WriteLine("word number = " + (p + 1) + " is " + words[p] + "    lenghth =" + words[p].Length);
            p++;
        }
        p = 0;
        while (p < num_of_words)
        {
            obj.n = words[p].Length;
            i = 0;
            obj.kmp(words[p]);
            p++;
        }
        Console.ReadLine();
    }
}
