using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AlarmClockTest
{
    [TestClass]
    public class ScenarioTimer : AlarmClockSession
    {
        private const string NewTimerName = "Sample Test Timer";

        [TestMethod]
        public void AddTimer()
        {
            session.FindElementByAccessibilityId("TimerButton").Click();
            session.FindElementByAccessibilityId("AddTimerButton").Click();
            session.FindElementByName("hours").SendKeys("05");
            session.FindElementByName("Timer name").Clear();
            session.FindElementByName("Timer name").SendKeys(NewTimerName);
            session.FindElementByName("Save").Click();

            Assert.IsNotNull(session.FindElementByAccessibilityId("TimerListView"));
            var timerEntries = session.FindElementByAccessibilityId("TimerListView").FindElementsByClassName("ListViewItem");
            Assert.IsTrue(timerEntries.Count > 0);
            var timerEntry = timerEntries[timerEntries.Count - 1];

            var timerEntryResetButton = timerEntry.FindElementByAccessibilityId("TimerResetButton");
            var timerEntryText = timerEntry.FindElementByAccessibilityId("TimerNameText").Text;

            Assert.IsTrue(timerEntryResetButton.Enabled);
            Assert.AreEqual(NewTimerName, timerEntryText);

            // Good practice to cleanup
            timerEntry.SendKeys(OpenQA.Selenium.Keys.Delete + OpenQA.Selenium.Keys.Enter);

            //var timerText = timerEntry.FindElementByAccessibilityId("TimerValueText");
            //Assert.IsNotNull(timerText);


          

        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

            TearDown();
        }

    }
}
