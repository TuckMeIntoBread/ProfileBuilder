using System;
using System.Collections.Generic;
using ff14bot.Managers;

namespace ProfileDevelopment
{
    public class QuestTodoInfo
    {
        public QuestTodoInfo(QuestWork questWork)
        {
            if (questWork.Step == 255)
            {
                return;
            }

            try
            {
                    Objective0TodoChecked = questWork.IsTodoChecked(questWork.Step, 0);
                    Objective1TodoChecked = questWork.IsTodoChecked(questWork.Step, 1);
                    Objective2TodoChecked = questWork.IsTodoChecked(questWork.Step, 2);
                    Objective3TodoChecked = questWork.IsTodoChecked(questWork.Step, 3);
                    Objective4TodoChecked = questWork.IsTodoChecked(questWork.Step, 4);
                    Objective5TodoChecked = questWork.IsTodoChecked(questWork.Step, 5);
            }
            catch (Exception)
            {
                // ignored
            }

            if (Objective1TodoChecked == null)
            {
                // there's only a single objective, do we're not gonna show the objective checkboxes
                Objective0TodoChecked = null;
            }
        }

        public bool? Objective0TodoChecked { get; set; }
        public bool? Objective1TodoChecked { get; set; }
        public bool? Objective2TodoChecked { get; set; }
        public bool? Objective3TodoChecked { get; set; }
        public bool? Objective4TodoChecked { get; set; }
        public bool? Objective5TodoChecked { get; set; }
    }
}