using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clio.Utilities;
using ff14bot;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.RemoteWindows;
using static Helpers.General;

namespace ProfileDevelopment
{
    public partial class Gui : Form
    {
        private readonly float _distanceCheck = 15;
        private static Vector3 _lastLocation = Vector3.Zero;
        private static ushort? _lastLocationId = null;
        private readonly List<ObjectData> _gameObjects = new List<ObjectData>();

        #region GUI

        public Gui()
        {
            InitializeComponent();
            pGridQuestData.PropertySort = PropertySort.NoSort;
            lbKeyItems.SelectionMode = SelectionMode.MultiExtended;
            lbInventory.SelectionMode = SelectionMode.MultiExtended;
            cBoxFlight.Checked = false;
            AllowTransparency = true;
            RefreshGUI();
        }

        private void Gui_Load(object sender, EventArgs e)
        {

        }

        private void CBoxActiveQuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            pGridQuestData.SelectedObject = cBoxActiveQuests.SelectedItem;
        }

        private void LbKeyItems_MouseDown(object sender, MouseEventArgs e)
        {
            int index = lbKeyItems.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches)
            {
                lbKeyItems.ClearSelected();
            }
        }

        private void LbInventory_MouseDown(object sender, MouseEventArgs e)
        {
            int index = lbInventory.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches)
            {
                lbInventory.ClearSelected();
            }
        }

        private void SetTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxTopMost.Checked == true)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        #endregion GUI

        #region Refresh Button

        private void ObjectManagerUpdate()
        {
            GameObjectManager.Update();
        }
        private void RefreshGUI()
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                _gameObjects.Clear();
                QuestWork[] quests = QuestLogManager.ActiveQuests;

                cBoxActiveQuests.DataSource = quests;
                cBoxActiveQuests.DisplayMember = "Name";
                cBoxActiveQuests.ValueMember = "Name";

                if (cBoxActiveQuests.SelectedItem is QuestWork questData)
                {
                    if (quests.Length > 0)
                    {
                        cBoxActiveQuests.SelectedItem = quests.FirstOrDefault(r => r.Name == questData.Name) ?? quests[0];
                    }
                }

                //refresh KeyItems
                lbKeyItems.DataSource = InventoryManager.GetBagByInventoryBagId(InventoryBagId.KeyItems).FilledSlots.OrderBy(s => s.Name).ToList();
                lbKeyItems.DisplayMember = "Name";
                lbKeyItems.ValueMember = "Name";
                lbKeyItems.SelectedItem = null;

                InventoryBagId[] theseBags = new[] { InventoryBagId.Bag1, InventoryBagId.Bag2, InventoryBagId.Bag3, InventoryBagId.Bag4 };
                // refresh InventoryItems
                lbInventory.DataSource = InventoryManager.FilledSlots.Where(r => theseBags.Contains(r.BagId)).OrderBy(s => s.Name).ToList();
                lbInventory.DisplayMember = "Name";
                lbInventory.ValueMember = "Name";
                lbInventory.SelectedItem = null;
            }
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGUI();
        }

        #endregion Refresh Button

        #region Set Output File

        public static string OutputFilePath;
        private void BtnOutput_Click(object sender, EventArgs e)
        {
            string path = $"{JsonSettings.AssemblyPath}\\Profiles";
            if (!Directory.Exists(path))
            {
                path = JsonSettings.AssemblyPath;
            }

            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = path,
                DefaultExt = ".xml",
                Filter = "xml and json files (*.xml;*.json)|*.xml;*.json"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputFile.Text = dlg.SafeFileName.TrimEnd('.', 'x', 'm', 'l');
                OutputFilePath = dlg.FileName;
            }
        }

        #endregion Set Output File

        #region Properties

        public bool IsLisbethTravel => cBoxLisbeth.Checked;

        public bool IsLisbethOptional => cBoxLisOptional.Checked;

        public bool IsForceGetTo => cBoxForceGetTo.Checked;

        public bool IsFlightEnabled => cBoxFlight.Checked;

        public bool MoveToOnly => cBoxMoveTo.Checked;

        public bool OutputClipboard => cBoxClipboard.Checked;

        public bool UseQuestInfo => cBoxUseQuestInfo.Checked;

        private static string LisbethArea => Helpers.Lisbeth.GetCurrentAreaName;

        private static string LisbethAreaNull => LisbethArea.Length < 1 ? WorldManager.CurrentZoneName : LisbethArea;

        private static string PlayerLocation => Core.Me.Location.ToString().Remove(0, 1).Remove(Core.Me.Location.ToString().Remove(0, 1).Length - 1, 1);

        private static string TargetLocation => Core.Target.Location.ToString().Remove(0, 1).Remove(Core.Target.Location.ToString().Remove(0, 1).Length - 1, 1);

        public static string ZoneId => WorldManager.ZoneId.ToString();

        public static string SubZoneId => WorldManager.SubZoneId.ToString();

        public static string TeleportTo
        {
            get
            {
                try
                {
                    ushort _currentZoneId = WorldManager.ZoneId;
                    List<Tuple<uint, Vector3>> _availableLocations = new List<Tuple<uint, Vector3>>();
                    foreach (WorldManager.TeleportLocation t in WorldManager.AvailableLocations.Where(z => z.ZoneId == _currentZoneId))
                    {
                        _availableLocations.Add(WorldManager.AetheryteIdsForZone(_currentZoneId).Where(al => al.Item1 == t.AetheryteId).FirstOrDefault());
                    }

                    uint _closestAetheryteId = _availableLocations.OrderBy(loc => Core.Me.Location.Distance2D(loc.Item2)).FirstOrDefault().Item1;
                    string _closestAetheryteName = WorldManager.AvailableLocations.Where(r => r.ZoneId == _currentZoneId && r.AetheryteId == _closestAetheryteId).FirstOrDefault().Name;

                    return $@"    <TeleportTo Name=""{_closestAetheryteName}"" AetheryteId=""{_closestAetheryteId}""/>" + "\n";
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public string ItemIdString
        {
            get
            {
                List<uint> itemIds = new List<uint>();
                foreach (BagSlot item in lbKeyItems.SelectedItems.Cast<BagSlot>())
                { itemIds.Add(item.RawItemId); }
                foreach (BagSlot item in lbInventory.SelectedItems.Cast<BagSlot>())
                { itemIds.Add(item.RawItemId); }

                string result = " ";
                if (itemIds.Count == 1)
                { result = $@" ItemId=""{itemIds.FirstOrDefault()}"" "; }
                else if (itemIds.Count > 1)
                { result = $@" ItemIds=""{string.Join(",", itemIds)}"" "; }

                return result;
            }
        }

        #endregion Properties

        #region AddGameObject

        private void BtnAddGameObject_Click(object sender, EventArgs e)
        {
            _gameObjects.Add(new ObjectData() { NpcId = Core.Target.NpcId, Location = Core.Target.Location });
        }

        #endregion AddGameObject

        #region PickUp

        private async void BtnPickUp_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str = $@"    <!-- {q.Name} -->
    <If Condition=""not HasQuest({q.GlobalId}) and not IsQuestCompleted({q.GlobalId})"">" + "\n";
                    str += GetToString();
                    str += $@"      <If Condition=""IsQuestAcceptQualified({q.GlobalId})"">
        <LLPickupQuest QuestId=""{q.GlobalId}"" NpcId=""{Core.Target.NpcId}""/>
        <LLSmallTalk/>
      </If>
    </If>";
                    UpdatePosition();
                    await Output(str);
                }
            }
        }

        #endregion PickUp

        #region TurnIn

        private async void BtnTurnIn_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str = $@"    <If Condition=""GetQuestStep({q.GlobalId}) == 255"">" + "\n";
                    str += GetToString();
                    str += $@"      <LLTurnIn{ItemIdString}QuestId=""{q.GlobalId}"" NpcId=""{Core.Target.NpcId}"" XYZ=""{TargetLocation}""/>
      <LLSmallTalk/>
    </If>";
                    UpdatePosition();
                    await Output(str);
                }
            }
        }

        #endregion TurnIn

        #region TalkTo

        private async void BtnTalkTo_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str = $@"    <If Condition=""{QuestStepConditionString(q)}"">" + "\n";
                    str += GetToString();
                    str += $@"      <LLTalkTo NpcId=""{Core.Target.NpcId}"" XYZ=""{TargetLocation}"" QuestId=""{q.GlobalId}"" StepId=""{q.Step}""/>
    </If>";
                    UpdatePosition();
                    await Output(str);
                }
            }
        }

        #endregion TalkTo

        #region UseTransport

        private async void BtnUseTransport_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                string str = string.Empty;
                ObjectManagerUpdate();
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str += GetToString();
                    str += $@"  <UseTransport NpcId=""{Core.Target.NpcId}"" InteractDistance=""3.0"" XYZ=""{TargetLocation}""/>";
                }
                await Output(str);
            }
        }

        #endregion UseTransport

        #region Handover

        private async void BtnHandover_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str = $@"    <If Condition=""{QuestStepConditionString(q)}"">" + "\n";
                    str += GetToString();
                    str += $@"      <LLHandOver{ItemIdString}NpcId=""{Core.Target.NpcId}"" XYZ=""{TargetLocation}"" QuestId=""{q.GlobalId}"" StepId=""{q.Step}""/>
    </If>";
                    UpdatePosition();
                    await Output(str);
                }
            }
        }

        #endregion Handover

        #region UseObjectString

        private string GetUseObjectString(int stepId, int questId)
        {
            if (_gameObjects == null || _gameObjects.Count == 0)
            {
                return $@"<UseObject NpcId=""{GameObjectManager.Target.NpcId}"" XYZ=""{TargetLocation}"" QuestId=""{questId}"" StepId=""{stepId}""/>";
            }
            Dictionary<uint, string> objs = new Dictionary<uint, string>();
            foreach (ObjectData obj in _gameObjects)
            {
                objs.Add(obj.NpcId, obj.Location.ToString().Remove(0, 1).Remove(obj.Location.ToString().Remove(0, 1).Length - 1, 1));
            }

            objs.OrderBy(r => r.Key);

            bool withinRadius = false;
            string result = string.Empty;
            if (objs.Count == 1)
            {
                result = $@"<UseObject NpcId=""{objs.FirstOrDefault().Key}"" XYZ=""{objs.FirstOrDefault().Value}"" QuestId=""{questId}"" StepId=""{stepId}""/>";
            }
            else if (objs.Count > 1)
            {
                foreach (KeyValuePair<uint, string> obj in objs)
                {
                    Vector3 _objLoc = new Vector3(obj.Value);
                    if ((_objLoc.X > Core.Me.X - 50 && _objLoc.X < Core.Me.X + 50) && (_objLoc.Z > Core.Me.Z - 50 && _objLoc.Z < Core.Me.Z + 50))
                    {
                        withinRadius = true;
                    }
                }

                if (withinRadius)
                {
                    result = $@"<UseObject NpcIds=""{string.Join(",", objs.Keys.ToArray())}"" XYZ=""{PlayerLocation}"" QuestId=""{questId}"" StepId=""{stepId}""/>";
                }
                else
                {
                    List<string> hotSpots = new List<string>();
                    foreach (string loc in objs.Values.ToArray())
                    {
                        hotSpots.Add($@"          <HotSpot XYZ=""{loc}"" Radius=""10""/>
");
                    }

                    result = $@"<UseObject NpcIds=""{string.Join(",", objs.Keys.ToArray())}"" QuestId=""{questId}"" StepId=""{stepId}"">
        <HotSpots>
{string.Join("", hotSpots).TrimEnd()}
        </HotSpots>
      </UseObject>";
                }
            }

            return result;
        }

        #endregion UseObjectString

        #region UseObject

        private async void BtnUseObject_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str = $@"    <If Condition=""{QuestStepConditionString(q)}"">" + "\n";
                    str += GetToString();
                    str += $@"      {GetUseObjectString(q.Step, q.GlobalId)}
    </If>";
                    _gameObjects.Clear();
                    UpdatePosition();
                    await Output(str);
                }
            }
        }

        #endregion UseObject

        #region UseItemString

        private string GetUseItemString(int stepId, int questId)
        {
            Dictionary<uint, string> objs = new Dictionary<uint, string>();
            foreach (ObjectData obj in _gameObjects)
            {
                objs.Add(obj.NpcId, obj.Location.ToString().Remove(0, 1).Remove(obj.Location.ToString().Remove(0, 1).Length - 1, 1));
            }

            objs.OrderBy(r => r.Key);

            bool withinRadius = false;
            string result = string.Empty;
            if (objs.Count == 1)
            {
                {
                    result = $@"<UseItem{ItemIdString}NpcId=""{objs.FirstOrDefault().Key}"" XYZ=""{objs.FirstOrDefault().Value}"" QuestId=""{questId}"" StepId=""{stepId}""/>";
                }
            }
            else if (objs.Count > 1)
            {
                foreach (KeyValuePair<uint, string> obj in objs)
                {
                    Vector3 _objLoc = new Vector3(obj.Value);
                    if ((_objLoc.X > Core.Me.X - 50 && _objLoc.X < Core.Me.X + 50) && (_objLoc.Z > Core.Me.Z - 50 && _objLoc.Z < Core.Me.Z + 50))
                    {
                        withinRadius = true;
                    }
                }

                if (withinRadius)
                {
                    result = $@"<UseItem{ItemIdString}NpcIds=""{string.Join(",", objs.Keys.ToArray())}"" XYZ=""{PlayerLocation}"" QuestId=""{questId}"" StepId=""{stepId}""/>";
                }
                else
                {
                    List<string> hotSpots = new List<string>();
                    foreach (string loc in objs.Values.ToArray())
                    {
                        hotSpots.Add($@"          <HotSpot XYZ=""{loc}"" Radius=""10""/>
");
                    }
                    result = $@"<UseItem{ItemIdString}NpcIds=""{string.Join(",", objs.Keys.ToArray())}"" QuestId=""{questId}"" StepId=""{stepId}"">
        <HotSpots>
{string.Join("", hotSpots).TrimEnd()}
        </HotSpots>
      </UseItem>";
                }
            }

            return result;
        }

        #endregion UseItemString

        #region UseItem

        private async void BtnUseItem_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str = $@"    <If Condition=""{QuestStepConditionString(q)}"">" + "\n";
                    str += GetToString();
                    str += $@"      {GetUseItemString(q.Step, q.GlobalId)}
    </If>";
                    _gameObjects.Clear();
                    UpdatePosition();
                    await Output(str);
                }
            }
        }

        #endregion UseItem

        #region TeleportTo

        private async void BtnTeleportTo_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                await Output(TeleportTo);
            }
        }

        #endregion

        #region OpenProfile

        private async void BtnOpenProfileTags_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                string str = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<!--
  Profile:
  Authors:
