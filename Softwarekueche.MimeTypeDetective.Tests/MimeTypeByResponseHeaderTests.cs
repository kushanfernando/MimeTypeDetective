﻿using System;
using FluentAssertions;
using NUnit.Framework;

namespace Softwarekueche.MimeTypeDetective.Tests
{
    [TestFixture]
    public class MimeTypeByResponseHeaderTests
    {
        [Test]
        [TestCase(@"http://www.google.de", "text/html")]
        [TestCase(@"http://upload.wikimedia.org/wikipedia/commons/0/07/Metallica_at_The_O2_Arena_London_2008.jpg", "image/jpeg")]
        //[TestCase(@"http://api.openweathermap.org/data/2.5/weather?q=Siegburg,de", "application/json")]
        [TestCase(@"http://api.geonames.org/citiesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&lang=de&username=demo", "application/json")]
        public void TryWebUris(string uriString, string expected)
        {
            var sut = new MimeTypeByResponseHeader();
            sut.GetMimeTypeFor(new Uri(uriString)).Should().Be(expected);
        }
    }
}