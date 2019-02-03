using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpHuntGamingAssessment
{
    public class Decrypt
    {
        Dictionary<int, char> alphabets = new Dictionary<int, char>()
        {
            {1,'A' }, {2, 'B' }, {3, 'C'},{4, 'D'},{5, 'E'},{6,'F'},{7,'G'},{8,'H'},{9, 'I'},{10, 'J'},{11, 'K'},{12,'L'}, {13, 'M' },{14, 'N'},
            { 15, 'O'}, {16, 'P'},{17,'Q'},{18, 'R'},{19, 'S'},{20, 'T'},{21, 'U'},{22, 'V'},{23, 'W'},{24, 'X'},{25, 'Y'},{26, 'Z'}
        };
        private string _encryptedMessage { get; set; }
        private int _key { get; set; }

        public Decrypt(string encryptedMessage, int key)
        {
            this._encryptedMessage = encryptedMessage;
            this._key = key;
        }

        public string GetDecrypedMessage()
        {
            char[] splittedChars = _encryptedMessage.ToCharArray();

            List<char> charsList = new List<char>();

            Dictionary<int, char> mappedCharacters = _GetMappedAlphabets();

            foreach(char ch in splittedChars)
            {
                if (ch == ' ')
                {
                    charsList.Add(' ');
                    continue;
                }
                else
                {
                    if(mappedCharacters.ContainsValue(ch))
                    {
                        int index = mappedCharacters.Where(item => item.Value.ToString().Trim() == ch.ToString().Trim()).Select(item => item.Key).FirstOrDefault();

                        charsList.Add(alphabets[index]);
                    }
                    else
                    {
                        charsList.Add(ch);
                    }
                }
            }

            return new string(charsList.ToArray());
        }

        private Dictionary<int, char> _GetMappedAlphabets()
        {
            Dictionary<int, char> mappedAlphabets = new Dictionary<int, char>();

            int reIndex = 0;
            foreach(int index in alphabets.Keys)
            {
                mappedAlphabets.Add(index, _GetDecryptCharacter(ref reIndex, index));
            }

            return mappedAlphabets;
        }

        private char _GetDecryptCharacter(ref int reIndex, int index)
        {
            if((index + _key) > 26)
            {
                reIndex += 1;
            }

            return alphabets[reIndex == 0 ? (index + _key) : reIndex];
        }
    }
}
