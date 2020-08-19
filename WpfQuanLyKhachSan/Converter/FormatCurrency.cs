﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Converter
{
    static class FormatCurrency
    {
        public static String FormatCurrencyVN(string money)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string moneyFormatVN = double.Parse(money).ToString("#,###", cul.NumberFormat);

            return moneyFormatVN;
        }
    }
}