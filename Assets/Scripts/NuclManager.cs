using System;
using System.Text.RegularExpressions;

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

    public static string ToString(NuclEnum nucl)
    {
        switch (nucl)
        {
            case NuclEnum.eNucl_A: return "A";
            case NuclEnum.eNucl_T: return "T";
            case NuclEnum.eNucl_C: return "C";
            case NuclEnum.eNucl_G: return "G";
            case NuclEnum.eNucl_X: return "X";
            default: return "";
        }
    }

    public static string ToString(NuclEnum nucl_0, NuclEnum nucl_1, NuclEnum nucl_2, NuclEnum nucl_3, NuclEnum nucl_4)
    {
        return ToString(nucl_0) + ToString(nucl_1) + ToString(nucl_2) + ToString(nucl_3) + ToString(nucl_4);
    }

    public static bool Compare(string origin, string model)
    {
        Regex rgx = new Regex(model.Replace("X", "[ATCG]"));
        return rgx.IsMatch(origin);
    }
}
