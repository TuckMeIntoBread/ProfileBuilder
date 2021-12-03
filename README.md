# [ProfileBuilder][0]

[![Download Now!][1]][2]

**ProfileBuilder** is a OrderBot profile-building tool for [RebornBuddy][3]. It generates OrderBot XML snippets based on current game state, and is especially useful for scripting quests.

Based on QuestDevTools by mastahg. Upgraded by sodimm, TuckMeIntoBread, et al.

## Installation

### Prerequisites

 * [RebornBuddy][3] with active license (paid)
 * [Lisbeth][4] with active license (paid)

### Manual Setup

 1. Download the [latest version][2].
 2. On the `.zip` file, right click > `Properties` > `Unblock` > `Apply`.
 3. Unzip all contents into `RebornBuddy\Plugins\ProfileBuilder\` so it looks like this:
```
RebornBuddy
└── Plugins
    └── ProfileBuilder
        ├── ProfileBuilder.sln
        └── ...
```
 4. Start RebornBuddy as normal.
 5. In the `Plugins` tab, enable `Profile Builder`.
    * If already enabled but window not visible, click `Toggle GUI`.

## Usage

 1. In RebornBuddy, switch to the `Plugins` tab and enable `Profile Builder`.
    * If already enabled but window not visible, click `Toggle GUI`.
 2. In the Profile Development window, click `Set Output` in top right and choose an XML file to append to.
 3. If starting a new XML file, click `Open <Profile> Tags` to add boilerplate XML.
 4. Click `Refresh` in top left and pick a quest from the dropdown. Only active quests appear here, so you may need to accept the quest first.
 5. Start by targeting the quest-giving NPC and clicking `PickUp` to insert XML tags for moving to that NPC and accepting the quest.
 6. Use remaining buttons to set up intermediate quest steps. May require manual adjustments or entirely new code via text editor after generating basic structure. GUI buttons not representative of OrderBot's full range of abilities, just common tasks.
 7. End by targeting the quest-ending NPC and clicking `TurnIn`.

### Tips

 * Open the XML file in an auto-reloading text editor like [Visual Studio Code][5] to see the code added in real time. If it doesn't auto-reload, make sure you don't have unsaved manual changes (a popup in bottom right will ask to merge or overwrite).

[0]: https://github.com/TuckMeIntoBread/ProfileBuilder "ProfileBuilder"
[1]: https://img.shields.io/badge/-DOWNLOAD-success
[2]: https://github.com/TuckMeIntoBread/ProfileBuilder/archive/master.zip "Download"
[3]: https://www.rebornbuddy.com/ "RebornBuddy"
[4]: https://www.siune.io/ "Lisbeth"
[5]: https://code.visualstudio.com/download "Visual Studio Code"
