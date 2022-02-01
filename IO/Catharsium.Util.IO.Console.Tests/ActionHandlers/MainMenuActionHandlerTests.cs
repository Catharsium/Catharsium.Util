using Catharsium.Util.IO.Console.ActionHandlers.Implementation;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Catharsium.Util.IO.Console.Tests.ActionHandlers;

[TestClass]
public class MainMenuActionHandlerTests : TestFixture<MainMenuActionHandler>
{
    #region Fixture

    private List<IMenuActionHandler> ActionHandlers { get; set; }


    [TestInitialize]
    public void Initialize()
    {
        var actionHandler1 = Substitute.For<IMenuActionHandler>();
        var actionHandler2 = Substitute.For<IMenuActionHandler>();
        actionHandler1.MenuName.Returns("My friendly name 1");
        actionHandler2.MenuName.Returns("My friendly name 2");
        this.ActionHandlers = new List<IMenuActionHandler> {
            actionHandler1, actionHandler2
        };
        this.SetDependency<IEnumerable<IMenuActionHandler>>(this.ActionHandlers, "actionHandlers");
    }

    #endregion

    #region Run

    [TestMethod]
    public async Task Run_WritesActionHandlers()
    {
        this.GetDependency<IConsole>().ReadLine().Returns("");

        await this.Target.Run();
        for (var i = 0; i < this.ActionHandlers.Count; i++) {
            this.GetDependency<IConsole>().Received().WriteLine($"[{i + 1}] {this.ActionHandlers[i].MenuName}");
            await this.ActionHandlers[i].DidNotReceive().Run();
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
                await this.ActionHandlers[i].Received().Run();
            }
            else {
                await this.ActionHandlers[i].DidNotReceive().Run();
            }
        }
    }

    #endregion

    #region ToString

    [TestMethod]
    public void ToString_ReturnsMenuName()
    {
        var actual = this.Target.ToString();
        Assert.AreEqual(this.Target.MenuName, actual);
    }

    #endregion
}