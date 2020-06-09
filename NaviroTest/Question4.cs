using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NaviroTest
{
    public class Question4
    {
        private Dictionary<int, uint> _numDict = new Dictionary<int, uint>();
        private uint _mostOccurence = 0;
        public Question4()
        {
        }

        public int[] GetMostCommon(int[] numArr)
        {
            foreach(int i in numArr)
            {
                // Add key to dictionary, increment by 1 if key exists in dictionary
                _numDict[i] = _numDict.ContainsKey(i) ? _numDict[i] + 1 : 1;
                // update _mostOccurence value
                if (_numDict[i] > _mostOccurence) { _mostOccurence = _numDict[i]; }
            }

            // select all key in dictionary with mostOccurence value
            var result = _numDict.Where(pair => pair.Value == _mostOccurence)
                                    .Select(pair => pair.Key);

            return result.ToArray();
        }   
    }
}