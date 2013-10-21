﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankBot
{
    enum VehicleClass { HT, MT, LT, SPG, TD, ERROR };
    class VehicleInfo
    {
        
        public int tier;
        public int speed;
        public VehicleClass vClass;
        public VehicleInfo(int _tier, int _speed, VehicleClass _vClass)
        {
            this.tier = _tier;
            this.speed = _speed;
            this.vClass = _vClass;
        }
        public VehicleInfo()
        {
            this.tier = 0;
            this.speed = 0;
            this.vClass = VehicleClass.ERROR;
        }

    }
    class VehicleInfoGet
    {
        public static Dictionary<string, VehicleInfo> d = new Dictionary<string,VehicleInfo>();
        public static VehicleInfo get(string vname)
        {
            if (d.Count == 0)
            {
                d["T-34"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["SU-85"] = new VehicleInfo(5, -1, VehicleClass.TD);
                d["IS"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["BT-7"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["BT-2"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["KV"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["T-28"] = new VehicleInfo(4, -1, VehicleClass.MT);
                d["S-51"] = new VehicleInfo(7, -1, VehicleClass.SPG);
                d["A-20"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["SU-152"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["T-34-85"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["KV-1s"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["T-46"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["MS-1"] = new VehicleInfo(1, -1, VehicleClass.LT);
                d["SU-100"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["SU-18"] = new VehicleInfo(2, -1, VehicleClass.SPG);
                d["SU-14"] = new VehicleInfo(8, -1, VehicleClass.SPG);
                d["T-44"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["T-26"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["SU-5"] = new VehicleInfo(4, -1, VehicleClass.SPG);
                d["AT-1"] = new VehicleInfo(2, -1, VehicleClass.TD);
                d["IS-3"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["SU-8"] = new VehicleInfo(6, -1, VehicleClass.SPG);
                d["KV-3"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["IS-4"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["SU-76"] = new VehicleInfo(3, -1, VehicleClass.TD);
                d["T-43"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["GAZ-74b"] = new VehicleInfo(4, -1, VehicleClass.TD);
                d["IS-7"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["ISU-152"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["SU-26"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["T-54"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["Object_704"] = new VehicleInfo(9, -1, VehicleClass.TD);
                d["Object_212"] = new VehicleInfo(9, -1, VehicleClass.SPG);
                d["Object_261"] = new VehicleInfo(10, -1, VehicleClass.SPG);
                d["KV-13"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["Object252"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["T-50"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["T_50_2"] = new VehicleInfo(5, -1, VehicleClass.LT);
                d["SU-101"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["SU100M1"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["KV2"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["ST_I"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["KV4"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["T150"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["IS8"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["KV1"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["SU122_54"] = new VehicleInfo(9, -1, VehicleClass.TD);
                d["A43"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["A44"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["Object416"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["Object268"] = new VehicleInfo(10, -1, VehicleClass.TD);
                d["T62A"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["Object263"] = new VehicleInfo(10, -1, VehicleClass.TD);
                d["T-70"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["T-60"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["Object_907"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["T80"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["SU14_1"] = new VehicleInfo(7, -1, VehicleClass.SPG);
                d["SU122A"] = new VehicleInfo(5, -1, VehicleClass.SPG);
                d["MT25"] = new VehicleInfo(6, -1, VehicleClass.LT);
                d["Object_140"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["KV-220"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["Matilda_II_LL"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["Churchill_LL"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["BT-SV"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["Valentine_LL"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["M3_Stuart_LL"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["A-32"] = new VehicleInfo(4, -1, VehicleClass.MT);
                d["KV-5"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["T-127"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["SU_85I"] = new VehicleInfo(5, -1, VehicleClass.TD);
                d["KV-220_action"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["Tetrarch_LL"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["SU100Y"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["SU122_44"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["T-34-85_training"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["LTP"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["T44_122"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["T44_85"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["PzIV"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["Hummel"] = new VehicleInfo(6, -1, VehicleClass.SPG);
                d["PzVI"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["Pz35t"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["StuGIII"] = new VehicleInfo(5, -1, VehicleClass.TD);
                d["PzV"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["JagdPzIV"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["Hetzer"] = new VehicleInfo(4, -1, VehicleClass.TD);
                d["PzII"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["VK3601H"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["VK3001H"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["Bison_I"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["Ltraktor"] = new VehicleInfo(1, -1, VehicleClass.LT);
                d["Pz38t"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["PanzerJager_I"] = new VehicleInfo(2, -1, VehicleClass.TD);
                d["JagdPanther"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["VK3002DB"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["PzIII"] = new VehicleInfo(4, -1, VehicleClass.MT);
                d["Sturmpanzer_II"] = new VehicleInfo(4, -1, VehicleClass.SPG);
                d["PzIII_A"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["PzVIB_Tiger_II"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["VK1602"] = new VehicleInfo(5, -1, VehicleClass.LT);
                d["Grille"] = new VehicleInfo(5, -1, VehicleClass.SPG);
                d["Wespe"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["PzII_Luchs"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["PzIII_IV"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["G20_Marder_II"] = new VehicleInfo(3, -1, VehicleClass.TD);
                d["Maus"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["VK3001P"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["VK4502P"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["Ferdinand"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["JagdTiger"] = new VehicleInfo(9, -1, VehicleClass.TD);
                d["Pz38_NA"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["Panther_II"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["G_Tiger"] = new VehicleInfo(9, -1, VehicleClass.SPG);
                d["G_Panther"] = new VehicleInfo(7, -1, VehicleClass.SPG);
                d["G_E"] = new VehicleInfo(10, -1, VehicleClass.SPG);
                d["E-100"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["E-75"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["VK2801"] = new VehicleInfo(6, -1, VehicleClass.LT);
                d["E-50"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["VK4502A"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["PzVI_Tiger_P"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["JagdPantherII"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["JagdPz_E100"] = new VehicleInfo(10, -1, VehicleClass.TD);
                d["E50_Ausf_M"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["PzI_ausf_C"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["PzI"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["Pz_II_AusfG"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["DW_II"] = new VehicleInfo(4, -1, VehicleClass.HT);
                d["VK2001DB"] = new VehicleInfo(4, -1, VehicleClass.MT);
                d["Indien_Panzer"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["VK3002DB_V1"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["Auf_Panther"] = new VehicleInfo(7, -1, VehicleClass.LT);
                d["Leopard1"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["Pro_Ag_A"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["GW_Mk_VIe"] = new VehicleInfo(2, -1, VehicleClass.SPG);
                d["GW_Tiger_P"] = new VehicleInfo(8, -1, VehicleClass.SPG);
                d["Pz_Sfl_IVb"] = new VehicleInfo(4, -1, VehicleClass.SPG);
                d["VK3002M"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["PzV_PzIV"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["PzII_J"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["S35_captured"] = new VehicleInfo(3, -1, VehicleClass.MT);
                d["B-1bis_captured"] = new VehicleInfo(4, -1, VehicleClass.HT);
                d["H39_captured"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["PzV_PzIV_ausf_Alfa"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["Lowe"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["T-25"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["T-15"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["PzIV_Hydro"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["JagdTiger_SdKfz_185"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["E-25"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["DickerMax"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["PzIV_schmalturm"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["Panther_M10"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["PzIII_training"] = new VehicleInfo(4, -1, VehicleClass.MT);
                d["PzVIB_Tiger_II_training"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["PzV_training"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["VK7201"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["T14"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["M3_Stuart"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["T1_Cunningham"] = new VehicleInfo(1, -1, VehicleClass.LT);
                d["M6"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["M4_Sherman"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["M4A3E8_Sherman"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["T20"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["M2_lt"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["T57"] = new VehicleInfo(2, -1, VehicleClass.SPG);
                d["T23"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["T30"] = new VehicleInfo(9, -1, VehicleClass.TD);
                d["T34_hvy"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["M3_Grant"] = new VehicleInfo(4, -1, VehicleClass.MT);
                d["T1_hvy"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["M7_Priest"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["T29"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["M41"] = new VehicleInfo(5, -1, VehicleClass.SPG);
                d["T32"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["M37"] = new VehicleInfo(4, -1, VehicleClass.SPG);
                d["M2_med"] = new VehicleInfo(3, -1, VehicleClass.MT);
                d["M5_Stuart"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["M7_med"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["T2_med"] = new VehicleInfo(2, -1, VehicleClass.MT);
                d["Pershing"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["T18"] = new VehicleInfo(2, -1, VehicleClass.TD);
                d["T82"] = new VehicleInfo(3, -1, VehicleClass.TD);
                d["M10_Wolverine"] = new VehicleInfo(5, -1, VehicleClass.TD);
                d["M36_Slagger"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["M40M43"] = new VehicleInfo(8, -1, VehicleClass.SPG);
                d["T40"] = new VehicleInfo(4, -1, VehicleClass.TD);
                d["M12"] = new VehicleInfo(7, -1, VehicleClass.SPG);
                d["T28"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["T92"] = new VehicleInfo(10, -1, VehicleClass.SPG);
                d["T95"] = new VehicleInfo(9, -1, VehicleClass.TD);
                d["M46_Patton"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["T25_AT"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["M103"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["M24_Chaffee"] = new VehicleInfo(5, -1, VehicleClass.LT);
                d["Sherman_Jumbo"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["M8A1"] = new VehicleInfo(4, -1, VehicleClass.TD);
                d["T49"] = new VehicleInfo(5, -1, VehicleClass.TD);
                d["T110"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["T25_2"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["T28_Prototype"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["M18_Hellcat"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["T110E4"] = new VehicleInfo(10, -1, VehicleClass.TD);
                d["T26_E4_SuperPershing"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["T110E3"] = new VehicleInfo(10, -1, VehicleClass.TD);
                d["M48A1"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["T69"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["T57_58"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["T21"] = new VehicleInfo(6, -1, VehicleClass.LT);
                d["T54E1"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["T71"] = new VehicleInfo(7, -1, VehicleClass.LT);
                d["M60"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["M53_55"] = new VehicleInfo(9, -1, VehicleClass.SPG);
                d["M44"] = new VehicleInfo(6, -1, VehicleClass.SPG);
                d["T2_lt"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["Ram-II"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["MTLS-1G14"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["M4A2E4"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["M6A2E1"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["M22_Locust"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["T1_E6"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["Sexton_I"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["M4A3E8_Sherman_training"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["Ch01_Type59"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["Ch02_Type62"] = new VehicleInfo(7, -1, VehicleClass.LT);
                d["Ch01_Type59_Gold"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["Ch03_WZ-111"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["Ch04_T34_1"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["Ch06_Renault_NC31"] = new VehicleInfo(1, -1, VehicleClass.LT);
                d["Ch05_T34_2"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["Ch18_WZ-120"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["Ch12_111_1_2_3"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["Ch07_Vickers_MkE_Type_BT26"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["Ch11_110"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["Ch09_M5"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["Ch16_WZ_131"] = new VehicleInfo(7, -1, VehicleClass.LT);
                d["Ch10_IS2"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["Ch17_WZ131_1_WZ132"] = new VehicleInfo(8, -1, VehicleClass.LT);
                d["Ch19_121"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["Ch08_Type97_Chi_Ha"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["Ch21_T34"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["Ch15_59_16"] = new VehicleInfo(6, -1, VehicleClass.LT);
                d["Ch20_Type58"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["Ch22_113"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["Ch14_T34_3"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["Ch04_T34_1_training"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["Ch23_112"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["Ch24_Type64"] = new VehicleInfo(6, -1, VehicleClass.LT);
                d["D2"] = new VehicleInfo(3, -1, VehicleClass.MT);
                d["RenaultFT"] = new VehicleInfo(1, -1, VehicleClass.LT);
                d["RenaultBS"] = new VehicleInfo(2, -1, VehicleClass.SPG);
                d["B1"] = new VehicleInfo(4, -1, VehicleClass.HT);
                d["Hotchkiss_H35"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["D1"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["_105_leFH18B2"] = new VehicleInfo(5, -1, VehicleClass.SPG);
                d["FCM_36Pak40"] = new VehicleInfo(3, -1, VehicleClass.TD);
                d["ARL_44"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["AMX40"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["AMX_50_100"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["Lorraine39_L_AM"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["Bat_Chatillon25t"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["AMX_50_120"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["AMX_105AM"] = new VehicleInfo(5, -1, VehicleClass.SPG);
                d["AMX_13F3AM"] = new VehicleInfo(6, -1, VehicleClass.SPG);
                d["AMX_13_90"] = new VehicleInfo(8, -1, VehicleClass.LT);
                d["AMX_13_75"] = new VehicleInfo(7, -1, VehicleClass.LT);
                d["Lorraine40t"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["AMX38"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["F10_AMX_50B"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["AMX_12t"] = new VehicleInfo(6, -1, VehicleClass.LT);
                d["BDR_G1B"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["AMX_M4_1945"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["Lorraine155_50"] = new VehicleInfo(7, -1, VehicleClass.SPG);
                d["Lorraine155_51"] = new VehicleInfo(8, -1, VehicleClass.SPG);
                d["RenaultFT_AC"] = new VehicleInfo(2, -1, VehicleClass.TD);
                d["RenaultUE57"] = new VehicleInfo(3, -1, VehicleClass.TD);
                d["Somua_Sau_40"] = new VehicleInfo(4, -1, VehicleClass.TD);
                d["S_35CA"] = new VehicleInfo(5, -1, VehicleClass.TD);
                d["AMX_AC_Mle1946"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["AMX50_Foch"] = new VehicleInfo(9, -1, VehicleClass.TD);
                d["ARL_V39"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["Bat_Chatillon155_58"] = new VehicleInfo(10, -1, VehicleClass.SPG);
                d["AMX_AC_Mle1948"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["AMX_50Fosh_155"] = new VehicleInfo(10, -1, VehicleClass.TD);
                d["ELC_AMX"] = new VehicleInfo(5, -1, VehicleClass.LT);
                d["Bat_Chatillon155_55"] = new VehicleInfo(9, -1, VehicleClass.SPG);
                d["AMX_Ob_Am105"] = new VehicleInfo(4, -1, VehicleClass.SPG);
                d["FCM_50t"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["GB01_Medium_Mark_I"] = new VehicleInfo(1, -1, VehicleClass.MT);
                d["GB05_Vickers_Medium_Mk_II"] = new VehicleInfo(2, -1, VehicleClass.MT);
                d["GB07_Matilda"] = new VehicleInfo(4, -1, VehicleClass.MT);
                d["GB21_Cromwell"] = new VehicleInfo(6, -1, VehicleClass.MT);
                d["GB20_Crusader"] = new VehicleInfo(5, -1, VehicleClass.LT);
                d["GB06_Vickers_Medium_Mk_III"] = new VehicleInfo(3, -1, VehicleClass.MT);
                d["GB08_Churchill_I"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["GB10_Black_Prince"] = new VehicleInfo(7, -1, VehicleClass.HT);
                d["GB27_Sexton"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["GB11_Caernarvon"] = new VehicleInfo(8, -1, VehicleClass.HT);
                d["GB12_Conqueror"] = new VehicleInfo(9, -1, VehicleClass.HT);
                d["GB09_Churchill_VII"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["GB04_Valentine"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["GB03_Cruiser_Mk_I"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["GB22_Comet"] = new VehicleInfo(7, -1, VehicleClass.MT);
                d["GB24_Centurion_Mk3"] = new VehicleInfo(9, -1, VehicleClass.MT);
                d["GB23_Centurion"] = new VehicleInfo(8, -1, VehicleClass.MT);
                d["GB13_FV215b"] = new VehicleInfo(10, -1, VehicleClass.HT);
                d["GB60_Covenanter"] = new VehicleInfo(4, -1, VehicleClass.LT);
                d["GB69_Cruiser_Mk_II"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["GB70_FV4202_105"] = new VehicleInfo(10, -1, VehicleClass.MT);
                d["GB59_Cruiser_Mk_IV"] = new VehicleInfo(3, -1, VehicleClass.LT);
                d["GB58_Cruiser_Mk_III"] = new VehicleInfo(2, -1, VehicleClass.LT);
                d["GB42_Valentine_AT"] = new VehicleInfo(3, -1, VehicleClass.TD);
                d["GB39_Universal_CarrierQF2"] = new VehicleInfo(2, -1, VehicleClass.TD);
                d["GB72_AT15"] = new VehicleInfo(8, -1, VehicleClass.TD);
                d["GB73_AT2"] = new VehicleInfo(5, -1, VehicleClass.TD);
                d["GB57_Alecto"] = new VehicleInfo(4, -1, VehicleClass.TD);
                d["GB48_FV215b_183"] = new VehicleInfo(10, -1, VehicleClass.TD);
                d["GB74_AT8"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["GB40_Gun_Carrier_Churchill"] = new VehicleInfo(6, -1, VehicleClass.TD);
                d["GB75_AT7"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["GB25_Loyd_Carrier"] = new VehicleInfo(2, -1, VehicleClass.SPG);
                d["GB26_Birch_Gun"] = new VehicleInfo(4, -1, VehicleClass.SPG);
                d["GB28_Bishop"] = new VehicleInfo(5, -1, VehicleClass.SPG);
                d["GB29_Crusader_5inch"] = new VehicleInfo(7, -1, VehicleClass.SPG);
                d["GB30_FV3805"] = new VehicleInfo(9, -1, VehicleClass.SPG);
                d["GB77_FV304"] = new VehicleInfo(6, -1, VehicleClass.SPG);
                d["GB79_FV206"] = new VehicleInfo(8, -1, VehicleClass.SPG);
                d["GB31_Conqueror_Gun"] = new VehicleInfo(10, -1, VehicleClass.SPG);
                d["GB32_Tortoise"] = new VehicleInfo(9, -1, VehicleClass.TD);
                d["GB68_Matilda_Black_Prince"] = new VehicleInfo(5, -1, VehicleClass.MT);
                d["GB63_TOG_II"] = new VehicleInfo(6, -1, VehicleClass.HT);
                d["GB71_AT_15A"] = new VehicleInfo(7, -1, VehicleClass.TD);
                d["GB51_Excelsior"] = new VehicleInfo(5, -1, VehicleClass.HT);
                d["GB78_Sexton_I"] = new VehicleInfo(3, -1, VehicleClass.SPG);
                d["Chi_Nu_Kai"] = new VehicleInfo(5, -1, VehicleClass.MT);

            }
            

            if (d.ContainsKey(vname))
                return d[vname];
            else
                return d["B1"];
        }
    }
}
