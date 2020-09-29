using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercisesTests
{
    public class AlarmTests
    {
        [Test]
        [TestCase(16.99999)]
        [TestCase(16)]
        [TestCase(0)]
        public void PressureIsBellowExpectedValuesTest(double pressurePsiValue)
        {
            var sensorMoq = new Mock<ISensor>();
            sensorMoq.Setup(s => s.PopNextPressurePsiValue()).Returns(pressurePsiValue);
            
            var alarm = new Alarm(sensorMoq.Object);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }
        
        [Test]
        [TestCase(21.001)]
        [TestCase(21.455)]
        [TestCase(22)]
        [TestCase(30)]
        public void PressureIsAboveExpectedValuesTest(double pressurePsiValue)
        {
            var sensorMoq = new Mock<ISensor>();
            sensorMoq.Setup(s => s.PopNextPressurePsiValue()).Returns(pressurePsiValue);
            
            var alarm = new Alarm(sensorMoq.Object);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }
        
        [Test]
        [TestCase(17.00)]
        [TestCase(20.00)]
        [TestCase(21.00)]
        public void PressureIsAsExpectedTest(double pressurePsiValue)
        {
            var sensorMoq = new Mock<ISensor>();
            sensorMoq.Setup(s => s.PopNextPressurePsiValue()).Returns(pressurePsiValue);
            
            var alarm = new Alarm(sensorMoq.Object);
            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}