-->
<Profile>
  <Name></Name>
  <BehaviorDirectory></BehaviorDirectory>
  <Order>";
                await Output(str);
            }
        }

        #endregion OpenProfile

        #region CloseProfile

        private async void BtnCloseProfileTags_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                string str = $@"  </Order>
</Profile>";
                await Output(str);
            }
        }

        #endregion CloseProfile

        #region LisbethJSON

        private async void BtnLisbethJSONEntranceTo_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                string whitespace = "    ";
                string startArea = LisbethAreaNull;
                Vector3 startPos = Core.Me.Location;
                uint npcId = GameObjectManager.Target.NpcId;
                GameObjectManager.Target.Interact();
                await WaitUntil(() => (SelectYesno.IsOpen || SelectString.IsOpen || SelectIconString.IsOpen || Talk.DialogOpen || JournalAccept.IsOpen || QuestLogManager.InCutscene || CommonBehaviors.IsLoading), timeout: 8000);
                await SmallTalk();
                string endArea = LisbethAreaNull;
                Vector3 endPos = Core.Me.Location;

                if (LisbethArea.Length < 1)
                {
                    str += "\\\\NewArea\n";
                    str += "  {\n";
                    str += $@"{whitespace}""Name"": ""{endArea}""," + "\n";
                    str += $@"{whitespace}""Zone"": {WorldManager.ZoneId}," + "\n";
                    str += $@"{whitespace}""CanTeleport"": {WorldManager.CanTeleport().ToString().ToLower()}," + "\n";
                    if (WorldManager.CanFly)
                    {
                        str += $@"{whitespace}""CanFly"": true," + "\n";
                    }

                    str = str.Remove(str.LastIndexOf(",", StringComparison.Ordinal), 1);
                    str += "  },\n";
                }

                str += "\\\\Entrance\n";
                str += "  {" + "\n";
                str += $@"{whitespace}""Name"": ""Entrance to {endArea}""," + "\n";
                str += $@"{whitespace}""Npc"": {npcId}," + "\n";
                str += $@"{whitespace}""StartArea"": ""{startArea}""," + "\n";
                str += $@"{whitespace}""StartPosition"": {{""X"": {startPos.X}, ""Y"": {startPos.Y}, ""Z"": {startPos.Z}}}," + "\n";
                str += $@"{whitespace}""EndArea"": ""{endArea}""," + "\n";
                str += $@"{whitespace}""EndPosition"": {{""X"": {endPos.X}, ""Y"": {endPos.Y}, ""Z"": {endPos.Z}}}" + "\n";
                str += "  },";

                await Output(str);
            }
        }

        private async void BtnLisbethJSONExitFrom_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                string whitespace = "    ";
                string startArea = LisbethAreaNull;
                Vector3 startPos = Core.Me.Location;
                uint npcId = GameObjectManager.Target.NpcId;
                GameObjectManager.Target.Interact();
                await WaitUntil(() => (SelectYesno.IsOpen || SelectString.IsOpen || SelectIconString.IsOpen || Talk.DialogOpen || JournalAccept.IsOpen || QuestLogManager.InCutscene || CommonBehaviors.IsLoading), timeout: 8000);
                await SmallTalk();
                string endArea = LisbethAreaNull;
                Vector3 endPos = Core.Me.Location;

                str += "\\\\Exit\n";
                str += "  {" + "\n";
                str += $@"{whitespace}""Name"": ""Exit from {startArea}""," + "\n";
                str += $@"{whitespace}""Npc"": {npcId}," + "\n";
                str += $@"{whitespace}""StartArea"": ""{startArea}""," + "\n";
                str += $@"{whitespace}""StartPosition"": {{""X"": {startPos.X}, ""Y"": {startPos.Y}, ""Z"": {startPos.Z}}}," + "\n";
                str += $@"{whitespace}""EndArea"": ""{endArea}""," + "\n";
                str += $@"{whitespace}""EndPosition"": {{""X"": {endPos.X}, ""Y"": {endPos.Y}, ""Z"": {endPos.Z}}}" + "\n";
                str += "  },";

                await Output(str);
            }
        }

        #endregion LisbethJSON

        #region QuestConditions

        private string QuestStepConditionString(QuestWork q)
        {
            string questStepString = $"GetQuestStep({q.GlobalId}) == {q.Step}";
            if (UseQuestInfo)
            {
                GridItem qInfo = pGridQuestData.SelectedGridItem;
                questStepString += $" and GetQuestById({q.GlobalId}).{qInfo.PropertyDescriptor.Name} == {qInfo.Value}";
            }

            return questStepString;
        }

        private async void BtnQuestStep_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    string str = $@"    <If Condition=""{QuestStepConditionString(q)}"">" + "\n";
                    str += $@"      " + "\n";
                    str += $@"    </If>";
                    await Output(str);
                }
            }
        }

        private async void BtnQuestStepGt0_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    string str = $@"    <If Condition=""GetQuestStep({q.GlobalId}) &gt; 0"">" + "\n";
                    await Output(str);
                }
            }
        }

        private async void BtnCloseIf_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    string str = $@"    </If>";
                    await Output(str);
                }
            }
        }

        #endregion QuestConditions

        #region Quest Wrapper

        private class QuestWrapper
        {
            public QuestWrapper(QuestWork value)
            {
                Value = value;
            }
            public QuestWork Value { get; set; }

            public override string ToString()
            {
                return Value.Name;
            }
        }

        #endregion  Quest Wrapper

        private async Task Output(string str)
        {
            if (OutputClipboard)
            {
                Clipboard.SetText(str);
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(OutputFilePath, true))
                {
                    await outputFile.WriteLineAsync(str);
                }
            }
        }

        private void UpdatePosition()
        {
            _lastLocation = Core.Me.Location;
            _lastLocationId = WorldManager.ZoneId;
        }

        private bool DistanceCheck => IsForceGetTo || _lastLocation == Vector3.Zero || _lastLocationId == null || _lastLocationId != WorldManager.ZoneId || Core.Me.Distance(_lastLocation) > _distanceCheck;

        private string GetToString()
        {
            if (!DistanceCheck)
            {
                return string.Empty;
            }

            if (!IsLisbethTravel)
            {
                return NonLisbethMoveString();
            }

            if (!IsLisbethOptional)
            {
                return $@"        <LisbethTravel Zone=""{ZoneId}"" Subzone=""{SubZoneId}"" Position=""{PlayerLocation}""/> <!-- Area=""{LisbethArea}"" -->" + "\n";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"      <If Condition=""LisbethPresent"">");
            sb.AppendLine($@"        <LisbethTravel Zone=""{ZoneId}"" Subzone=""{SubZoneId}"" Position=""{PlayerLocation}""/> <!-- Area=""{LisbethArea}"" -->");
            sb.AppendLine(@"      </If>");
            sb.AppendLine(@"      <If Condition=""not LisbethPresent"">");
            sb.Append("  " + NonLisbethMoveString());
            sb.AppendLine(@"      </If>");
            return sb.ToString();
        }

        private string NonLisbethMoveString()
        {
            if (IsFlightEnabled && WorldManager.CanFly)
            {
                StringBuilder sb = new StringBuilder();
                if (_lastLocationId != WorldManager.ZoneId)
                {
                    sb.Append(TeleportTo);
                }

                sb.AppendLine($@"      <FlyTo XYZ=""{PlayerLocation}"" Land=""True""/> <!-- Zone: ""{ZoneId}"" Subzone=""{SubZoneId}"" Area=""{LisbethArea}"" -->");
                return sb.ToString();
            }
            if (MoveToOnly)
            {
                return $@"      <MoveTo XYZ=""{PlayerLocation}""/> <!-- Zone: ""{ZoneId}"" Subzone=""{SubZoneId}"" Area=""{LisbethArea}"" -->" + "\n";
            }

            return $@"      <GetTo ZoneId=""{ZoneId}"" XYZ=""{PlayerLocation}""/>  <!-- Subzone=""{SubZoneId}"" Area=""{LisbethArea}"" -->" + "\n";
        }

        #region EmoteNPC

        private async void BtnEmoteNPC_Click(object sender, EventArgs e)
        {
            using (Core.Memory.TemporaryCacheState(false))
            {
                ObjectManagerUpdate();
                string str = string.Empty;
                if (cBoxActiveQuests.SelectedItem is QuestWork q)
                {
                    str = $@"    <If Condition=""{QuestStepConditionString(q)}"">" + "\n";
                    str += GetToString();
                    str += $@"      {GetEmoteNPCString(q.Step, q.GlobalId)}
    </If>";
                    _gameObjects.Clear();
                    UpdatePosition();
                    await Output(str);
                }
            }
        }

        private static string GetEmoteNPCString(int stepId, int questId)
        {
            string emote = "greet"; // TODO: Make selectable instead of post-editing XML file

            return $@"<EmoteNPC Emote=""{emote}"" NpcId=""{GameObjectManager.Target.NpcId}"" XYZ=""{TargetLocation}"" QuestId=""{questId}"" StepId=""{stepId}""/>";
        }
        #endregion EmoteNPC
    }

    public class ObjectData
    {
        public ObjectData() { }

        public uint NpcId { get; set; }
        public Vector3 Location { get; set; }
    }
}
