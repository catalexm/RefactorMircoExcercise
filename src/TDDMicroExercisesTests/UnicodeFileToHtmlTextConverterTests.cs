using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;

namespace TDDMicroExercisesTests
{
    public class UnicodeFileToHtmlTextConverterTests
    {
        [Test]
        public void ConvertToHtmlTest()
        {
            var lines = new List<string> {"abc", "def"};
            
            var streamReaderMock = new Mock<IStreamReader>();
            streamReaderMock.Setup(sr => sr.Read()).Returns(lines);
            
            var sut = new UnicodeFileToHtmlTextConverter(streamReaderMock.Object);
            var html = sut.ConvertToHtml();
            Assert.That(html.Contains(lines[0]));
            Assert.That(html.Contains(lines[1]));
            
            streamReaderMock.Verify(mock => mock.Dispose(), Times.Once());
        }
        
        [Test]
        public void FileEmptyTest()
        {
            var streamReaderMock = new Mock<IStreamReader>();
            streamReaderMock.Setup(sr => sr.Read()).Returns(new List<string>());
            
            var sut = new UnicodeFileToHtmlTextConverter(streamReaderMock.Object);
            var html = sut.ConvertToHtml();
            Assert.IsEmpty(html);
        }
    }
}