namespace ProfileDevelopment
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.FormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnUseObject = new System.Windows.Forms.Button();
            this.btnUseItem = new System.Windows.Forms.Button();
            this.cBoxFlight = new System.Windows.Forms.CheckBox();
            this.CheckBoxTopMost = new System.Windows.Forms.CheckBox();
            this.btnTeleportTo = new System.Windows.Forms.Button();
            this.cBoxLisbeth = new System.Windows.Forms.CheckBox();
            this.cBoxClipboard = new System.Windows.Forms.CheckBox();
            this.cBoxForceGetTo = new System.Windows.Forms.CheckBox();
            this.cBoxMoveTo = new System.Windows.Forms.CheckBox();
            this.cBoxLisOptional = new System.Windows.Forms.CheckBox();
            this.cBoxUseQuestInfo = new System.Windows.Forms.CheckBox();
            this.cBoxNoMount = new System.Windows.Forms.CheckBox();
            this.cBoxActiveQuests = new System.Windows.Forms.ComboBox();
            this.pGridQuestData = new System.Windows.Forms.PropertyGrid();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPickUp = new System.Windows.Forms.Button();
            this.btnTurnIn = new System.Windows.Forms.Button();
            this.lbKeyItems = new System.Windows.Forms.ListBox();
            this.btnTalkTo = new System.Windows.Forms.Button();
            this.btnUseTransport = new System.Windows.Forms.Button();
            this.btnHandover = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.btnCloseProfileTags = new System.Windows.Forms.Button();
            this.btnOpenProfileTags = new System.Windows.Forms.Button();
            this.labelInventory = new System.Windows.Forms.Label();
            this.lbInventory = new System.Windows.Forms.ListBox();
            this.btnAddGameObject = new System.Windows.Forms.Button();
            this.btnQuestStep = new System.Windows.Forms.Button();
            this.btnQuestStepGt0 = new System.Windows.Forms.Button();
            this.btnCloseIf = new System.Windows.Forms.Button();
            this.btnLisbethJSONEntrance = new System.Windows.Forms.Button();
            this.btnLisbethJSONExit = new System.Windows.Forms.Button();
            this.btnEmoteNPC = new System.Windows.Forms.Button();
            this.grindButton = new System.Windows.Forms.Button();
            this.cBoxObjective0 = new System.Windows.Forms.CheckBox();
            this.cBoxObjective1 = new System.Windows.Forms.CheckBox();
            this.cBoxObjective2 = new System.Windows.Forms.CheckBox();
            this.cBoxObjective3 = new System.Windows.Forms.CheckBox();
            this.cBoxObjective4 = new System.Windows.Forms.CheckBox();
            this.cBoxObjective5 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnUseObject
            // 
            this.btnUseObject.Location = new System.Drawing.Point(290, 316);
            this.btnUseObject.Name = "btnUseObject";
            this.btnUseObject.Size = new System.Drawing.Size(137, 23);
            this.btnUseObject.TabIndex = 11;
            this.btnUseObject.Text = "UseObject";
            this.FormToolTip.SetToolTip(this.btnUseObject, "FlyTo location will be your current location, be sure to be in an appropriate pla" + "ce before pressing. Clears all saved GameObjects on execution. Assign Objects wi" + "th the Add GameObject button.");
            this.btnUseObject.UseVisualStyleBackColor = true;
            this.btnUseObject.Click += new System.EventHandler(this.BtnUseObject_Click);
            // 
            // btnUseItem
            // 
            this.btnUseItem.Location = new System.Drawing.Point(290, 348);
            this.btnUseItem.Name = "btnUseItem";
            this.btnUseItem.Size = new System.Drawing.Size(137, 23);
            this.btnUseItem.TabIndex = 12;
            this.btnUseItem.Text = "Use Item";
            this.FormToolTip.SetToolTip(this.btnUseItem, resources.GetString("btnUseItem.ToolTip"));
            this.btnUseItem.UseVisualStyleBackColor = true;
            this.btnUseItem.Click += new System.EventHandler(this.BtnUseItem_Click);
            // 
            // cBoxFlight
            // 
            this.cBoxFlight.AutoSize = true;
            this.cBoxFlight.Location = new System.Drawing.Point(281, 737);
            this.cBoxFlight.Name = "cBoxFlight";
            this.cBoxFlight.Size = new System.Drawing.Size(90, 17);
            this.cBoxFlight.TabIndex = 22;
            this.cBoxFlight.Text = "FlightEnabled";
            this.FormToolTip.SetToolTip(this.cBoxFlight, "Uses Flightor FlyTo Tags in preference to GetTo");
            this.cBoxFlight.UseVisualStyleBackColor = true;
            // 
            // CheckBoxTopMost
            // 
            this.CheckBoxTopMost.AutoSize = true;
            this.CheckBoxTopMost.Location = new System.Drawing.Point(281, 803);
            this.CheckBoxTopMost.Name = "CheckBoxTopMost";
            this.CheckBoxTopMost.Size = new System.Drawing.Size(115, 17);
            this.CheckBoxTopMost.TabIndex = 25;
            this.CheckBoxTopMost.Text = "Set Always on Top";
            this.FormToolTip.SetToolTip(this.CheckBoxTopMost, "Set always on top");
            this.CheckBoxTopMost.UseVisualStyleBackColor = true;
            this.CheckBoxTopMost.CheckedChanged += new System.EventHandler(this.SetTopMost_CheckedChanged);
            // 
            // btnTeleportTo
            // 
            this.btnTeleportTo.Location = new System.Drawing.Point(290, 124);
            this.btnTeleportTo.Name = "btnTeleportTo";
            this.btnTeleportTo.Size = new System.Drawing.Size(137, 23);
            this.btnTeleportTo.TabIndex = 5;
            this.btnTeleportTo.Text = "TeleportTo";
            this.FormToolTip.SetToolTip(this.btnTeleportTo, resources.GetString("btnTeleportTo.ToolTip"));
            this.btnTeleportTo.UseVisualStyleBackColor = true;
            this.btnTeleportTo.Click += new System.EventHandler(this.BtnTeleportTo_Click);
            // 
            // cBoxLisbeth
            // 
            this.cBoxLisbeth.AutoSize = true;
            this.cBoxLisbeth.Checked = true;
            this.cBoxLisbeth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxLisbeth.Location = new System.Drawing.Point(281, 715);
            this.cBoxLisbeth.Name = "cBoxLisbeth";
            this.cBoxLisbeth.Size = new System.Drawing.Size(90, 17);
            this.cBoxLisbeth.TabIndex = 20;
            this.cBoxLisbeth.Text = "LisbethTravel";
            this.FormToolTip.SetToolTip(this.cBoxLisbeth, "Uses LisbethTravel tags in preference to GetTo");
            this.cBoxLisbeth.UseVisualStyleBackColor = true;
            // 
            // cBoxClipboard
            // 
            this.cBoxClipboard.AutoSize = true;
            this.cBoxClipboard.Checked = true;
            this.cBoxClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxClipboard.Location = new System.Drawing.Point(444, 40);
            this.cBoxClipboard.Name = "cBoxClipboard";
            this.cBoxClipboard.Size = new System.Drawing.Size(109, 17);
            this.cBoxClipboard.TabIndex = 92;
            this.cBoxClipboard.Text = "Copy to Clipboard";
            this.FormToolTip.SetToolTip(this.cBoxClipboard, "Set always on top");
            this.cBoxClipboard.UseVisualStyleBackColor = true;
            // 
            // cBoxForceGetTo
            // 
            this.cBoxForceGetTo.AutoSize = true;
            this.cBoxForceGetTo.Checked = true;
            this.cBoxForceGetTo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxForceGetTo.Location = new System.Drawing.Point(281, 759);
            this.cBoxForceGetTo.Name = "cBoxForceGetTo";
            this.cBoxForceGetTo.Size = new System.Drawing.Size(86, 17);
            this.cBoxForceGetTo.TabIndex = 23;
            this.cBoxForceGetTo.Text = "Force GetTo";
            this.FormToolTip.SetToolTip(this.cBoxForceGetTo, "Forces LisbethTravel or GetTo regardless of distance check");
            this.cBoxForceGetTo.UseVisualStyleBackColor = true;
            // 
            // cBoxMoveTo
            // 
            this.cBoxMoveTo.AutoSize = true;
            this.cBoxMoveTo.Location = new System.Drawing.Point(281, 781);
            this.cBoxMoveTo.Name = "cBoxMoveTo";
            this.cBoxMoveTo.Size = new System.Drawing.Size(90, 17);
            this.cBoxMoveTo.TabIndex = 24;
            this.cBoxMoveTo.Text = "MoveTo Only";
            this.FormToolTip.SetToolTip(this.cBoxMoveTo, "Uses only MoveTo tags for movement");
            this.cBoxMoveTo.UseVisualStyleBackColor = true;
            // 
            // cBoxLisOptional
            // 
            this.cBoxLisOptional.AutoSize = true;
            this.cBoxLisOptional.Location = new System.Drawing.Point(371, 715);
            this.cBoxLisOptional.Name = "cBoxLisOptional";
            this.cBoxLisOptional.Size = new System.Drawing.Size(65, 17);
            this.cBoxLisOptional.TabIndex = 21;
            this.cBoxLisOptional.Text = "Optional";
            this.FormToolTip.SetToolTip(this.cBoxLisOptional, "Uses LisbethTravel tags in preference to GetTo");
            this.cBoxLisOptional.UseVisualStyleBackColor = true;
            // 
            // cBoxUseQuestInfo
            // 
            this.cBoxUseQuestInfo.AutoSize = true;
            this.cBoxUseQuestInfo.Location = new System.Drawing.Point(99, 40);
            this.cBoxUseQuestInfo.Name = "cBoxUseQuestInfo";
            this.cBoxUseQuestInfo.Size = new System.Drawing.Size(97, 17);
            this.cBoxUseQuestInfo.TabIndex = 93;
            this.cBoxUseQuestInfo.Text = "Use Quest Info";
            this.FormToolTip.SetToolTip(this.cBoxUseQuestInfo, "Uses LisbethTravel tags in preference to GetTo");
            this.cBoxUseQuestInfo.UseVisualStyleBackColor = true;
            // 
            // cBoxNoMount
            // 
            this.cBoxNoMount.AutoSize = true;
            this.cBoxNoMount.Location = new System.Drawing.Point(371, 782);
            this.cBoxNoMount.Name = "cBoxNoMount";
            this.cBoxNoMount.Size = new System.Drawing.Size(73, 17);
            this.cBoxNoMount.TabIndex = 93;
            this.cBoxNoMount.Text = "No Mount";
            this.FormToolTip.SetToolTip(this.cBoxNoMount, "Disables mount during MoveTo");
            this.cBoxNoMount.UseVisualStyleBackColor = true;
            // 
            // cBoxActiveQuests
            // 
            this.cBoxActiveQuests.FormattingEnabled = true;
            this.cBoxActiveQuests.Location = new System.Drawing.Point(12, 12);
            this.cBoxActiveQuests.Name = "cBoxActiveQuests";
            this.cBoxActiveQuests.Size = new System.Drawing.Size(263, 21);
            this.cBoxActiveQuests.TabIndex = 0;
            this.cBoxActiveQuests.SelectedIndexChanged += new System.EventHandler(this.CBoxActiveQuests_SelectedIndexChanged);
            // 
            // pGridQuestData
            // 
            this.pGridQuestData.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pGridQuestData.Location = new System.Drawing.Point(12, 40);
            this.pGridQuestData.Name = "pGridQuestData";
            this.pGridQuestData.Size = new System.Drawing.Size(263, 734);
            this.pGridQuestData.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(281, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnPickUp
            // 
            this.btnPickUp.Location = new System.Drawing.Point(290, 188);
            this.btnPickUp.Name = "btnPickUp";
            this.btnPickUp.Size = new System.Drawing.Size(137, 23);
            this.btnPickUp.TabIndex = 7;
            this.btnPickUp.Text = "PickUp";
            this.btnPickUp.UseVisualStyleBackColor = true;
            this.btnPickUp.Click += new System.EventHandler(this.BtnPickUp_Click);
            // 
            // btnTurnIn
            // 
            this.btnTurnIn.Location = new System.Drawing.Point(290, 380);
            this.btnTurnIn.Name = "btnTurnIn";
            this.btnTurnIn.Size = new System.Drawing.Size(137, 23);
            this.btnTurnIn.TabIndex = 13;
            this.btnTurnIn.Text = "TurnIn";
            this.btnTurnIn.UseVisualStyleBackColor = true;
            this.btnTurnIn.Click += new System.EventHandler(this.BtnTurnIn_Click);
            // 
            // lbKeyItems
            // 
            this.lbKeyItems.FormattingEnabled = true;
            this.lbKeyItems.Location = new System.Drawing.Point(615, 80);
            this.lbKeyItems.Name = "lbKeyItems";
            this.lbKeyItems.Size = new System.Drawing.Size(153, 745);
            this.lbKeyItems.TabIndex = 27;
            this.lbKeyItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbKeyItems_MouseDown);
            // 
            // btnTalkTo
            // 
            this.btnTalkTo.Location = new System.Drawing.Point(290, 220);
            this.btnTalkTo.Name = "btnTalkTo";
            this.btnTalkTo.Size = new System.Drawing.Size(137, 23);
            this.btnTalkTo.TabIndex = 8;
            this.btnTalkTo.Text = "TalkTo";
            this.btnTalkTo.UseVisualStyleBackColor = true;
            this.btnTalkTo.Click += new System.EventHandler(this.BtnTalkTo_Click);
            // 
            // btnUseTransport
            // 
            this.btnUseTransport.Location = new System.Drawing.Point(290, 156);
            this.btnUseTransport.Name = "btnUseTransport";
            this.btnUseTransport.Size = new System.Drawing.Size(137, 23);
            this.btnUseTransport.TabIndex = 6;
            this.btnUseTransport.Text = "UseTransport";
            this.btnUseTransport.UseVisualStyleBackColor = true;
            this.btnUseTransport.Click += new System.EventHandler(this.BtnUseTransport_Click);
            // 
            // btnHandover
            // 
            this.btnHandover.Location = new System.Drawing.Point(290, 252);
            this.btnHandover.Name = "btnHandover";
            this.btnHandover.Size = new System.Drawing.Size(137, 23);
            this.btnHandover.TabIndex = 9;
            this.btnHandover.Text = "HandOver";
            this.btnHandover.UseVisualStyleBackColor = true;
            this.btnHandover.Click += new System.EventHandler(this.BtnHandover_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(612, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Key Items";
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(444, 12);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 90;
            this.btnOutput.Text = "Set Output";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Location = new System.Drawing.Point(525, 14);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.Size = new System.Drawing.Size(243, 20);
            this.textBoxOutputFile.TabIndex = 91;
            // 
            // btnCloseProfileTags
            // 
            this.btnCloseProfileTags.Location = new System.Drawing.Point(290, 92);
            this.btnCloseProfileTags.Name = "btnCloseProfileTags";
            this.btnCloseProfileTags.Size = new System.Drawing.Size(137, 23);
            this.btnCloseProfileTags.TabIndex = 4;
            this.btnCloseProfileTags.Text = "Close <Profile> Tags";
            this.btnCloseProfileTags.UseVisualStyleBackColor = true;
            this.btnCloseProfileTags.Click += new System.EventHandler(this.BtnCloseProfileTags_Click);
            // 
            // btnOpenProfileTags
            // 
            this.btnOpenProfileTags.Location = new System.Drawing.Point(290, 60);
            this.btnOpenProfileTags.Name = "btnOpenProfileTags";
            this.btnOpenProfileTags.Size = new System.Drawing.Size(137, 23);
            this.btnOpenProfileTags.TabIndex = 3;
            this.btnOpenProfileTags.Text = "Open <Profile> Tags";
            this.btnOpenProfileTags.UseVisualStyleBackColor = true;
            this.btnOpenProfileTags.Click += new System.EventHandler(this.BtnOpenProfileTags_Click);
            // 
            // labelInventory
            // 
            this.labelInventory.AutoSize = true;
            this.labelInventory.Location = new System.Drawing.Point(441, 64);
            this.labelInventory.Name = "labelInventory";
            this.labelInventory.Size = new System.Drawing.Size(51, 13);
            this.labelInventory.TabIndex = 22;
            this.labelInventory.Text = "Inventory";
            // 
            // lbInventory
            // 
            this.lbInventory.FormattingEnabled = true;
            this.lbInventory.Location = new System.Drawing.Point(444, 80);
            this.lbInventory.Name = "lbInventory";
            this.lbInventory.Size = new System.Drawing.Size(153, 745);
            this.lbInventory.TabIndex = 26;
            this.lbInventory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbInventory_MouseDown);
            // 
            // btnAddGameObject
            // 
            this.btnAddGameObject.Location = new System.Drawing.Point(290, 284);
            this.btnAddGameObject.Name = "btnAddGameObject";
            this.btnAddGameObject.Size = new System.Drawing.Size(137, 23);
            this.btnAddGameObject.TabIndex = 10;
            this.btnAddGameObject.Text = "Add GameObject";
            this.btnAddGameObject.UseVisualStyleBackColor = true;
            this.btnAddGameObject.Click += new System.EventHandler(this.BtnAddGameObject_Click);
            // 
            // btnQuestStep
            // 
            this.btnQuestStep.Location = new System.Drawing.Point(290, 657);
            this.btnQuestStep.Name = "btnQuestStep";
            this.btnQuestStep.Size = new System.Drawing.Size(137, 23);
            this.btnQuestStep.TabIndex = 18;
            this.btnQuestStep.Text = "QuestStep Condition";
            this.btnQuestStep.UseVisualStyleBackColor = true;
            this.btnQuestStep.Click += new System.EventHandler(this.BtnQuestStep_Click);
            // 
            // btnQuestStepGt0
            // 
            this.btnQuestStepGt0.Location = new System.Drawing.Point(290, 628);
            this.btnQuestStepGt0.Name = "btnQuestStepGt0";
            this.btnQuestStepGt0.Size = new System.Drawing.Size(137, 23);
            this.btnQuestStepGt0.TabIndex = 17;
            this.btnQuestStepGt0.Text = "QuestStep > 0";
            this.btnQuestStepGt0.UseVisualStyleBackColor = true;
            this.btnQuestStepGt0.Click += new System.EventHandler(this.BtnQuestStepGt0_Click);
            // 
            // btnCloseIf
            // 
            this.btnCloseIf.Location = new System.Drawing.Point(290, 686);
            this.btnCloseIf.Name = "btnCloseIf";
            this.btnCloseIf.Size = new System.Drawing.Size(137, 23);
            this.btnCloseIf.TabIndex = 19;
            this.btnCloseIf.Text = "</If>";
            this.btnCloseIf.UseVisualStyleBackColor = true;
            this.btnCloseIf.Click += new System.EventHandler(this.BtnCloseIf_Click);
            // 
            // btnLisbethJSONEntrance
            // 
            this.btnLisbethJSONEntrance.Location = new System.Drawing.Point(290, 536);
            this.btnLisbethJSONEntrance.Name = "btnLisbethJSONEntrance";
            this.btnLisbethJSONEntrance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLisbethJSONEntrance.Size = new System.Drawing.Size(137, 23);
            this.btnLisbethJSONEntrance.TabIndex = 15;
            this.btnLisbethJSONEntrance.Text = "Lisbeth JSON Entrance";
            this.btnLisbethJSONEntrance.UseVisualStyleBackColor = true;
            this.btnLisbethJSONEntrance.Click += new System.EventHandler(this.BtnLisbethJSONEntranceTo_Click);
            // 
            // btnLisbethJSONExit
            // 
            this.btnLisbethJSONExit.Location = new System.Drawing.Point(290, 565);
            this.btnLisbethJSONExit.Name = "btnLisbethJSONExit";
            this.btnLisbethJSONExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLisbethJSONExit.Size = new System.Drawing.Size(137, 23);
            this.btnLisbethJSONExit.TabIndex = 16;
            this.btnLisbethJSONExit.Text = "Lisbeth JSON Exit";
            this.btnLisbethJSONExit.UseVisualStyleBackColor = true;
            this.btnLisbethJSONExit.Click += new System.EventHandler(this.BtnLisbethJSONExitFrom_Click);
            // 
            // btnEmoteNPC
            // 
            this.btnEmoteNPC.Location = new System.Drawing.Point(290, 409);
            this.btnEmoteNPC.Name = "btnEmoteNPC";
            this.btnEmoteNPC.Size = new System.Drawing.Size(137, 23);
            this.btnEmoteNPC.TabIndex = 14;
            this.btnEmoteNPC.Text = "EmoteNPC";
            this.btnEmoteNPC.UseVisualStyleBackColor = true;
            this.btnEmoteNPC.Click += new System.EventHandler(this.BtnEmoteNPC_Click);
            // 
            // grindButton
            // 
            this.grindButton.Location = new System.Drawing.Point(290, 438);
            this.grindButton.Name = "grindButton";
            this.grindButton.Size = new System.Drawing.Size(137, 23);
            this.grindButton.TabIndex = 94;
            this.grindButton.Text = "GrindArea";
            this.grindButton.UseVisualStyleBackColor = true;
            this.grindButton.Click += new System.EventHandler(this.grindButton_Click);
            // 
            // cBoxObjective0
            // 
            this.cBoxObjective0.AutoSize = true;
            this.cBoxObjective0.Location = new System.Drawing.Point(13, 780);
            this.cBoxObjective0.Name = "cBoxObjective0";
            this.cBoxObjective0.Size = new System.Drawing.Size(80, 17);
            this.cBoxObjective0.TabIndex = 95;
            this.cBoxObjective0.Text = "Objective 0";
            this.cBoxObjective0.UseVisualStyleBackColor = true;
            // 
            // cBoxObjective1
            // 
            this.cBoxObjective1.AutoSize = true;
            this.cBoxObjective1.Location = new System.Drawing.Point(100, 780);
            this.cBoxObjective1.Name = "cBoxObjective1";
            this.cBoxObjective1.Size = new System.Drawing.Size(80, 17);
            this.cBoxObjective1.TabIndex = 96;
            this.cBoxObjective1.Text = "Objective 1";
            this.cBoxObjective1.UseVisualStyleBackColor = true;
            // 
            // cBoxObjective2
            // 
            this.cBoxObjective2.AutoSize = true;
            this.cBoxObjective2.Location = new System.Drawing.Point(186, 780);
            this.cBoxObjective2.Name = "cBoxObjective2";
            this.cBoxObjective2.Size = new System.Drawing.Size(80, 17);
            this.cBoxObjective2.TabIndex = 97;
            this.cBoxObjective2.Text = "Objective 2";
            this.cBoxObjective2.UseVisualStyleBackColor = true;
            // 
            // cBoxObjective3
            // 
            this.cBoxObjective3.AutoSize = true;
            this.cBoxObjective3.Location = new System.Drawing.Point(13, 803);
            this.cBoxObjective3.Name = "cBoxObjective3";
            this.cBoxObjective3.Size = new System.Drawing.Size(80, 17);
            this.cBoxObjective3.TabIndex = 98;
            this.cBoxObjective3.Text = "Objective 3";
            this.cBoxObjective3.UseVisualStyleBackColor = true;
            // 
            // cBoxObjective4
            // 
            this.cBoxObjective4.AutoSize = true;
            this.cBoxObjective4.Enabled = false;
            this.cBoxObjective4.Location = new System.Drawing.Point(99, 803);
            this.cBoxObjective4.Name = "cBoxObjective4";
            this.cBoxObjective4.Size = new System.Drawing.Size(80, 17);
            this.cBoxObjective4.TabIndex = 99;
            this.cBoxObjective4.Text = "Objective 4";
            this.cBoxObjective4.UseVisualStyleBackColor = true;
            // 
            // cBoxObjective5
            // 
            this.cBoxObjective5.AutoSize = true;
            this.cBoxObjective5.Enabled = false;
            this.cBoxObjective5.Location = new System.Drawing.Point(185, 803);
            this.cBoxObjective5.Name = "cBoxObjective5";
            this.cBoxObjective5.Size = new System.Drawing.Size(80, 17);
            this.cBoxObjective5.TabIndex = 100;
            this.cBoxObjective5.Text = "Objective 5";
            this.cBoxObjective5.UseVisualStyleBackColor = true;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(777, 832);
            this.Controls.Add(this.cBoxObjective5);
            this.Controls.Add(this.cBoxObjective4);
            this.Controls.Add(this.cBoxObjective3);
            this.Controls.Add(this.cBoxObjective2);
            this.Controls.Add(this.cBoxObjective1);
            this.Controls.Add(this.cBoxObjective0);
            this.Controls.Add(this.grindButton);
            this.Controls.Add(this.cBoxNoMount);
            this.Controls.Add(this.cBoxUseQuestInfo);
            this.Controls.Add(this.btnEmoteNPC);
            this.Controls.Add(this.cBoxLisOptional);
            this.Controls.Add(this.cBoxMoveTo);
            this.Controls.Add(this.btnLisbethJSONExit);
            this.Controls.Add(this.btnLisbethJSONEntrance);
            this.Controls.Add(this.btnCloseIf);
            this.Controls.Add(this.btnQuestStepGt0);
            this.Controls.Add(this.btnQuestStep);
            this.Controls.Add(this.cBoxForceGetTo);
            this.Controls.Add(this.cBoxClipboard);
            this.Controls.Add(this.cBoxLisbeth);
            this.Controls.Add(this.btnTeleportTo);
            this.Controls.Add(this.CheckBoxTopMost);
            this.Controls.Add(this.cBoxFlight);
            this.Controls.Add(this.btnUseItem);
            this.Controls.Add(this.btnAddGameObject);
            this.Controls.Add(this.btnUseObject);
            this.Controls.Add(this.lbInventory);
            this.Controls.Add(this.labelInventory);
            this.Controls.Add(this.btnOpenProfileTags);
            this.Controls.Add(this.btnCloseProfileTags);
            this.Controls.Add(this.textBoxOutputFile);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHandover);
            this.Controls.Add(this.btnUseTransport);
            this.Controls.Add(this.btnTalkTo);
            this.Controls.Add(this.lbKeyItems);
            this.Controls.Add(this.btnTurnIn);
            this.Controls.Add(this.btnPickUp);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pGridQuestData);
            this.Controls.Add(this.cBoxActiveQuests);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Gui";
            this.Load += new System.EventHandler(this.Gui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox cBoxObjective5;

        private System.Windows.Forms.ComboBox cBoxActiveQuests;
        private System.Windows.Forms.PropertyGrid pGridQuestData;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPickUp;
        private System.Windows.Forms.Button btnTurnIn;
        private System.Windows.Forms.ListBox lbKeyItems;
        private System.Windows.Forms.Button btnTalkTo;
        private System.Windows.Forms.Button btnUseTransport;
        private System.Windows.Forms.Button btnHandover;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox textBoxOutputFile;
        private System.Windows.Forms.Button btnCloseProfileTags;
        private System.Windows.Forms.Button btnOpenProfileTags;
        private System.Windows.Forms.Label labelInventory;
        private System.Windows.Forms.ListBox lbInventory;
        private System.Windows.Forms.Button btnUseObject;
        private System.Windows.Forms.Button btnAddGameObject;
        private System.Windows.Forms.Button btnUseItem;
        private System.Windows.Forms.CheckBox cBoxFlight;
        private System.Windows.Forms.CheckBox CheckBoxTopMost;
        private System.Windows.Forms.Button btnTeleportTo;
        private System.Windows.Forms.CheckBox cBoxLisbeth;
        private System.Windows.Forms.CheckBox cBoxClipboard;
        private System.Windows.Forms.CheckBox cBoxForceGetTo;
        private System.Windows.Forms.Button btnQuestStep;
        private System.Windows.Forms.Button btnQuestStepGt0;
        private System.Windows.Forms.Button btnCloseIf;
        private System.Windows.Forms.Button btnLisbethJSONEntrance;
        private System.Windows.Forms.Button btnLisbethJSONExit;
        private System.Windows.Forms.CheckBox cBoxMoveTo;
        private System.Windows.Forms.CheckBox cBoxLisOptional;
        private System.Windows.Forms.Button btnEmoteNPC;
        private System.Windows.Forms.CheckBox cBoxUseQuestInfo;
        private System.Windows.Forms.CheckBox cBoxNoMount;
        private System.Windows.Forms.Button grindButton;
        private System.Windows.Forms.CheckBox cBoxObjective0;
        private System.Windows.Forms.CheckBox cBoxObjective1;
        private System.Windows.Forms.CheckBox cBoxObjective2;
        private System.Windows.Forms.CheckBox cBoxObjective3;
        private System.Windows.Forms.CheckBox cBoxObjective4;

        #endregion

        private System.Windows.Forms.ToolTip FormToolTip;
    }
}

