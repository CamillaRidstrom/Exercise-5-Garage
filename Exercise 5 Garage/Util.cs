using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    public static class Util
    {
        //Metod som skriver ut en meny av valfri längd
        //Måste ha en string array med menyalternativen
        //och en menytitel
        public static void CreateMenu(string[] options, string menuTitle)
        {

            Console.WriteLine($"\n:::::::::::::::: {menuTitle} :::::::::::::::::\n");
            Console.WriteLine("Please navigate through the menu by inputting one of the following numbers: \n");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{options[i]}");
            }
        }


        //Metod som skapar en ConsoleRead och testar så att input är valid
        //Har defaultvärden som kan ändras när man kallar på metoden
        /* Obs characterTypeToSerachFor inte implementerad än*/
        public static string ValidateInput(string prompt = "Please write: ", int minLength = 1, int maxLength = 25, bool allCharactersAccepted = true, string defineOnlyCharacterTypeAllowed = " ", bool requireNonEmpty = true, char characterTypeToSerachFor = '\0')
        {
            string userInput;
            bool isValid = false;
            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if (requireNonEmpty && string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Input cannot be empty.");
                }
                else if (userInput.Length < minLength)
                {
                    Console.WriteLine($"Input needs to be at leaset {minLength} characters long.");
                }
                else if (userInput.Length > maxLength)
                {
                    Console.WriteLine($"Input can be at most {maxLength} characters long.");
                }
                else if (!allCharactersAccepted)
                {
                        string choosenCharacterType = defineOnlyCharacterTypeAllowed;

                        bool hasDigits;
                        bool hasLetters; 
                        bool hasSymbols; 
                        bool hasPunctuation;
                        int DigitCount;
                        int LetterCount;
                        int SymbolCount;
                        int PunctationCount;

                        characterTypeFromUser(userInput, out hasDigits, out DigitCount, out hasLetters, out LetterCount, out hasSymbols, out SymbolCount, out hasPunctuation, out PunctationCount);
                        
                    if (choosenCharacterType == "digits" && (hasLetters == true || hasSymbols == true || hasPunctuation == true))
                    {
                        Console.WriteLine($"Please use only {choosenCharacterType}.");
                    }
                    else if (choosenCharacterType == "letters" && (hasDigits == true || hasSymbols == true || hasPunctuation == true))
                    {
                        Console.WriteLine($"Please use only {choosenCharacterType}.");
                    }
                    else if (choosenCharacterType == "symbols" && (hasDigits == true || hasLetters == true || hasPunctuation == true))
                    {
                        Console.WriteLine($"Please use only {choosenCharacterType}.");
                    }
                    else if (choosenCharacterType == "punctuation" && (hasDigits == true || hasLetters == true || hasSymbols == true))
                    {
                        Console.WriteLine($"Please use only {choosenCharacterType}.");
                    }
                    else if (choosenCharacterType != "digits"  && choosenCharacterType != "letters" && choosenCharacterType != "symbols" && choosenCharacterType != "punctuation")
                    {
                        Console.WriteLine($"{choosenCharacterType} is not a valid option for defineOnlyCharacterTypeAllowed, please check the code and change it to 'digits', 'letters', 'symbols' or 'punctuation' all in lowercase.");
                    }
                    else
                    {
                        isValid = true;
                    }

                    //if (hasDigits == true)
                    //    {
                    //        Console.WriteLine($"Your input contains {DigitCount} numbers.");
                    //    }
                    //    if (hasLetters == true)
                    //    {
                    //        Console.WriteLine($"Your input contains {LetterCount} letters.");
                    //    }
                    //    if (hasSymbols == true)
                    //    {
                    //        Console.WriteLine($"Your input contains {SymbolCount} symbols.");
                    //    }
                    //    if (hasPunctuation == true)
                    //    {
                    //        Console.WriteLine($"Your input contains {PunctationCount} punctuations.");
                    //    }
                        //Console.WriteLine($"Innehåller {hasDigits} siffror.");
                        //Console.WriteLine($"Innehåller {hasLetters} bokstäver.");
                        //Console.WriteLine($"Innehåller {hasSymbols} symboler.");
                        //Console.WriteLine($"Innehåller {hasPunctuation} punkter.");
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            return userInput;
        }

        //Metod som testar vilken typ av tecken och hur många som finns i userInput
        public static void characterTypeFromUser (string userInput, out bool hasDigits, out int DigitCount, out bool hasLetters, out int LetterCount, out bool hasSymbols, out int SymbolCount, out bool hasPunctuation, out int PunctationCount)
        {
            DigitCount = 0;
            LetterCount = 0;
            SymbolCount = 0;
            PunctationCount = 0;
            
            foreach (char c in userInput) 
            {
                if (char.IsDigit(c))
                {
                    DigitCount++;
                }
                else if(char.IsLetter(c)) 
                {
                    LetterCount++;
                }
                else if (char.IsSymbol(c))
                {
                    SymbolCount++;
                }
                else if (char.IsPunctuation(c))
                {
                    PunctationCount++;
                }
            }
            hasDigits = DigitCount > 0;
            hasLetters = LetterCount > 0;
            hasSymbols = SymbolCount > 0;
            hasPunctuation = PunctationCount > 0;
        }
    }
}
