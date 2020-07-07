using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460_Hwk03
{
    class Program
    {
        /// <summary>
        ///     utility function -- 
        ///     prints instructions to use this program on the command-line
        /// </summary>
        ///------------------------------------------------------------
        private static void PrintUsage()
        {
            // obviously will adjust this for C#.....
            Console.WriteLine("\n\nUsage is thusly:\n" +
                "\tProgram C inputFile outputFile\n\n" +
                "Where:\n" +
                "'C' is the column number you want to wrap to...\n" +
                "'inputFile' is your input text file...\n" +
                "'outputFile' is the new output file name, which will " +
                "contain the newly-wrapped text.\n" +
                "This program will create a new ouput file, or " +
                "over-write an existing one.\n\n" +
                "e.g., Program 45 myInputFile.txt myWrappedOutputFile.txt");
        }
        //===============================================================================

        //===============================================================================
        //                         MAIN() STARTS HERE
        /// <summary>
        ///     this is what runs everything
        /// </summary>
        /// <param name="args">
        ///     the command-line arguments -- see usage notes ^^^ up there
        /// </param>
        /// <notes>
        ///     1) to compile from command line:
        ///         * open VS Developer Command Prompt
        ///         * get to the directory your stuff is in
        ///         * type: csc Node.cs IQueueInterface.cs LinkedQueue.cs 
        ///                     QueueUnderflowException.cs Program.cs  (all on one line)
        ///         * it does it's thing -- hopefully it all compiles correctly.....
        ///             * then type: Program arg0 arg1 arg2
        ///     
        ///     2) if you run this right from VS, the input file needs to be in \bin\bug
        ///         and this is where the output file will go, also
        ///         
        ///         if you run this from command line, those files need to be in the same
        ///         directory as your .cs files
        /// </notes>
        ///------------------------------------------------------------
        static void Main(string[] args)
        {
            int C = 72;     // column length you want to wrap to

            string inputFileName = "WarOfTheWorlds.txt";
            string outputFileName = "output.txt";

            // HERE IS OUR LINKED QUEUE!
            // read in words -- and their lengths -- from the input file, 
            //  into these vectors...
            IQueueInterface<String> words = new LinkedQueue<String>();

            // for interim step:
            string[] wordsRead = null;

            //---------------------------------------------------------
            // read in the command-line arguments
            if (args.Length != 3)
            {
                PrintUsage();
                Environment.Exit(0);
            }
            //---------------------------------------------------------
            // try reading in command-line args
            try
            {
                C = int.Parse(args[0]);
                inputFileName = args[1];
                outputFileName = args[2];               
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("I couldn't find your input file...");
                Environment.Exit(0);
            }
            catch (IOException ex)
            {
                Console.WriteLine("something is wrong with the input...");
                PrintUsage();
                Environment.Exit(0);
            }
            catch (Exception)
            {
                Console.WriteLine("general/random exception arose...");
                Environment.Exit(0);
            }
            //---------------------------------------------------------

            // NOW..... 
            // read the input text file..... tokenize it by whitespace.....
            // THIS IS WHERE SCANNER *** aka StreamReader *** CRAP GOES.....
            using (StreamReader input = new StreamReader(new FileStream(inputFileName, FileMode.Open)))
            {
                // read each word from intputFile into the array we made up there
                // 'tokenize by whitespace' -- aka one word per array element
                wordsRead = input.ReadToEnd().Split(' ', '\n', '\r');

                // now push each element aka word onto our LinkedQueue
                for (int i = 0; i < wordsRead.Length; i++)
                {
                    // push if not empty string
                    if (wordsRead[i] != "")
                    {
                        words.Push(wordsRead[i]);
                    }
                }
            }   // the 'using' thing closes StreamReader
            //---------------------------------------------------------

            // at this point, the input text file has been placed,
            // word-by-word, into our FIFO Queue.....
            // each word does not have white spaces included -- 
            // but does have punctuation, numbers, etc.

            //---------------------------------------------------------
            // set up for & start the word-wrapping function.....

            int spacesRemaining = WrapSimply(words, C, outputFileName);
            Console.WriteLine("total spaces remaining (Greedy): " + spacesRemaining);
            Console.WriteLine("\n\n\nhit enter to exit..... ");

            //---------------------------------------------------------
            //
            // this keeps the console from closing before you can even see what happened 
            Console.ReadKey();  

        }   // END OF MAIN()
        //===============================================================================

        //                               +++++++++

        //===============================================================================
        //                  our Greedy Word-Wrapping Algorithm
        //    it's non-optimal -- i.e., it's an approximate or heuristic solution
        //-------------------------------------------------------------------------------
        /// <summary>
        ///     this takes the words in our LinkedQueue, called 'words',
        ///     and word-wraps them to the given width (col-width)
        /// </summary>
        /// <param name="words">
        ///     our LinkedQueue with all the words from our inputFileName
        ///     file, tokenized by whitespace
        /// </param>
        /// <param name="columnLength">
        ///     how wide do we want our text? at what point do we wrap?
        /// </param>
        /// <param name="outputFileName">
        ///     the file that we're writing our word-wrapped results to
        /// </param>
        /// <returns></returns>
        ///------------------------------------------------------------
        private static int WrapSimply(IQueueInterface<string> words,
                                        int columnLength, string outputFileName)
        {
            StreamWriter output;

            try
            {
                // this is the one we'll be using in the big while-loop
                output = new StreamWriter(outputFileName);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("can't create or open " + outputFileName +
                                    " to write to..... using standard output instead!");
                using (output = new StreamWriter(Console.OpenStandardOutput()))
                {
                    Console.WriteLine("\nhere is your wrapped text:\n");
                }
                throw ex;
            }
            //---------------------------------------------------------

            // the vertical character location/space
            int col = 1;

            // running count of spaces left at the ends of the lines
            int spacesRemaining = 0;

            // as long as we've still got words in the LinkedQueue, 
            // keep right on popping & wrapping.....
            while (!words.IsEmpty())
            {
                // assign the next word in the LinkedQueue to 'str'
                string str = words.Peek();
                // get the length of that word
                int strLength = str.Length;

                // do we need to wrap to next line?
                if (col == 1)
                {
                    output.Write(str);
                    col += strLength;
                    words.Pop();
                }
                // go to the next line.....
                else if ((col + strLength) >= columnLength)
                {
                    output.WriteLine(" ");  // drop to next line
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;    // reset this!
                }
                // the usual case of printing next word on same line:
                else
                {
                    output.Write(" ");  // put a space between each word
                    output.Write(str);
                    col += (strLength + 1);
                    words.Pop();
                }
            } // end while-loop!
            //---------------------------------------------------------
            output.WriteLine();
            output.Flush();
            output.Close();     // since we didn't use 'using' for this, we have to
                                // 'flush' and close Streamwriter ourselves
            return spacesRemaining;

        }   // end of wrapSimply() function
        // now to detect where we want to keep some of the line-breaks,
        // like for the titular stuff at the top of the original file
        //  and the chapter headings and stuff like that.....
        //===============================================================================
    }
}