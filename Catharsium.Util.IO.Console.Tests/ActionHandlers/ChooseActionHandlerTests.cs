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
    public class ChooseActionHandlerTests : TestFixture<ChooseActionHandler>
    {
        #region Fixture

        private List<IActionHandler> ActionHandlers { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            var actionHandler1 = Substitute.For<IActionHandler>();
            var actionHandler2 = Substitute.For<IActionHandler>();
            actionHandler1.DisplayName.Returns("My friendly name 1");
            actionHandler2.DisplayName.Returns("My friendly name 2");
            this.ActionHandlers = new List<IActionHandler> {
                actionHandler1, actionHandler2
            };
            this.SetDependency<IEnumerable<IActionHandler>>(this.ActionHandlers);
        }


        #endregion


        [TestMethod]
        public async Task Run_WritesActionHandlers()
        {
            this.GetDependency<IConsole>().ReadLine().Returns("");

            await this.Target.Run();
            for (var i = 0; i < this.ActionHandlers.Count; i++) {
                this.GetDependency<IConsole>().Received().WriteLine($"[{i + 1}] {this.ActionHandlers[i].DisplayName}");
                await this.ActionHandlers[i].DidNotReceive().Run<object>();
            }
        }


        [TestMethod]
        public async Task Run_ValidIndex_CallsRunOnActionHandler()
        {
            var index = 1;
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(index, 0);

            await this.Target.Run();
            for (var i = 0; i < this.ActionHandlers.Count; i++) {
                if (i == index - 1) {
                    await this.ActionHandlers[i].Received().Run<object>();
                }
                else {
                    await this.ActionHandlers[i].DidNotReceive().Run<object>();
                }
            }
        }
    }
}