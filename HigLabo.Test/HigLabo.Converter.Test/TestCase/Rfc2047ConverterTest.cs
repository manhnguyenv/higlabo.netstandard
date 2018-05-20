﻿using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HigLabo.Converter.Test
{
    [TestClass]
    public class Rfc2047ConverterTest
    {
        [TestMethod]
        public void Rfc2047Converter_Basic1()
        {
            Rfc2047Converter cv = new Rfc2047Converter();

            Assert.AreEqual("a", cv.Decode("=?ISO-8859-1?Q?a?="));

            Assert.AreEqual("a b", cv.Decode("=?ISO-8859-1?Q?a?= b"));
            Assert.AreEqual("a b", cv.Decode("a =?ISO-8859-1?Q?b?="));
            Assert.AreEqual("a b", cv.Decode("a \r\n=?ISO-8859-1?Q?b?="));
            Assert.AreEqual("a b", cv.Decode("=?ISO-8859-1?Q?a?=\r\n b"));

        }
        [TestMethod]
        public void Rfc2047Converter_Basic2()
        {
            Rfc2047Converter cv = new Rfc2047Converter();

            Assert.AreEqual("ab", cv.Decode("=?ISO-8859-1?Q?a?= =?ISO-8859-1?Q?b?="));
            Assert.AreEqual("ab", cv.Decode("=?ISO-8859-1?Q?a?=  =?ISO-8859-1?Q?b?="));
            Assert.AreEqual("ab", cv.Decode("=?ISO-8859-1?Q?a?= \r\n\t   =?ISO-8859-1?Q?b?="));

        }
        [TestMethod]
        public void Rfc2047Converter_Basic3()
        {
            Rfc2047Converter cv = new Rfc2047Converter();

            Assert.AreEqual("a b", cv.Decode("=?ISO-8859-1?Q?a_b?="));
            Assert.AreEqual("a b", cv.Decode("=?ISO-8859-1?Q?a?= =?ISO-8859-1?Q?_b?="));
        }
        [TestMethod]
        public void Rfc2047Converter_Basic4()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Rfc2047Converter cv = new Rfc2047Converter();

            Assert.AreEqual("2014年4月16日", cv.Decode("2014=?ISO-2022-JP?B?GyRCRy8bKEI=?=" 
                + "4=?ISO-2022-JP?B?GyRCN24bKEI=?=16=?ISO-2022-JP?B?GyRCRnwbKEI=?="));
        }
        [TestMethod]
        public void Rfc2047Converter_Basic5()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Rfc2047Converter cv = new Rfc2047Converter();

            Assert.AreEqual("Отчёт о движении вагонов с углём АО \"Сибугл"
                , cv.Decode("=?utf-8?B?0J7RgtGH0ZHRgiDQviDQtNCy0LjQttC10L3QuNC4INCy0LDQ?=\r\n" 
                + " =?utf-8?B?s9C+0L3QvtCyINGBINGD0LPQu9GR0Lwg0JDQniAi0KHQuNCx0YPQs9C7?=\r\n"));
        }
    }
}