using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace TaskyUITests
{
    //[TestFixture (Platform.Android)]
    [TestFixture (Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest ()
        {
            app = AppInitializer.StartApp (platform);
        }

        void AddANewTask (string name, string description)
        {
            if (platform == Platform.iOS)
            {
                app.Tap(c => c.Button("Add"));
                app.EnterText(c => c.Class("UITextField").Index(0), name);
                app.EnterText(c => c.Class("UITextField").Index(1), description);
            }
            else
            {
                app.Tap("Add Task");
                app.EnterText(c => c.Class("EditText").Index(0), name);
                app.EnterText(c => c.Class("EditText").Index(1), description);
            }
            
            app.Tap ("Save");
        }

        [Test]
        [Ignore]
        public void AppLaunches()
        {
            app.Repl();
        }

        [Test]
        public void TaskyPro_CreatingATask_ShouldBeSuccessful ()
        {
            AddANewTask ("Get Milk", "Pick up some milk");
            app.WaitForElement(c => c.Marked("Get Milk"));
        }

        [Test]
        public void TaskyPro_DeletingATask_ShouldBeSuccessful ()
        {
            AddANewTask ("Test Delete", "This item should be deleted");
            app.Tap ("Test Delete");
            app.Tap ("Delete");
            Assert.AreEqual (0, app.Query ("Test Delete").Length);
        }
    }
}

