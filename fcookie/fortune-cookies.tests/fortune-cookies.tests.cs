using System;
using NUnit.Framework;
using FortuneCookies;

namespace FortuneCookies.Tests
{
    [TestFixture]
    public class FortuneCookieTests
    {
        private FortuneCookie _cookie;

        [SetUp]
        public void SetUp()
        {
            _cookie = new FortuneCookie();
        }

        // ── VERSION 1 — GetFortune ────────────────────────────────────────────

        [Test]
        public void LuckyNumber1_ReturnsCamusQuote()
        {
            Assert.AreEqual(
                "In the midst of winter, I found there was, within me, an invincible summer.",
                _cookie.GetFortune(1));
        }

        [Test]
        public void LuckyNumber2_ReturnsDostoevskyQuote()
        {
            Assert.AreEqual(
                "Pain and suffering are always inevitable for a large intelligence and a deep heart.",
                _cookie.GetFortune(2));
        }

        [Test]
        public void LuckyNumber3_ReturnsNietzscheQuote()
        {
            Assert.AreEqual(
                "He who has a why to live can bear almost any how.",
                _cookie.GetFortune(3));
        }

        [Test]
        public void LuckyNumber4_ReturnsBaldwinQuote()
        {
            Assert.AreEqual(
                "Not everything that is faced can be changed, but nothing can be changed until it is faced.",
                _cookie.GetFortune(4));
        }

        [Test]
        public void LuckyNumber21_WrapsAroundToQuote1()
        {
            Assert.AreEqual(_cookie.GetFortune(1), _cookie.GetFortune(21));
        }

        [Test]
        public void LuckyNumber0_ThrowsArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _cookie.GetFortune(0));
        }

        [Test]
        public void NegativeLuckyNumber_ThrowsArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _cookie.GetFortune(-5));
        }

        // ── VERSION 2 — GetAuthor ─────────────────────────────────────────────

        [Test]
        public void LuckyNumber1_ReturnsCamus()
        {
            Assert.AreEqual("Camus", _cookie.GetAuthor(1));
        }

        [Test]
        public void LuckyNumber2_ReturnsDostoevsky()
        {
            Assert.AreEqual("Dostoevsky", _cookie.GetAuthor(2));
        }

        [Test]
        public void LuckyNumber3_ReturnsNietzsche()
        {
            Assert.AreEqual("Nietzsche", _cookie.GetAuthor(3));
        }

        [Test]
        public void LuckyNumber4_ReturnsBaldwin()
        {
            Assert.AreEqual("Baldwin", _cookie.GetAuthor(4));
        }

        // ── VERSION 3 — GetLuckyColor ─────────────────────────────────────────

        [Test]
        public void LuckyNumber1_ReturnsRed()
        {
            Assert.AreEqual("Red", _cookie.GetLuckyColor(1));
        }

        [Test]
        public void LuckyNumber7_ReturnsBlue()
        {
            Assert.AreEqual("Blue", _cookie.GetLuckyColor(7));
        }

        [Test]
        public void LuckyNumber10_ReturnsGold()
        {
            Assert.AreEqual("Gold", _cookie.GetLuckyColor(10));
        }

        [Test]
        public void ColorLuckyNumber0_ThrowsArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _cookie.GetLuckyColor(0));
        }

        // ── VERSION 4 — CrackOpen ─────────────────────────────────────────────

        [Test]
        public void CrackOpen1_ContainsQuote()
        {
            Assert.That(_cookie.CrackOpen(1), Does.Contain("invincible summer"));
        }

        [Test]
        public void CrackOpen1_ContainsAuthor()
        {
            Assert.That(_cookie.CrackOpen(1), Does.Contain("Camus"));
        }

        [Test]
        public void CrackOpen1_ContainsLuckyNumber()
        {
            Assert.That(_cookie.CrackOpen(1), Does.Contain("1"));
        }

        [Test]
        public void CrackOpen1_ContainsColor()
        {
            Assert.That(_cookie.CrackOpen(1), Does.Contain("Red"));
        }

        [Test]
        public void CrackOpen1_ContainsHeader()
        {
            Assert.That(_cookie.CrackOpen(1), Does.Contain("============================"));
        }

        [Test]
        public void CrackOpen_IsInternallySelfConsistent()
        {
            for (int n = 1; n <= 20; n++)
            {
                string result = _cookie.CrackOpen(n);
                Assert.That(result, Does.Contain(_cookie.GetFortune(n)),    "quote mismatch at " + n);
                Assert.That(result, Does.Contain(_cookie.GetAuthor(n)),     "author mismatch at " + n);
                Assert.That(result, Does.Contain(_cookie.GetLuckyColor(n)), "color mismatch at " + n);
            }
        }
    }
}