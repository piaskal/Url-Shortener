using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UrlShortener.Domain;

namespace UrlShortener.Test
{
    [TestFixture]
    class IdEncoderTest
    {
        [Test]
        public void Encode_Decode_Results_Consistent()
        {
            int before = 8645;
            int after = IdEncoder.Decode(IdEncoder.Encode(before));

            Assert.AreEqual(before,after);


            before = int.MaxValue;
            after = IdEncoder.Decode(IdEncoder.Encode(before));

            Assert.AreEqual(before,after);
        }
    }
}
