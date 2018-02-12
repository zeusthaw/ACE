namespace ACE.Server.Network.GameMessages
{
    public enum GameMessageOpcode
    {
        None                            = 0x0000,
        SetStackSize                    = 0x0197,
        PlayerKilled                    = 0x019E,
        EmoteText                       = 0x01E0,
        SoulEmote                       = 0x01E2,
        CreatureMessage                 = 0x02BB,
        HearDirectSpeech                = 0x02BD,
        PrivateUpdatePropertyInt        = 0x02CD,
        PublicUpdatePropertyInt         = 0x02CE,
        PrivateUpdatePropertyInt64      = 0x02CF,
        PublicUpdatePropertyInt64       = 0x02D0,
        PrivateUpdatePropertyBool       = 0x02D1,
        PublicUpdatePropertyBool        = 0x02D2,
        PrivateUpdatePropertyDouble     = 0x02D3,
        PublicUpdatePropertyDouble      = 0x02D4,
        PrivateUpdatePropertyString     = 0x02D5,
        PublicUpdatePropertyString      = 0x02D6,
        PrivateUpdatePropertyDataID     = 0x02D7,
        UpdateInstanceId                = 0x02DA,
        PrivateUpdateSkill              = 0x02DD,
        PublicUpdateSkill               = 0x02DE,
        PrivateUpdateSkillLevel         = 0x02DF,
        PublicUpdateSkillLevel          = 0x02E0,
        PrivateUpdateAttribute          = 0x02E3,
        PublicUpdateAttribute           = 0x02E4,
        PrivateUpdateVital              = 0x02E7,
        PublicUpdateVital               = 0x02E8,
        PrivateUpdateAttribute2ndLevel  = 0x02E9,
        PositionAndMovement             = 0xF619,
        ObjDescEvent                    = 0xF625,
        CharacterCreateResponse         = 0xF643,
        CharacterRestoreResponse        = 0xF643, // This is a duplicate...
        CharacterLogOff                 = 0xF653,
        CharacterDelete                 = 0xF655,
        CharacterCreate                 = 0xF656,
        CharacterEnterWorld             = 0xF657,
        CharacterList                   = 0xF658,
        CharacterError                  = 0xF659,
        ForceObjectDescSend             = 0xF6EA,
        ObjectCreate                    = 0xF745,
        PlayerCreate                    = 0xF746,
        ObjectDelete                    = 0xF747,
        UpdatePosition                  = 0xF748,
        ParentEvent                     = 0xF749,
        PickupEvent                     = 0xF74A,
        SetState                        = 0xF74B,
        MovementEvent                   = 0xF74C,
        Motion                          = 0xF74C,
        VectorUpdate                    = 0xF74E,
        Sound                           = 0xF750,
        PlayerTeleport                  = 0xF751,
        AutonomousPosition              = 0xF753,
        PlayScriptId                    = 0xF754,
        PlayEffect                      = 0xF755,
        GameEvent                       = 0xF7B0,
        GameAction                      = 0xF7B1,
        CharacterEnterWorldRequest      = 0xF7C8,
        FriendsOld                      = 0xF7CD,
        CharacterRestore                = 0xF7D9,
        AccountBoot                     = 0xF7DC,
        UpdateObject                    = 0xF7DB,
        TurbineChat                     = 0xF7DE,
        CharacterEnterWorldServerReady  = 0xF7DF,
        ServerMessage                   = 0xF7E0,
        ServerName                      = 0xF7E1,
        DDD_Interrogation               = 0xF7E5,
        DDD_InterrogationResponse       = 0xF7E6,
        DDD_BeginDDD                    = 0xF7E7,
        DDD_BeginPullDDD                = 0xF7E8,
        DDD_IterationData               = 0xF7E9,
        DDD_EndDDD                      = 0xF7EA,
    }
}