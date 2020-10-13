// Copyright 2009-2020 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvHelper.Tests.Culture
{
	[TestClass]
	public class Iso8601Tests
	{
		[TestMethod]
		public void IsoLikeDateFormatCultureTest()
		{
			var c = CultureInfo.GetCultureInfo(1031).UseIsoLikeDateFormat();

			Assert.AreEqual(new DateTimeOffset(2020, 10, 13, 12, 0, 0, TimeSpan.Zero), DateTimeOffset.Parse("2020-10-13 12:00:00 +00:00", c));
			Assert.AreEqual(new DateTime(2020, 10, 13), DateTime.Parse("2020-10-13 00:00:00", c));

			Assert.AreEqual("2020-10-13 12:00:00 +00:00", new DateTimeOffset(2020, 10, 13, 12, 0, 0, TimeSpan.Zero).ToString(c));
			Assert.AreEqual("2020-10-13 00:00:00", new DateTime(2020, 10, 13).ToString(c));
		}

		[TestMethod]
		public void Iso8601DateFormatCultureTest()
		{
			var c = CultureInfo.InvariantCulture.UseIso8601DateFormat();

			Assert.AreEqual(new DateTimeOffset(2020, 10, 13, 12, 0, 0, TimeSpan.Zero), DateTimeOffset.Parse("2020-10-13T12:00:00 +00:00", c));
			Assert.AreEqual(new DateTime(2020, 10, 13), DateTime.Parse("2020-10-13T00:00:00", c));

			Assert.AreEqual("2020-10-13 12:00:00 +00:00", new DateTimeOffset(2020, 10, 13, 12, 0, 0, TimeSpan.Zero).ToString(c));
			Assert.AreEqual("2020-10-13T00:00:00", new DateTime(2020, 10, 13).ToString(c));
		}

	}
}
