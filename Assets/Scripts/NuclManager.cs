using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class NuclManager
{
    public enum NuclEnum
    {
        eNucl_A,
        eNucl_T,
        eNucl_C,
        eNucl_G,
        eNucl_X
    }

    public static char ToChar(NuclEnum nucl)
    {
        switch (nucl)
        {
            case NuclEnum.eNucl_A: return 'A';
            case NuclEnum.eNucl_T: return 'T';
            case NuclEnum.eNucl_C: return 'C';
            case NuclEnum.eNucl_G: return 'G';
            case NuclEnum.eNucl_X:
            default:
                return 'X';
        }
    }

    public static string ToString(NuclEnum nucl_0, NuclEnum nucl_1, NuclEnum nucl_2, NuclEnum nucl_3, NuclEnum nucl_4)
    {
        return "" + ToChar(nucl_0) + ToChar(nucl_1) + ToChar(nucl_2) + ToChar(nucl_3) + ToChar(nucl_4);
    }

    public static NuclEnum FromChar(char chr)
    {
        switch (chr)
        {
            case 'A': return NuclEnum.eNucl_A;
            case 'T': return NuclEnum.eNucl_T;
            case 'C': return NuclEnum.eNucl_C;
            case 'G': return NuclEnum.eNucl_G;
            case 'X':
            default:
                return NuclEnum.eNucl_X;
        }
    }

    public static bool Compare(string origin, string model)
    {
        Regex rgx = new Regex(model.Replace("X", "[ATCG]"));
        return rgx.IsMatch(origin);
    }

    public static List<int> CorrectIndices(string origin, string model)
    {
        Debug.Assert(origin.Length == 5);
        Debug.Assert(model.Length == 5);
        List<int> indexes = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            char m = model[i];
            if (m == ToChar(NuclEnum.eNucl_X))
                continue;
            
            char o = origin[i];
            if (m == o)
                indexes.Add(i);
        }

        return indexes;
    }
}
