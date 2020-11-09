using System;
using System.Threading.Tasks;
using ff14bot.Behavior;
using ff14bot.Managers;
using ff14bot.RemoteAgents;
using ff14bot.RemoteWindows;

namespace Helpers
{
    public static class General
    {
        private static bool InSmallTalk => SelectYesno.IsOpen || SelectString.IsOpen || SelectIconString.IsOpen || Talk.DialogOpen || JournalAccept.IsOpen || QuestLogManager.InCutscene || CommonBehaviors.IsLoading;

        public static async Task SmallTalk(int waitTime = 500)
        {
            await WaitUntil(() => InSmallTalk, timeout:waitTime);

            while (InSmallTalk)
            {
                if (CommonBehaviors.IsLoading)
                {
                    await WaitUntil(() => !CommonBehaviors.IsLoading);
                }

                if (SelectYesno.IsOpen)
                {
                    SelectYesno.ClickNo();
                }

                if (SelectString.IsOpen)
                {
                    if (!await WindowEscapeSpam("SelectString"))
                    {
                        if (SelectString.Lines().Contains("Cancel")) SelectString.ClickLineContains("Cancel");
                        else if (SelectString.Lines().Contains("Quit")) SelectString.ClickLineContains("Quit");
                        else if (SelectString.Lines().Contains("Exit")) SelectString.ClickLineContains("Exit");
                        else if (SelectString.Lines().Contains("Nothing")) SelectString.ClickLineContains("Nothing");
                        else SelectString.ClickSlot((uint) (SelectString.LineCount - 1));
                    }
                }

                if (SelectIconString.IsOpen)
                {
                    if (!await WindowEscapeSpam("SelectIconString"))
                    {
                        if (SelectIconString.Lines().Contains("Cancel")) SelectString.ClickLineContains("Cancel");
                        else if (SelectIconString.Lines().Contains("Quit")) SelectString.ClickLineContains("Quit");
                        else if (SelectIconString.Lines().Contains("Exit")) SelectString.ClickLineContains("Exit");
                        else if (SelectIconString.Lines().Contains("Nothing")) SelectString.ClickLineContains("Nothing");
                        else SelectIconString.ClickSlot((uint) (SelectIconString.LineCount - 1));
                    }
                }

                while (QuestLogManager.InCutscene)
                {
                    AgentCutScene.Instance.PromptSkip();
                    if (AgentCutScene.Instance.CanSkip && SelectString.IsOpen) SelectString.ClickSlot(0);
                }

                while (Talk.DialogOpen)
                {
                    Talk.Next();
                    await WaitUntil(() => !Talk.DialogOpen, timeout:1500);
                    await WaitUntil(() => Talk.DialogOpen, timeout:1500);
                }

                if (JournalAccept.IsOpen)
                {
                    JournalAccept.Decline();
                }

                await WaitUntil(() => InSmallTalk, timeout:waitTime);
            }
        }

        private static async Task<bool> WindowEscapeSpam(string windowName)
        {
            for (var i = 0; i < 5 && RaptureAtkUnitManager.GetWindowByName(windowName) != null; i++)
            {
                RaptureAtkUnitManager.Update();

                if (RaptureAtkUnitManager.GetWindowByName(windowName) != null)
                {
                    RaptureAtkUnitManager.GetWindowByName(windowName).SendAction(1, 3UL, (ulong) uint.MaxValue);
                }

                await WaitUntil(() => RaptureAtkUnitManager.GetWindowByName(windowName) == null, timeout:1500);
                await WaitUntil(() => RaptureAtkUnitManager.GetWindowByName(windowName) != null, timeout:1500);
            }

            return RaptureAtkUnitManager.GetWindowByName(windowName) == null;
        }

        public static async Task WaitUntil(Func<bool> condition, int frequency = 25, int timeout = 60000)
        {
            var waitTask = Task.Run(async () =>
            {
                while (!condition())
                {
                    RaptureAtkUnitManager.Update();
                    GameObjectManager.Update();
                    await Task.Delay(frequency);
                }
            });

            await Task.WhenAny(waitTask, Task.Delay(timeout));
        }
        
        public static async Task WaitWhile(Func<bool> condition, int frequency = 25, int timeout = 60000)
        {
            var waitTask = Task.Run(async () =>
            {
                while (condition())
                {
                    RaptureAtkUnitManager.Update();
                    GameObjectManager.Update();
                    await Task.Delay(frequency);
                }
            });

            await Task.WhenAny(waitTask, Task.Delay(timeout));
        }
    }
}