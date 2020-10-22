using System;
using System.Threading.Tasks;
using ff14bot.Behavior;
using ff14bot.Managers;
using ff14bot.RemoteWindows;

namespace Helpers
{
    public static class General
    {
        public static async Task SmallTalk()
        {
            while (SelectYesno.IsOpen || SelectString.IsOpen || SelectIconString.IsOpen || Talk.DialogOpen || JournalAccept.IsOpen || QuestLogManager.InCutscene || CommonBehaviors.IsLoading)
            {
                if (SelectYesno.IsOpen) SelectYesno.ClickYes();
                if (SelectString.IsOpen)
                {
                    if (SelectString.Lines().Contains("Cancel")) SelectString.ClickLineContains("Cancel");
                    else SelectString.ClickSlot(0);
                }
                if (SelectIconString.IsOpen)
                {
                    if (SelectIconString.Lines().Contains("Cancel")) SelectIconString.ClickLineContains("Cancel");
                    else SelectIconString.ClickSlot(0);
                }
                if (Talk.DialogOpen) Talk.Next();
                if (JournalAccept.IsOpen) JournalAccept.Decline();
                if (QuestLogManager.InCutscene)
                {
                    ff14bot.RemoteAgents.AgentCutScene.Instance.PromptSkip();
                    if (ff14bot.RemoteAgents.AgentCutScene.Instance.CanSkip && SelectString.IsOpen)
                    {
                        SelectString.ClickSlot(0);
                    }
                }

                await WaitUntil(() => (SelectYesno.IsOpen || SelectString.IsOpen || SelectIconString.IsOpen || Talk.DialogOpen || JournalAccept.IsOpen || QuestLogManager.InCutscene || CommonBehaviors.IsLoading), timeout: 1000);
            }
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