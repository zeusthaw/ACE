using System;
using ACE.Entity.Enum;
using ACE.Server.Network.GameMessages.Messages;
using ACE.Server.WorldObjects;

namespace ACE.Server.Entity
{
    /*public enum CastingState
    {
        WindupTurn,
        WindupGesture,
        CastGesture,
        CastTurn,
        Ready
    };*/

    public class MagicState
    {
        //public CastingState CastingState { get; set; }

        /// <summary>
        /// A reference to the Player for this MagicState
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// This flag indicates if player is currently casting a spell
        /// //
        /// It gets set to TRUE when they press the cast button,
        /// and becomes FALSE again when their recoil animation has completed.
        ///
        /// If server is running with spellcast_recoil_queue = true,
        /// it becomes FALSE when their recoil animation has started.
        /// </summary>
        public bool IsCasting { get; set; }

        /// <summary>
        /// Returns TRUE if the first half of the 'launch spell' motion
        /// has made its way through the motion queue
        /// </summary>
        public bool CastMotionDone { get; set; }

        /// <summary>
        /// Returns TRUE if player has started turning for either the windup or cast launch
        /// After turning has completed, this will still be true
        /// </summary>
        public bool TurnStarted { get; set; }

        /// <summary>
        /// Returns TRUE if current player animation frame is turning
        /// </summary>
        public bool IsTurning { get; set; }

        /// <summary>
        /// Information required for launching the spell
        /// </summary>
        public CastSpellParams CastSpellParams { get; set; }

        /// <summary>
        /// The 'launch spell' motion for the current cast
        /// </summary>
        public MotionCommand CastGesture { get; set; }

        /// <summary>
        /// The time when the player pressed the key to begin spell casting
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Tracks the cast # for /recordcast
        /// </summary>
        public int CastNum { get; set; }

        /// <summary>
        /// If TRUE, the casting efficiency meter has been enabled with /castmeter
        /// This shows the player information about how quickly they interrupted the cast motion
        /// 
        /// - 0% would be a standard cast, with no additional buttons pressed
        /// - 50% would mean they interrupted the cast motion 1/2 way through
        /// - 100% could theoretically be possible, and would indicate the cast motion was completely avoided
        /// - Negative % indicates the player pressed additional keys which actually slowed down the cast
        /// </summary>
        public bool CastMeter { get; set; }

        /// <summary>
        /// The time when the player started performing the 'launch spell' casting gesture
        /// This is used for CastMeter measurement
        /// </summary>
        public DateTime CastGestureStartTime { get; set; }

        public MagicState(Player player)
        {
            Player = player;
        }

        /// <summary>
        /// Called when the player begins casting a spell
        /// </summary>
        public void OnCastStart()
        {
            Player.IsBusy = true;
            IsCasting = true;
            CastMotionDone = false;
            TurnStarted = false;
            IsTurning = false;

            StartTime = DateTime.UtcNow;
            CastGestureStartTime = DateTime.MinValue;

            if (Player.UnderLifestoneProtection)
                Player.LifestoneProtectionDispel();

            CastNum++;

            if (Player.RecordCast.Enabled)
            {
                Player.Session.Network.EnqueueSend(new GameMessageSystemChat($"Cast #: {CastNum}", ChatMessageType.Broadcast));
                Player.RecordCast.Log($"MagicState.OnCastStart({CastNum})");
                Player.RecordCast.Log($"Player Location: {Player.Location.ToLOCString()}");
            }
        }

        /// <summary>
        /// Called when the player finishes casting a spell
        /// </summary>
        public void OnCastDone()
        {
            Player.IsBusy = false;
            IsCasting = false;
            CastMotionDone = false;
            TurnStarted = false;
            IsTurning = false;

            CastGesture = MotionCommand.Invalid;
            CastGestureStartTime = DateTime.MinValue;

            if (Player.RecordCast.Enabled)
            {
                Player.RecordCast.Log($"MagicState.OnCastDone()");
                Player.RecordCast.Log($"Player Location: {Player.Location.ToLOCString()}");
                if (CastSpellParams?.Target != null)
                    Player.RecordCast.Log($"Target Location: {CastSpellParams.Target.Location.ToLOCString()}");
                Player.RecordCast.Log("================================================================================");
                Player.RecordCast.Flush();
            }

            CastSpellParams = null;
        }

        public void SetCastParams(Spell spell, bool isWeaponSpell, uint magicSkill, uint manaUsed, WorldObject target, Player.CastingPreCheckStatus status)
        {
            CastSpellParams = new CastSpellParams(spell, isWeaponSpell, magicSkill, manaUsed, target, status);

            if (Player.RecordCast.Enabled && CastSpellParams.Target != null)
                Player.RecordCast.Log($"Target Location: {CastSpellParams.Target.Location.ToLOCString()}");
        }

        public override string ToString()
        {
            var str = $"Player: {Player.Name} ({Player.Guid})\n";
            str += $"IsCasting: {IsCasting}\n";
            str += $"CastMotionDone: {CastMotionDone}\n";
            str += $"TurnStarted: {TurnStarted}\n";
            str += $"IsTurning: {IsTurning}\n";
            str += $"CastSpellParams: {CastSpellParams}\n";
            str += $"CastGesture: {CastGesture}\n";
            str += $"StartTime: {StartTime}\n";
            return str;
        }
    }
}
