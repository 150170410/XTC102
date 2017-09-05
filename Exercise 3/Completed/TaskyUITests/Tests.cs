using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TaskyUITests
{
    [TestFixture (Platform.Android)]
    [TestFixture (Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        readonly Func<AppQuery,AppQuery> AddButton;
        readonly Func<AppQuery,AppQuery> NameField;
        readonly Func<AppQuery,AppQuery> DescriptionField;

        public Tests(Platform platform)
        {
            this.platform = platform;

            if (platform == Platform.iOS)
            {
                AddButton = c => c.Button("Add");
                NameField = c => c.Class("UITextField").Index(0);
                DescriptionField = c => c.Class("UITextField").Index(1);
            }
            else
            {
                AddButton = c => c.Marked("Add Task");
                NameField = c => c.Class("EditText").Index(0);
                DescriptionField = c => c.Class("EditText").Index(1);
            }
        }

        [SetUp]
        public void BeforeEachTest ()
        {
            app = AppInitializer.StartApp (platform);
        }

        void AddANewTask (string name, string description)
        {
            app.Tap(AddButton);
            app.EnterText(NameField, name);
            app.EnterText(DescriptionField, description);
            app.Tap ("Save");
        }

        [Test]
        [Ignore]
        public void AppLaunches()
        {
            app.Repl();
        }

        [Test]
        public void TaskyPro_CreatingATask_ShouldBeSuccessful()
        {
            AddANewTask ("Get Milk", "Pick up some milk");
            app.WaitForElement(c => c.Marked("Get Milk"));
        }

        [Test]
        public void TaskyPro_DeletingATask_ShouldBeSuccessful()
        {
            AddANewTask ("Test Delete", "This item should be deleted");
            app.Tap ("Test Delete");

            app.Tap ("Delete");
            Assert.AreEqual (0, app.Query ("Test Delete").Length);
        }
    }
}

