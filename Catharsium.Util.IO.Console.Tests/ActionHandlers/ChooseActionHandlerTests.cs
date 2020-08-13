using Catharsium.Util.IO.Console.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Tests.ActionHandlers
{
    [TestClass]
    [Ignore]
    public class ChooseActionHandlerTests : TestFixture<ChooseActionHandler>
    {
        #region Fixture

        private List<IActionHandler> ActionHandlers { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            var actionHandler1 = Substitute.For<IActionHandler>();
            var actionHandler2 = Substitute.For<IActionHandler>();
            actionHandler1.FriendlyName.Returns("My friendly name 1");
            actionHandler2.FriendlyName.Returns("My friendly name 2");
            this.ActionHandlers = new List<IActionHandler> {
                actionHandler1, actionHandler2
            };
            this.SetDependency<IEnumerable<IActionHandler>>(this.ActionHandlers);
        }


        #endregion


        [TestMethod]
        public async Task Run_WritesActionHandlers()
        {
            await this.Target.Run();
            for (var i = 0; i < this.ActionHandlers.Count; i++) {
                this.GetDependency<IConsole>().Received().Write($"[{i + 1}] {this.ActionHandlers[i].FriendlyName}");
            }
        }


        [TestMethod]
        public async Task Run_ValidIndex_CallsRunOnActionHandler()
        {
            var index = 1;
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(index);

            await this.Target.Run();
            await this.ActionHandlers[index].Received().Run();
        }
    }
}